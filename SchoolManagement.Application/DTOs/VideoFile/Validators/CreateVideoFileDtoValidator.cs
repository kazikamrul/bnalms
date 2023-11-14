using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;

namespace SchoolManagement.Application.DTOs.VideoFile.Validators
{
    public class CreateVideoFileDtoValidator : AbstractValidator<CreateVideoFileDto>
    {
        public CreateVideoFileDtoValidator()
        {
            Include(new IVideoFileDtoValidator());
        }
    }
}
