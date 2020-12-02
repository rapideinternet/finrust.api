using FinRust.Application.Calculation.Interfaces;
using FinRust.Domain.ValueObjects;
using System;
using Type = FinRust.Domain.ValueObjects.Type;

namespace FinRust.Application.Calculation.Services
{
    class CalculationService : IGetCashFlowAmount, ICalculateAOW
    {
        private readonly IGetAmount _getAmount;

        public CalculationService(IGetAmount getAmount)
        {
            _getAmount = getAmount;
        }

        public decimal GetCashflowAmountAt(Cashflow cashflow, DateTime date, bool net)
        {
            if (cashflow.Type == Type.AOW)
            {
                return CalculateAOW(date, net);
            }

            return _getAmount.GetAmount(cashflow, date, net);
        }

        public decimal CalculateAOW(DateTime date, bool net)
        {
            return 1;
        }
    }
}
