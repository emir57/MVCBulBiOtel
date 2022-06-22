﻿using OtelProject.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtelProject.Models
{
    public class OtelUserEditViewModel
    {
        public List<Country> Countries { get; set; }
        public Otel Otel { get; set; }
    }
}
