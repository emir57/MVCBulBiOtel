using System.Collections.Generic;

namespace OtelProject.Models.Tables
{
    public class OtelCountry
    {
        public IEnumerable<Otel> Otels { get; set; }
        public IEnumerable<Country> Countries { get; set; }
    }
}