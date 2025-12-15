using Polling.Domain.ValueObjects;

namespace Polling.Infrastructure.Queries
{
    public interface IResultQuery
    {
        Task<IEnumerable<AggregatedResult>> GetAggregatedResults(Guid questionnaireId);
    }
}