using System;
using System.Collections.Generic;

namespace SchoolManagement.Api.Models
{
    public partial class FeeInformation
    {
        public int FeeInformationId { get; set; }
        public int? BaseSchoolNameId { get; set; }
        public int? BookInformationId { get; set; }
        public int? MemberInfoId { get; set; }
        public int? FeeCategoryId { get; set; }
        public DateTime? PaidDate { get; set; }
        public DateTime? ExpiredDate { get; set; }
        public double? PaidAmount { get; set; }
        public string ReceivedAmount { get; set; }
        public string CreatedBy { get; set; }
        public DateTime DateCreated { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public bool IsActive { get; set; }

        public virtual BaseSchoolName BaseSchoolName { get; set; }
        public virtual BookInformation BookInformation { get; set; }
        public virtual FeeCategory FeeCategory { get; set; }
        public virtual MemberInfo MemberInfo { get; set; }
    }
}
