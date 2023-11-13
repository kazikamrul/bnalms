using System;
using System.Collections.Generic;

namespace SchoolManagement.Api.Models
{
    public partial class LibraryAuthority
    {
        public LibraryAuthority()
        {
            HelpLines = new HashSet<HelpLine>();
        }

        public int LibraryAuthorityId { get; set; }
        public string Name { get; set; }
        public int? MenuPosition { get; set; }
        public string CreatedBy { get; set; }
        public DateTime DateCreated { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<HelpLine> HelpLines { get; set; }
    }
}
