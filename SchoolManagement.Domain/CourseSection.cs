using SchoolManagement.Domain.Common;

namespace SchoolManagement.Domain
{
    public class CourseSection : BaseDomainEntity
    {
        public int CourseSectionId { get; set; }
        public int? BaseSchoolNameId { get; set; }
        public int? CourseNameId { get; set; }
        public string? SectionName { get; set; }
        public string? SectionShortName { get; set; }
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }

        public virtual BaseSchoolName? BaseSchoolName { get; set; }
        public virtual CourseName? CourseName { get; set; }
    }
}
