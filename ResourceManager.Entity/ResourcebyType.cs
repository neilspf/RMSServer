using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ResourceManager.Entity
{
    [Keyless]
    public class ResourcebyType
    {
        public String RTypeName { get; set; }
        public int resourceCount { get; set; }
    }
}
