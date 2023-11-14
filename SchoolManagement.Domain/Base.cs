using SchoolManagement.Domain.Common;

namespace SchoolManagement.Domain
{
    public class Base : BaseDomainEntity
    {
        public Base()
        {
            MemberInfos = new HashSet<MemberInfo>();
            MemberRegistrations = new HashSet<MemberRegistration>();

        }

        public int BaseId { get; set; }
        public string? Name { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<MemberInfo> MemberInfos { get; set; }
        public virtual ICollection<MemberRegistration> MemberRegistrations { get; set; }
    }
}
