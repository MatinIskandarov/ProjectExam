using System.ComponentModel.DataAnnotations;

namespace AdminPanel.Models.Teams
{
    public class UpdateModel
    {
        [Required]
        public string Fullname { get; set; }
        [Required]
        public string Position { get; set; }
        [Required]
        public string Description { get; set; }
    }
}
