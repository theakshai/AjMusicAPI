using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AjMusicApi.Models
{
    public class PlayList
    {
        [Key]
        [Column("id")]
        public string? Id { get; set; }
        [Column("name")]
        public string? Name { get; set; }
    }
}
