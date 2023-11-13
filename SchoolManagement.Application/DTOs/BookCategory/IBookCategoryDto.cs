using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.BookCategory 
{
    public interface IBookCategoryDto 
    {
        public int BookCategoryId { get; set; }
        public string? BookCategoryName { get; set; }
        public int? MenuPosition { get; set; }
        public string? Remarks { get; set; }
        public bool IsActive { get; set; }
    } 
}
