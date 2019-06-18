using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SocialService.DataAccess.Entities
{
    public class ClientProfile
    {
        [Key]
        [ForeignKey("ApplicationUser")]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }

        public ApplicationUser ApplicationUser { get; set; }
    }
}
