using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.MainClass
{
    public class MainClassDto : IMainClassDto
    {
        public int MainClassId { get; set; }
        public string? Name { get; set; }
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }
    }
}
