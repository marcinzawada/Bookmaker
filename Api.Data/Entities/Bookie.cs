using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Bookie
    {
        [Key]
        public int Id { get; set; }

        public int ExtBookmakerId { get; set; }

        public string Name { get; set; }
    }
}
