using Dar_e_Arqam_pwd_isb.ENT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace Dar_e_Arqam_pwd_isb.DAL
{
    public class ResultsDAL
    {
        public List<Results> SelectAllResults()
        {
            SqlCommand cmd = new SqlCommand("Select * from results order by id", DALUtil.getConnection());
            return fetchResults(cmd);
        }

        public List<Sub_Results> SelectAllSubResults()
        {
            SqlCommand cmd = new SqlCommand("Select * from sub_results order by id", DALUtil.getConnection());
            return fetchSubResults(cmd);
        }

        public List<Sub_Results> SelectAllSubResultsForWeb()
        {
            SqlCommand cmd = new SqlCommand("Select * from sub_results where publish = '2' order by id", DALUtil.getConnection());
            return fetchSubResults(cmd);
        }

        public Sub_Results SelectAllSubResultsForWeb(int? id)
        {
            SqlCommand cmd = new SqlCommand("Select * from sub_results where id=@Id and publish = '2' order by id", DALUtil.getConnection());
            cmd.Parameters.AddWithValue("@Id", id);
            List<Sub_Results> temp = fetchSubResults(cmd);
            return (temp != null) ? temp[0] : null;
        }

        public Sub_Results SelectSubResult(int? id)
        {
            SqlCommand cmd = new SqlCommand("Select * from sub_results where id=@Id order by id", DALUtil.getConnection());
            cmd.Parameters.AddWithValue("@Id", id);
            List<Sub_Results> temp = fetchSubResults(cmd);
            return (temp != null) ? temp[0] : null;
        }

        public List<Sub_Results> SelectAllSubResults(int id)
        {
            SqlCommand cmd = new SqlCommand("Select * from sub_results where r_id=@Id order by id", DALUtil.getConnection());
            cmd.Parameters.AddWithValue("@Id", id);
            return fetchSubResults(cmd);
        }

        public List<Results> SelectBySearch(string Search_key)
        {
            SqlCommand cmd = new SqlCommand("Select * from results where session_year=@Search", DALUtil.getConnection());
            cmd.Parameters.AddWithValue("@Search", Search_key);
            return fetchResults(cmd);
        }

        public Results SelectById(int id)
        {
            SqlCommand cmd = new SqlCommand("Select * from results where Id=@Id", DALUtil.getConnection());
            cmd.Parameters.AddWithValue("@Id", id);
            List<Results> temp = fetchResults(cmd);
            return (temp != null) ? temp[0] : null;
        }

        private List<Results> fetchResults(SqlCommand cmd)
        {
            SqlConnection con = cmd.Connection;
            List<Results> results = null;
            con.Open();
            using (con)
            {
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    results = new List<Results>();
                    while (dr.Read())
                    {
                        Results r = new Results();
                        r.db_Id = Convert.ToString(dr["id"]);
                        r.Session_year = Convert.ToString(dr["session_year"]);
                        results.Add(r);
                    }
                    results.TrimExcess();
                }
            }
            return results;
        }

        private List<Sub_Results> fetchSubResults(SqlCommand cmd)
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
                        sr.Publish = Convert.ToString(dr["publish"]);
                        sr.S_id = SelectResultTitleById(Convert.ToInt32(dr["r_id"]));
                        sub_results.Add(sr);
                    }
                    sub_results.TrimExcess();
                }
            }
            return sub_results;
        }

        public Results SelectResultTitleById(int mrid)
        {
            SqlCommand cmd = new SqlCommand("Select * from results where id=@Id", DALUtil.getConnection());
            cmd.Parameters.AddWithValue("@Id", mrid);
            List<Results> temp = fetchSubjectsResult(cmd);
            return (temp != null) ? temp[0] : null;
        }

        private List<Results> fetchSubjectsResult(SqlCommand cmd)
        {
            SqlConnection con = cmd.Connection;
            List<Results> results = null;
            con.Open();
            using (con)
            {
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    results = new List<Results>();
                    while (dr.Read())
                    {
                        Results r = new Results();
                        if (dr["id"] == null)
                        {
                            r.db_Id = "null";
                        }
                        else
                        {
                            r.db_Id = Convert.ToString(dr["id"]);
                        }
                        r.Session_year = Convert.ToString(dr["session_year"]);
                        results.Add(r);
                    }
                    results.TrimExcess();
                }
            }
            return results;
        }

        public List<Sub_Results> SelectSubResultsWithDetail(int id, int sid)
        {
            SqlCommand cmd = new SqlCommand("Select * from sub_results where r_id=@Id order by id", DALUtil.getConnection());
            cmd.Parameters.AddWithValue("@Id", id);
            return fetchSubResultsWithDetail(cmd , sid);
        }

        private List<Sub_Results> fetchSubResultsWithDetail(SqlCommand cmd , int sid)
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
                        sr.Publish = Convert.ToString(dr["publish"]);
                        sr.Percentage = Convert.ToDouble(dr["percentage"]);
                        sr.S_r= SelectResultByRidSid_(Convert.ToInt32(dr["id"]), sid);
                        sub_results.Add(sr);
                    }
                    sub_results.TrimExcess();
                }
            }
            return sub_results;
        }

        public List<SubjectResults> SelectResultByRidSid_(int rid, int sid)
        {
            SqlCommand cmd = new SqlCommand("Select * from result_details where sub_r_id=@Rid and student_id=@Sid", DALUtil.getConnection());
            //SqlCommand cmd = new SqlCommand("Select * from result_details where sub_r_id=1 and student_id=1", DALUtil.getConnection());
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
                        sr.Obtn_marks = Convert.ToDouble(dr["obtain_marks"]);
                        sr.Status = Convert.ToInt32(dr["status"]);
                        subjectresults.Add(sr);
                    }
                    subjectresults.TrimExcess();
                }
            }
            return subjectresults;
        }


        public List<Sub_Results> SelectSubResultsWithDetailForWeb(int id, int sid)
        {
            SqlCommand cmd = new SqlCommand("Select * from sub_results where r_id=@Id and publish ='2' order by id", DALUtil.getConnection());
            cmd.Parameters.AddWithValue("@Id", id);
            return fetchSubResultsWithDetailWeb(cmd, sid);
        }

        private List<Sub_Results> fetchSubResultsWithDetailWeb(SqlCommand cmd, int sid)
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
                        sr.Publish = Convert.ToString(dr["publish"]);
                        sr.Percentage = Convert.ToDouble(dr["percentage"]);
                        sr.S_r = SelectResultByRidSid_ForWeb(Convert.ToInt32(dr["id"]), sid);
                        sub_results.Add(sr);
                    }
                    sub_results.TrimExcess();
                }
            }
            return sub_results;
        }

        public List<SubjectResults> SelectResultByRidSid_ForWeb(int rid, int sid)
        {
            SqlCommand cmd = new SqlCommand("Select * from result_details where sub_r_id=@Rid and student_id=@Sid", DALUtil.getConnection());
            //SqlCommand cmd = new SqlCommand("Select * from result_details where sub_r_id=1 and student_id=1", DALUtil.getConnection());
            cmd.Parameters.AddWithValue("@Sid", sid);
            cmd.Parameters.AddWithValue("@Rid", rid);
            return fetchSubjectsResultTitle_ForWeb(cmd);
        }

        private List<SubjectResults> fetchSubjectsResultTitle_ForWeb(SqlCommand cmd)
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
                        sr.Subject_id = Convert.ToString(dr["subject_id"]);
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

        public List<SubjectsTotalMarks> SelectAllSubjectsTotalMarksWithIds(int id, int rid)
        {
            SqlCommand cmd = new SqlCommand("Select * from rslt_sbjcts_ttl_mrks where class_id=@Id and sub_r_id=@R_id", DALUtil.getConnection());
            cmd.Parameters.AddWithValue("@Id", id);
            cmd.Parameters.AddWithValue("@R_id", rid);
            return fetchSubjectsTotalMarks(cmd);
        }

        public List<SubjectsTotalMarks> SelectAllSubjectsTotalMarks()
        {
            SqlCommand cmd = new SqlCommand("Select * from rslt_sbjcts_ttl_mrks", DALUtil.getConnection());
            return fetchSubjectsTotalMarks(cmd);
        }

        public SubjectsTotalMarks SelectSubjectTotalMarksWithIds(int sid,int rid)
        {
            SqlCommand cmd = new SqlCommand("Select * from rslt_sbjcts_ttl_mrks where subject_id=@Sid and sub_r_id=@Rid ", DALUtil.getConnection());
            cmd.Parameters.AddWithValue("@Sid", sid);
            cmd.Parameters.AddWithValue("@Rid", rid);
            List<SubjectsTotalMarks> temp = fetchSubjectsTotalMarks(cmd);
            return (temp != null) ? temp[0] : null;
        }

        private List<SubjectsTotalMarks> fetchSubjectsTotalMarks(SqlCommand cmd)
        {
            SqlConnection con = cmd.Connection;
            List<SubjectsTotalMarks> subjectstotalmarks = null;
            con.Open();
            using (con)
            {
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    subjectstotalmarks = new List<SubjectsTotalMarks>();
                    while (dr.Read())
                    {
                        SubjectsTotalMarks sr = new SubjectsTotalMarks();
                        sr.Id = Convert.ToString(dr["id"]);
                        sr.Class_id = Convert.ToString(dr["class_id"]);
                        sr.R_id = Convert.ToString(dr["sub_r_id"]);
                        sr.Subject_id = Convert.ToString(dr["subject_id"]);
                        sr.Subject_name = new SubjectsDAL().SelectById(Convert.ToInt32(dr["subject_id"]));
                        sr.Total_marks = Convert.ToDouble(dr["total_marks"]);
                        subjectstotalmarks.Add(sr);
                    }
                    subjectstotalmarks.TrimExcess();
                }
            }
            return subjectstotalmarks;
        }

    }
}
