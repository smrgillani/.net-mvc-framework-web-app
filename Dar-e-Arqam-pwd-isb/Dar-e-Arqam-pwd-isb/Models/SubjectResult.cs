using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dar_e_Arqam_pwd_isb.Models
{
    public class SubjectResult
    {
        public string Id { get; set; }
        public string Sub_r_id { get; set; }
        public string Student_id { get; set; }
        public string Subject_id { get; set; }
        public string Subject_name { get; set; }
        public double Obtn_marks { get; set; }
        public double Total_marks { get; set; }
        public int Status { get; set; }
        public string Subresultid { get; set; }
        public string Subresultname { get; set; }
    }
}