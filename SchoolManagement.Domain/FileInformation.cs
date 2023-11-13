using SchoolManagement.Domain.Common;

namespace SchoolManagement.Domain
{
    public class FileInformation : BaseDomainEntity
    {
        public int FileInformationId { get; set; }
        public int? BaseSchoolNameId { get; set; }
        public string? BooksTitle { get; set; }
        public string? Author { get; set; }
        public string? CorporateAuthor { get; set; }
        public string? Editor { get; set; }
        public string? BooksUrl { get; set; }
        public string? Remarks { get; set; }
        public bool IsActive { get; set; }

        public virtual BaseSchoolName? BaseSchoolName { get; set; }
        


    }
}
