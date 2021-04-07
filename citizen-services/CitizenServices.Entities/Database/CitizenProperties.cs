using System.ComponentModel.DataAnnotations;

namespace CitizenServices.Entities.Database
{
    public class CitizenProperties
    {
        [Key]
        public int CitizenPropertyId { get; set; }
        public double MarketValue { get; set; }

        public int CitizenPropertyTypeId { get; set; }
        public virtual CitizenPropertyTypes CitizenPropertyType { get; set; }
    }
}