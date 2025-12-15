using Polling.Domain.Aggregates;
using Polling.Domain.Common;
using Polling.Domain.Repositories;
using Polling.Domain.ValueObjects;
using Pooling.Application.Dtos;
using Pooling.Application.Interfaces;

namespace Pooling.Application.Services
{
    public class ResponseService : IResponseService
    {
        private readonly IResponseRepository _responseRepository;
        private readonly IQuestionnaireRepository _questionnaireRepository;

        public ResponseService(IResponseRepository responseRepository, IQuestionnaireRepository questionnaireRepository)
        {
            _responseRepository = responseRepository;
            _questionnaireRepository = questionnaireRepository;
        }

        public async Task Submit(SubmitResponseDto dto)
        {
            var questionnaire = await _questionnaireRepository.GetByIdAsync(dto.QuestionnaireId);

            if (questionnaire == null)
                throw new DomainException("Questionário não encontrado.");

            var fingerprint = Fingerprint.Create(dto.Fingerprint);

            var alreadyAnswered = await _responseRepository.ExistsAsync(dto.QuestionnaireId, fingerprint);

            if (alreadyAnswered)
                throw new DomainException("Usuário já respondeu este questionário.");

            var response = Response.Create(dto.QuestionnaireId, dto.Fingerprint);

            foreach (var a in dto.Answers)
            {
                response.AddAnswer(Answer.Create(a.QuestionId, a.Value));
            }

            await _responseRepository.AddAsync(response);
        }
    }
}
