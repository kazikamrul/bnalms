using System;
using System.Collections.Generic;

namespace SchoolManagement.Api.Models
{
    public partial class MemberRegistration
    {
        public int MemberRegistrationId { get; set; }
        public int? BookInformationId { get; set; }
        public int? BaseSchoolNameId { get; set; }
        public int? MemberCategoryId { get; set; }
        public int? RankId { get; set; }
        public int? DesignationId { get; set; }
        public int? JobStatusId { get; set; }
        public int? AreaId { get; set; }
        public int? BaseId { get; set; }
        public int? SecurityQuestionId { get; set; }
        public string Answer { get; set; }
        public int? MemberInfoIdentity { get; set; }
        public string Email { get; set; }
        public string ImageUrl { get; set; }
        public string Region { get; set; }
        public string Director { get; set; }
        public string MemberName { get; set; }
        public string FatherName { get; set; }
        public string MotherName { get; set; }
        public string YearlyFee { get; set; }
        public string PresentAddress { get; set; }
        public string PermanentAddress { get; set; }
        public string Nid { get; set; }
        public string Sex { get; set; }
        public DateTime? IssueDate { get; set; }
        public DateTime? ExpireDate { get; set; }
        public DateTime? Dob { get; set; }
        public string Pno { get; set; }
        public string Department { get; set; }
        public string Tntoffice { get; set; }
        public string MobileNoOffice { get; set; }
        public string FamilyContact { get; set; }
        public string MobileNoPersonal { get; set; }
        public int? EmpStatus { get; set; }
        public int? MenuPosition { get; set; }
        public string CreatedBy { get; set; }
        public DateTime DateCreated { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public bool IsActive { get; set; }
        public int? IssueQty { get; set; }
        public DateTime? LastPaymentDate { get; set; }

        public virtual Area Area { get; set; }
        public virtual Base Base { get; set; }
        public virtual BaseSchoolName BaseSchoolName { get; set; }
        public virtual BookInformation BookInformation { get; set; }
        public virtual Designation Designation { get; set; }
        public virtual JobStatus JobStatus { get; set; }
        public virtual MemberCategory MemberCategory { get; set; }
        public virtual Rank Rank { get; set; }
        public virtual SecurityQuestion SecurityQuestion { get; set; }
    }
}
