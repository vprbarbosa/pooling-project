using Polling.Infrastructure.Queries;
using Pooling.Application.Dtos;
using Pooling.Application.Interfaces;

namespace Pooling.Application.Services
{
    public class ResultService : IResultService
    {
        private readonly IResultQuery _query;

        public ResultService(IResultQuery query)
        {
            _query = query;
        }

        public async Task<IEnumerable<QuestionnaireResultDto>> GetResults(Guid questionnaireId)
        {
            var results = await _query.GetAggregatedResults(questionnaireId);

            return results.Select(r => new QuestionnaireResultDto
            {
                QuestionId = r.QuestionId,
                Option = r.Option,
                Count = r.Count
            });
        }
    }
}
