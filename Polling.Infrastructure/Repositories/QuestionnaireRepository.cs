using Microsoft.EntityFrameworkCore;
using Polling.Domain.Aggregates;
using Polling.Domain.Repositories;
using Polling.Infrastructure.Persistence;

namespace Polling.Infrastructure.Repositories
{
    public class QuestionnaireRepository : IQuestionnaireRepository
    {
        private readonly PollingDbContext _context;

        public QuestionnaireRepository(PollingDbContext context)
        {
            _context = context;
        }

        public async Task<Questionnaire?> GetByIdAsync(Guid id)
        {
            return await _context.Questionnaires
                .Include(q => q.Questions)
                    .ThenInclude(q => q.Options)
                .FirstOrDefaultAsync(q => q.Id == id);
        }

        public async Task AddAsync(Questionnaire questionnaire)
        {
            await _context.Questionnaires.AddAsync(questionnaire);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Questionnaire questionnaire)
        {
            _context.Questionnaires.Update(questionnaire);
            await _context.SaveChangesAsync();
        }
    }
}
