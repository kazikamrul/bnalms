using SchoolManagement.Domain.Common;
using System;
using System.Collections.Generic;

namespace SchoolManagement.Domain
{
    public class InventoryType:BaseDomainEntity
    {
        public InventoryType()
        {
            Inventories = new HashSet<Inventory>();
        }

        public int InventoryTypeId { get; set; }
        public string Name { get; set; }
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<Inventory> Inventories { get; set; }
    }
}
