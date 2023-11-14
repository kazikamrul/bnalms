using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.DamageInformationByLibrary
{
    public class CreateDamageInformationByLibraryDto : IDamageInformationByLibraryDto  
    {
        public int DamageInformationByLibraryId { get; set; }
        public int? BaseSchoolNameId { get; set; }
        public int? BookInformationId { get; set; }
        public string? DamageBy { get; set; }
        public string? Remarks { get; set; }
        public bool IsActive { get; set; }
    }
}
