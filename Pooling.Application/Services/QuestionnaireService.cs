using Polling.Domain.Aggregates;
using Polling.Domain.Common;
using Polling.Domain.Repositories;
using Polling.Domain.ValueObjects;
using Pooling.Application.Dtos;
using Pooling.Application.Interfaces;

namespace Pooling.Application.Services
{
    public sealed class QuestionnaireService : IQuestionnaireService
    {
        private readonly IQuestionnaireRepository _repository;

        public QuestionnaireService(IQuestionnaireRepository repository)
        {
            _repository = repository;
        }

        public async Task<QuestionnaireCreatedDto> Create(CreateQuestionnaireDto dto)
        {
            var questionnaire = Questionnaire.Create(dto.Title);

            foreach (var questionDto in dto.Questions)
            {
                var question = Question.Create(
                    questionDto.Text,
                    questionDto.Options.Select(o => o.Label).ToList()
                );

                questionnaire.AddQuestion(question);
            }

            await _repository.AddAsync(questionnaire);

            return new QuestionnaireCreatedDto
            {
                Id = questionnaire.Id,
                Title = questionnaire.Title
            };
        }

        public async Task<QuestionnaireDto> GetById(Guid id)
        {
            var questionnaire = await _repository.GetByIdAsync(id);

            if (questionnaire == null)
                throw new DomainException("Questionário não encontrado.");

            return QuestionnaireDto.FromDomain(questionnaire);
        }
    }
}
