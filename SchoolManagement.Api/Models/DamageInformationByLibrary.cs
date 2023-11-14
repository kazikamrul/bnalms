using System;
using System.Collections.Generic;

namespace SchoolManagement.Api.Models
{
    public partial class DamageInformationByLibrary
    {
        public int DamageInformationByLibraryId { get; set; }
        public int? BaseSchoolNameId { get; set; }
        public int? BookInformationId { get; set; }
        public string DamageBy { get; set; }
        public string Remarks { get; set; }
        public string CreatedBy { get; set; }
        public DateTime DateCreated { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public bool IsActive { get; set; }

        public virtual BaseSchoolName BaseSchoolName { get; set; }
        public virtual BookInformation BookInformation { get; set; }
    }
}
