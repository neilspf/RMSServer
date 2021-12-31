using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ResourceManager.Entity
{
    [Keyless]
    public class CalculateResource
    {
        public int Total { get; set; }
        public int assigned { get; set; }
    }
}
