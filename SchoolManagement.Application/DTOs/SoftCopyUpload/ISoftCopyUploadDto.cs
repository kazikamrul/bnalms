using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.SoftCopyUpload 
{
    public interface ISoftCopyUploadDto 
    {
        public int SoftCopyUploadId { get; set; }
        public int? BaseSchoolNameId { get; set; }
        public int? DocumentTypeId { get; set; }
        public string? TitleName { get; set; }
        public string? AuthorName { get; set; }
        public string? CorporateAuthor { get; set; }
        public string? Editor { get; set; }
        public string? StorePDFFile { get; set; }
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }
    } 
}
