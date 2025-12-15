using Pooling.Application.Dtos;

namespace Pooling.Application.Interfaces
{
    public interface IQuestionnaireService
    {
        Task<QuestionnaireCreatedDto> Create(CreateQuestionnaireDto dto);
        Task<QuestionnaireDto> GetById(Guid id);
    }
}
