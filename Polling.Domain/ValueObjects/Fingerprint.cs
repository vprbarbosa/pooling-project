using Polling.Domain.Common;
using System;
using System.Collections.Generic;

namespace Polling.Domain.ValueObjects
{
    public class Fingerprint : ValueObject
    {
        public string Hash { get; private set; }

        private Fingerprint() { }

        private Fingerprint(string hash)
        {
            Hash = hash;
        }

        public static Fingerprint Create(string hash)
        {
            if (string.IsNullOrWhiteSpace(hash))
                throw new InvalidOperationException("Fingerprint inválido.");

            return new Fingerprint(hash);
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Hash;
        }
    }
}
