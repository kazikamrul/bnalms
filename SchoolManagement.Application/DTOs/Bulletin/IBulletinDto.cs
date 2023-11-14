using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.Bulletin 
{
    public interface IBulletinDto 
    {
        public int BulletinId { get; set; }
        public int? BaseSchoolNameId { get; set; }
        public string? BuletinDetails { get; set; }
        public string? Status { get; set; }
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string? BaseSchoolName { get; set; }
    } 
}
