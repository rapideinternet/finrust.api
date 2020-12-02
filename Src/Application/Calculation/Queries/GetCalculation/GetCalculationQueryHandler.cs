using FinRust.Application.Calculation.Interfaces;
using FinRust.Application.Calculation.Models;
using FinRust.Domain.ValueObjects;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace FinRust.Application.Calculation.Queries.GetCalculation
{
    class GetCalculationQueryHandler : IRequestHandler<GetCalculationQuery, CalculationDto>
    {
        private readonly IGetCashFlowAmount _getCashFlowAmount;

        public GetCalculationQueryHandler(IGetCashFlowAmount getCashFlowAmount)
        {
            _getCashFlowAmount = getCashFlowAmount;
        }

        public Task<CalculationDto> Handle(GetCalculationQuery request, CancellationToken cancellationToken)
        {
            var result = _getCashFlowAmount.GetCashflowAmountAt(
                new Cashflow() { Type = request.Type },
                request.DateTime,
                request.Net
                );

            //Example when no async is involved
            var task = new TaskCompletionSource<CalculationDto>();

            task.SetResult(new CalculationDto()
            {
                Result = result
            });

            return task.Task;
        }
    }
}
