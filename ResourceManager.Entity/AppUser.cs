using System;
using System.ComponentModel.DataAnnotations;

namespace ResourceManager.Entity
{
    public class AppUser
    {
        [Key]
        public int EmpId { get; set; }
        public string EmpUserName { get; set; }
        public string EmpName { get; set; }
        public string EmpEmail { get; set; }
        public string Password { get; set; }
        public bool IsAuthorised { get; set; }
        public bool IsAdmin { get; set; }
    }
}
