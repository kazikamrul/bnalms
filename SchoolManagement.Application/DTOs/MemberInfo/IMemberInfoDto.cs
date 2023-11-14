using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.MemberInfo 
{
    public interface IMemberInfoDto 
    {
        public int MemberInfoId { get; set; }
        public int? BookInformationId { get; set; }
        public int? BaseSchoolNameId { get; set; }
        public int? MemberCategoryId { get; set; }
        public int? RankId { get; set; }
        public int? DesignationId { get; set; }
        public int? JobStatusId { get; set; }
        public int? AreaId { get; set; }
        public int? BaseId { get; set; }
        public int? SecurityQuestionId { get; set; }
        public string? Answer { get; set; }
        public int? MemberInfoIdentity { get; set; }
        public string? Email { get; set; }
        public string? ImageUrl { get; set; }
        public string? Region { get; set; }
        public string? Director { get; set; }
        public string? MemberName { get; set; }
        public DateTime? MemberShipDate { get; set; }
        public DateTime? MemberExpireDate { get; set; }
        public int? MemberShipNumber { get; set; }
        public string? FatherName { get; set; }
        public string? MotherName { get; set; }
        public string? YearlyFee { get; set; }
        public string? PresentAddress { get; set; }
        public string? PermanentAddress { get; set; }
        public string? NID { get; set; }
        public string? Sex { get; set; }
        public DateTime? IssueDate { get; set; }
        public DateTime? ExpireDate { get; set; }
        public DateTime? DOB { get; set; }
        public string? PNO { get; set; }
        public string? Department { get; set; }
        public string? TNTOffice { get; set; }
        public string? MobileNoOffice { get; set; }
        public string? FamilyContact { get; set; }
        public string? MobileNoPersonal { get; set; }
        public int? EmpStatus { get; set; }
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }
        public int? IssueQty { get; set; }
        public DateTime? LastPaymentDate { get; set; }
    } 
}
