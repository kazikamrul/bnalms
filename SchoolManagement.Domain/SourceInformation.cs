using SchoolManagement.Domain.Common;

namespace SchoolManagement.Domain
{
    public class SourceInformation : BaseDomainEntity
    {
        public SourceInformation()
        {
           

        }

        public int SourceInformationId { get; set; }
        public int? BaseSchoolNameId { get; set; }
        public int? BookInformationId { get; set; }
        public string? SourceName { get; set; }
        public string? Address { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public DateTime? OrderDate { get; set; }
        public DateTime? ReceivedDate { get; set; }
        public string? Remarks { get; set; }
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }

        public virtual BaseSchoolName? BaseSchoolName { get; set; }
        public virtual BookInformation? BookInformation { get; set; }


    }
}
