using SchoolManagement.Domain.Common;

namespace SchoolManagement.Domain
{
    public class VideoFile : BaseDomainEntity
    {
        public int VideoFileId { get; set; } 
        public string? DocumentName { get; set; }
        public string? DocumentLink { get; set; }
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }
    }
}
