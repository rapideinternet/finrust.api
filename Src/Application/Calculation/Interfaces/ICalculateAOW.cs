using System;

namespace FinRust.Application.Calculation.Interfaces
{
    public interface ICalculateAOW
    {
        decimal CalculateAOW(DateTime date, bool net);
    }
}
