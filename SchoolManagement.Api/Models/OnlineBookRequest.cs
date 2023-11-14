using System;
using System.Collections.Generic;

namespace SchoolManagement.Api.Models
{
    public partial class OnlineBookRequest
    {
        public int OnlineBookRequestId { get; set; }
        public int? BookInformationId { get; set; }
        public int? MemberInfoId { get; set; }
        public int? BaseSchoolNameId { get; set; }
        public string AccessionNo { get; set; }
        public int? RequestStatus { get; set; }
        public int? IssueStatus { get; set; }
        public int? CancelStatus { get; set; }
        public int? MenuPosition { get; set; }
        public DateTime? RequestDate { get; set; }
        public DateTime? CancelDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime DateCreated { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public bool IsActive { get; set; }

        public virtual BaseSchoolName BaseSchoolName { get; set; }
        public virtual BookInformation BookInformation { get; set; }
        public virtual MemberInfo MemberInfo { get; set; }
    }
}
