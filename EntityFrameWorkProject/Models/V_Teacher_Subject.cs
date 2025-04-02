using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameWorkProject.Models
{
    public class V_Teacher_Subject
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime HireDate { get; set; }
        public string Name { get; set; }

        public string Description { get; set; }

        public int SubjectId { get; set; }
        public int Id { get; set; }

    }
}
