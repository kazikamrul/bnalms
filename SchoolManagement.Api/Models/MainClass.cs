using System;
using System.Collections.Generic;

namespace SchoolManagement.Api.Models
{
    public partial class MainClass
    {
        public MainClass()
        {
            BookInformations = new HashSet<BookInformation>();
        }

        public int MainClassId { get; set; }
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
