using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.ReaderInformation 
{
    public interface IReaderInformationDto 
    {
        public int ReaderInformationId { get; set; }
        public int? BaseSchoolNameId { get; set; }
        public int? MemberInfoId { get; set; }
        public string? ReaderName { get; set; }
        public DateTime? InDate { get; set; }
        public DateTime? OutDate { get; set; }
        public bool IsActive { get; set; }
    } 
}
