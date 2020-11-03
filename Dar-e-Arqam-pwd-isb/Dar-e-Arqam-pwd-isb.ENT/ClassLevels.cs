using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dar_e_Arqam_pwd_isb.ENT
{
    public class ClassLevels
    {
        public string db_Id { get; set; }
        public string Name { get; set; }
        public string Range { get; set; }
        public List<Subjects> SubjectsId { set; get; } 
        public string Date { get; set; }
        public string Month { get; set; }
        public string Year { get; set; }
        public string Time { get; set; }
    }
}