using SchoolManagement.Domain.Common;

namespace SchoolManagement.Domain
{
    public class BookCategory : BaseDomainEntity
    {
        public BookCategory()
        {
            BookInformations = new HashSet<BookInformation>();

        }

        public int BookCategoryId { get; set; }
        public string? BookCategoryName { get; set; }
        public int? MenuPosition { get; set; }
        public string? Remarks { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<BookInformation> BookInformations { get; set; }


    }
}
