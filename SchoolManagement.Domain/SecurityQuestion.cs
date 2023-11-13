using SchoolManagement.Domain.Common;

namespace SchoolManagement.Domain
{
    public class SecurityQuestion : BaseDomainEntity
    {
        public SecurityQuestion()
        {
            MemberInfos = new HashSet<MemberInfo>();
            MemberRegistrations = new HashSet<MemberRegistration>();

        }

        public int SecurityQuestionId { get; set; }
        public string? Name { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<MemberInfo> MemberInfos { get; set; }
        public virtual ICollection<MemberRegistration> MemberRegistrations { get; set; }
    }
}
