using System;
using System.Collections.Generic;

namespace SchoolManagement.Api.Models
{
    public partial class BookCategory
    {
        public BookCategory()
        {
            BookInformations = new HashSet<BookInformation>();
        }

        public int BookCategoryId { get; set; }
        public string BookCategoryName { get; set; }
        public int? MenuPosition { get; set; }
        public string CreatedBy { get; set; }
        public DateTime DateCreated { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<BookInformation> BookInformations { get; set; }
    }
}
