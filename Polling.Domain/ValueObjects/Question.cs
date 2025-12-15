using Polling.Domain.Common;
using Polling.Domain.Enums;
using System.Collections.Generic;
using System.Linq;

namespace Polling.Domain.ValueObjects
{
    public class Question : Entity
    {
        private readonly List<Option> _options = new();
        public IReadOnlyCollection<Option> Options => _options.AsReadOnly();

        public string Text { get; private set; }
        public QuestionType Type { get; private set; }

        private Question(string text, QuestionType type)            
        {
            Text = text;
            Type = type;
        }

        public static Question Create(string text, IEnumerable<string> options)
        {
            if (string.IsNullOrWhiteSpace(text))
                throw new DomainException("Texto da pergunta inválido.");

            if (options == null || !options.Any())
                throw new DomainException("Pergunta deve ter opções.");

            var question = new Question(text, QuestionType.MultipleChoice);

            foreach (var option in options)
            {
                question._options.Add(Option.Create(option));
            }

            return question;
        }

        private Question() { }
    }
}
