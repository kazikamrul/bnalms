using SchoolManagement.Domain.Common;

namespace SchoolManagement.Domain
{
    public class NoticeInfo : BaseDomainEntity
    {
        public NoticeInfo()
        {
            

        }

        public int NoticeInfoId { get; set; }
        public int? BaseSchoolNameId { get; set; }
        public int? NoticeTypeId { get; set; }
        public string? NoticeTitle { get; set; }
        public string? UploadPDFFile { get; set; }
        public string? Remarks { get; set; }
        public int? ViewStatus { get; set; }
        public int? DetailViewStatus { get; set; }
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; } 
        public int? MemberInfoId { get; set; }
        public DateTime? NoticeEndDate { get; set; }
        public virtual BaseSchoolName? BaseSchoolName { get; set; }
        public virtual NoticeType? NoticeType { get; set; }




    }
}
