using Microsoft.AspNetCore.Http;

namespace SchoolManagement.Application.DTOs.SoftCopyUpload
{
    public class CreateInitializeDto
    {
        

        public IFormFile Doc { get; set; }
        public CreateSoftCopyUploadDto SoftCopyUploadForm { get; set; }
}
}
