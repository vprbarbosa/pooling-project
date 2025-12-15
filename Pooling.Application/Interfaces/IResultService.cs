using Pooling.Application.Dtos;

namespace Pooling.Application.Interfaces
{
    public interface IResultService
    {
        Task<IEnumerable<QuestionnaireResultDto>> GetResults(Guid questionnaireId);
    }
}
