using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dar_e_Arqam_pwd_isb.ENT
{
    public class SubjectsTotalMarks
    {
        public string Id { get; set; }
        public string Subject_id { get; set; }
        public string Class_id { get; set; }
        public string R_id { get; set; }
        public double Total_marks { get; set; }
        public virtual Subjects Subject_name { get; set; }
        public string Date { get; set; }
        public string Month { get; set; }
        public string Year { get; set; }
        public string Time { get; set; }
    }
}