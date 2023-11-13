using Microsoft.AspNetCore.Http;

namespace SchoolManagement.Application.DTOs.VideoFile
{
    public class CreateVideoDto
    {
        public IFormFile Doc { get; set; }
        public CreateVideoFileDto VideoFileForm { get; set; }
}
}
