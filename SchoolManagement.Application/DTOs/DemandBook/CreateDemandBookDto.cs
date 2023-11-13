using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.DemandBook
{
    public class CreateDemandBookDto : IDemandBookDto  
    {
        public int DemandBookId { get; set; }
        public string? BookName { get; set; }
        public string? AuthorName { get; set; }
        public bool IsActive { get; set; }
    }
}
