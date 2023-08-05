using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School_App.Models
{
    public class ClassSubject
    {
        public int Id { get; set; }
        
        public int ClassId { get; set; }
        public Class Class { get; set; }

        public int SubjectId { get; set; }
        public virtual Subject Subject { get; set; }

        public int TeacherId { get; set; }
        public virtual Teacher Teacher { get; set; }


    }
}
