using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.PublishersInformation
{
    public class CreatePublishersInformationDto : IPublishersInformationDto  
    {
        public int PublishersInformationId { get; set; }
        public int? BaseSchoolNameId { get; set; }
        public int? BookInformationId { get; set; }
        public string? PublishersName { get; set; }
        public string? PublishersAddress { get; set; }
        public string? PublisherDate { get; set; }
        public string? PublisherPlace { get; set; }
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }
    }
}
