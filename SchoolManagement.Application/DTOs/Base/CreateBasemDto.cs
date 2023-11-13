using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.Base
{
    public class CreateBasemDto : IBaseDto  
    {
        public int BaseId { get; set; }
        public string? Name { get; set; }
        public bool IsActive { get; set; }
    }
}
