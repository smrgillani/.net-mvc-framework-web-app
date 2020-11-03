using Dar_e_Arqam_pwd_isb.ENT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace Dar_e_Arqam_pwd_isb.DAL
{
    public class AddAndUpdtSyllabusDAL
    {
        public void AddSyllabus(Syllabuses s)
        {
            SqlCommand cmd = new SqlCommand("INSERT into syllabus (name_of_lvl,detail_of_syllabus,date,month,year,time) VALUES (@Name_of_lvl,@Detail_of_syllabus,@Date,@Month,@Year,@Time)", DALUtil.getConnection());
            cmd.Parameters.AddWithValue("@Name_of_lvl", (s.Name_of_lvl == null) ? Convert.DBNull : s.Name_of_lvl);
            cmd.Parameters.AddWithValue("@Detail_of_syllabus", (s.Detail_of_syllabus == null) ? Convert.DBNull : s.Detail_of_syllabus);
            cmd.Parameters.AddWithValue("@Date", (s.Date == null) ? Convert.DBNull : s.Date);
            cmd.Parameters.AddWithValue("@Month", (s.Month == null) ? Convert.DBNull : s.Month);
            cmd.Parameters.AddWithValue("@Year", (s.Year == null) ? Convert.DBNull : s.Year);
            cmd.Parameters.AddWithValue("@Time", (s.Time == null) ? Convert.DBNull : s.Time);
            addsyllabus(cmd);
        }
        public void UpdateSyllabus(Syllabuses us,int id)
        {
            SqlCommand cmd = new SqlCommand("Update syllabus Set name_of_lvl=@Name_of_lvl , detail_of_syllabus=@Detail_of_syllabus Where id=@Id", DALUtil.getConnection());
            cmd.Parameters.AddWithValue("@Id", id);
            cmd.Parameters.AddWithValue("@Name_of_lvl", (us.Name_of_lvl == null) ? Convert.DBNull : us.Name_of_lvl);
            cmd.Parameters.AddWithValue("@Detail_of_syllabus", (us.Detail_of_syllabus == null) ? Convert.DBNull : us.Detail_of_syllabus);
            addsyllabus(cmd);
        }

        public void PublishSyllabus(Syllabuses ps, int id)
        {
            SqlCommand cmd = new SqlCommand("Update syllabus Set publish=@Publish Where id = @Id", DALUtil.getConnection());
            cmd.Parameters.AddWithValue("@Id", id);
            cmd.Parameters.AddWithValue("@Publish", (ps.Publish == null) ? Convert.DBNull : ps.Publish);
            addsyllabus(cmd);
        }

        internal void addsyllabus(SqlCommand cmd)
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
