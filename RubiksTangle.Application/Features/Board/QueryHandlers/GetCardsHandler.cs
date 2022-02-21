using MediatR;
using Microsoft.EntityFrameworkCore;
using RubiksTangle.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace RubiksTangle.Application.Features
{
    public class GetCardsHandler : IRequestHandler<GetCards, IEnumerable<CardViewModel>>
    {
        private readonly RubikDbContext dbContext;
        public GetCardsHandler(RubikDbContext dbContext)
        {
            this.dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public async Task<IEnumerable<CardViewModel>> Handle(GetCards request, CancellationToken cancellationToken)
        {
            return await this.dbContext.Cards.Select(x =>

                new CardViewModel()
                {
                    Id = x.Id,
                    OrdinalNumber = x.OrdinalNumber,
                    Rotation = x.Rotation,
                    Picture = x.Picture
                }
            ).OrderBy(a => a.OrdinalNumber).ToListAsync();
        }
    }
}
