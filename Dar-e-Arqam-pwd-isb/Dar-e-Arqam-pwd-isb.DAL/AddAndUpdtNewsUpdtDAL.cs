using Dar_e_Arqam_pwd_isb.ENT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace Dar_e_Arqam_pwd_isb.DAL
{
    public class AddAndUpdtNewsUpdtDAL
    {
        public void AddNewsUpdt(NewsUpdts nu)
        {
            SqlCommand cmd = new SqlCommand("INSERT into news_and_updts (name,detail,picture,date,month,year,time) VALUES (@Name,@Detail,@Picture,@Date,@Month,@Year,@Time)", DALUtil.getConnection());
            cmd.Parameters.AddWithValue("@Name", (nu.Name == null) ? Convert.DBNull : nu.Name);
            cmd.Parameters.AddWithValue("@Detail", (nu.Detail == null) ? Convert.DBNull : nu.Detail);
            cmd.Parameters.AddWithValue("@Picture", (nu.Picture == null) ? Convert.DBNull : nu.Picture);
            cmd.Parameters.AddWithValue("@Date", (nu.Date == null) ? Convert.DBNull : nu.Date);
            cmd.Parameters.AddWithValue("@Month", (nu.Month == null) ? Convert.DBNull : nu.Month);
            cmd.Parameters.AddWithValue("@Year", (nu.Year == null) ? Convert.DBNull : nu.Year);
            cmd.Parameters.AddWithValue("@Time", (nu.Time == null) ? Convert.DBNull : nu.Time);
            addnewsupdt_and_updt(cmd);
        }

        public void UpdateNewsUpdt(NewsUpdts nu,int id)
        {
            SqlCommand cmd = new SqlCommand("Update news_and_updts Set name=@Name , detail=@Detail Where id = @Id", DALUtil.getConnection());
            cmd.Parameters.AddWithValue("@Id", id);
            cmd.Parameters.AddWithValue("@Name", (nu.Name == null) ? Convert.DBNull : nu.Name);
            cmd.Parameters.AddWithValue("@Detail", (nu.Detail == null) ? Convert.DBNull : nu.Detail);
            addnewsupdt_and_updt(cmd);
        }

        public void UpdateNewsUpdt_img(NewsUpdts nu, int id)
        {
            SqlCommand cmd = new SqlCommand("Update news_and_updts Set name=@Name , detail=@Detail , picture=@Picture Where id = @Id", DALUtil.getConnection());
            cmd.Parameters.AddWithValue("@Id", id);
            cmd.Parameters.AddWithValue("@Name", (nu.Name == null) ? Convert.DBNull : nu.Name);
            cmd.Parameters.AddWithValue("@Detail", (nu.Detail == null) ? Convert.DBNull : nu.Detail);
            cmd.Parameters.AddWithValue("@Picture", (nu.Picture == null) ? Convert.DBNull : nu.Picture);
            addnewsupdt_and_updt(cmd);
        }

        public void PublishNewsUpdt(NewsUpdts pnu, int id)
        {
            SqlCommand cmd = new SqlCommand("Update news_and_updts Set publish=@Publish Where id = @Id", DALUtil.getConnection());
            cmd.Parameters.AddWithValue("@Id", id);
            cmd.Parameters.AddWithValue("@Publish", (pnu.Publish == null) ? Convert.DBNull : pnu.Publish);
            addnewsupdt_and_updt(cmd);
        }

        public void DeleteNewsUpdt(int id)
        {
            SqlCommand cmd = new SqlCommand("Delete From news_and_updts Where id=@Id", DALUtil.getConnection());
            cmd.Parameters.AddWithValue("@Id", id);
            addnewsupdt_and_updt(cmd);
        }

        internal void addnewsupdt_and_updt(SqlCommand cmd)
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
