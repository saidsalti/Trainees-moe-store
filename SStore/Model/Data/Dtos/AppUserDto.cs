using System.ComponentModel.DataAnnotations;

namespace SStore.Model.Data.Dtos
{
    public class AppUserDto
    {
      
        public int Id { get; set; }
        [StringLength(50)]
        [Required]
        public string? UserName { get; set; }
        [StringLength(500)]
        [Required]
        public string? Email { get; set; }
        [StringLength(50)]
        [Required]
        public string? FirstName { get; set; }
        [StringLength(50)]
        [Required]
        public string? LastName { get; set; }
        [StringLength(15)]

        public string? PhoneNumber { get; set; }
        public bool? IsActive { get; set; }
    }
}
