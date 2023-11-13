using System;
using System.Collections.Generic;

namespace SchoolManagement.Api.Models
{
    public partial class InventoryType
    {
        public InventoryType()
        {
            Inventories = new HashSet<Inventory>();
        }

        public int InventoryTypeId { get; set; }
        public string Name { get; set; }
        public int? MenuPosition { get; set; }
        public string CreatedBy { get; set; }
        public DateTime DateCreated { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<Inventory> Inventories { get; set; }
    }
}
