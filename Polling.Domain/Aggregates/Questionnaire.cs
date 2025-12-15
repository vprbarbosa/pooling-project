using Polling.Domain.Common;
using Polling.Domain.Entities;
using System.Collections.Generic;

namespace Polling.Domain.Aggregates
{
    public sealed class Questionnaire : AggregateRoot
    {
        private readonly List<Question> _questions = new();

        public string Title { get; private set; }
        public IReadOnlyCollection<Question> Questions => _questions;

        protected Questionnaire() { }

        private Questionnaire(string title)
        {
            if (string.IsNullOrWhiteSpace(title))
                throw new DomainException("Título do questionário é obrigatório.");

            Title = title;
        }

        public static Questionnaire Create(string title)
        {
            return new Questionnaire(title);
        }

        public void AddQuestion(Question question)
        {
            if (question == null)
                throw new DomainException("Pergunta inválida.");

            _questions.Add(question);
        }
    }
}
