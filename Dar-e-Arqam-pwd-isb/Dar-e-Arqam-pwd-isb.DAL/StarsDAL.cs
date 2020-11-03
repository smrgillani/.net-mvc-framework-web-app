using Dar_e_Arqam_pwd_isb.ENT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace Dar_e_Arqam_pwd_isb.DAL
{
    public class StarsDAL
    {
        public List<Stars> SelectAllStars()
        {
            SqlCommand cmd = new SqlCommand("Select * from shining_stars order by id", DALUtil.getConnection());
            return fetchStars(cmd);
        }

        public List<Stars> SelectAllStarsForWeb()
        {
            SqlCommand cmd = new SqlCommand("Select * from shining_stars where publish = '2' order by id", DALUtil.getConnection());
            return fetchStars(cmd);
        }

        public List<Stars> SelectBySearch(string Search_key)
        {
            SqlCommand cmd = new SqlCommand("Select * from shining_stars where name=@Search", DALUtil.getConnection());
            cmd.Parameters.AddWithValue("@Search", Search_key);
            return fetchStars(cmd);
        }

        public Stars SelectById(int id)
        {
            SqlCommand cmd = new SqlCommand("Select * from shining_stars where Id=@Id", DALUtil.getConnection());
            cmd.Parameters.AddWithValue("@Id", id);
            List<Stars> temp = fetchStars(cmd);
            return (temp != null) ? temp[0] : null;
        }

        private List<Stars> fetchStars(SqlCommand cmd)
        {
            SqlConnection con = cmd.Connection;
            List<Stars> stars = null;
            con.Open();
            using (con)
            {
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    stars = new List<Stars>();
                    while (dr.Read())
                    {
                        Stars s = new Stars();
                        s.db_Id = Convert.ToString(dr["id"]);
                        s.Name = Convert.ToString(dr["name"]);
                        s.Star_type = Convert.ToString(dr["star_type"]);
                        s.Achievement = Convert.ToString(dr["achvmnt"]);
                        s.Picture = Convert.ToString(dr["picture"]);
                        s.Publish = Convert.ToString(dr["publish"]);
                        stars.Add(s);
                    }
                    stars.TrimExcess();
                }
            }
            return stars;
        }
    }
}
