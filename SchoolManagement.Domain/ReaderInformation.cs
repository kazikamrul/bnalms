using SchoolManagement.Domain.Common;

namespace SchoolManagement.Domain
{
    public class ReaderInformation : BaseDomainEntity
    {
        public ReaderInformation()
        {
            

        }

        public int ReaderInformationId { get; set; }
        public int? BaseSchoolNameId { get; set; }
        public int? MemberInfoId { get; set; }
        public string? ReaderName { get; set; }
        public DateTime? InDate { get; set; }
        public DateTime? OutDate { get; set; }
        public bool IsActive { get; set; }

       public virtual MemberInfo? MemberInfo { get; set; }
        public virtual BaseSchoolName? BaseSchoolName { get; set; }
    }
}
