using System.ComponentModel.DataAnnotations;

namespace CarSearch.Model
{
    public class Entity
    {
        [Key]
        public Guid Id { get; set; }
    }
}
