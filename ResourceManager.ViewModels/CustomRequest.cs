using System;

namespace ResourceManager.ViewModels
{
    public class CustomRequest
    {
        public int RequestId { get; set; }
        public int RTypeId { get; set; }
        public string EmpEmail { get; set; }
        public string Description { get; set; }
        public bool Status { get; set; }
        public int RequestTo { get; set; }
    }
}
