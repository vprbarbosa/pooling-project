using Polling.Domain.Aggregates;
using Polling.Domain.ValueObjects;
using System;
using System.Threading.Tasks;

namespace Polling.Domain.Repositories
{
    public interface IResponseRepository
    {
        Task<bool> ExistsAsync(Guid questionnaireId, Fingerprint fingerprint);
        Task AddAsync(Response response);
    }
}
