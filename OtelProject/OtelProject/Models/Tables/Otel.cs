using System.ComponentModel.DataAnnotations;

namespace OtelProject.Models.Tables
{
    public class Otel
    {
        [Key]
        public int OtelsId { get; set; }
        public string OtelName { get; set; }
        public string OtelLocation { get; set; }
        public decimal OtelPrice { get; set; }
        public string OtelDescription { get; set; }
        public byte OtelStars { get; set; }
        public double OtelRating { get; set; }
        public int OtelCountry { get; set; }
        public string OtelPicture { get; set; }
    }
}