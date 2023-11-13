using AutoMapper;
using SchoolManagement.Domain;
using SchoolManagement.Application.DTOs.VideoFile;
using Microsoft.Extensions.Configuration;

namespace SchoolManagement.Application.Helpers
{
    public class FileUrlResolver : IValueResolver<VideoFile, VideoFileDto, string>
    {
        //private readonly IConfiguration _config;
        //public FileUrlResolver(IConfiguration config)
        //{
        //    _config = config;
        //}

        private readonly IConfiguration _config;
        public FileUrlResolver(IConfiguration config)
        {
            _config = config;
        }

        public string Resolve(VideoFile source, VideoFileDto destination, string destMember, ResolutionContext context)
        {
            if (!string.IsNullOrEmpty(source.DocumentLink))
            {

                return _config["ApiUrl"] + source.DocumentLink;
            }

            return null;
        }
    }
}
