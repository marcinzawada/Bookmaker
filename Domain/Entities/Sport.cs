using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Sport
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(64)]
        public string Name { get; set; }
    }
}
