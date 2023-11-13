using Microsoft.AspNetCore.Http;

namespace SchoolManagement.Application.DTOs.VideoFile
{
    public class CreateVideoFileDto : IVideoFileDto
    {
        public int VideoFileId { get; set; }
        public string? DocumentName { get; set; }
        public string? DocumentLink { get; set; }
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }

        public IFormFile? Doc { get; set; }
    }
}
