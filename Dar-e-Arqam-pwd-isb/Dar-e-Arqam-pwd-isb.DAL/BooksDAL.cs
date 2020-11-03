using Dar_e_Arqam_pwd_isb.ENT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace Dar_e_Arqam_pwd_isb.DAL
{
    public class BooksDAL
    {
        public List<Books> SelectAllBooks()
        {
            SqlCommand cmd = new SqlCommand("Select * from books order by id desc", DALUtil.getConnection());
            return fetchBooks(cmd);
        }

        public List<Books> SelectAllActiveBooks()
        {
            SqlCommand cmd = new SqlCommand("Select * from books where publish = '2' and trash = '0' order by id desc", DALUtil.getConnection());
            return fetchBooks(cmd);
        }

        public List<Books> SelectBySearch(string Search_key)
        {
            SqlCommand cmd = new SqlCommand("Select * from books where name=@Search", DALUtil.getConnection());
            cmd.Parameters.AddWithValue("@Search", Search_key);
            return fetchBooks(cmd);
        }

        public Books SelectById(int id)
        {
            SqlCommand cmd = new SqlCommand("Select * from books where Id=@Id", DALUtil.getConnection());
            cmd.Parameters.AddWithValue("@Id", id);
            List<Books> temp = fetchBooks(cmd);
            return (temp != null) ? temp[0] : null;
        }

        private List<Books> fetchBooks(SqlCommand cmd)
        {
            SqlConnection con = cmd.Connection;
            List<Books> books = null;
            con.Open();
            using (con)
            {
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    books = new List<Books>();
                    while (dr.Read())
                    {
                        Books b = new Books();
                        b.db_Id = Convert.ToString(dr["id"]);
                        b.Name = Convert.ToString(dr["name"]);
                        b.Class_name = new StudentDAL().SelectClassLevel(Convert.ToInt32(dr["class_subject_id"]));
                        b.Picture = Convert.ToString(dr["picture"]);
                        b.Publish = Convert.ToString(dr["publish"]);
                        books.Add(b);
                    }
                    books.TrimExcess();
                }
            }
            return books;
        }
    }
}
