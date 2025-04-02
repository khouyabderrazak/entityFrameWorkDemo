using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameWorkProject.Models
{
    public class Class
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string  Name { get; set; }


        [Required]
        public string Description { get; set; }

        [Required]
        public string Level { get; set; }

        [Required]
        
        public int TeacherId { get; set; }
        public Teacher? Teacher { get; set; }
    }
}
