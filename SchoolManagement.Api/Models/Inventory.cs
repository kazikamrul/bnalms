using System;
using System.Collections.Generic;

namespace SchoolManagement.Api.Models
{
    public partial class Inventory
    {
        public int InventoryId { get; set; }
        public int InventoryTypeId { get; set; }
        public int BaseSchoolNameId { get; set; }
        public string IdentityNo { get; set; }
        public string Location { get; set; }
        public string Remarks { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public DateTime? PurchaseDate { get; set; }
        public string CompanyName { get; set; }
        public string ContractNumber { get; set; }
        public double? Price { get; set; }
        public int? DamageStatus { get; set; }
        public DateTime? DamageDate { get; set; }
        public string DamageReason { get; set; }
        public int? MenuPosition { get; set; }
        public string CreatedBy { get; set; }
        public DateTime DateCreated { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public bool IsActive { get; set; }

        public virtual BaseSchoolName BaseSchoolName { get; set; }
        public virtual InventoryType InventoryType { get; set; }
    }
}
