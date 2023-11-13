using SchoolManagement.Domain.Common;

namespace SchoolManagement.Domain
{
    public class RowInfo : BaseDomainEntity
    {
        public RowInfo()
        {

            BookInformations = new HashSet<BookInformation>();
            BookIssueAndSubmissions = new HashSet<BookIssueAndSubmission>();
        }

        public int RowInfoId { get; set; }
        public int? ShelfInfoId { get; set; }
        public string? RowName { get; set; }
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }

        public virtual ShelfInfo? ShelfInfo { get; set; }

        public virtual ICollection<BookInformation>? BookInformations { get; set; }
        public virtual ICollection<BookIssueAndSubmission>? BookIssueAndSubmissions { get; set; }

    }
}
