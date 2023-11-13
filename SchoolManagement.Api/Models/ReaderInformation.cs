using System;
using System.Collections.Generic;

namespace SchoolManagement.Api.Models
{
    public partial class ReaderInformation
    {
        public int ReaderInformationId { get; set; }
        public int? BaseSchoolNameId { get; set; }
        public int? MemberInfoId { get; set; }
        public string ReaderName { get; set; }
        public DateTime? InDate { get; set; }
        public DateTime? OutDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime DateCreated { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public bool IsActive { get; set; }

        public virtual BaseSchoolName BaseSchoolName { get; set; }
        public virtual MemberInfo MemberInfo { get; set; }
    }
}
