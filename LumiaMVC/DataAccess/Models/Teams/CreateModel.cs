using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models.Teams
{
    public class CreateModel
    {
        [Required]
        public string Image { get; set; }
        [Required]
        public string Fullname { get; set; }
        [Required]
        public string Position { get; set; }
        [Required]
        public string Description { get; set; }
    }
}
