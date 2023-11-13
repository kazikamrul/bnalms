using SchoolManagement.Domain.Common;

namespace SchoolManagement.Domain
{
    public class Area : BaseDomainEntity
    {
        public Area()
        {
            MemberInfos = new HashSet<MemberInfo>();
            MemberRegistrations = new HashSet<MemberRegistration>();

        }

        public int AreaId { get; set; }
        public string? Name { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<MemberInfo> MemberInfos { get; set; }
        public virtual ICollection<MemberRegistration> MemberRegistrations { get; set; }
    }
}
