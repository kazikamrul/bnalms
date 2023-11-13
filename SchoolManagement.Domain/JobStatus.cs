using SchoolManagement.Domain.Common;

namespace SchoolManagement.Domain
{
    public class JobStatus : BaseDomainEntity
    {
        public JobStatus()
        {
            MemberInfos = new HashSet<MemberInfo>();
            MemberRegistrations = new HashSet<MemberRegistration>();

        }

        public int JobStatusId { get; set; }
        public string? JobStatusName { get; set; }
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<MemberInfo> MemberInfos { get; set; }
        public virtual ICollection<MemberRegistration> MemberRegistrations { get; set; }
    }
}
