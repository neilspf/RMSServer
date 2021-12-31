using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ResourceManager.Entity
{
    public class Request
    {
        [Key]
        public int RequestId { get; set; }
        public int RTypeId { get; set; }
        public int EmpId { get; set; }
        public string Description { get; set; }
        public bool Status { get; set; }
        public int RequestTo { get; set; }
    }
}
