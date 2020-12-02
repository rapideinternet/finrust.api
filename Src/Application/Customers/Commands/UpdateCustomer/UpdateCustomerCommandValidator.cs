using FluentValidation;
using FluentValidation.Validators;

namespace FinRust.Application.Customers.Commands.UpdateCustomer
{
    public class UpdateCustomerCommandValidator : AbstractValidator<UpdateCustomerCommand>
    {
        public UpdateCustomerCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.Name).MaximumLength(100).Must(FilterBadWords);
        }

        private static bool FilterBadWords(UpdateCustomerCommand model, string nameValue, PropertyValidatorContext ctx)
        {
            return !nameValue.Contains("bad");
        }
    }
}
