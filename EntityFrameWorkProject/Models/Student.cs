﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameWorkProject.Models
{
    public class Student : Person
    {
        [Required]
        public int StudentNumber { get; set; }

        //[Required]
        //public int PersonId { get; set; }
    }
}
