using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ResourceManager.Entity
{
    public class Resource
    {
        [Key]
        public int ResourceId { get; set; }
        public int RTypeId { get; set; }
        public string ResourceName { get; set; }
        public string MacId { get; set; }
        public string SerialId { get; set; }
        public string WarrantyValidUpTo { get; set; }
        public string PurchaseDate { get; set; }
        public string Vendor { get; set; }
        public bool IsAssigned { get; set; }
        public int AssignedTo { get; set; }
    }
}
