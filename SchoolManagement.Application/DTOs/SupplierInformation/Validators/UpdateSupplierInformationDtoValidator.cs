using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
 
namespace SchoolManagement.Application.DTOs.SupplierInformation.Validators
{
    public class UpdateSupplierInformationDtoValidator : AbstractValidator<SupplierInformationDto>
    {
        public UpdateSupplierInformationDtoValidator()
        {
            Include(new ISupplierInformationDtoValidator());

            RuleFor(b => b.SupplierInformationId).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}

