using Polling.Domain.Common;
using System;
using System.Collections.Generic;

namespace Polling.Domain.ValueObjects
{
    public class AggregatedResult : ValueObject
    {
        public Guid QuestionId { get; }
        public string Option { get; }
        public int Count { get; }

        public AggregatedResult(Guid questionId, string option, int count)
        {
            QuestionId = questionId;
            Option = option;
            Count = count;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return QuestionId;
            yield return Option;
            yield return Count;
        }
    }
}
