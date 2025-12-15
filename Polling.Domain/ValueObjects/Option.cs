using Polling.Domain.Common;
using System;
using System.Collections.Generic;

namespace Polling.Domain.ValueObjects
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
