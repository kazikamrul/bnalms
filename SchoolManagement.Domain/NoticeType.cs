using SchoolManagement.Domain.Common;

namespace SchoolManagement.Domain
{
    public class NoticeType : BaseDomainEntity
    {
        public NoticeType()
        {
            NoticeInfos = new HashSet<NoticeInfo>();

        }

        public int NoticeTypeId { get; set; }
        public string? Name { get; set; }
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<NoticeInfo> NoticeInfos { get; set; }


    }
}
