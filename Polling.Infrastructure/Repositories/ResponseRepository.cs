using Microsoft.EntityFrameworkCore;
using Polling.Domain.Aggregates;
using Polling.Domain.Repositories;
using Polling.Domain.ValueObjects;
using Polling.Infrastructure.Persistence;

namespace Polling.Infrastructure.Repositories
{
    public class ResponseRepository : IResponseRepository
    {
        private readonly PollingDbContext _context;

        public ResponseRepository(PollingDbContext context)
        {
            _context = context;
        }

        public async Task<bool> ExistsAsync(Guid questionnaireId, Fingerprint fingerprint)
        {
            return await _context.Responses
                .AsNoTracking()
                .AnyAsync(r =>
                    r.QuestionnaireId == questionnaireId &&
                    r.Fingerprint.Hash == fingerprint.Hash
                );
        }

        public async Task AddAsync(Response response)
        {
            await _context.Responses.AddAsync(response);
            await _context.SaveChangesAsync();
        }
    }
}
