using Polling.Domain.Aggregates;
using System;
using System.Threading.Tasks;

namespace Polling.Domain.Repositories
{
    public interface IQuestionnaireRepository
    {
        Task<Questionnaire?> GetByIdAsync(Guid id);
        Task AddAsync(Questionnaire questionnaire);
        Task UpdateAsync(Questionnaire questionnaire);
    }
}
