using Microsoft.AspNetCore.Http;

namespace SchoolManagement.Application.DTOs.MemberInfo
{
    public class CreateMemberDto
    {
        

        public IFormFile Photo { get; set; }
        public CreateMemberInfoDto MemberInfoForm { get; set; }
}
}
