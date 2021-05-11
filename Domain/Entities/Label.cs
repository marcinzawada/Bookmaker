using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Label
    {
        [Key]
        public int Id { get; set; }

        public int ExtLabelId { get; set; }

        public string Name { get; set; }
    }
}
