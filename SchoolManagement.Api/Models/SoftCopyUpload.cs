using System;
using System.Collections.Generic;

namespace SchoolManagement.Api.Models
{
    public partial class SoftCopyUpload
    {
        public int SoftCopyUploadId { get; set; }
        public int? BaseSchoolNameId { get; set; }
        public int? DocumentTypeId { get; set; }
        public string TitleName { get; set; }
        public string AuthorName { get; set; }
        public string CorporateAuthor { get; set; }
        public string Editor { get; set; }
        public string StorePdffile { get; set; }
        public int? MenuPosition { get; set; }
        public string CreatedBy { get; set; }
        public DateTime DateCreated { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public bool IsActive { get; set; }

        public virtual BaseSchoolName BaseSchoolName { get; set; }
        public virtual DocumentType DocumentType { get; set; }
    }
}
