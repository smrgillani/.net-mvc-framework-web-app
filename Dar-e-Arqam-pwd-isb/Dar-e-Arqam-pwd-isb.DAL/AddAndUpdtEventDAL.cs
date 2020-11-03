using Dar_e_Arqam_pwd_isb.ENT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace Dar_e_Arqam_pwd_isb.DAL
{
    public class AddAndUpdtEventDAL
    {
        public void AddEvent(Events nu)
        {
            SqlCommand cmd = new SqlCommand("INSERT into events (name,detail,picture,date,month,year,time) VALUES (@Name,@Detail,@Picture,@Date,@Month,@Year,@Time)", DALUtil.getConnection());
            cmd.Parameters.AddWithValue("@Name", (nu.Name == null) ? Convert.DBNull : nu.Name);
            cmd.Parameters.AddWithValue("@Detail", (nu.Detail == null) ? Convert.DBNull : nu.Detail);
            cmd.Parameters.AddWithValue("@Picture", (nu.Picture == null) ? Convert.DBNull : nu.Picture);
            cmd.Parameters.AddWithValue("@Date", (nu.Date == null) ? Convert.DBNull : nu.Date);
            cmd.Parameters.AddWithValue("@Month", (nu.Month == null) ? Convert.DBNull : nu.Month);
            cmd.Parameters.AddWithValue("@Year", (nu.Year == null) ? Convert.DBNull : nu.Year);
            cmd.Parameters.AddWithValue("@Time", (nu.Time == null) ? Convert.DBNull : nu.Time);
            event_(cmd);
        }

        public void UpdateEvent(Events e, int id)
        {
            SqlCommand cmd = new SqlCommand("Update events Set name=@Name , detail=@Detail Where id = @Id", DALUtil.getConnection());
            cmd.Parameters.AddWithValue("@Id", id);
            cmd.Parameters.AddWithValue("@Name", (e.Name == null) ? Convert.DBNull : e.Name);
            cmd.Parameters.AddWithValue("@Detail", (e.Detail == null) ? Convert.DBNull : e.Detail);
            event_(cmd);
        }

        public void UpdateEvent_img(Events e, int id)
        {
            SqlCommand cmd = new SqlCommand("Update events Set name=@Name , detail=@Detail , picture=@Picture Where id = @Id", DALUtil.getConnection());
            cmd.Parameters.AddWithValue("@Id", id);
            cmd.Parameters.AddWithValue("@Name", (e.Name == null) ? Convert.DBNull : e.Name);
            cmd.Parameters.AddWithValue("@Detail", (e.Detail == null) ? Convert.DBNull : e.Detail);
            cmd.Parameters.AddWithValue("@Picture", (e.Picture == null) ? Convert.DBNull : e.Picture);
            event_(cmd);
        }

        public void PublishEvent(Events pe, int id)
        {
            SqlCommand cmd = new SqlCommand("Update events Set publish=@Publish Where id = @Id", DALUtil.getConnection());
            cmd.Parameters.AddWithValue("@Id", id);
            cmd.Parameters.AddWithValue("@Publish", (pe.Publish == null) ? Convert.DBNull : pe.Publish);
            event_(cmd);
        }

        public void DeleteEvent(int id)
        {
            SqlCommand cmd = new SqlCommand("Delete From events Where id=@Id", DALUtil.getConnection());
            cmd.Parameters.AddWithValue("@Id", id);
            event_(cmd);
        }

        internal void event_(SqlCommand cmd)
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
