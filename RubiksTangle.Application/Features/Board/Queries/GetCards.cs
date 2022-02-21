using MediatR;
using System.Collections.Generic;

namespace RubiksTangle.Application.Features
{
    public class GetCards : IRequest<IEnumerable<CardViewModel>>
    {
    }
}
