using Polling.Api.Models.Responses;
using Pooling.Application.Dtos;

namespace Polling.Api.Mappers
{
    public static class QuestionnaireMapper
    {
        public static QuestionnaireResponse ToResponse(this QuestionnaireDto dto)
        {
            return new QuestionnaireResponse
            {
                Id = dto.Id,
                Questions = dto.Questions.Select(q => new QuestionResponse
                {
                    Id = q.Id,
                    Text = q.Text,
                    Options = q.Options.Select(o => new OptionResponse
                    {
                        Id = o.Id,
                        Label = o.Label
                    }).ToList()
                }).ToList()
            };
        }

        public static QuestionnaireCreatedResponse ToResponse(this QuestionnaireCreatedDto dto)
        {
            return new QuestionnaireCreatedResponse
            {
                Id = dto.Id,
                Title = dto.Title
            };
        }
    }
}
