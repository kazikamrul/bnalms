using System;
using System.Collections.Generic;

namespace SchoolManagement.Api.Models
{
    public partial class SelfControlInfo
    {
        public long SelfControlInfoIdentity { get; set; }
        public decimal ParentCode { get; set; }
        public decimal SelfId { get; set; }
        public string ControlName { get; set; }
        public string Remarks { get; set; }
        public int? ControlLevel { get; set; }
        public int? SortOrder { get; set; }
        public bool IsActive { get; set; }
        public string Level1 { get; set; }
        public string Level2 { get; set; }
        public string Level3 { get; set; }
        public string Level4 { get; set; }
        public string Level5 { get; set; }
        public DateTime? CreateDate { get; set; }
        public string CreateDateId { get; set; }
        public DateTime? LastUpdateDate { get; set; }
        public string LastUpdateId { get; set; }
    }
}
