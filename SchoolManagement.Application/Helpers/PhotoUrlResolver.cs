using AutoMapper;
using SchoolManagement.Domain;
using Microsoft.Extensions.Configuration;
using SchoolManagement.Application.DTOs.BookInformation;

namespace SchoolManagement.Application.Helpers
{
    public class PhotoUrlResolver : IValueResolver<BookInformation, BookInformationDto, string>
    {
        

        private readonly IConfiguration _config;
        public PhotoUrlResolver(IConfiguration config)
        {
            _config = config;
        }

        public string Resolve(BookInformation source, BookInformationDto destination, string destMember, ResolutionContext context)
        {
            if (!string.IsNullOrEmpty(source.CoverImage))
            {

                return _config["ApiUrl"] + source.CoverImage;
            }

            return null;
        }
    }
}
