using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

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