using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.FeeCategory
{
    public class CreateFeeCategoryDto : IFeeCategoryDto  
    {
        public int FeeCategoryId { get; set; }
        public string? FeeCategoryName { get; set; }
        public bool IsActive { get; set; }
    }
}
