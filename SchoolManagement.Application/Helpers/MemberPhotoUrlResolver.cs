using AutoMapper;
using SchoolManagement.Domain;
using Microsoft.Extensions.Configuration;
using SchoolManagement.Application.DTOs.MemberInfo;

namespace SchoolManagement.Application.Helpers
{
    public class MemberPhotoUrlResolver : IValueResolver<MemberInfo, MemberInfoDto, string>
    {
        

        private readonly IConfiguration _config;
        public MemberPhotoUrlResolver(IConfiguration config)
        {
            _config = config;
        }

        public string Resolve(MemberInfo source, MemberInfoDto destination, string destMember, ResolutionContext context)
        {
            if (!string.IsNullOrEmpty(source.ImageUrl))
            {

                return _config["ApiUrl"] + source.ImageUrl;
            }

            return null;
        }
    }
}
