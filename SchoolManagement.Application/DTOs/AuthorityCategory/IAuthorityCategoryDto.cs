using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.AuthorityCategory 
{
    public interface IAuthorityCategoryDto 
    {
        public int AuthorityCategoryId { get; set; }
        public string? AuthorCategoryName { get; set; }
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }
    } 
}
