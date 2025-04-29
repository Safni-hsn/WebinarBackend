using System.ComponentModel.DataAnnotations;

namespace WebinarBackend.Models
{
    public class Webinar
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string WebinarId { get; set; } = string.Empty;

    }
}
