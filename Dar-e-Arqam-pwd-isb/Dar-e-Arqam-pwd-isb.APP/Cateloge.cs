using Dar_e_Arqam_pwd_isb.DAL;
using Dar_e_Arqam_pwd_isb.ENT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dar_e_Arqam_pwd_isb.APP
{
    public class Cateloge
    {
        // Insert Data Into DB
        public void AddTeacher(Teachers t)
        {
            new AddAndUpdtTeacherDAL().AddTeacher(t);
        }

        public void AddStudent(Students s)
        {
            new AddAndUpdtStudentDAL().AddStudent(s);
        }

        public void PublishAllStudentsResult(Students pas)
        {
            new AddAndUpdtStudentDAL().PublishAllStudents(pas);
        }

        public void AddNewsUpdt(NewsUpdts nu)
        {
            new AddAndUpdtNewsUpdtDAL().AddNewsUpdt(nu);
        }

        public void AddEvent(Events e)
        {
            new AddAndUpdtEventDAL().AddEvent(e);
        }

        public void AddClassLevel(ClassLevels cl)
        {
            new AddAndUpdtClassLevelDAL().AddClassLevel(cl);
        }

        public void AddGradeSection(GradesSections gs)
        {
            new AddAndUpdtGradeSectionDAL().AddSection(gs);
        }

        public void AddSubject(Subjects s)
        {
            new AddAndUpdtSubjectDAL().AddSubject(s);
        }

        public void AddAsgndClsSub(ClassesOrSubjectsToTeacher cs, int id)
        {
            new AddAndUpdtTeacherDAL().AsgnClsSub(cs, id);
        }

        public void DelSubjectResult(int sid , int rid)
        {
            new AddAndUpdtStudentDAL().DeleteSubjectResult(sid,rid);
        }

        public void DelResultPosition(int id)
        {
            new AddAndUpdtStudentDAL().DeleteResultPosition(id);
        }

        public void DelNewsUpdt(int id)
        {
            new AddAndUpdtNewsUpdtDAL().DeleteNewsUpdt(id);
        }

        public void DelStar(int id)
        {
            new AddAndUpdtStarDAL().DeleteStar(id);
        }

        public void DelEvent(int id)
        {
            new AddAndUpdtEventDAL().DeleteEvent(id);
        }

        public void DelContactInfo(int id)
        {
            new AddAndUpdtContactInfoDAL().DeleteContactInfo(id);
        }

        public void DelUniform(int id)
        {
            new AddAndUpdtUniformDAL().DeleteUniform(id);
        }

        public void DelClassLvl(int id)
        {
            new AddAndUpdtClassLevelDAL().DeleteClassLvl(id);
        }

        public void DelBook(int id)
        {
            new AddAndUpdtBookDAL().DeleteBook(id);
        }

        public void DelSubjectDiary(int id)
        {
            new AddAndUpdtDiarySubjectDAL().DeleteSubjectDiary(id);
        }

        public void AddBook(Books b)
        {
            new AddAndUpdtBookDAL().AddBook(b);
        }

        public void AddDiary(Diaries d)
        {
            new AddAndUpdtDiaryDAL().AddDiary(d);
        }

        public void AddDiarySubjects(Diaries_Contxts dc)
        {
            new AddAndUpdtDiarySubjectDAL().AddSubjectDiary(dc);
        }

        public void AddSyllabus(Syllabuses s)
        {
            new AddAndUpdtSyllabusDAL().AddSyllabus(s);
        }

        public void AddUniform(Uniforms u)
        {
            new AddAndUpdtUniformDAL().AddUniform(u);
        }

        public void AddResult(Results r)
        {
            new AddAndUpdtResultDAL().AddResult(r);
        }

        //public void AddSubjectsResult(List<SubjectResults> srd)
        //{
        //    new AddAndUpdtStudentDAL().AddStudentsResults(srd);
        //}

        public void AddResultPosition(ResultsPositions rs)
        {
            new AddAndUpdtStudentDAL().AddResultPosition(rs);
        }

        public void AddStar(Stars s)
        {
            new AddAndUpdtStarDAL().AddStar(s);
        }

        public void AddAchvmnt(Achvmnts a)
        {
            new AddAndUpdtAchvmntDAL().AddAchvmnt(a);
        }

        public void AddFeeStructure(FeeStructures fs)
        {
            new AddAndUpdtFeeStructureDAL().AddFeeStructure(fs);
        }

        public void AddStuffInStorage(StuffsInStorages ss)
        {
            new AddAndUpdtStuffInStorageDAL().AddStuffInStorage(ss);
        }

        public void AddEmployee(Employees e)
        {
            new AddAndUpdtEmployeeDAL().AddEmployee(e);
        }

        public void AddContactInfo(ContactsInfo ci)
        {
            new AddAndUpdtContactInfoDAL().AddContactInfo(ci);
        }

        public void AddSubjectsTotalMarks(SubjectsTotalMarks stm)
        {
            new AddAndUpdtResultDAL().AddSubjectsTotalMarksForResult(stm);
        }

        public void AddSubjectsObtnMarks(List<SubjectResults> som)
        {
            new AddAndUpdtStudentDAL().AddSubjectsObtainMarksForResult(som);
        }

        public void UpdtSubjectsObtnMarks(List<SubjectResults> som)
        {
            new AddAndUpdtStudentDAL().UpdtSubjectsObtainMarksForResult(som);
        }

        public void DelSbjctsTtlMrks(int id, int rid)
        {
            new AddAndUpdtResultDAL().DeleteSubjectsTotalMarks(id, rid);
        }

        //Select Data From DB
        
        public List<Logins> SelectAllLoginUsers()
        {
            return new UsersDAL().SelectAllUsers();
        }

        public List<Students> AllStudentsResultStatus()
        {
            return new StudentDAL().AllStudentsResultStatus();
        }

        public List<Teachers> Teachers()
        {
            return new TeacherDAL().SelectAllTeachers();
        }

        public List<Teachers> ActiveTeachers()
        {
            return new TeacherDAL().SelectAllActiveTeachers();
        }

        public List<Teachers> OldTeachers()
        {
            return new TeacherDAL().SelectAllOldTeachers();
        }

        public List<Teachers> TrashTeachers()
        {
            return new TeacherDAL().SelectAllTrashTeachers();
        }

        public List<Teachers> SearchTeacher(string Search_key)
        {
            return new TeacherDAL().SelectBySearch(Search_key);
        }

        public List<Teachers> SearchActiveTeacher(string Search_key)
        {
            return new TeacherDAL().SelectActiveBySearch(Search_key);
        }

        public List<Teachers> SearchOldTeacher(string Search_key)
        {
            return new TeacherDAL().SelectOldBySearch(Search_key);
        }

        public List<Teachers> SearchTrashTeacher(string Search_key)
        {
            return new TeacherDAL().SelectTrashBySearch(Search_key);
        }

        public Teachers SelectTeacher(int id)
        {
            return new TeacherDAL().SelectById(id);
        }

        public Sub_Results SelectAllSubjectsResultTitle(int rid)
        {
            return new StudentDAL().SelectResultTitleById(rid);
        }

        public List<Students> Students()
        {
            return new StudentDAL().SelectAllStudents();
        }

        public List<Students> SearchStudent(string Search_key)
        {
            return new StudentDAL().SelectBySearch(Search_key);
        }

        public Students SelectStudent(int id)
        {
            return new StudentDAL().SelectById(id);
        }

        public Students SelectStudentForPanel(int? zid)
        {
            return new StudentDAL().SelectByIdForPanel(zid);
        }

        public List<Students> SelectStudentsForClassLevels(int id)
        {
            return new StudentDAL().SelectByClassLevelId(id);
        }

        public Students SelectAllStudentForWeb(int? zid)
        {
            return new StudentDAL().SelectByIdForWeb(zid);
        }

        public List<SubjectResults> SelectStudentResultById(int id)
        {
            return new StudentDAL().SelectResultsByStudentId(id);
        }

        public List<Students> Parents()
        {
            return new ParentDAL().SelectAllParents();
        }

        public List<Students> SearchParent(string Search_key)
        {
            return new ParentDAL().SelectBySearch(Search_key);
        }

        public Students SelectParent(int id)
        {
            return new ParentDAL().SelectById(id);
        }

        public List<NewsUpdts> NewsAndUpdts()
        {
            return new NewsAndUptsDAL().SelectAllNewsAndUpdts();
        }

        public List<NewsUpdts> SearchNewsAndUpdts(string Search_key)
        {
            return new NewsAndUptsDAL().SelectBySearch(Search_key);
        }

        public NewsUpdts SelectNewsAndUpdts(int id)
        {
            return new NewsAndUptsDAL().SelectById(id);
        }

        public List<NewsUpdts> SelectAllNewsForWeb()
        {
            return new NewsAndUptsDAL().SelectAllNewsAndUpdtsForWeb();
        }

        public NewsUpdts SelectNewsForWeb(int? id)
        {
            return new NewsAndUptsDAL().SelectByIdForWeb(id);
        }

        public List<Events> Events()
        {
            return new EventsDAL().SelectAllEvents();
        }

        public List<Events> SearchEvents(string Search_key)
        {
            return new EventsDAL().SelectBySearch(Search_key);
        }

        public Events SelectEvent(int id)
        {
            return new EventsDAL().SelectById(id);
        }

        public List<Events> EventsForWeb()
        {
            return new EventsDAL().SelectAllEventsForWeb();
        }

        public Events EventForWeb(int? id)
        {
            return new EventsDAL().SelectByIdForWeb(id);
        }

        public List<ClassLevels> ClassLevels()
        {
            return new ClassLevelsDAL().SelectAllClassLevels();
        }

        public List<ClassLevels> SearchClassLevel(string Search_key)
        {
            return new ClassLevelsDAL().SelectBySearch(Search_key);
        }

        public ClassLevels SelectClassLevel(int id)
        {
            return new ClassLevelsDAL().SelectById(id);
        }

        public List<ClassLevels> SelectAllClassLevelsWithSubjects()
        {
            return new ClassLevelsDAL().SelectAllClassLevelsWithSubjects();
        }

        public List<GradesSections> GradeSections(int id)
        {
            return new GradeSectionDAL().SelectAll(id);
        }

        public List<GradesSections> SearchGradeSection(string Search_key)
        {
            return new GradeSectionDAL().SelectBySearch(Search_key);
        }

        public GradesSections SelectGradeSection(int id)
        {
            return new GradeSectionDAL().SelectById(id);
        }

        public List<Subjects> Subjects()
        {
            return new SubjectsDAL().SelectAllSubjects();
        }

        public List<Subjects> SearchSubjects(string Search_key)
        {
            return new SubjectsDAL().SelectBySearch(Search_key);
        }

        public Subjects SelectSubject(int id)
        {
            return new SubjectsDAL().SelectById(id);
        }

        public List<Subjects> SelectSubjectsOfClassById(int id)
        {
            return new SubjectsDAL().SelectSubjectsOfClassById(id);
        }

        public List<Books> Books()
        {
            return new BooksDAL().SelectAllBooks();
        }

        public List<Books> SearchBooks(string Search_key)
        {
            return new BooksDAL().SelectBySearch(Search_key);
        }

        public Books SelectBook(int id)
        {
            return new BooksDAL().SelectById(id);
        }

        public List<Books> ActiveBooks()
        {
            return new BooksDAL().SelectAllActiveBooks();
        }

        public List<Diaries> Diaries()
        {
            return new DiaryDAL().SelectAllDiary();
        }

        public List<Diaries> SearchDiaries(string Search_key)
        {
            return new DiaryDAL().SelectBySearch(Search_key);
        }

        public Diaries SelectDiary(int id)
        {
            return new DiaryDAL().SelectById(id);
        }

        public List<Diaries> ActiveDiaries()
        {
            return new DiaryDAL().SelectAllActiveDiary();
        }

        public Diaries SelectActiveDiary(int id)
        {
            return new DiaryDAL().SelectActiveById(id);
        }

        public List<Diaries_Contxts> DiariesSubjects(int sid , int did)
        {
            return new DiaryWithSubjectsDAL().SelectAll(sid,did);
        }

        public Diaries_Contxts SelectDiarySubject(int id)
        {
            return new DiaryWithSubjectsDAL().SelectById(id);
        }

        public List<Syllabuses> Syllabuses()
        {
            return new SyllabusDAL().SelectAllSyllabuses();
        }

        public List<Syllabuses> SearchSyllabuses(string Search_key)
        {
            return new SyllabusDAL().SelectBySearch(Search_key);
        }

        public Syllabuses SelectSyllabus(int id)
        {
            return new SyllabusDAL().SelectById(id);
        }

        public List<Uniforms> Uniforms()
        {
            return new UniformsDAL().SelectAllUniforms();
        }

        public List<Uniforms> SearchUniforms(string Search_key)
        {
            return new UniformsDAL().SelectBySearch(Search_key);
        }

        public Uniforms SelectUniforms(int id)
        {
            return new UniformsDAL().SelectById(id);
        }

        public List<Results> Results()
        {
            return new ResultsDAL().SelectAllResults();
        }

        public List<Results> SearchResults(string Search_key)
        {
            return new ResultsDAL().SelectBySearch(Search_key);
        }

        public Results SelectResults(int id)
        {
            return new ResultsDAL().SelectById(id);
        }

        public List<SubjectResults> SelectAllSubjectResult(int id)
        {
            return new StudentDAL().SelectResultTitle(id);
        }

        public List<Sub_Results> SelectSubResultsTitles()
        {
            return new StudentDAL().SelectSubResultsTitle();
        }

        public List<SubjectResults> SelectAllSubjectsResult(int sid, int rid)
        {
            return new StudentDAL().SelectResultByRidSid(sid, rid);
        }

        public ResultsPositions SelectResultPositionByRidSid(int? sid, int? rid)
        {
            return new StudentDAL().SelectResultPositionByRidSid(sid, rid);
        }

        public List<SubjectResults> SelectAllSubjectsResultForWeb(int? sid, int? rid)
        {
            return new StudentDAL().SelectResultByRidSidForWeb(sid, rid);
        }

        public List<Sub_Results> SelectSubResults(int id)
        {
            return new ResultsDAL().SelectAllSubResults(id);
        }

        public List<Sub_Results> SelectSubResultsWithDetail(int id , int sid)
        {
            return new ResultsDAL().SelectSubResultsWithDetail(id, sid);
        }

        public List<Sub_Results> SelectSubResultsWithDetailForWeb(int id, int sid)
        {
            return new ResultsDAL().SelectSubResultsWithDetailForWeb(id, sid);
        }

        public List<SubjectResults> SelectSubResultTitleAndId(int id)
        {
            return new StudentDAL().SelectResultTitle(id);
        }

        public List<Sub_Results> SelectAllSubResults()
        {
            return new ResultsDAL().SelectAllSubResults();
        }

        public Sub_Results SelectSubResult(int? id)
        {
            return new ResultsDAL().SelectSubResult(id);
        }

        public List<Sub_Results> SelectAllSubResultsForWeb()
        {
            return new ResultsDAL().SelectAllSubResultsForWeb();
        }

        public Sub_Results SelectAllSubResultForWeb(int? id)
        {
            return new ResultsDAL().SelectAllSubResultsForWeb(id);
        }

        public List<Stars> Stars()
        {
            return new StarsDAL().SelectAllStars();
        }

        public List<Stars> SearchStars(string Search_key)
        {
            return new StarsDAL().SelectBySearch(Search_key);
        }

        public Stars SelectStars(int id)
        {
            return new StarsDAL().SelectById(id);
        }

        public List<Stars> StarsForWeb()
        {
            return new StarsDAL().SelectAllStarsForWeb();
        }

        public List<Achvmnts> Achvmnts()
        {
            return new AchvmntsDAL().SelectAllAchvmnts();
        }

        public List<Achvmnts> AchvmntsForWeb()
        {
            return new AchvmntsDAL().AllAchvmntsForWeb();
        }

        public Achvmnts SelectAchvmntForWeb(int? id)
        {
            return new AchvmntsDAL().SelectByIdForWeb(id);
        }

        public List<Achvmnts> SearchAchvmnts(string Search_key)
        {
            return new AchvmntsDAL().SelectBySearch(Search_key);
        }

        public Achvmnts SelectAchvmnts(int id)
        {
            return new AchvmntsDAL().SelectById(id);
        }

        public List<FeeStructures> FeeStructures()
        {
            return new FeeStructuresDAL().SelectAllFeeStructures();
        }

        public List<FeeStructures> SearchFeeStructures(string Search_key)
        {
            return new FeeStructuresDAL().SelectBySearch(Search_key);
        }

        public FeeStructures SelectFeeStructures(int id)
        {
            return new FeeStructuresDAL().SelectById(id);
        }

        public List<StuffsInStorages> StuffsInStorages()
        {
            return new StuffsInStoragesDAL().SelectAllStuffsInStorages();
        }

        public List<StuffsInStorages> SearchStuffsInStorages(string Search_key)
        {
            return new StuffsInStoragesDAL().SelectBySearch(Search_key);
        }

        public StuffsInStorages SelectStuffInStorage(int id)
        {
            return new StuffsInStoragesDAL().SelectById(id);
        }

        public List<Employees> Employees()
        {
            return new EmployeeDAL().SelectAllEmployees();
        }

        public List<Employees> SearchEmployees(string Search_key)
        {
            return new EmployeeDAL().SelectBySearch(Search_key);
        }

        public Employees SelectEmployee(int id)
        {
            return new EmployeeDAL().SelectById(id);
        }

        public List<ContactsInfo> ContactsInfo()
        {
            return new ContactsInfoDAL().SelectAllContactsInfo();
        }

        public List<ContactsInfo> SearchContactsInfo(string Search_key)
        {
            return new ContactsInfoDAL().SelectBySearch(Search_key);
        }

        public ContactsInfo SelectContactInfo(int id)
        {
            return new ContactsInfoDAL().SelectById(id);
        }

        public ContactsInfo ContactInfoForWeb()
        {
            return new ContactsInfoDAL().SelectContactInfoForWeb();
        }

        public List<SubjectsTotalMarks> SelectAllSubjectsTotalMarks()
        {
            return new ResultsDAL().SelectAllSubjectsTotalMarks();
        }

        public List<SubjectsTotalMarks> SelectAllSubjectsTotalMarksWithIds(int id , int rid)
        {
            return new ResultsDAL().SelectAllSubjectsTotalMarksWithIds(id,rid);
        }

        //Update Data Of DB

        public void UpdateTeacher(Teachers t, int id)
        {
            new AddAndUpdtTeacherDAL().UpdateTeacher(t, id);
        }

        public void UpdateStudent(Students s, int id)
        {
            new AddAndUpdtStudentDAL().UpdateStudent(s, id);
        }

        public void UpdateParent(Students p, int id)
        {
            new UpdtParentDAL().UpdateParent(p, id);
        }

        public void UpdateNewsAndUpdts(NewsUpdts nu, int id)
        {
            new AddAndUpdtNewsUpdtDAL().UpdateNewsUpdt(nu, id);
        }

        public void UpdateNewsAndUpdts_img(NewsUpdts nu, int id)
        {
            new AddAndUpdtNewsUpdtDAL().UpdateNewsUpdt_img(nu, id);
        }

        public void UpdateEvent(Events e, int id)
        {
            new AddAndUpdtEventDAL().UpdateEvent(e, id);
        }

        public void UpdateEvent_img(Events e, int id)
        {
            new AddAndUpdtEventDAL().UpdateEvent_img(e, id);
        }

        public void UpdateClassLevel(ClassLevels cl, int id)
        {
            new AddAndUpdtClassLevelDAL().UpdateClassLevel(cl, id);
        }

        public void UpdateGradeSection(GradesSections gs, int id)
        {
            new AddAndUpdtGradeSectionDAL().UpdateSection(gs, id);
        }

        public void UpdateSubject(Subjects s, int id)
        {
            new AddAndUpdtSubjectDAL().UpdateSubject(s, id);
        }

        public void UpdateBooks(Books ub, int id)
        {
            new AddAndUpdtBookDAL().UpdateBook(ub, id);
        }

        public void UpdateBooks_img(Books ub, int id)
        {
            new AddAndUpdtBookDAL().UpdateBook_img(ub, id);
        }

        public void UpdateDiary(Diaries ud, int id)
        {
            new AddAndUpdtDiaryDAL().UpdateDiary(ud, id);
        }

        public void UpdateDiarySubject(Diaries_Contxts dc, int id)
        {
            new AddAndUpdtDiarySubjectDAL().UpdateSubjectDiary(dc, id);
        }

        public void UpdateSyllabus(Syllabuses us, int id)
        {
            new AddAndUpdtSyllabusDAL().UpdateSyllabus(us, id);
        }

        public void UpdateUniform(Uniforms uu, int id)
        {
            new AddAndUpdtUniformDAL().UpdateUniform(uu, id);
        }

        public void UpdateUniform_img(Uniforms uu, int id)
        {
            new AddAndUpdtUniformDAL().UpdateUniform_img(uu, id);
        }

        public void UpdateResult(Results ur, int id)
        {
            new AddAndUpdtResultDAL().UpdateResult(ur, id);
        }

        public void UpdateStar(Stars us, int id)
        {
            new AddAndUpdtStarDAL().UpdateStar(us, id);
        }

        public void UpdateStar_img(Stars us, int id)
        {
            new AddAndUpdtStarDAL().UpdateStar_img(us, id);
        }

        public void UpdateAchvmnt(Achvmnts ua, int id)
        {
            new AddAndUpdtAchvmntDAL().UpdateAchvmnt(ua, id);
        }

        public void UpdateAchvmnt_img(Achvmnts ua, int id)
        {
            new AddAndUpdtAchvmntDAL().UpdateAchvmnt_img(ua, id);
        }

        public void UpdateFeeStructure(FeeStructures ufs, int id)
        {
            new AddAndUpdtFeeStructureDAL().UpdateFeeStructure(ufs, id);
        }

        public void UpdateStuffInStorage(StuffsInStorages uss, int id)
        {
            new AddAndUpdtStuffInStorageDAL().UpdateStuffInStorage(uss, id);
        }

        public void UpdateStuffInStorage_file(StuffsInStorages uss, int id)
        {
            new AddAndUpdtStuffInStorageDAL().UpdateStuffInStorage_file(uss, id);
        }

        public void UpdateEmployee(Employees ue, int id)
        {
            new AddAndUpdtEmployeeDAL().UpdateEmployee(ue, id);
        }

        public void UpdateContactInfo(ContactsInfo uci, int id)
        {
            new AddAndUpdtContactInfoDAL().UpdateContactInfo(uci, id);
        }

        public void PublishNewsOrUpdate(NewsUpdts pnu, int id)
        {
            new AddAndUpdtNewsUpdtDAL().PublishNewsUpdt(pnu, id);
        }

        public void PublishShiningStar(Stars pss, int id)
        {
            new AddAndUpdtStarDAL().PublishStar(pss, id);
        }

        public void PublishAchvmnt(Achvmnts pa, int id)
        {
            new AddAndUpdtAchvmntDAL().PublishAchvmnt(pa, id);
        }

        public void PublishFeeStructure(FeeStructures pfs, int id)
        {
            new AddAndUpdtFeeStructureDAL().PublishFeeStructure(pfs, id);
        }

        public void PublishContactInfo(ContactsInfo pci, int id)
        {
            new AddAndUpdtContactInfoDAL().PublishContactInfo(pci, id);
        }

        public void PublishUniform(Uniforms pu, int id)
        {
            new AddAndUpdtUniformDAL().PublishUniform(pu, id);
        }

        public void PublishBook(Books pb, int id)
        {
            new AddAndUpdtBookDAL().PublishBook(pb, id);
        }

        public void PublishSyllabus(Syllabuses ps, int id)
        {
            new AddAndUpdtSyllabusDAL().PublishSyllabus(ps, id);
        }

        public void PublishEvent(Events pe, int id)
        {
            new AddAndUpdtEventDAL().PublishEvent(pe, id);
        }

        public void PublishStudent(Students ps, int id)
        {
            new AddAndUpdtStudentDAL().PublishStudent(ps, id);
        }

        public void AddSubResult(Sub_Results sr, int id)
        {
            new AddAndUpdtResultDAL().AddSubResult(sr, id);
        }

        public void PublishSubResults(Sub_Results sr, int id)
        {
            new AddAndUpdtResultDAL().PublishSubResult(sr, id);
        }

        public void UpdateSubjectsTotalMarks(List<SubjectsTotalMarks> sr)
        {
            new AddAndUpdtResultDAL().UpdateSubjectsTotalMarksForResult(sr);
        }
    }
}
