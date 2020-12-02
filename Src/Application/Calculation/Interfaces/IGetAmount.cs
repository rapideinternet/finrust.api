using FinRust.Domain.ValueObjects;
using System;

namespace FinRust.Application.Calculation.Interfaces
{
    public interface IGetAmount
    {
        decimal GetAmount(Cashflow cashflow, DateTime date, bool net);
    }
}
