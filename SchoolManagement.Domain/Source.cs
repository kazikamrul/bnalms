using SchoolManagement.Domain.Common;

namespace SchoolManagement.Domain
{
    public class Source : BaseDomainEntity
    {
        public Source()
        {

            BookInformations = new HashSet<BookInformation>();
        }

        public int SourceId { get; set; }
        public string? Name { get; set; }
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<BookInformation> BookInformations { get; set; }
    }
}
