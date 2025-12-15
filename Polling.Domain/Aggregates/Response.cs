using Polling.Domain.Common;
using Polling.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Polling.Domain.Aggregates
{
    public sealed class Response : AggregateRoot
    {
        private readonly List<Answer> _answers = new();

        public Guid QuestionnaireId { get; private set; }
        public DateTime SubmittedAt { get; private set; }
        public Fingerprint Fingerprint { get; private set; }

        public IReadOnlyCollection<Answer> Answers => _answers;

        protected Response() { }

        private Response(Guid questionnaireId, Fingerprint fingerprint)
        {
            QuestionnaireId = questionnaireId;            
            Fingerprint = fingerprint;
            SubmittedAt = DateTime.UtcNow;
        }

        public static Response Create(Guid questionnaireId, string fingerprint)
        {
            return new Response(questionnaireId, Fingerprint.Create(fingerprint));
        }

        public void AddAnswer(Answer answer)
        {
            if (answer == null)
                throw new DomainException("Resposta inválida.");

            if (_answers.Any(a => a.QuestionId == answer.QuestionId))
                throw new DomainException("Pergunta já respondida.");

            _answers.Add(answer);
        }
    }
}
