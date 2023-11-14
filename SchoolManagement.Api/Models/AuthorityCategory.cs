using System;
using System.Collections.Generic;

namespace SchoolManagement.Api.Models
{
    public partial class AuthorityCategory
    {
        public AuthorityCategory()
        {
            AuthorInformations = new HashSet<AuthorInformation>();
        }

        public int AuthorityCategoryId { get; set; }
        public string AuthorCategoryName { get; set; }
        public int? MenuPosition { get; set; }
        public string CreatedBy { get; set; }
        public DateTime DateCreated { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<AuthorInformation> AuthorInformations { get; set; }
    }
}
