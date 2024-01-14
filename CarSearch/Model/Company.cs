using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CarSearch.Model
{
    [Table("Companies")]
    public class Company
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int CompanyId { get; set; }

        public string CompanyName { get; set; } = string.Empty;

        public string CarModel { get; set; } = string.Empty;

        public bool IsActive { get; set; } = true;

    }
}
