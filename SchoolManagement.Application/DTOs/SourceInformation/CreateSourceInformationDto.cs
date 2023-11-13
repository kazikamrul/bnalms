using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.SourceInformation
{
    public class CreateSourceInformationDto : ISourceInformationDto  
    {
        public int SourceInformationId { get; set; }
        public int? BaseSchoolNameId { get; set; }
        public int? BookInformationId { get; set; }
        public string? SourceName { get; set; }
        public string? Address { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public DateTime? OrderDate { get; set; }
        public DateTime? ReceivedDate { get; set; }
        public string? Remarks { get; set; }
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }
    }
}
