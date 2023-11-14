using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.InventoryTypes
{
    public class CreateInventoryTypeDto : IInventoryTypeDto  
    {
        public int InventoryTypeId { get; set; }
        public string Name { get; set; }
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }
    }
}
