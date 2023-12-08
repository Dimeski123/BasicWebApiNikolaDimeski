using System.ComponentModel.DataAnnotations;

namespace BasicWebApiNikolaDimeski.Models
{
    public class ContactUpdated
    {
        [Required]
        public int ContactId { get; set; }
        [Required]
        public string ContactName { get; set; }

        public string CompanyName { get; set; }
        public string CountryName { get; set; }
    }
}
