using SchoolManagement.Domain.Common;

namespace SchoolManagement.Domain
{
    public class AuthorityCategory : BaseDomainEntity
    {
        public AuthorityCategory()
        {

            AuthorInformations = new HashSet<AuthorInformation>();
        }

        public int AuthorityCategoryId { get; set; }
        public string? AuthorCategoryName { get; set; }
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<AuthorInformation> AuthorInformations { get; set; }
    }
}
