using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AjMusicApi.Models
{
    public class Users
    {

        [Key]

        [Column("user_id")]
        public string? UserId { get; set; }
        [Column("name")]
        public string? Name { get; set; }
        [Column("following")]
        public int? Following { get; set; }
        [Column("dob")]
        public DateTime? Dob { get; set; }
        [Column("country")]
        public string? Country { get; set; }
        [Column("created_on")]
        public DateTime? CreatedOn { get; set; }
    }
}
