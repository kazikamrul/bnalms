using SchoolManagement.Domain;
using SchoolManagement.Domain.Common;
using System;
using System.Collections.Generic;

namespace SchoolManagement.Domain
{
    public class DocumentType:BaseDomainEntity
    {
        public DocumentType()
        {
            SoftCopyUploads = new HashSet<SoftCopyUpload>();
        }

        public int DocumentTypeId { get; set; }
        public string? DocumentTypeName { get; set; }
        public string? IconName { get; set; }
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<SoftCopyUpload> SoftCopyUploads { get; set; }
    }
}
