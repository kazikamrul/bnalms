using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.Source
{
    public class CreateSourceDto : ISourceDto  
    {
        public int SourceId { get; set; }
        public string? Name { get; set; }
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }
    }
}
