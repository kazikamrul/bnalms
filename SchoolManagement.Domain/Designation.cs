using SchoolManagement.Domain.Common;

namespace SchoolManagement.Domain
{
    public class Designation : BaseDomainEntity
    {
        public Designation()
        {

            MemberInfos = new HashSet<MemberInfo>();
            Ranks = new HashSet<Rank>();
            MemberRegistrations = new HashSet<MemberRegistration>();
        }

        public int DesignationId { get; set; }
        public string? DesignationName { get; set; }
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<MemberInfo> MemberInfos { get; set; }
        public virtual ICollection<Rank> Ranks { get; set; }
        public virtual ICollection<MemberRegistration> MemberRegistrations { get; set; }
    }
}
