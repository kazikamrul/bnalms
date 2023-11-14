using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.MemberCategory 
{
    public interface IMemberCategoryDto 
    {
        public int MemberCategoryId { get; set; }
        public string? MemberCategoryName { get; set; }
        public bool IsActive { get; set; }
    } 
}
