using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
 
namespace SchoolManagement.Application.DTOs.Bulletin.Validators
{
    public class UpdateBulletinDtoValidator : AbstractValidator<BulletinDto>
    {
        public UpdateBulletinDtoValidator()
        {
            Include(new IBulletinDtoValidator());

            RuleFor(b => b.BulletinId).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}

