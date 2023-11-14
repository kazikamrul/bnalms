using AutoMapper;
using SchoolManagement.Domain;
using SchoolManagement.Application.DTOs.SoftCopyUpload;
using Microsoft.Extensions.Configuration;

namespace SchoolManagement.Application.Helpers
{
    public class SoftCopyUploadFileUrlResolver : IValueResolver<SoftCopyUpload, SoftCopyUploadDto, string>
    {
        

        private readonly IConfiguration _config;
        public SoftCopyUploadFileUrlResolver(IConfiguration config)
        {
            _config = config;
        }

        public string Resolve(SoftCopyUpload source, SoftCopyUploadDto destination, string destMember, ResolutionContext context)
        {
            if (!string.IsNullOrEmpty(source.StorePDFFile))
            {

                return _config["ApiUrl"] + source.StorePDFFile;
            }

            return null;
        }
    }
}
