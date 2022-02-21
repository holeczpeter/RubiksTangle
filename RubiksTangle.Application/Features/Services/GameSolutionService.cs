using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using RubiksTangle.Application.Models;
using RubiksTangle.Core;
using RubiksTangle.Core.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace RubiksTangle.Application.Features
{

    public class GameSolutionService : IGameSolutionService
    {
        private readonly RubikDbContext dbContext;
        private readonly IRotationService rotationService;
      

        public GameSolutionService(RubikDbContext dbContext, IRotationService rotationService)
        {
            this.dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            this.rotationService = rotationService ?? throw new ArgumentNullException(nameof(rotationService));
        }

        public async Task<IEnumerable<SolutionStepModel>> Resolve()
        {
           
            var cards = await this.dbContext.Cards.Select(x => new CardModel
            {
                CardId = x.Id,
                Rotation = x.Rotation,
                Points = x.Points.Select(y => new PointModel()
                {
                    Color = y.Color,
                    Order = y.OrdinalNumber,
                    Side = y.Side

                }).OrderBy(x => x.Side).ThenBy(x => x.Order).ToArray()
            }).ToArrayAsync();

            CardModel[] results = new CardModel[9];
            if (BackTracking(0, results, cards.ToArray()))
            {
                return results.Select((x, index) => new SolutionStepModel()
                {
                    Order = index,
                    PictureId = x.CardId,
                    Rotation = x.Rotation < 4 ? x.Rotation : x.Rotation % 4,
                });
            }
            else return null;
        }

        bool BackTracking(int level, CardModel[] results, CardModel[] cards)
        {

            if (level == 9) return true;
            for (int i = 0; i < cards.Length; i++)
            {
                if (IsInTheBoard(cards[i], results)) continue;

                for (int j = 0; j < 4; j++)
                {
                    cards[i] = GetRotate(j, cards[i]);
                    if (IsSuitable(level, cards[i], results))
                    {
                        results[level] = cards[i];
                        if (BackTracking(level + 1, results, cards)) return true;
                        results[level] = null;
                    }
                }
            }
            return false;
        }
        
        bool IsSuitable(int level, CardModel card, CardModel[] results)
        {
            if (CheckLeft(results, card) && CheckTop(results, card, level)) return true;
            return false;
        }

        bool IsInTheBoard(CardModel card, CardModel[] results)
        {
            return results.Where(x => x != null && x.CardId == card.CardId).Any();
        }

        bool CheckLeft(CardModel[] results, CardModel checkedCard)
        {
            var counter = results.Where(x => x != null).Count();
            if (counter == 3 || counter == 6) return true;
            var left = results.Where(x => x != null).LastOrDefault();
            if (left == null) return true;
            else
            {
                var rightSide = left.Points.Where(x => x.Side == Sides.C);
                var leftSide = checkedCard.Points.Where(x => x.Side == Sides.A);
                return rightSide.SequenceEqual(leftSide, new PointModelEqualityComparer());
            }
        }

        bool CheckTop(CardModel[] results, CardModel checkedCard, int level)
        {
            if (level < 3) return true;
            else
            {
                var top = results[level - 3];
                var bottomSide = top.Points.Where(x => x.Side == Sides.D);
                var topSide = checkedCard.Points.Where(x => x.Side == Sides.B);
                return bottomSide.SequenceEqual(topSide, new PointModelEqualityComparer());
            }
        }

        CardModel GetRotate(int rotate, CardModel originalModel)
        {
            var nextState = originalModel.Rotation + rotate;
            return new CardModel()
            {
                CardId = originalModel.CardId,
                Rotation = nextState,
                Points = originalModel.Points.Select(x => this.rotationService.Rotate(new RotationModel()
                           {
                               CurrentRotationState = originalModel.Rotation,
                               NextRotationState = nextState,
                               PointModel = x
                           })).OrderBy(x => x.Side).ThenBy(x => x.Order).ToArray()
            };
        }
    }
}
