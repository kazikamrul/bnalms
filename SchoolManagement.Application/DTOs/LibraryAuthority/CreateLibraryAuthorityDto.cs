using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.LibraryAuthority
{
    public class CreateLibraryAuthorityDto : ILibraryAuthorityDto  
    {
        public int LibraryAuthorityId { get; set; }
        public string? Name { get; set; }
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }
    }
}
