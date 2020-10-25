using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Api.Data.Models
{
    public class Label
    {
        [Key]
        public int Id { get; set; }

        public int ExtLabelId { get; set; }

        public string Name { get; set; }
    }
}
