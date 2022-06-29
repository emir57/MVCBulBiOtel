using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OtelProject.Models.Tables
{
    public class OtelCountry
    {
        public IEnumerable<Otel> Otels { get; set; }
        public IEnumerable<Country> Countries { get; set; }
    }
}