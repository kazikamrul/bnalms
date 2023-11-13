using SchoolManagement.Domain.Common;

namespace SchoolManagement.Domain
{
    public class ShelfInfo : BaseDomainEntity
    {
        public ShelfInfo()
        {
            BookInformations = new HashSet<BookInformation>();
            RowInfos = new HashSet<RowInfo>();
            BookIssueAndSubmissions = new HashSet<BookIssueAndSubmission>();
        }

        public int ShelfInfoId { get; set; }
        public string? ShelfName { get; set; }
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<BookInformation>? BookInformations { get; set; }
        public virtual ICollection<RowInfo>? RowInfos { get; set; }
        public virtual ICollection<BookIssueAndSubmission>? BookIssueAndSubmissions { get; set; }
    }
}
