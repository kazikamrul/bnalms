using Microsoft.AspNetCore.Http;

namespace SchoolManagement.Application.DTOs.BookInformation
{
    public class CreateBookInfoDto
    {
        public IFormFile Photo { get; set; }
        public CreateBookInformationDto BookInformationForm { get; set; }
}
}
