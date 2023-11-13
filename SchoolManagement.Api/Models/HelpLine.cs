using System;
using System.Collections.Generic;

namespace SchoolManagement.Api.Models
{
    public partial class HelpLine
    {
        public int HelpLineId { get; set; }
        public int? BaseSchoolNameId { get; set; }
        public int? LibraryAuthorityId { get; set; }
        public string HelpContact { get; set; }
        public string EmailAddress { get; set; }
        public int? MenuPosition { get; set; }
        public bool? DashboardDisplayStatus { get; set; }
        public string CreatedBy { get; set; }
        public DateTime DateCreated { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public bool IsActive { get; set; }

        public virtual BaseSchoolName BaseSchoolName { get; set; }
        public virtual LibraryAuthority LibraryAuthority { get; set; }
    }
}
