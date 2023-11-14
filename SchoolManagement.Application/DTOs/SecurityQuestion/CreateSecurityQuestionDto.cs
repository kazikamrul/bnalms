﻿using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.SecurityQuestion
{
    public class CreateSecurityQuestionDto : ISecurityQuestionDto  
    {
        public int SecurityQuestionId { get; set; }
        public string? Name { get; set; }
        public bool IsActive { get; set; }
    }
}
