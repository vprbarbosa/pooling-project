using Polling.Domain.Common;
using System;
using System.Collections.Generic;

namespace Polling.Domain.ValueObjects
{
    public class Answer : ValueObject
    {
        public Guid QuestionId { get; }
        public string Value { get; }

        private Answer(Guid questionId, string value)
        {
            QuestionId = questionId;
            Value = value;
        }

        public static Answer Create(Guid questionId, string value)
        {
            if (questionId == Guid.Empty)
                throw new DomainException("Id do questionário inválido.");

            if (string.IsNullOrWhiteSpace(value))
                throw new DomainException("Resposta inválida.");

            return new Answer(questionId, value);
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return QuestionId;
            yield return Value;
        }
    }
}
