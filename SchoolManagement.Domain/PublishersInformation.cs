using SchoolManagement.Domain.Common;

namespace SchoolManagement.Domain
{
    public class PublishersInformation : BaseDomainEntity
    {
        public PublishersInformation()
        {
            

        }

        public int PublishersInformationId { get; set; }
        public int? BaseSchoolNameId { get; set; }
        public int? BookInformationId { get; set; }
        public string? PublishersName { get; set; }
        public string? PublishersAddress { get; set; }
        public string? PublisherDate { get; set; }
        public string? PublisherPlace { get; set; }
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }

        public virtual BaseSchoolName? BaseSchoolName { get; set; }
        public virtual BookInformation? BookInformation { get; set; }


    }
}
