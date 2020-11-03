using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dar_e_Arqam_pwd_isb.Models
{
    public class SubjectTotalMark
    {
        public string Id { get; set; }
        public string Subject_id { get; set; }
        public string Subject_Name { get; set; }
        public string Class_id { get; set; }
        public string R_id { get; set; }
        public double Total_marks { get; set; }
    }
}