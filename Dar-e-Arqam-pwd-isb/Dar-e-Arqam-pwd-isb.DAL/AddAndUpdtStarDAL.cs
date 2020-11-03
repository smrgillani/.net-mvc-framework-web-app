using Dar_e_Arqam_pwd_isb.ENT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace Dar_e_Arqam_pwd_isb.DAL
{
    public class AddAndUpdtStarDAL
    {
        public void AddStar(Stars s)
        {
            SqlCommand cmd = new SqlCommand("INSERT into shining_stars (name,star_type,achvmnt,picture,date,month,year,time) VALUES (@Name,@Star_type,@Achievement,@Picture,@Date,@Month,@Year,@Time)", DALUtil.getConnection());
            cmd.Parameters.AddWithValue("@Name", (s.Name == null) ? Convert.DBNull : s.Name);
            cmd.Parameters.AddWithValue("@Star_type", (s.Star_type == null) ? Convert.DBNull : s.Star_type);
            cmd.Parameters.AddWithValue("@Achievement", (s.Achievement == null) ? Convert.DBNull : s.Achievement);
            cmd.Parameters.AddWithValue("@Picture", (s.Picture == null) ? Convert.DBNull : s.Picture);
            cmd.Parameters.AddWithValue("@Date", (s.Date == null) ? Convert.DBNull : s.Date);
            cmd.Parameters.AddWithValue("@Month", (s.Month == null) ? Convert.DBNull : s.Month);
            cmd.Parameters.AddWithValue("@Year", (s.Year == null) ? Convert.DBNull : s.Year);
            cmd.Parameters.AddWithValue("@Time", (s.Time == null) ? Convert.DBNull : s.Time);
            add_and_updt_stars(cmd);
        }
        public void UpdateStar(Stars us, int id)
        {
            SqlCommand cmd = new SqlCommand("Update shining_stars Set name=@Name , star_type=@Star_type , achvmnt=@Achievement Where id=@Id ", DALUtil.getConnection());
            cmd.Parameters.AddWithValue("@Id", id);
            cmd.Parameters.AddWithValue("@Name", (us.Name == null) ? Convert.DBNull : us.Name);
            cmd.Parameters.AddWithValue("@Star_type", (us.Star_type == null) ? Convert.DBNull : us.Star_type);
            cmd.Parameters.AddWithValue("@Achievement", (us.Achievement == null) ? Convert.DBNull : us.Achievement);
            add_and_updt_stars(cmd);
        }
        public void UpdateStar_img(Stars us, int id)
        {
            SqlCommand cmd = new SqlCommand("Update shining_stars Set name=@Name , star_type=@Star_type , achvmnt=@Achievement , picture=@Picture Where id=@Id ", DALUtil.getConnection());
            cmd.Parameters.AddWithValue("@Id", id);
            cmd.Parameters.AddWithValue("@Name", (us.Name == null) ? Convert.DBNull : us.Name);
            cmd.Parameters.AddWithValue("@Star_type", (us.Star_type == null) ? Convert.DBNull : us.Star_type);
            cmd.Parameters.AddWithValue("@Achievement", (us.Achievement == null) ? Convert.DBNull : us.Achievement);
            cmd.Parameters.AddWithValue("@Picture", (us.Picture == null) ? Convert.DBNull : us.Picture);
            add_and_updt_stars(cmd);
        }
        public void PublishStar(Stars pss, int id)
        {
            SqlCommand cmd = new SqlCommand("Update shining_stars Set publish=@Publish Where id = @Id", DALUtil.getConnection());
            cmd.Parameters.AddWithValue("@Id", id);
            cmd.Parameters.AddWithValue("@Publish", (pss.Publish == null) ? Convert.DBNull : pss.Publish);
            add_and_updt_stars(cmd);
        }

        public void DeleteStar(int id)
        {
            SqlCommand cmd = new SqlCommand("Delete From shining_stars Where id=@Id", DALUtil.getConnection());
            cmd.Parameters.AddWithValue("@Id", id);
            add_and_updt_stars(cmd);
        }

        internal void add_and_updt_stars(SqlCommand cmd)
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
