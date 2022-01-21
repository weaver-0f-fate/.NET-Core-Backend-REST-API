using FluentValidation;
using Services.DataTransferObjects.OperationDTOs;

namespace Task12.FluentValidator {
    public class OperationForUpdateDtoValidator : AbstractValidator<OperationForUpdateDTO> {
        public OperationForUpdateDtoValidator() {
            RuleFor(x => x.Name).NotNull().NotEmpty();
            RuleFor(x => x.OperationTypeId).NotNull();
            RuleFor(x => x.Amount).NotNull().Must(x => x > 0);
            RuleFor(x => x.Date).NotNull();
        }
    }
}
