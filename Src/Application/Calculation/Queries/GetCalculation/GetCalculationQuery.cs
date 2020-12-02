using FinRust.Application.Calculation.Models;
using MediatR;
using System;
using Type = FinRust.Domain.ValueObjects.Type;

namespace FinRust.Application.Calculation.Queries.GetCalculation
{
    public class GetCalculationQuery : IRequest<CalculationDto>
    {
        public Type Type { get; set; }

        public DateTime DateTime { get; set; }

        public bool Net { get; set; }
    }
}
