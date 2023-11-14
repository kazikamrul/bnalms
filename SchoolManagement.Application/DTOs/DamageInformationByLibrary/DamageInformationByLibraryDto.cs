using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.DamageInformationByLibrary
{
    public class DamageInformationByLibraryDto : IDamageInformationByLibraryDto
    {
        public int DamageInformationByLibraryId { get; set; }
        public int? BaseSchoolNameId { get; set; }
        public int? BookInformationId { get; set; }
        public string? DamageBy { get; set; }
        public string? Remarks { get; set; }
        public bool IsActive { get; set; }

        public string? AccessionNo { get; set; }
        public string? BookTitle { get; set; }
    }
}
