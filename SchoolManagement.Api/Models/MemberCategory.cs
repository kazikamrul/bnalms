using System;
using System.Collections.Generic;

namespace SchoolManagement.Api.Models
{
    public partial class MemberCategory
    {
        public MemberCategory()
        {
            MemberInfos = new HashSet<MemberInfo>();
            MemberRegistrations = new HashSet<MemberRegistration>();
        }

        public int MemberCategoryId { get; set; }
        public string MemberCategoryName { get; set; }
        public string CreatedBy { get; set; }
        public DateTime DateCreated { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<MemberInfo> MemberInfos { get; set; }
        public virtual ICollection<MemberRegistration> MemberRegistrations { get; set; }
    }
}
