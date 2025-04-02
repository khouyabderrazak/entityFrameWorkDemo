using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameWorkProject.Models
{
    public class Teacher : Person
    {

        [Required]
        public DateTime HireDate { get; set; }


        //[Required]
        //public int PersonId { get; set; }


        [Required]
        public int SubjectId { get; set; }

        public Subject? Subject { get; set; }

    }
}
