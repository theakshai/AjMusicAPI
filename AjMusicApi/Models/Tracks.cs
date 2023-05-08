using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace AjMusicApi.Models
{
    public class Tracks
    {
        [Key]
        [Column("track_id")]
        public string? TrackId { get; set; }
        [Column("title")]
        public string? Title { get; set; }
        [Column("artist_id")]
        public string? ArtistId { get; set; }
        [Column("img_url")]
        public string? ImgUrl { get; set; }
        [Column("added_on")]
        public DateTime? AddedOn { get; set; }
        [Column("likes")]
        public int? Likes { get; set; }
        [Column("duration")]
        public string? Duration { get; set; }
        [Column("preview_url")]
        public string? PreviewUrl { get; set; }

    }
}
