using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dar_e_Arqam_pwd_isb.ENT
{
    public class Sub_Results
    {
        public string id { get; set; }
        public string name { get; set; }
        public string Publish { get; set; }
        public virtual Results S_id { get; set; }
        public virtual List<SubjectResults> S_r { get; set; }
        public virtual SubjectResults S_r_ { get; set; }
        public double Percentage { get; set; }
        public string Date { get; set; }
        public string Month { get; set; }
        public string Year { get; set; }
        public string Time { get; set; }
    }
}
