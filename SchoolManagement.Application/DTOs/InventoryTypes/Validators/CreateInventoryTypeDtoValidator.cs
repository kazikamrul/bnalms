using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.InventoryTypes.Validators
{
    public class CreateInventoryTypeDtoValidator : AbstractValidator<CreateInventoryTypeDto>
    {
        public CreateInventoryTypeDtoValidator()  
        {
            Include(new IInventoryTypeDtoValidator()); 
        }
    }
}
