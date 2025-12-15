using Polling.Api.Models.Responses;
using Pooling.Application.Dtos;

namespace Polling.Api.Mappers
{
    public static class AggregatedResultMapper
    {
        public static AggregatedResultResponse ToResponse(this QuestionnaireResultDto dto)
        {
            return new AggregatedResultResponse
            {
                QuestionId = dto.QuestionId,
                Option = dto.Option,
                Count = dto.Count
            };
        }
    }
}
