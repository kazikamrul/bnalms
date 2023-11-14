using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.InformationFezup 
{
    public interface IInformationFezupDto 
    {
        public int InformationFezupId { get; set; }
        public int? BaseSchoolNameId { get; set; }
        public string? Category { get; set; }
        public string? PONo { get; set; }
        public string? MemberName { get; set; }
        public string? FatherName { get; set; }
        public string? MotherName { get; set; }
        public string? Email { get; set; }
        public string? PresentAddress { get; set; }
        public string? PermanentAddress { get; set; }
        public string? NationalId { get; set; }
        public string? Sex { get; set; }
        public string? Designation { get; set; }
        public string? Department { get; set; }
        public string? JobStatus { get; set; }
        public int? MobileNo { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public bool IsActive { get; set; }
    } 
}
