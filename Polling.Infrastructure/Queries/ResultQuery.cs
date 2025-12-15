using Microsoft.EntityFrameworkCore;
using Polling.Domain.ValueObjects;
using Polling.Infrastructure.Persistence;

namespace Polling.Infrastructure.Queries
{
    public class ResultQuery : IResultQuery
    {
        private readonly PollingDbContext _context;

        public ResultQuery(PollingDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<AggregatedResult>> GetAggregatedResults(Guid questionnaireId)
        {
            return await _context.Responses
                .Where(r => r.QuestionnaireId == questionnaireId)
                .SelectMany(r => r.Answers)
                .GroupBy(a => new { a.QuestionId, a.Value })
                .Select(g => new AggregatedResult(
                    g.Key.QuestionId,
                    g.Key.Value,
                    g.Count()
                ))
                .ToListAsync();
        }
    }
}
