using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.Base 
{
    public interface IBaseDto 
    {
        public int BaseId { get; set; }
        public string? Name { get; set; }
        public bool IsActive { get; set; }
    } 
}
