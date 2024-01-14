using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CarSearch.Model
{
    [Table("CarTypes")]
    public class CarType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int CarTypeId { get; set; }

        public string CarTypeName { get; set; } = string.Empty;

        public string CarTypeCode { get; set; } = string.Empty;

        public bool IsActive { get; set; } = true;
    }
}
