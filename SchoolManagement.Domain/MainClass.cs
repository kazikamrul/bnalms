using SchoolManagement.Domain.Common;

namespace SchoolManagement.Domain
{
    public class MainClass : BaseDomainEntity
    {
        public MainClass()
        {
            BookInformations = new HashSet<BookInformation>();

        }

        public int MainClassId { get; set; }
        public string? Name { get; set; }
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<BookInformation> BookInformations { get; set; }


    }
}
