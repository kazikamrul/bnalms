using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.NoticeInfo 
{
    public interface INoticeInfoDto 
    {
        public int NoticeInfoId { get; set; }
        public int? BaseSchoolNameId { get; set; }
        public int? NoticeTypeId { get; set; }
        public string? NoticeTitle { get; set; }
        public string? UploadPDFFile { get; set; }
        public string? Remarks { get; set; }
        public int? ViewStatus { get; set; }
        public int? DetailViewStatus { get; set; }
        public int? MemberInfoId { get; set; }
        public DateTime? NoticeEndDate { get; set; }
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }
    } 
}
