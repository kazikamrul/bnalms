using SchoolManagement.Domain.Common;

namespace SchoolManagement.Domain
{
    public class Language : BaseDomainEntity
    {
        public Language()
        {
            BookInformations = new HashSet<BookInformation>();

        }

        public int LanguageId { get; set; }
        public string? LanguageName { get; set; }
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<BookInformation> BookInformations { get; set; }
    }
}
