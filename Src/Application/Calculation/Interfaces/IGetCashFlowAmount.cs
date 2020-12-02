using FinRust.Domain.ValueObjects;
using System;

namespace FinRust.Application.Calculation.Interfaces
{
    interface IGetCashFlowAmount
    {
        decimal GetCashflowAmountAt(Cashflow cashflow, DateTime date, bool net);
    }
}
