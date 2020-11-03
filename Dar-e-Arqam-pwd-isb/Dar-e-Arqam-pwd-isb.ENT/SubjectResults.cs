using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dar_e_Arqam_pwd_isb.ENT
{
    public class SubjectResults
    {
        public string Id { get; set; }
        public string Sub_r_id { get; set; }
        public string Student_id { get; set; }
        public virtual Subjects Subject_name { get; set; }
        public string Subject_id { get; set; }
        public virtual SubjectsTotalMarks Total_marks { get; set; }
        public double Obtn_marks { get; set; }
        public virtual Sub_Results Subresult { get; set; }
        public int Status { get; set; }
        public string Date { get; set; }
        public string Month { get; set; }
        public string Year { get; set; }
        public string Time { get; set; }
    }
}
