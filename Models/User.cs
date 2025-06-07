using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UserApi.Models
{
    public class User
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public List<Phone> Phones { get; set; }

        public DateTime Created { get; set; } = DateTime.UtcNow;
        public DateTime Modified {  get; set; } = DateTime.UtcNow;
        public DateTime LastLogin {  get; set; } = DateTime.UtcNow;
        public string Token { get; set; }
        public bool IsActive { get; set; } = true;

    }
}
