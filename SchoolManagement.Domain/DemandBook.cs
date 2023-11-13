using SchoolManagement.Domain.Common;

namespace SchoolManagement.Domain
{
    public class DemandBook : BaseDomainEntity
    {
        public DemandBook()
        {
            

        }

        public int DemandBookId { get; set; }
        public string? BookName { get; set; }
        public string? AuthorName { get; set; }
        public bool IsActive { get; set; }

        
    }
}
