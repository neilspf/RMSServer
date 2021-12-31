using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace ResourceManager.Entity
{
    [Keyless]
    public class GridViewUserRequest
    {
        public string ResourceTypeName { get; set; }
        public string Description { get; set; }
        public bool Status { get; set; }
        public string RequestedTo { get; set; }
    }
}
