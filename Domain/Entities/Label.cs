using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Label
    {
        [Key]
        public int Id { get; set; }

        public int ExtLabelId { get; set; }

        [MaxLength(128)]
        public string Name { get; set; }
    }
}
