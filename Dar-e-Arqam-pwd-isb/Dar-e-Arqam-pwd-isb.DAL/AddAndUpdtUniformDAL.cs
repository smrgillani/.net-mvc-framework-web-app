using Dar_e_Arqam_pwd_isb.ENT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace Dar_e_Arqam_pwd_isb.DAL
{
    public class AddAndUpdtUniformDAL
    {
        public void AddUniform(Uniforms u)
        {
            SqlCommand cmd = new SqlCommand("INSERT into uniform (name,class_lvl_id,picture,date,month,year,time) VALUES (@Name,@Class_lvl_id,@Picture,@Date,@Month,@Year,@Time)", DALUtil.getConnection());
            cmd.Parameters.AddWithValue("@Name", (u.Name == null) ? Convert.DBNull : u.Name);
            cmd.Parameters.AddWithValue("@Class_lvl_id", (u.Class_lvl_id == null) ? Convert.DBNull : u.Class_lvl_id);
            cmd.Parameters.AddWithValue("@Picture", (u.Picture == null) ? Convert.DBNull : u.Picture);
            cmd.Parameters.AddWithValue("@Date", (u.Date == null) ? Convert.DBNull : u.Date);
            cmd.Parameters.AddWithValue("@Month", (u.Month == null) ? Convert.DBNull : u.Month);
            cmd.Parameters.AddWithValue("@Year", (u.Year == null) ? Convert.DBNull : u.Year);
            cmd.Parameters.AddWithValue("@Time", (u.Time == null) ? Convert.DBNull : u.Time);
            uniform(cmd);
        }
        public void UpdateUniform(Uniforms uu, int id)
        {
            SqlCommand cmd = new SqlCommand("Update uniform Set name=@Name , class_lvl_id=@Class_lvl_id Where id=@Id", DALUtil.getConnection());
            cmd.Parameters.AddWithValue("@Id", id);
            cmd.Parameters.AddWithValue("@Name", (uu.Name == null) ? Convert.DBNull : uu.Name);
            cmd.Parameters.AddWithValue("@Class_lvl_id", (uu.Name == null) ? Convert.DBNull : uu.Class_lvl_id);
            uniform(cmd);
        }
        public void UpdateUniform_img(Uniforms uu, int id)
        {
            SqlCommand cmd = new SqlCommand("Update uniform Set name=@Name , class_lvl_id=@Class_lvl_id , picture=@Picture Where id=@Id", DALUtil.getConnection());
            cmd.Parameters.AddWithValue("@Id", id);
            cmd.Parameters.AddWithValue("@Name", (uu.Name == null) ? Convert.DBNull : uu.Name);
            cmd.Parameters.AddWithValue("@Class_lvl_id", (uu.Name == null) ? Convert.DBNull : uu.Class_lvl_id);
            cmd.Parameters.AddWithValue("@Picture", (uu.Picture == null) ? Convert.DBNull : uu.Picture);
            uniform(cmd);
        }

        public void PublishUniform(Uniforms pu, int id)
        {
            SqlCommand cmd = new SqlCommand("Update uniform Set publish=@Publish Where id = @Id", DALUtil.getConnection());
            cmd.Parameters.AddWithValue("@Id", id);
            cmd.Parameters.AddWithValue("@Publish", (pu.Publish == null) ? Convert.DBNull : pu.Publish);
            uniform(cmd);
        }

        public void DeleteUniform(int id)
        {
            SqlCommand cmd = new SqlCommand("Delete From uniform Where id=@Id", DALUtil.getConnection());
            cmd.Parameters.AddWithValue("@Id", id);
            uniform(cmd);
        }

        internal void uniform(SqlCommand cmd)
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
