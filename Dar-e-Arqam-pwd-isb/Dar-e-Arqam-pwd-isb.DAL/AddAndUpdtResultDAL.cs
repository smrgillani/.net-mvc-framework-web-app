using Dar_e_Arqam_pwd_isb.ENT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace Dar_e_Arqam_pwd_isb.DAL
{
    public class AddAndUpdtResultDAL
    {
        public void AddResult(Results r)
        {
            SqlCommand cmd = new SqlCommand("INSERT into results (session_year,date,month,year,time) VALUES (@Session_year,@Date,@Month,@Year,@Time)", DALUtil.getConnection());
            cmd.Parameters.AddWithValue("@Session_year", (r.Session_year == null) ? Convert.DBNull : r.Session_year);
            cmd.Parameters.AddWithValue("@Date", (r.Date == null) ? Convert.DBNull : r.Date);
            cmd.Parameters.AddWithValue("@Month", (r.Month == null) ? Convert.DBNull : r.Month);
            cmd.Parameters.AddWithValue("@Year", (r.Year == null) ? Convert.DBNull : r.Year);
            cmd.Parameters.AddWithValue("@Time", (r.Time == null) ? Convert.DBNull : r.Time);
            addresult(cmd);
        }
        public void UpdateResult(Results ur, int id)
        {
            SqlCommand cmd = new SqlCommand("Update results Set session_year=@Session_year Where id=@Id", DALUtil.getConnection());
            cmd.Parameters.AddWithValue("@Id", id);
            cmd.Parameters.AddWithValue("@Session_year", (ur.Session_year == null) ? Convert.DBNull : ur.Session_year);
            addresult(cmd);
        }

        public void AddSubResult(Sub_Results sr, int Id)
        {
            SqlCommand cmd = new SqlCommand("INSERT into sub_results (r_id,name,date,month,year,time) VALUES (@Id,@Name,@Date,@Month,@Year,@Time)", DALUtil.getConnection());
            cmd.Parameters.AddWithValue("@Id", Id);
            cmd.Parameters.AddWithValue("@Name", (sr.name == null) ? Convert.DBNull : sr.name);
            cmd.Parameters.AddWithValue("@Date", (sr.Date == null) ? Convert.DBNull : sr.Date);
            cmd.Parameters.AddWithValue("@Month", (sr.Month == null) ? Convert.DBNull : sr.Month);
            cmd.Parameters.AddWithValue("@Year", (sr.Year == null) ? Convert.DBNull : sr.Year);
            cmd.Parameters.AddWithValue("@Time", (sr.Time == null) ? Convert.DBNull : sr.Time);
            addresult(cmd);
        }
        public void UpdateSubResult(Sub_Results usr, int id)
        {
            SqlCommand cmd = new SqlCommand("Update sub_results Set name=@Name Where id=@Id", DALUtil.getConnection());
            cmd.Parameters.AddWithValue("@Id", id);
            cmd.Parameters.AddWithValue("@Name", (usr.name== null) ? Convert.DBNull : usr.name);
            addresult(cmd);
        }
        public void AddSubjectsTotalMarksForResult(SubjectsTotalMarks r)
        {

            SqlCommand cmd = new SqlCommand("INSERT into rslt_sbjcts_ttl_mrks (class_id,sub_r_id,subject_id,total_marks,date,month,year,time) VALUES (@Class_id,@R_id,@Subject_id,@Total_marks,@Date,@Month,@Year,@Time)", DALUtil.getConnection());
            cmd.Parameters.AddWithValue("@Subject_id", (r.Subject_id == null) ? Convert.DBNull : r.Subject_id);
            cmd.Parameters.AddWithValue("@Class_id", (r.Class_id == null) ? Convert.DBNull : r.Class_id);
            cmd.Parameters.AddWithValue("@R_id", (r.R_id == null) ? Convert.DBNull : r.R_id);
            cmd.Parameters.AddWithValue("@Total_marks", r.Total_marks);
            cmd.Parameters.AddWithValue("@Date", (r.Date == null) ? Convert.DBNull : r.Date);
            cmd.Parameters.AddWithValue("@Month", (r.Month == null) ? Convert.DBNull : r.Month);
            cmd.Parameters.AddWithValue("@Year", (r.Year == null) ? Convert.DBNull : r.Year);
            cmd.Parameters.AddWithValue("@Time", (r.Time == null) ? Convert.DBNull : r.Time);
            addresult(cmd);
        }
        public void UpdateSubjectsTotalMarksForResult(List<SubjectsTotalMarks> r)
        {

            foreach (SubjectsTotalMarks pdr in r)
            {
                SqlCommand cmd = new SqlCommand("Update rslt_sbjcts_ttl_mrks Set total_marks=@Total_marks Where id=@Id", DALUtil.getConnection());
                cmd.Parameters.AddWithValue("@Total_marks", pdr.Total_marks);
                cmd.Parameters.AddWithValue("@Id", (pdr.Id == null) ? Convert.DBNull : pdr.Id);
                addresult(cmd);
            }

        }
        public void PublishSubResult(Sub_Results pr, int id)
        {
            SqlCommand cmd = new SqlCommand("Update sub_results Set publish=@Publish_result Where id=@Id", DALUtil.getConnection());
            cmd.Parameters.AddWithValue("@Id", id);
            cmd.Parameters.AddWithValue("@Publish_result", (pr.Publish== null) ? Convert.DBNull : pr.Publish);
            addresult(cmd);
        }
        public void DeleteSubjectsTotalMarks(int id,int rid)
        {
            SqlCommand cmd = new SqlCommand("Delete From rslt_sbjcts_ttl_mrks Where class_id=@Id and sub_r_id = @R_id", DALUtil.getConnection());
            cmd.Parameters.AddWithValue("@Id", id);
            cmd.Parameters.AddWithValue("@R_id", rid);
            addresult(cmd);
        }
        internal void addresult(SqlCommand cmd)
        {
            SqlConnection con = cmd.Connection;
            con.Open();
            using (con)
            {
                cmd.ExecuteNonQuery();
            }
        }
    }
}
