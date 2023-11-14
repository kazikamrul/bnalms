﻿using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.ExamType
{
    public interface IExamTypeDto
    {
        public int ExamTypeId { get; set; }
        public string ExamTypeName { get; set; }
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }
    }
}
