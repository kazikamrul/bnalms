using SchoolManagement.Domain.Common;

namespace SchoolManagement.Domain
{
    public class LibraryAuthority : BaseDomainEntity
    {
        public LibraryAuthority()
        {
            HelpLines = new HashSet<HelpLine>();

        }

        public int LibraryAuthorityId { get; set; }
        public string? Name { get; set; }
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<HelpLine> HelpLines { get; set; }


    }
}
