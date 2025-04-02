using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameWorkProject.Models
{
    public class Enrollment
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int PersonId { get; set; }

        public Person? Person { get; set; }

        [Required]
        public int ClassId { get; set; }

        public Class? Class { get; set; }


        [Required]
        public DateTime EnrollmentDate { get; set; }

    }
}
