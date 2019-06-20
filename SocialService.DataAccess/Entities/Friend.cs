using System.ComponentModel.DataAnnotations;

namespace SocialService.DataAccess.Entities
{
    public class Friend
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        public int UserId { get; set; }
    }
}
