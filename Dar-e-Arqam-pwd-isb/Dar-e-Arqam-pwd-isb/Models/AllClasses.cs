using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dar_e_Arqam_pwd_isb.Models
{
    public class AllClasses
    {
        public List<Teacher> Teacher { get; set; }
        public Teacher Teacher_s { get; set; }
        public Search Search_key { get; set; }
        public Student Student { get; set; }
        public List<Student> Student_s { get; set; }
        public List<NewsUpdt> New_sAndUpdt_s { get; set; }
        public NewsUpdt NewsAndUpdt { get; set; }
        public List<Event> Event_s { get; set; }
        public Event Events { get; set; }
        public List<ClassLevel> ClassLevel_s { get; set; }
        public ClassLevel ClassLevel_ { get; set; }
        public GradeSection GradeSection_ { get; set; }
        public List<GradeSection> GradeSection_s { get; set; }
        public List<Subject> Subject_s { get; set; }
        public Subject Subject { get; set; }
        public Book Book_ { get; set; }
        public List<Book> Book_s { get; set; }
        public Diary Diary { get; set; }
        public List<Diary> Diary_s { get; set; }
        public Diary_Contxt Diary_contxt_ { get; set; }
        public List<Diary_Contxt> Diary_contxt_s { get; set; } 
        public List<Syllabus> Syllabus_s { get; set; }
        public Syllabus Syllabus { get; set; }
        public List<Uniform> Uniform_s { get; set; }
        public Uniform Uniform_ { get; set; }
        public List<Result> Result_s { get; set; }
        public Result Result { get; set; }
        public List<Sub_Result> Sub_Result_s { get; set; }
        public List<Star> Star_s { get; set; }
        public Star Star { get; set; }
        public List<Achvmnt> Achvmnt_s { get; set; }
        public Achvmnt Achvmnt { get; set; }
        public List<FeeStructure> FeeStructure_s { get; set; }
        public FeeStructure FeeStructure { get; set; }
        public List<StuffInStorage> Stuff_sInStorage_s { get; set; }
        public List<Employee> Employee_s { get; set; }
        public List<ContactInfo> Contact_sInfo_s { get; set; }
        public ContactInfo ContactInfo { get; set; }
        public SubjectResult SubjectResult { get; set; }
        public List<SubjectResult> SubjectResult_s { get; set; }
        public List<SubjectResult> SubjectResult_s_ { get; set; }
        public SubjectTotalMark SubjectsTotalMarks_ { get; set; }
        public List<SubjectTotalMark> SubjectsTotalMark_s { get; set; }
        public Sub_Result Sub_Result { get; set; }
        public ResultPosition Result_Position { get; set; }
        public string zid { set; get; }
    }
}