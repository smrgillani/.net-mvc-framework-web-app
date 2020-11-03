using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dar_e_Arqam_pwd_isb.Models
{
    public class Sub_Result
    {
        public string id { get; set; }
        public string name { get; set; }
        public string Publish { get; set; }
        public virtual Result S_id { get; set; }
        public virtual List<SubjectResult> S_r { get; set; }
        public virtual SubjectResult S_r_ { get; set; }
        public virtual List<SubjectResult> S__r { get; set; }
        public double Percentage { get; set; }
        public string Date { get; set; }
        public string Month { get; set; }
        public string Year { get; set; }
        public string Time { get; set; }
    }
}