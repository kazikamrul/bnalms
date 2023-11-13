using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
 
namespace SchoolManagement.Application.DTOs.Inventorys.Validators
{
    public class IInventoryDtoValidator : AbstractValidator<IInventoryDto>
    {
        //public IInventoryDtoValidator() 
        //{
        //    RuleFor(b => b.InventoryName)
        //        .NotEmpty().WithMessage("{PropertyName} is required.").MaximumLength(150).WithMessage("{PropertyName} must not exceed {ComparisonValue} characters.");
        //}
    }
}
