using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Inventory.Entities
{
    public class InventoryItems
    {
        [Key]
        public int IdItem { get; set; }
        public string Name { get; set; }
        public decimal Amount { get; set; }
        public string InventoryCode { get; set; }
    }
}
