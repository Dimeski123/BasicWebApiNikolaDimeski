using System.ComponentModel.DataAnnotations;

namespace BasicWebApiNikolaDimeski.Models
{
    public class Company
    {
        [Required]
        public int CompanyId { get; set; }
        [Required]
        public string CompanyName { get; set; }
    }
}
