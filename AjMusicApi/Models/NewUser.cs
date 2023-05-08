namespace AjMusicApi.Models
{
    public class NewUser
    {
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? password { get; set; }
        public DateTime? dob { get; set; }
        public string? Country { get; set; }
    }
}
