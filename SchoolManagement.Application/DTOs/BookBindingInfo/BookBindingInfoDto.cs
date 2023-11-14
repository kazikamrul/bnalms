using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.BookBindingInfo
{
    public class BookBindingInfoDto : IBookBindingInfoDto
    {
        public int BookBindingInfoId { get; set; }
        public int? BaseSchoolNameId { get; set; }
        public int? BookInformationId { get; set; }
        public string? PressName { get; set; }
        public DateTime? Date { get; set; }
        public int? PressNumber { get; set; }
        public string? PressEmail { get; set; }
        public string? PressAddress { get; set; }
        public string? SenderOfficer { get; set; }
        public string? OfficeDispiseNumber { get; set; }
        public string? ReceivedOfficerName { get; set; }
        public bool IsActive { get; set; }
        public string? AccessionNo { get; set; }
        public string? Category { get; set; }
        public string? BookTitleEnglish { get; set; }
        public string? BookTitleBangla { get; set; }
    }
}
 