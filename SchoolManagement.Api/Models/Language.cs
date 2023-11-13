using System;
using System.Collections.Generic;

namespace SchoolManagement.Api.Models
{
    public partial class Language
    {
        public Language()
        {
            BookInformations = new HashSet<BookInformation>();
        }

        public int LanguageId { get; set; }
        public string LanguageName { get; set; }
        public int? MenuPosition { get; set; }
        public string CreatedBy { get; set; }
        public DateTime DateCreated { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<BookInformation> BookInformations { get; set; }
    }
}
