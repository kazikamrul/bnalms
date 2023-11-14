using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
 
namespace SchoolManagement.Application.DTOs.SupplierInformation.Validators
{
    public class ISupplierInformationDtoValidator : AbstractValidator<ISupplierInformationDto>
    {
        public ISupplierInformationDtoValidator() 
        {
            RuleFor(b => b.SupplierName)
                .NotEmpty().WithMessage("{PropertyName} is required.").MaximumLength(150).WithMessage("{PropertyName} must not exceed {ComparisonValue} characters.");
        }
    }
}
