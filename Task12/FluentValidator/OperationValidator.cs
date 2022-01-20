using Core.Models;
using FluentValidation;

namespace Task12.FluentValidator {
	public class OperationValidator : AbstractValidator<Operation> {
		public OperationValidator() {
			RuleFor(x => x.Id).NotNull();
			RuleFor(x => x.Name).Length(0, 10);
			RuleFor(x => x.Amount).Must(x => x > 0);
			RuleFor(x => x.Date);
		}
	}
}
