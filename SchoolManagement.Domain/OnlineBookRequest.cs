using SchoolManagement.Domain.Common;

namespace SchoolManagement.Domain
{
    public class OnlineBookRequest : BaseDomainEntity
    {
        public int OnlineBookRequestId { get; set; }
        public int? BookInformationId { get; set; }
        public int? MemberInfoId { get; set; }
        public int? RequestStatus { get; set; }
        public int? IssueStatus { get; set; }
        public int? CancelStatus { get; set; }
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }
        public int? BaseSchoolNameId { get; set; } 
        public string? AccessionNo { get; set; }
        public DateTime? RequestDate { get; set; }
        public DateTime? CancelDate { get; set; }

        public virtual BaseSchoolName? BaseSchoolName { get; set; }
        public virtual BookInformation? BookInformation { get; set; }
        public virtual MemberInfo? MemberInfo { get; set; }
    }
}
