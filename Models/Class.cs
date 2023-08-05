using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School_App.Models
{
    public class Class
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public string Division { get; set; }
        public DateTime AcademicYear { get; set; }

        public int TeacherID { get; set; }
        public virtual Teacher Teacher { get; set; }

    }
}
