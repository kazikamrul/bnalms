using System;
using System.Collections.Generic;

namespace SchoolManagement.Api.Models
{
    public partial class Source
    {
        public Source()
        {
            BookInformations = new HashSet<BookInformation>();
        }

        public int SourceId { get; set; }
        public string Name { get; set; }
        public int? MenuPosition { get; set; }
        public string CreatedBy { get; set; }
        public DateTime DateCreated { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<BookInformation> BookInformations { get; set; }
    }
}
