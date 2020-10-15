using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Bookmaker.Models
{
    public class Country
    {
        [Key]
        public int Id { get; set; }

        public int Name { get; set; }

        public string Code { get; set; }

        public string Flag { get; set; }
    }
}
