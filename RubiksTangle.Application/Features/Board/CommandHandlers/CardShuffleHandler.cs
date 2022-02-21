using MediatR;
using RubiksTangle.Application.Models;
using RubiksTangle.Core;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace RubiksTangle.Application.Features
{
    public class CardShuffleHandler : IRequestHandler<CardSuffle, bool>
    {
        private readonly RubikDbContext dbContext;
        private readonly IRotationService rotationService;
        public CardShuffleHandler(RubikDbContext dbContext, IRotationService rotationService)
        {
            this.dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            this.rotationService = rotationService ?? throw new ArgumentNullException(nameof(rotationService));
        }

        public async Task<bool> Handle(CardSuffle request, CancellationToken cancellationToken)
        {
            Random r = new Random();

            var cards = this.dbContext.Cards.ToList().OrderBy(a => Guid.NewGuid());

            foreach (var (card, index) in cards.Select((card, i) => (card, i)))
            {
              
                var currentRotatation = r.Next(0, 3);
                var fullRotatation = card.Rotation + currentRotatation;
                
                var points = this.dbContext.Points.Where(x => x.CardId == card.Id);

                foreach (var point in points)
                {
                    var rotatedPoint = this.rotationService.Rotate(new RotationModel()
                    {
                        CurrentRotationState = card.Rotation,
                        NextRotationState = fullRotatation,
                        PointModel = new PointModel()
                        {
                            Color = point.Color,
                            Order = point.OrdinalNumber,
                            Side = point.Side
                        },
                        
                    });
                    point.Side = rotatedPoint.Side;
                    point.OrdinalNumber = rotatedPoint.Order;
                    point.Color = rotatedPoint.Color;
                }
                card.Rotation = fullRotatation < 4 ? fullRotatation : fullRotatation % 4;
                card.OrdinalNumber = index + 1;
            }

            await dbContext.SaveChangesAsync(cancellationToken);
            return true;
        }
    }
}
