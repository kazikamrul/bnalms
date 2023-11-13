using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.Inventorys.Validators
{
    public class CreateInventoryDtoValidator : AbstractValidator<CreateInventoryDto>
    {
        public CreateInventoryDtoValidator()  
        {
            Include(new IInventoryDtoValidator()); 
        }
    }
}
