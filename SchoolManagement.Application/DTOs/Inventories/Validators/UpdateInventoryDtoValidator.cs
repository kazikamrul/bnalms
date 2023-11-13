using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
 
namespace SchoolManagement.Application.DTOs.Inventorys.Validators
{
    public class UpdateInventoryDtoValidator : AbstractValidator<InventoryDto>
    {
        public UpdateInventoryDtoValidator()
        {
            Include(new IInventoryDtoValidator());

            RuleFor(b => b.InventoryId).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}

