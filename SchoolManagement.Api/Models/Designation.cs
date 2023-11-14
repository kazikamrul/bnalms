using System;
using System.Collections.Generic;

namespace SchoolManagement.Api.Models
{
    public partial class Designation
    {
        public Designation()
        {
            MemberInfos = new HashSet<MemberInfo>();
            MemberRegistrations = new HashSet<MemberRegistration>();
            Ranks = new HashSet<Rank>();
        }

        public int DesignationId { get; set; }
        public string DesignationName { get; set; }
        public int? MenuPosition { get; set; }
        public string CreatedBy { get; set; }
        public DateTime DateCreated { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<MemberInfo> MemberInfos { get; set; }
        public virtual ICollection<MemberRegistration> MemberRegistrations { get; set; }
        public virtual ICollection<Rank> Ranks { get; set; }
    }
}
