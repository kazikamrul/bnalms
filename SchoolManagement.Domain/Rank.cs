using SchoolManagement.Domain.Common;

namespace SchoolManagement.Domain
{
    public class Rank : BaseDomainEntity
    {
        public Rank()
        {
            MemberInfos = new HashSet<MemberInfo>();
            MemberRegistrations = new HashSet<MemberRegistration>();

        }

        public int RankId { get; set; }
        public int? DesignationId { get; set; }
        public string? RankName { get; set; }
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }

        public virtual Designation? Designation { get; set; }
        public virtual ICollection<MemberInfo> MemberInfos { get; set; }
        public virtual ICollection<MemberRegistration> MemberRegistrations { get; set; }
    }
}
