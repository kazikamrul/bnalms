using SchoolManagement.Domain.Common;

namespace SchoolManagement.Domain
{
    public class DamageInformationByLibrary : BaseDomainEntity
    {
        public DamageInformationByLibrary()
        {
            

        }

        public int DamageInformationByLibraryId { get; set; }
        public int? BaseSchoolNameId { get; set; }
        public int? BookInformationId { get; set; }
        public string? DamageBy { get; set; }
        public string? Remarks { get; set; }
        public bool IsActive { get; set; }

        public virtual BaseSchoolName? BaseSchoolName { get; set; }
        public virtual BookInformation? BookInformation { get; set; }


    }
}
