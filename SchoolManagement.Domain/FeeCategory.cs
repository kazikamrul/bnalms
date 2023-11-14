using SchoolManagement.Domain.Common;

namespace SchoolManagement.Domain
{
    public class FeeCategory : BaseDomainEntity
    {
        public FeeCategory()
        {
            FeeInformations = new HashSet<FeeInformation>();

        }

        public int FeeCategoryId { get; set; }
        public string? FeeCategoryName { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<FeeInformation> FeeInformations { get; set; }
    }
}
