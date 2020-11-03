using Dar_e_Arqam_pwd_isb.ENT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace Dar_e_Arqam_pwd_isb.DAL
{
    public class AddAndUpdtDiarySubjectDAL
    {
        public void AddSubjectDiary(Diaries_Contxts dc)
        {
            SqlCommand cmd = new SqlCommand("INSERT into diary_subjects (sid,did,subject_name,subject_diary_text,type,date,month,year,time) VALUES (@Section_id,@Diary_id,@Subject_name,@Contxt,@Type,@Date,@Month,@Year,@Time)", DALUtil.getConnection());
            cmd.Parameters.AddWithValue("@Section_id", (dc.Section_id == null) ? Convert.DBNull : dc.Section_id);
            cmd.Parameters.AddWithValue("@Diary_id", (dc.Diary_id == null) ? Convert.DBNull : dc.Diary_id);
            cmd.Parameters.AddWithValue("@Subject_name", (dc.Subject_name == null) ? Convert.DBNull : dc.Subject_name);
            cmd.Parameters.AddWithValue("@Contxt", (dc.Contxt == null) ? Convert.DBNull : dc.Contxt);
            cmd.Parameters.AddWithValue("@Type", (dc.Type == null) ? Convert.DBNull : dc.Type);
            cmd.Parameters.AddWithValue("@Date", (dc.Date == null) ? Convert.DBNull : dc.Date);
            cmd.Parameters.AddWithValue("@Month", (dc.Month == null) ? Convert.DBNull : dc.Month);
            cmd.Parameters.AddWithValue("@Year", (dc.Year == null) ? Convert.DBNull : dc.Year);
            cmd.Parameters.AddWithValue("@Time", (dc.Time == null) ? Convert.DBNull : dc.Time);
            subjectdiary_(cmd);
        }

        public void UpdateSubjectDiary(Diaries_Contxts dc, int id)
        {
            SqlCommand cmd = new SqlCommand("Update diary_subjects Set subject_name=@Subject_name , subject_diary_text=@Contxt Where id = @Id", DALUtil.getConnection());
            cmd.Parameters.AddWithValue("@Id", id);
            cmd.Parameters.AddWithValue("@Subject_name", (dc.Subject_name == null) ? Convert.DBNull : dc.Subject_name);
            cmd.Parameters.AddWithValue("@Contxt", (dc.Contxt == null) ? Convert.DBNull : dc.Contxt);
            subjectdiary_(cmd);
        }
        public void DeleteSubjectDiary(int id)
        {
            SqlCommand cmd = new SqlCommand("Delete From diary_subjects Where id=@Id", DALUtil.getConnection());
            cmd.Parameters.AddWithValue("@Id", id);
            subjectdiary_(cmd);
        }

        internal void subjectdiary_(SqlCommand cmd)
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
