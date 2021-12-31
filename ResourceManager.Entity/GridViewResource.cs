using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace ResourceManager.Entity
{
    [Keyless]
    public class GridViewResource
    {
        public string ResourceTypeName { get; set; }
        public string ResourceName { get; set; }
        public string MacId { get; set; }
        public string SerialId { get; set; }
        public string WarrantyValidUpTo { get; set; }
        public string PurchaseDate { get; set; }
        public string Vendor { get; set; }
    }
}
