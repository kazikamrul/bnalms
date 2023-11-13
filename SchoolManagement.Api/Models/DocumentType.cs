using System;
using System.Collections.Generic;

namespace SchoolManagement.Api.Models
{
    public partial class DocumentType
    {
        public DocumentType()
        {
            SoftCopyUploads = new HashSet<SoftCopyUpload>();
        }

        public int DocumentTypeId { get; set; }
        public string DocumentTypeName { get; set; }
        public string IconName { get; set; }
        public int? MenuPosition { get; set; }
        public string CreatedBy { get; set; }
        public DateTime DateCreated { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<SoftCopyUpload> SoftCopyUploads { get; set; }
    }
}
