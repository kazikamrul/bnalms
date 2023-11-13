using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.SecurityQuestion 
{
    public interface ISecurityQuestionDto 
    {
        public int SecurityQuestionId { get; set; }
        public string? Name { get; set; }
        public bool IsActive { get; set; }
    } 
}
