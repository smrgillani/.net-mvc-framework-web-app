using Dar_e_Arqam_pwd_isb.ENT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace Dar_e_Arqam_pwd_isb.DAL
{
    public class AddAndUpdtBookDAL
    {
        public void AddBook(Books b)
        {
            SqlCommand cmd = new SqlCommand("INSERT into books (name,class_subject_id,picture,trash,date,month,year,time) VALUES (@Name,@Class_subject_id,@Picture,'0',@Date,@Month,@Year,@Time)", DALUtil.getConnection());
            cmd.Parameters.AddWithValue("@Name", (b.Name == null) ? Convert.DBNull : b.Name);
            cmd.Parameters.AddWithValue("@Class_subject_id", (b.Class_subject_id == null) ? Convert.DBNull : b.Class_subject_id);
            cmd.Parameters.AddWithValue("@Picture", (b.Picture == null) ? Convert.DBNull : b.Picture);
            cmd.Parameters.AddWithValue("@Date", (b.Date == null) ? Convert.DBNull : b.Date);
            cmd.Parameters.AddWithValue("@Month", (b.Month == null) ? Convert.DBNull : b.Month);
            cmd.Parameters.AddWithValue("@Year", (b.Year == null) ? Convert.DBNull : b.Year);
            cmd.Parameters.AddWithValue("@Time", (b.Time == null) ? Convert.DBNull : b.Time);
            book(cmd);
        }
        public void UpdateBook(Books ub,int id)
        {
            SqlCommand cmd = new SqlCommand("Update books Set name=@Name , class_subject_id=@Class_subject_id Where id=@Id", DALUtil.getConnection());
            cmd.Parameters.AddWithValue("@Name", (ub.Name == null) ? Convert.DBNull : ub.Name);
            cmd.Parameters.AddWithValue("@Class_subject_id", (ub.Class_subject_id == null) ? Convert.DBNull : ub.Class_subject_id);
            book(cmd);
        }
        public void UpdateBook_img(Books ub, int id)
        {
            SqlCommand cmd = new SqlCommand("Update books Set name=@Name , class_subject_id=@Class_subject_id , picture=@Picture Where id=@Id", DALUtil.getConnection());
            cmd.Parameters.AddWithValue("@Name", (ub.Name == null) ? Convert.DBNull : ub.Name);
            cmd.Parameters.AddWithValue("@Class_subject_id", (ub.Class_subject_id == null) ? Convert.DBNull : ub.Class_subject_id);
            cmd.Parameters.AddWithValue("@Picture", (ub.Picture == null) ? Convert.DBNull : ub.Picture);
            book(cmd);
        }
        public void PublishBook(Books pb, int id)
        {
            SqlCommand cmd = new SqlCommand("Update books Set publish=@Publish Where id = @Id", DALUtil.getConnection());
            cmd.Parameters.AddWithValue("@Id", id);
            cmd.Parameters.AddWithValue("@Publish", (pb.Publish == null) ? Convert.DBNull : pb.Publish);
            book(cmd);
        }
        public void DeleteBook(int id)
        {
            SqlCommand cmd = new SqlCommand("Delete From books Where id=@Id", DALUtil.getConnection());
            cmd.Parameters.AddWithValue("@Id", id);
            book(cmd);
        }
        internal void book(SqlCommand cmd)
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
