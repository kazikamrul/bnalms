using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.Bulletin.Validators
{
    public class CreateBulletinDtoValidator : AbstractValidator<CreateBulletinDto>
    {
        public CreateBulletinDtoValidator()  
        {
            Include(new IBulletinDtoValidator()); 
        }
    }
}
