﻿using System.ComponentModel.DataAnnotations;

namespace BasicWebApiNikolaDimeski.Models
{
    public class Country
    {
        [Required]
        public int CountryId { get; set; }
        [Required]
        public int CompanyName { get; set; }
    }
}
