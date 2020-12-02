using FinRust.Domain.Common;
using System;
using System.Collections.Generic;
using Action = FinRust.Domain.Enums.Action;

namespace FinRust.Domain.ValueObjects
{
    public class CalculationDate : ValueObject
    {
        public DateTime Date { get; set; }

        public Action Action { get; set; }


        protected override IEnumerable<object> GetAtomicValues()
        {
            throw new NotImplementedException();
        }
    }
}
