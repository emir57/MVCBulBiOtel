﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OtelProject.Models.Tables
{
    public class LogRecord
    {
        [Key]
        public int LogId { get; set; }
        public string LogAdminUserName { get; set; }
        public DateTime ProcessingDateTime { get; set; }
        public string OperationType { get; set; }
        public string Description { get; set; }
    }
}