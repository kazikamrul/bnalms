using SchoolManagement.Domain.Common;

namespace SchoolManagement.Domain
{
    public class HelpLine : BaseDomainEntity
    {
        public HelpLine()
        {
            //NoticeInfos = new HashSet<NoticeInfo>();

        }

        public int HelpLineId { get; set; }
        public int? BaseSchoolNameId { get; set; }
        public int? LibraryAuthorityId { get; set; }
        public string? HelpContact { get; set; }
        public string? EmailAddress { get; set; }
        public int? MenuPosition { get; set; }
        public bool? DashboardDisplayStatus { get; set; }
        public bool IsActive { get; set; }

        public virtual BaseSchoolName? BaseSchoolName { get; set; }
        public virtual LibraryAuthority? LibraryAuthority { get; set; }

        //public virtual ICollection<NoticeInfo> NoticeInfos { get; set; }


    }
}
