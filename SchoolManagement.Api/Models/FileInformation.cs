using System;
using System.Collections.Generic;

namespace SchoolManagement.Api.Models
{
    public partial class FileInformation
    {
        public int FileInformationId { get; set; }
        public int? BaseSchoolNameId { get; set; }
        public string BooksTitle { get; set; }
        public string Author { get; set; }
        public string CorporateAuthor { get; set; }
        public string Editor { get; set; }
        public string BooksUrl { get; set; }
        public string Remarks { get; set; }
        public string CreatedBy { get; set; }
        public DateTime DateCreated { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public bool IsActive { get; set; }

        public virtual BaseSchoolName BaseSchoolName { get; set; }
    }
}
