using System.ComponentModel.DataAnnotations;

namespace UserApi.Models
{
    public class Phone
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Number { get; set; }
        [Required]
        public string CityCode { get; set; }
        [Required]
        public string ContryCode { get; set; } 
    }
}
