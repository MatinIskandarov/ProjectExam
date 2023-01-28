using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Team
    {
        public int Id { get; set; }
        [Required]
        public string? Fullname { get; set; }

        [Required]
        public string? Position { get; set; }

        [Required]
        public string? Description { get; set; }

        public string? Img { get; set; }

        public string? Facebook { get; set; }
        public string? Instagram { get; set; }
        public string? Twitter { get; set; }
        public string? LinkedIn { get; set; }

    }
}
