using Dar_e_Arqam_pwd_isb.ENT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace Dar_e_Arqam_pwd_isb.DAL
{
    public class NewsAndUptsDAL
    {
        public List<NewsUpdts> SelectAllNewsAndUpdts()
        {
            SqlCommand cmd = new SqlCommand("Select * from news_and_updts order by id", DALUtil.getConnection());
            return fetchNewsAndUpdts(cmd);
        }

        public List<NewsUpdts> SelectAllNewsAndUpdtsForWeb()
        {
            SqlCommand cmd = new SqlCommand("Select * from news_and_updts where publish = '2' order by id desc ", DALUtil.getConnection());
            return fetchNewsAndUpdts(cmd);
        }

        public NewsUpdts SelectByIdForWeb(int? id)
        {
            SqlCommand cmd = new SqlCommand("Select * from news_and_updts where Id=@Id and publish = '2'", DALUtil.getConnection());
            cmd.Parameters.AddWithValue("@Id", id);
            List<NewsUpdts> temp = fetchNewsAndUpdts(cmd);
            return (temp != null) ? temp[0] : null;
        }

        public List<NewsUpdts> SelectBySearch(string Search_key)
        {
            SqlCommand cmd = new SqlCommand("Select * from news_and_updts where name=@Search", DALUtil.getConnection());
            cmd.Parameters.AddWithValue("@Search", Search_key);
            return fetchNewsAndUpdts(cmd);
        }

        public NewsUpdts SelectById(int id)
        {
            SqlCommand cmd = new SqlCommand("Select * from news_and_updts where Id=@Id", DALUtil.getConnection());
            cmd.Parameters.AddWithValue("@Id", id);
            List<NewsUpdts> temp = fetchNewsAndUpdts(cmd);
            return (temp != null) ? temp[0] : null;
        }

        private List<NewsUpdts> fetchNewsAndUpdts(SqlCommand cmd)
        {
            SqlConnection con = cmd.Connection;
            List<NewsUpdts> newsandupdts = null;
            con.Open();
            using (con)
            {
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    newsandupdts = new List<NewsUpdts>();
                    while (dr.Read())
                    {
                        NewsUpdts nau = new NewsUpdts();
                        nau.db_Id = Convert.ToString(dr["id"]);
                        nau.Name = Convert.ToString(dr["name"]);
                        nau.Picture = Convert.ToString(dr["picture"]);
                        nau.Detail = Convert.ToString(dr["detail"]);
                        nau.Publish = Convert.ToString(dr["publish"]);
                        nau.Date = Convert.ToString(dr["Date"]);
                        nau.Month = Convert.ToString(dr["Month"]);
                        nau.Year = Convert.ToString(dr["Year"]);
                        nau.Time = Convert.ToString(dr["Time"]);
                        newsandupdts.Add(nau);
                    }
                    newsandupdts.TrimExcess();
                }
            }
            return newsandupdts;
        }
    }
}
