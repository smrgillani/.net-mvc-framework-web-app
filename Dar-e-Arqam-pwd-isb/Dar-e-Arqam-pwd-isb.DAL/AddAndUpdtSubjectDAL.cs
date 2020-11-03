using Dar_e_Arqam_pwd_isb.ENT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace Dar_e_Arqam_pwd_isb.DAL
{
    public class AddAndUpdtSubjectDAL
    {
        public void AddSubject(Subjects s)
        {
            SqlCommand cmd = new SqlCommand("INSERT into subjects (classlevel_id,name,date,month,year,time) VALUES (@Classlevel,@Name,@Date,@Month,@Year,@Time)", DALUtil.getConnection());
            cmd.Parameters.AddWithValue("@Classlevel", (s.ClassLevel == null) ? Convert.DBNull : s.ClassLevel);
            cmd.Parameters.AddWithValue("@Name", (s.Name == null) ? Convert.DBNull : s.Name);
            cmd.Parameters.AddWithValue("@Date", (s.Date == null) ? Convert.DBNull : s.Date);
            cmd.Parameters.AddWithValue("@Month", (s.Month == null) ? Convert.DBNull : s.Month);
            cmd.Parameters.AddWithValue("@Year", (s.Year == null) ? Convert.DBNull : s.Year);
            cmd.Parameters.AddWithValue("@Time", (s.Time == null) ? Convert.DBNull : s.Time);
            addsubject(cmd);
        }
        public void UpdateSubject(Subjects us,int id)
        {
            SqlCommand cmd = new SqlCommand("Update subjects Set classlevel_id=@Classlevel , name=@Name Where id=@Id", DALUtil.getConnection());
            cmd.Parameters.AddWithValue("@Id", id);
            cmd.Parameters.AddWithValue("@Classlevel", (us.ClassLevel == null) ? Convert.DBNull : us.ClassLevel);
            cmd.Parameters.AddWithValue("@Name", (us.Name == null) ? Convert.DBNull : us.Name);
            addsubject(cmd);
        }
        internal void addsubject(SqlCommand cmd)
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
