using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace CarSearch.Model
{
    [Table("Cars")]
    public class Car : Entity
    {
        public string CarName { get; set; }
        public string CarColor { get; set; }

        public string CarEngineCapacity { get; set; }

        public string CarFuelType { get; set; }

        public string CarManFacYear { get; set; }

        public int CarSeating { get; set; }

        [ForeignKey("CarType")]

        public int CarTypeId { get; set; }

        public virtual CarType? CarType { get; set; }


        [ForeignKey("Company")]
        public int CompanyId { get; set; }

        //public string CompanyName { get; set; } = string.Empty;

        public virtual Company? Company { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal CarPriceExShowroom { get; set; }
    }
}
