using System.ComponentModel.DataAnnotations;

namespace OtelProject.Models.Tables
{
    public class Country
    {
        [Key]
        public int CountryId { get; set; }
        public string CountryName { get; set; }
    }
}