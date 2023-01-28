using System.ComponentModel.DataAnnotations;

namespace AdminPanel.Models.Teams
{
    public class CreateModel
    {
        [Required]
        public IFormFile Image { get; set; }
        [Required]
        public string Fullname { get; set; }
        [Required]
        public string Position { get; set; }
        [Required]
        public string Description { get; set; }
    }
}
