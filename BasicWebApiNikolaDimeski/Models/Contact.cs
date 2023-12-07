using System.ComponentModel.DataAnnotations;

namespace BasicWebApiNikolaDimeski.Models
{
    public class Contact
    {
        [Required]
        public int ContactId { get; set; }
        [Required]
        public string ContactName { get; set; }
        [Required]
        public int CompanyId { get; set; }
        [Required]
        public int CountryId { get; set; }
        public DateTime Created { get; set; }

        public DateTime? Completed { get; set; }
    }
}

