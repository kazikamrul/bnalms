using AutoMapper;
using SchoolManagement.Domain;
using SchoolManagement.Application.DTOs.NoticeInfo;
using Microsoft.Extensions.Configuration;

namespace SchoolManagement.Application.Helpers
{
    public class NoticeInfoFileUrlResolver : IValueResolver<NoticeInfo, NoticeInfoDto, string>
    {

        private readonly IConfiguration _config;
        public NoticeInfoFileUrlResolver(IConfiguration config)
        {
            _config = config;
        }

        public string Resolve(NoticeInfo source, NoticeInfoDto destination, string destMember, ResolutionContext context)
        {
            if (!string.IsNullOrEmpty(source.UploadPDFFile))
            {

                return _config["ApiUrl"] + source.UploadPDFFile;
            }

            return null;
        }
    }
}
