using SchoolManagement.Domain.Common;

namespace SchoolManagement.Domain
{
    public class Bulletin : BaseDomainEntity
    {
        public Bulletin()
        {
           

        }

        public int BulletinId { get; set; }
        public int? BaseSchoolNameId { get; set; }
        public string? BuletinDetails { get; set; }
        public string? Status { get; set; }
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; } 
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public virtual BaseSchoolName? BaseSchoolName { get; set; }
    }
}
