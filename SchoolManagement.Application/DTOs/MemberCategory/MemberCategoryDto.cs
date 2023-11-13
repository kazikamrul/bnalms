namespace SchoolManagement.Application.DTOs.MemberCategory
{
    public class MemberCategoryDto : IMemberCategoryDto
    {
        public int MemberCategoryId { get; set; }
        public string? MemberCategoryName { get; set; }
        public bool IsActive { get; set; }
    }
}
