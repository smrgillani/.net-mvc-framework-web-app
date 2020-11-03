using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dar_e_Arqam_pwd_isb.Models
{
    public class WebAllClass
    {
        public ContactMsg ContactMsg { set; get; }
        public Student Student { set; get; }
        public Achvmnt Achievement { set; get; }
        public List<Achvmnt> Achievements { set; get; }
        public List<Sub_Result> Sub_Result_s { set; get; }
        public Sub_Result Sub_Result { set; get; }
        public List<SubjectResult> SubjectResult_s { set; get; }
        public List<NewsUpdt> NewsAndUpdts_s { set; get; }
        public NewsUpdt NewsAndUpdts { set; get; }
        public List<Event> Event_s { set; get; }
        public Event Event_ { set; get; }
        public List<Star> Star_s { set; get; }
        public ContactInfo ContactInfo { set; get; }
        public List<SubjectResult> SubjectResult_s_ { set; get; }
        public Diary Diary_ { get; set; }
        public List<Diary> Diary_s { get; set; }
        public ClassLevel ClassLevel_ { get; set; }
        public List<ClassLevel> ClassLevel_s { get; set; }
        public Diary_Contxt Diary_contxt_ { get; set; }
        public List<Diary_Contxt> Diary_contxt_s { get; set; }
        public GradeSection GradeSection_ { get; set; }
        public List<GradeSection> GradeSection_s { get; set; }
        public string zid { set; get; }
    }
}