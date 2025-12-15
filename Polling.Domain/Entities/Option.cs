using Polling.Domain.Common;
using System;

namespace Polling.Domain.Entities
{
    public class Option : Entity
    {
        public string Label { get; private set; }

        private Option(string label)
        {
            Label = label;
        }

        public static Option Create(string label)
        {
            if (string.IsNullOrWhiteSpace(label))
                throw new DomainException("Opção de questionário inválida.");

            return new Option(label);
        }

        private Option() { }
    }
}
