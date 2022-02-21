using MediatR;
using System.Collections.Generic;

namespace RubiksTangle.Application.Features
{
    public class GetSolutionSteps : IRequest<IEnumerable<SolutionStepModel>>
    {
        
    }
}
