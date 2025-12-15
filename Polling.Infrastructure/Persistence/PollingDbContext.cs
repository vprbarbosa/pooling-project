using Microsoft.EntityFrameworkCore;
using Polling.Domain.Aggregates;

namespace Polling.Infrastructure.Persistence
{
    public class PollingDbContext : DbContext
    {
        public PollingDbContext(DbContextOptions<PollingDbContext> options)
            : base(options)
        {
        }

        public DbSet<Questionnaire> Questionnaires { get; set; }
        public DbSet<Response> Responses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Questionnaire>(q =>
            {
                q.HasKey(x => x.Id);

                q.OwnsMany(x => x.Questions, question =>
                {
                    question.WithOwner().HasForeignKey("QuestionnaireId");
                    question.HasKey("Id");

                    question.Property(q => q.Text).IsRequired();

                    question.OwnsMany(q => q.Options, option =>
                    {
                        option.WithOwner().HasForeignKey("QuestionId");
                        option.HasKey(o => o.Id);
                        option.Property(o => o.Label).IsRequired();
                    });
                });
            });

            modelBuilder.Entity<Response>(response =>
            {
                response.HasKey(r => r.Id);

                response.Property(r => r.QuestionnaireId).IsRequired();
                response.Property(r => r.SubmittedAt).IsRequired();

                response.OwnsOne(r => r.Fingerprint, fingerprint =>
                {
                    fingerprint.Property(f => f.Hash)
                               .HasColumnName("FingerprintHash")
                               .IsRequired();
                });

                response.OwnsMany(r => r.Answers, answers =>
                {
                    answers.WithOwner()
                           .HasForeignKey("ResponseId");

                    answers.Property(a => a.QuestionId).IsRequired();
                    answers.Property(a => a.Value).IsRequired();

                    answers.HasKey("ResponseId", "QuestionId");
                });
            });
        }
    }
}
