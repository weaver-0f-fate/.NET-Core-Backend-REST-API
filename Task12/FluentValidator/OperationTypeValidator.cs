using Core.Models;
using FluentValidation;

namespace Task12.FluentValidator {
	public class OperationTypeValidator : AbstractValidator<OperationType> {
		public OperationTypeValidator() {
			RuleFor(x => x.Id).NotNull();
			RuleFor(x => x.Name).NotNull();
			RuleFor(x => x.IsIncome).NotNull();
		}
	}
}
