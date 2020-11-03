using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dar_e_Arqam_pwd_isb.Models
{
    public class ClassLevel
    {   
        public string Id { get; set; }
        public string Name { get; set; }
        public string Range { get; set; }
        public string SubjectName { get; set; }
        public List<Subject> SubjectId { get; set; }
    }
}