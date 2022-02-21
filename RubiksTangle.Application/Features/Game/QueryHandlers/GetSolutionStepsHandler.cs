using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace RubiksTangle.Application.Features
{
    public class GetSolutionStepsHandler : IRequestHandler<GetSolutionSteps, IEnumerable<SolutionStepModel>>
    {
        private readonly IGameSolutionService solutionService;
        public GetSolutionStepsHandler(IGameSolutionService solutionService)
        {
            this.solutionService = solutionService;
        }

        public async Task<IEnumerable<SolutionStepModel>> Handle(GetSolutionSteps request, CancellationToken cancellationToken)
        {
            return await this.solutionService.Resolve();
        }
    }
}
