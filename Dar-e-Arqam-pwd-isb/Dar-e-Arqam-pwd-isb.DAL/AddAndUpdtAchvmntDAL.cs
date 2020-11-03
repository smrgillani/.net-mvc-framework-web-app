using Dar_e_Arqam_pwd_isb.ENT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace Dar_e_Arqam_pwd_isb.DAL
{
    public class AddAndUpdtAchvmntDAL
    {
        public void AddAchvmnt(Achvmnts a)
        {
            SqlCommand cmd = new SqlCommand("INSERT into achievements (name,detail,picture,date,month,year,time) VALUES (@Name,@Detail,@Picture,@Date,@Month,@Year,@Time)", DALUtil.getConnection());
            cmd.Parameters.AddWithValue("@Name", (a.Name == null) ? Convert.DBNull : a.Name);
            cmd.Parameters.AddWithValue("@Detail", (a.Detail == null) ? Convert.DBNull : a.Detail);
            cmd.Parameters.AddWithValue("@Picture", (a.Picture == null) ? Convert.DBNull : a.Picture);
            cmd.Parameters.AddWithValue("@Date", (a.Date == null) ? Convert.DBNull : a.Date);
            cmd.Parameters.AddWithValue("@Month", (a.Month == null) ? Convert.DBNull : a.Month);
            cmd.Parameters.AddWithValue("@Year", (a.Year == null) ? Convert.DBNull : a.Year);
            cmd.Parameters.AddWithValue("@Time", (a.Time == null) ? Convert.DBNull : a.Time);
            addachvmnt(cmd);
        }
        public void UpdateAchvmnt(Achvmnts ua, int id)
        {
            SqlCommand cmd = new SqlCommand("Update achievements Set name=@Name,detail=@Detail Where id=@Id", DALUtil.getConnection());
            cmd.Parameters.AddWithValue("@Id", id);
            cmd.Parameters.AddWithValue("@Name", (ua.Name == null) ? Convert.DBNull : ua.Name);
            cmd.Parameters.AddWithValue("@Detail", (ua.Detail == null) ? Convert.DBNull : ua.Detail);
            addachvmnt(cmd);
        }
        public void UpdateAchvmnt_img(Achvmnts ua, int id)
        {
            SqlCommand cmd = new SqlCommand("Update achievements Set name=@Name,detail=@Detail,picture=@Picture Where id=@Id", DALUtil.getConnection());
            cmd.Parameters.AddWithValue("@Id", id);
            cmd.Parameters.AddWithValue("@Name", (ua.Name == null) ? Convert.DBNull : ua.Name);
            cmd.Parameters.AddWithValue("@Detail", (ua.Detail == null) ? Convert.DBNull : ua.Detail);
            cmd.Parameters.AddWithValue("@Picture", (ua.Picture == null) ? Convert.DBNull : ua.Picture);
            addachvmnt(cmd);
        }
        public void PublishAchvmnt(Achvmnts pa, int id)
        {
            SqlCommand cmd = new SqlCommand("Update achievements Set publish=@Publish Where id = @Id", DALUtil.getConnection());
            cmd.Parameters.AddWithValue("@Id", id);
            cmd.Parameters.AddWithValue("@Publish", (pa.Publish == null) ? Convert.DBNull : pa.Publish);
            addachvmnt(cmd);
        }
        internal void addachvmnt(SqlCommand cmd)
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
