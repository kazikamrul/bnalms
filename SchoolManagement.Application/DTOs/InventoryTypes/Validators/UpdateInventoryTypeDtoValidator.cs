using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
 
namespace SchoolManagement.Application.DTOs.InventoryTypes.Validators
{
    public class UpdateInventoryTypeDtoValidator : AbstractValidator<InventoryTypeDto>
    {
        public UpdateInventoryTypeDtoValidator()
        {
            Include(new IInventoryTypeDtoValidator());

            RuleFor(b => b.InventoryTypeId).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}

