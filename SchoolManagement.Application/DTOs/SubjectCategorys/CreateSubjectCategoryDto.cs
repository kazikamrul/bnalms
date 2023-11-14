﻿using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.SubjectCategorys
{
    public class CreateSubjectCategoryDto : ISubjectCategoryDto
    {
        public int SubjectCategoryId { get; set; }
        public string SubjectCategoryName { get; set; } = null!;
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }
    }
}
