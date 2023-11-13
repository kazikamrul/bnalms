using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.SupplierInformation
{
    public class SupplierInformationDto : ISupplierInformationDto
    {
        public int SupplierInformationId { get; set; }
        public int? BaseSchoolNameId { get; set; }
        public int? BookInformationId { get; set; }
        public string? SupplierName { get; set; }
        public string? Address { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public DateTime? SuppliedDate { get; set; }
        public DateTime? ReceivedDate { get; set; }
        public string? Remarks { get; set; }
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }

        public string? BookTitle { get; set; }
    }
}
