using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ResourceManager.Entity
{
    public class RType
    {
        [Key]
        public int RTypeId { get; set; }
        public string RTypeName { get; set; }
    }
}
