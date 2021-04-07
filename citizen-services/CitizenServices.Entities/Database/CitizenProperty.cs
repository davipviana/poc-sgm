using System.ComponentModel.DataAnnotations;

namespace CitizenServices.Entities.Database
{
    public class CitizenProperty
    {
        [Key]
        public int CitizenPropertyId { get; set; }
        public double MarketValue { get; set; }
        public double? TaxValue { get; set; }

        [StringLength(50)]
        public string CitizenId { get; set; }
    }
}