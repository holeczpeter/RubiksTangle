using System.Collections.Generic;
using System.Threading.Tasks;

namespace RubiksTangle.Application.Features
{
    public interface IGameSolutionService
    {
        Task<IEnumerable<SolutionStepModel>> Resolve();
    }
}
