using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OtelProject.Models.Tables
{
    public class OtelUser:IUser
    {
        [Key]
        public int OtelUserId { get; set; }
        public string OtelUserName { get; set; }
        public string OtelName { get; set; }
        public string OtelPassword { get; set; }
        public string OtelMail { get; set; }
        public int OtelStatus { get; set; }
        public int OtelId { get; set; }
        public string Permission { get ; set ; }
    }
}