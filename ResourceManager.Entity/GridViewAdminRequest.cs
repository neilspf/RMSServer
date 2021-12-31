using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace ResourceManager.Entity
{
    [Keyless]
    public class GridViewAdminRequest
    {
        public string ResourceTypeName { get; set; }
        public string Description { get; set; }
        public bool Status { get; set; }
        public string RequestedTo { get; set; }
        public string RequestedBy { get; set; }
    }
}
