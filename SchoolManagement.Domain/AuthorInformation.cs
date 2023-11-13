using SchoolManagement.Domain.Common;

namespace SchoolManagement.Domain
{
    public class AuthorInformation : BaseDomainEntity
    {

        public int AuthorInformationId { get; set; }
        public int? BaseSchoolNameId { get; set; }
        public int? BookInformationId { get; set; }
        public int? AuthorityCategoryId { get; set; }
        public string? AuthorName { get; set; }
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }

        public virtual BaseSchoolName? BaseSchoolName { get; set; }
        public virtual BookInformation? BookInformation { get; set; }
        public virtual AuthorityCategory? AuthorityCategory { get; set; }


    }
}
