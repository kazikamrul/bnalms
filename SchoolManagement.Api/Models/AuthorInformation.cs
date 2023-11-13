using System;
using System.Collections.Generic;

namespace SchoolManagement.Api.Models
{
    public partial class AuthorInformation
    {
        public int AuthorInformationId { get; set; }
        public int? BaseSchoolNameId { get; set; }
        public int? BookInformationId { get; set; }
        public string AuthorName { get; set; }
        public int? AuthorityCategoryId { get; set; }
        public int? MenuPosition { get; set; }
        public string CreatedBy { get; set; }
        public DateTime DateCreated { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public bool IsActive { get; set; }

        public virtual AuthorityCategory AuthorityCategory { get; set; }
        public virtual BaseSchoolName BaseSchoolName { get; set; }
        public virtual BookInformation BookInformation { get; set; }
    }
}
