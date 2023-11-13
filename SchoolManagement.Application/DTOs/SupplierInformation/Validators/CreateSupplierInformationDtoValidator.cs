using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.SupplierInformation.Validators
{
    public class CreateSupplierInformationDtoValidator : AbstractValidator<CreateSupplierInformationDto>
    {
        public CreateSupplierInformationDtoValidator()  
        {
            Include(new ISupplierInformationDtoValidator()); 
        }
    }
}
