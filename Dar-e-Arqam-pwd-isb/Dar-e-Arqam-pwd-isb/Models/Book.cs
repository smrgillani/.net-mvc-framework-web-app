using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dar_e_Arqam_pwd_isb.Models
{
    public class Book
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Class_subject_id { get; set; }
        public string Picture { get; set; }
        public string Publish { get; set; }
        public string Class_name { get; set; }
    }
}