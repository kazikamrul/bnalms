using Microsoft.AspNetCore.Http;

namespace SchoolManagement.Application.DTOs.NoticeInfo
{
    public class CreateInitializeDto
    {
        

        public IFormFile Doc { get; set; }
        public CreateNoticeInfoDto NoticeInfoForm { get; set; }
}
}
