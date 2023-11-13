using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.Language
{
    public class CreateLanguageDto : ILanguageDto  
    {
        public int LanguageId { get; set; }
        public string? LanguageName { get; set; }
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }
    }
}
