using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.AuthorInformation 
{
    public interface IAuthorInformationDto 
    {
        public int AuthorInformationId { get; set; }
        public int? BaseSchoolNameId { get; set; }
        public int? BookInformationId { get; set; }
        public int? AuthorityCategoryId { get; set; }
        public string? AuthorName { get; set; }
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }
    } 
}
