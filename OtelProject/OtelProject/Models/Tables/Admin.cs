using System.ComponentModel.DataAnnotations;

namespace OtelProject.Models.Tables
{
    public class Admin : IUser
    {
        [Key]
        public byte AdminId { get; set; }
        public string AdminUserName { get; set; }
        public string AdminPassword { get; set; }
        public string Permission { get; set ; }
    }
}