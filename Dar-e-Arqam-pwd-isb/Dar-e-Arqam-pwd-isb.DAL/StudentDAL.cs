using Dar_e_Arqam_pwd_isb.ENT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace Dar_e_Arqam_pwd_isb.DAL
{
    public class StudentDAL
    {
        public List<Students> SelectAllStudents()
        {
            SqlCommand cmd = new SqlCommand("Select * from Students order by id", DALUtil.getConnection());
            return fetchStudents(cmd);
        }

        public List<Students> SelectAllActiveStudents()
        {
            SqlCommand cmd = new SqlCommand("Select * from Students where active_set = '2' and del_set = '0' or del_set = '1' order by id", DALUtil.getConnection());
            return fetchStudents(cmd);
        }

        public List<Students> SelectAllTrashStudents()
        {
            SqlCommand cmd = new SqlCommand("Select * from Students where del_set = '2' and active_set = '0' or active_set = '1' order by id", DALUtil.getConnection());
            return fetchStudents(cmd);
        }

        public List<Students> AllStudentsResultStatus()
        {
            SqlCommand cmd = new SqlCommand("Select * from Students where result_set='1' order by id", DALUtil.getConnection());
            return fetchStudents(cmd);
        }

        public List<Students> SelectBySearch(string Search_key)
        {
            SqlCommand cmd = new SqlCommand("Select * from Students where name=@Search or reg_id=@Search or father_name=@Search order by id", DALUtil.getConnection());
            cmd.Parameters.AddWithValue("@Search", Search_key);
            return fetchStudents(cmd);
        }

        public Students SelectById(int id)
        {
            SqlCommand cmd = new SqlCommand("Select * from Students where Id=@Id", DALUtil.getConnection());
            cmd.Parameters.AddWithValue("@Id", id);
            List<Students> temp = fetchStudents(cmd);
            return (temp != null) ? temp[0] : null;
        }

        public Students SelectByIdForPanel(int? zid)
        {
            SqlCommand cmd = new SqlCommand(" Select * from Students Where reg_id=@Id ", DALUtil.getConnection());
            cmd.Parameters.AddWithValue("@Id", zid);
            List<Students> temp = fetchStudents(cmd);
            return (temp != null) ? temp[0] : null;
        }

        public Students SelectByIdForWeb(int? zid)
        {
            SqlCommand cmd = new SqlCommand("Select * from Students Where reg_id=@Id and result_set = '2'", DALUtil.getConnection());
            cmd.Parameters.AddWithValue("@Id", zid);
            List<Students> temp = fetchStudents(cmd);
            return (temp != null) ? temp[0] : null;
        }

        public List<Students> SelectByClassLevelId(int id)
        {
            SqlCommand cmd = new SqlCommand("Select * from Students Where grade=@Id order by reg_id", DALUtil.getConnection());
            cmd.Parameters.AddWithValue("@Id", id);
            return fetchStudents(cmd);
        }

        private List<Students> fetchStudents(SqlCommand cmd)
        {
            SqlConnection con = cmd.Connection;
            List<Students> students = null;
            con.Open();
            using (con)
            {
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    students = new List<Students>();
                    while (dr.Read())
                    {
                        Students s = new Students();
                        s.db_Id = Convert.ToString(dr["id"]);
                        s.Aplicnt_Id = Convert.ToString(dr["reg_id"]);
                        s.Aplicnt_name = Convert.ToString(dr["name"]);
                        s.Aplicnt_nnlty = Convert.ToString(dr["ntnlty"]);
                        s.Aplicnt_c_grade = Convert.ToString(dr["grade"]);
                        s.Aplicnt_dob = Convert.ToString(dr["dob"]);
                        s.Aplicnt_pob = Convert.ToString(dr["pob"]);
                        s.Aplicnt_gender = Convert.ToString(dr["gender"]);
                        s.Aplicnt_c_addr = Convert.ToString(dr["c_h_addr"]);
                        s.Aplicnt_p_addr = Convert.ToString(dr["p_h_addr"]);
                        s.Aplicnt_h_phone = Convert.ToString(dr["stdnt_h_ph_ll"]);
                        s.Aplicnt_pp_photo = Convert.ToString(dr["stdnt_pp_s_pic"]);
                        s.Aplicnt_emrgncy_p_name = Convert.ToString(dr["emrgncy_p_name"]);
                        s.Aplicnt_emrgncy_p_rltn = Convert.ToString(dr["emrgncy_p_rltn"]);
                        s.Aplicnt_emrgncy_p_cell = Convert.ToString(dr["emrgncy_p_c_num"]);
                        s.Aplicnt_emrgncy_p_ldln = Convert.ToString(dr["emrgncy_p_ll_num"]);
                        s.Aplicnt_emrgncy_p_addr = Convert.ToString(dr["emrgncy_p_addr"]);
                        s.Aplicnt_emrgncy_p_email = Convert.ToString(dr["emrgncy_p_email"]);
                        s.Aplicnt_f_name = Convert.ToString(dr["father_name"]);
                        s.Aplicnt_f_ocptn = Convert.ToString(dr["ocptn"]);
                        s.Aplicnt_f_title = Convert.ToString(dr["title"]);
                        s.Aplicnt_f_cell = Convert.ToString(dr["father_c_num"]);
                        s.Aplicnt_f_bsns_name = Convert.ToString(dr["name_of_bsns"]);
                        s.Aplicnt_f_bsns_addr = Convert.ToString(dr["addr_of_bsns"]);
                        s.Aplicnt_f_email = Convert.ToString(dr["father_email"]);
                        s.Aplicnt_f_phone = Convert.ToString(dr["father_ll_num"]);
                        s.Aplicnt_m_name  = Convert.ToString(dr["mother_name"]);
                        s.Aplicnt_m_cell = Convert.ToString(dr["mother_c_num"]);
                        s.Aplicnt_m_ldln = Convert.ToString(dr["mother_ll_num"]);
                        s.Aplicnt_b_one_name = Convert.ToString(dr["first_bro_name"]);
                        s.Aplicnt_b_one_grade = Convert.ToString(dr["first_bro_g"]);
                        s.Aplicnt_b_two_name = Convert.ToString(dr["scnd_bro_name"]);
                        s.Aplicnt_b_two_grade = Convert.ToString(dr["scnd_bro_g"]);
                        s.Aplicnt_b_thr_name = Convert.ToString(dr["thrd_bro_name"]);
                        s.Aplicnt_b_thr_grade = Convert.ToString(dr["thrd_bro_g"]);
                        s.Aplicnt_b_fou_name = Convert.ToString(dr["four_bro_name"]);
                        s.Aplicnt_b_fou_grade = Convert.ToString(dr["four_bro_g"]);
                        s.Aplicnt_b_prsnt_schl = Convert.ToString(dr["psn"]);
                        s.Aplicnt_b_date_atdnc = Convert.ToString(dr["doa"]);
                        s.Aplicnt_b_lng_ins = Convert.ToString(dr["loi"]);
                        s.Aplicnt_p_schl_name_o = Convert.ToString(dr["first_schl_name"]);
                        s.Aplicnt_p_schl_strt_date_o = Convert.ToString(dr["first_schl_d_from"]);
                        s.Aplicnt_p_schl_end_date_o = Convert.ToString(dr["first_schl_d_to"]);
                        s.Aplicnt_p_schl_name_t = Convert.ToString(dr["scnd_schl_name"]);
                        s.Aplicnt_p_schl_strt_date_t = Convert.ToString(dr["scnd_schl_d_from"]);
                        s.Aplicnt_p_schl_end_date_t = Convert.ToString(dr["scnd_schl_d_to"]);
                        s.Aplicnt_phycl_emo_cndtn_ackwlg = Convert.ToString(dr["xplntn_abt_stdnt"]);
                        s.Aplicnt_spcl_intrst_hobby = Convert.ToString(dr["hobby_spcl_intrst"]);
                        s.Source_of_acknwlge_abt_da = Convert.ToString(dr["knwldg_source_of_da"]);
                        s.Publish_result = Convert.ToString(dr["result_set"]);
                        s.Active_set = Convert.ToString(dr["active_set"]);
                        s.Date = Convert.ToString(dr["date"]);
                        s.Month = Convert.ToString(dr["month"]);
                        s.Year = Convert.ToString(dr["year"]);
                        s.Time = Convert.ToString(dr["time"]);
                        s.ClassName = SelectClassLevel(Convert.ToInt32(dr["grade"]));
                        //s.Subresult = SelectSubResultDtlOfStudent(Convert.ToInt32(s.db_Id));

                        students.Add(s);
                    }
                    students.TrimExcess();
                }
            }
            return students;
        }

        public List<SubjectResults> SelectResultTitle(int id)
        {
            SqlCommand cmd = new SqlCommand("Select distinct sub_r_id from result_details where student_id=@Id", DALUtil.getConnection());
            cmd.Parameters.AddWithValue("@Id", id);
            return fetchResultTitle(cmd);
        }

        public List<Sub_Results> SelectSubResultsTitle()
        {
            SqlCommand cmd = new SqlCommand("Select * from sub_results order by id desc", DALUtil.getConnection());
            return fetchSubjectsResult(cmd);
        }

        private List<SubjectResults> fetchResultTitle(SqlCommand cmd)
        {
            SqlConnection con = cmd.Connection;
            List<SubjectResults> subjectresults = null;
            con.Open();
            using (con)
            {
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    subjectresults = new List<SubjectResults>();
                    while (dr.Read())
                    {
                        SubjectResults sr = new SubjectResults();
                        sr.Sub_r_id = Convert.ToString(dr["sub_r_id"]);
                        sr.Subresult = SelectResultTitleById(Convert.ToInt32(dr["sub_r_id"]));
                        subjectresults.Add(sr);
                    }
                    subjectresults.TrimExcess();
                }
            }
            return subjectresults;
        }

        public Sub_Results SelectResultTitleById(int rid)
        {
            SqlCommand cmd = new SqlCommand("Select * from sub_results where id=@Id", DALUtil.getConnection());
            cmd.Parameters.AddWithValue("@Id", rid);
            List<Sub_Results> temp = fetchSubjectsResult(cmd);
            return (temp != null) ? temp[0] : null;
        }

        private List<Sub_Results> fetchSubjectsResult(SqlCommand cmd)
        {
            SqlConnection con = cmd.Connection;
            List<Sub_Results> sub_results = null;
            con.Open();
            using (con)
            {
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    sub_results = new List<Sub_Results>();
                    while (dr.Read())
                    {
                        Sub_Results sr = new Sub_Results();
                        sr.id = Convert.ToString(dr["id"]);
                        sr.name = Convert.ToString(dr["name"]);
                        sub_results.Add(sr);
                    }
                    sub_results.TrimExcess();
                }
            }
            return sub_results;
        }

        public ResultsPositions SelectResultPositionByRidSid(int? sid, int? rid)
        {
            SqlCommand cmd = new SqlCommand("Select * from Position_in_rslt where sub_result_id=@Rid and student_id=@Sid", DALUtil.getConnection());
            cmd.Parameters.AddWithValue("@Sid", sid);
            cmd.Parameters.AddWithValue("@Rid", rid);
            List<ResultsPositions> temp = fetchResultPosition(cmd);
            return (temp != null) ? temp[0] : null;
        }

        private List<ResultsPositions> fetchResultPosition(SqlCommand cmd)
        {
            SqlConnection con = cmd.Connection;
            List<ResultsPositions> resultposition = null;
            con.Open();
            using (con)
            {
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    resultposition = new List<ResultsPositions>();
                    while (dr.Read())
                    {
                        ResultsPositions rp = new ResultsPositions();
                        rp.Id = Convert.ToString(dr["id"]);
                        rp.Student_id = Convert.ToString(dr["student_id"]);
                        rp.Class_Section = Convert.ToString(dr["class_section"]);
                        rp.Obtn_Pstn = Convert.ToString(dr["position"]);
                        resultposition.Add(rp);
                    }
                    resultposition.TrimExcess();
                }
            }
            return resultposition;
        }

        public List<SubjectResults> SelectResultsByStudentId(int id)
        {
            SqlCommand cmd = new SqlCommand("Select * from result_details where student_id=@Id", DALUtil.getConnection());
            cmd.Parameters.AddWithValue("@Id", id);
            return fetchSubjectsResultTitle(cmd);
        }

        public List<SubjectResults> SelectResultByRidSid(int sid , int rid)
        {
            SqlCommand cmd = new SqlCommand("Select * from result_details where sub_r_id=@Rid and student_id=@Sid", DALUtil.getConnection());
            cmd.Parameters.AddWithValue("@Sid", sid);
            cmd.Parameters.AddWithValue("@Rid", rid);
            return fetchSubjectsResultTitle(cmd);
        }

        public List<SubjectResults> SelectResultByRidSidForWeb(int? sid, int? rid)
        {
            SqlCommand cmd = new SqlCommand("Select * from result_details where sub_r_id=@Rid and student_id=@Sid", DALUtil.getConnection());
            cmd.Parameters.AddWithValue("@Sid", sid);
            cmd.Parameters.AddWithValue("@Rid", rid);
            return fetchSubjectsResultTitle(cmd);
        }

        private List<SubjectResults> fetchSubjectsResultTitle(SqlCommand cmd)
        {
            SqlConnection con = cmd.Connection;
            List<SubjectResults> subjectresults = null;
            con.Open();
            using (con)
            {
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    subjectresults = new List<SubjectResults>();
                    while (dr.Read())
                    {
                        SubjectResults sr = new SubjectResults();
                        sr.Id = Convert.ToString(dr["id"]);
                        sr.Sub_r_id = Convert.ToString(dr["sub_r_id"]);
                        sr.Student_id = Convert.ToString(dr["student_id"]);
                        sr.Subject_name = new SubjectsDAL().SelectById(Convert.ToInt32(dr["subject_id"]));
                        sr.Total_marks = new ResultsDAL().SelectSubjectTotalMarksWithIds(Convert.ToInt32(dr["subject_id"]), Convert.ToInt32(dr["sub_r_id"]));
                        sr.Obtn_marks = Convert.ToDouble(dr["obtain_marks"]);
                        sr.Status = Convert.ToInt32(dr["status"]);
                        subjectresults.Add(sr);
                    }
                    subjectresults.TrimExcess();
                }
            }
            return subjectresults;
        }

        public ClassLevels SelectClassLevel(int? id)
        {
            SqlCommand cmd = new SqlCommand("Select * from class_levels where Id=@Id", DALUtil.getConnection());
            cmd.Parameters.AddWithValue("@Id", id);
            List<ClassLevels> temp = fetchClsLvl(cmd);
            return (temp != null) ? temp[0] : null;
        }

        private List<ClassLevels> fetchClsLvl(SqlCommand cmd)
        {
            SqlConnection con = cmd.Connection;
            List<ClassLevels> class_level = null;
            con.Open();
            using (con)
            {
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    class_level = new List<ClassLevels>();
                    while (dr.Read())
                    {
                        ClassLevels cl = new ClassLevels();
                        cl.db_Id = Convert.ToString(dr["id"]);
                        cl.Name = Convert.ToString(dr["name"]);
                        class_level.Add(cl);
                    }
                    class_level.TrimExcess();
                }
            }
            return class_level;
        }
    }
}
