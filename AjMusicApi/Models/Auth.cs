using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace AjMusicApi.Models
{
    public class Auth
    {
        [Key]
        [Column("user_id")]

        public string? UserId { get; set; }

        [Column("email")]
        public string? Email { get; set; }

        [Column("password")]
        public string? Password { get; set; }

    }
}
