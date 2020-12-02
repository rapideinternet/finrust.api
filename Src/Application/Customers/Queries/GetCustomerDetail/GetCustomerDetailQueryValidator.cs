using FluentValidation;

namespace FinRust.Application.Customers.Queries.GetCustomerDetail
{
    public class GetCustomerDetailQueryValidator : AbstractValidator<GetCustomerDetailQuery>
    {
        public GetCustomerDetailQueryValidator()
        {
            RuleFor(v => v.Id).NotEmpty();
        }
    }
}
