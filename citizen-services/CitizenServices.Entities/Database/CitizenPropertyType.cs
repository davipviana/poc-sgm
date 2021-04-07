using System.ComponentModel.DataAnnotations;

namespace CitizenServices.Entities.Database
{
    public class CitizenPropertyType
    {
        [Key]
        public int CitizenPropertyTypeId { get; set; }

        [StringLength(50)]
        public string Description { get; set; }
    }
}