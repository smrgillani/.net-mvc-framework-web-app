using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dar_e_Arqam_pwd_isb.ENT
{
    public class Subjects
    {
        public string db_Id { get; set; }
        public string ClassLevel { get; set; }
        public string Name { get; set; }
        public virtual ClassLevels ClassName { get; set; }
        public string R_id { get; set; }
        public string Date { get; set; }
        public string Month { get; set; }
        public string Year { get; set; }
        public string Time { get; set; }
    }
}