using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AjMusicApi.Models
{
    public class Artists
    {
        [Key]
        [Column("id")]
        public string? Id { get; set; }

        [Column("followers")]
        public int? Followers { get; set; }

        [Column("img_url")]
        public string? ImgUrl { get; set; }

        [Column("name")]
        public string? Name { get; set; }

    }
}
