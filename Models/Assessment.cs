using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School_App.Models
{
    public class Assessment
    {
        public int Id { get; set; }
        public int SubjectId { get; set; }
        public virtual Subject Subject { get; set; }


        public int ClassId { get; set; }
        public virtual Class Class { get; set; }


        public float TotalMarks { get; set; }
        public float PassMarks { get; set; }


    }
}
