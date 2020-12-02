using FinRust.Application.Calculation.Interfaces;
using FinRust.Domain.ValueObjects;
using System;

namespace FinRust.Application.Calculation.Services
{
    public class CalculatorHelper : IGetAmount
    {
        public decimal GetAmount(Cashflow cashflow, DateTime date, bool net)
        {
            return 2;
        }
    }
}
