using Dar_e_Arqam_pwd_isb.ENT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace Dar_e_Arqam_pwd_isb.DAL
{
    public class AddAndUpdtClassLevelDAL
    {
        public void AddClassLevel(ClassLevels cl)
        {
            SqlCommand cmd = new SqlCommand("INSERT into class_levels (name,range,date,month,year,time) VALUES (@Name,@Range,@Date,@Month,@Year,@Time)", DALUtil.getConnection());
            cmd.Parameters.AddWithValue("@Name", (cl.Name == null) ? Convert.DBNull : cl.Name);
            cmd.Parameters.AddWithValue("@Range", (cl.Range == null) ? Convert.DBNull : cl.Range);
            cmd.Parameters.AddWithValue("@Date", (cl.Date == null) ? Convert.DBNull : cl.Date);
            cmd.Parameters.AddWithValue("@Month", (cl.Month == null) ? Convert.DBNull : cl.Month);
            cmd.Parameters.AddWithValue("@Year", (cl.Year == null) ? Convert.DBNull : cl.Year);
            cmd.Parameters.AddWithValue("@Time", (cl.Time == null) ? Convert.DBNull : cl.Time);
            classlevel(cmd);
        }
        public void UpdateClassLevel(ClassLevels cl,int id)
        {
            SqlCommand cmd = new SqlCommand("UPDATE class_levels set name=@Name , range=@Range Where id=@Id", DALUtil.getConnection());
            cmd.Parameters.AddWithValue("@Id", id);
            cmd.Parameters.AddWithValue("@Name", (cl.Name == null) ? Convert.DBNull : cl.Name);
            cmd.Parameters.AddWithValue("@Range", (cl.Range == null) ? Convert.DBNull : cl.Range);
            classlevel(cmd);
        }

        public void DeleteClassLvl(int id)
        {
            SqlCommand cmd = new SqlCommand("Delete From class_levels Where id=@Id", DALUtil.getConnection());
            cmd.Parameters.AddWithValue("@Id", id);
            classlevel(cmd);
        }

        internal void classlevel(SqlCommand cmd)
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
