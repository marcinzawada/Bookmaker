﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Data.Models
{
    public class Season
    {
        [Key]
        public int Id { get; set; }

        public int Year { get; set; }

        public List<League> Leagues { get; set; }
    }
}
