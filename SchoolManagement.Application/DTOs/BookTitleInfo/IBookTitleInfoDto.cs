using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.BookTitleInfo 
{
    public interface IBookTitleInfoDto 
    {
        public int BookTitleInfoId { get; set; }
        public string? BookTitleName { get; set; }
        public int? BaseSchoolNameId { get; set; }
        public string? TitleBangla { get; set; }
        public string? BookSubtitle { get; set; }
        public string? Remarks { get; set; }
        public DateTime? CreateDate { get; set; }
        public string? CreateUserId { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string? UpdateUserId { get; set; }
        public bool IsActive { get; set; }
    } 
}
