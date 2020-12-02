using FinRust.Domain.Common;
using System.Collections.Generic;

namespace FinRust.Domain.ValueObjects
{
    public enum Type
    {
        AOW
    }

    public class Cashflow : ValueObject
    {
        public Type Type { get; set; }

        protected override IEnumerable<object> GetAtomicValues()
        {
            throw new System.NotImplementedException();
        }
    }
}
