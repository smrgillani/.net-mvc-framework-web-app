using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dar_e_Arqam_pwd_isb.ENT
{
    public class GradesSections
    {
        public string db_Id { get; set; }
        public string Class_Level_id { get; set; }
        public virtual ClassLevels Class_name { get; set; }
        public string Name { get; set; }
        public string Settings { get; set; }
        public string Date { get; set; }
        public string Month { get; set; }
        public string Year { get; set; }
        public string Time { get; set; }
    }
}