using Dar_e_Arqam_pwd_isb.ENT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace Dar_e_Arqam_pwd_isb.DAL
{
    public class AchvmntsDAL
    {
        public List<Achvmnts> SelectAllAchvmnts()
        {
            SqlCommand cmd = new SqlCommand("Select * from achievements order by id", DALUtil.getConnection());
            return fetchAchvmnts(cmd);
        }

        public List<Achvmnts> AllAchvmntsForWeb()
        {
            SqlCommand cmd = new SqlCommand("Select * from achievements where publish = '2' order by id", DALUtil.getConnection());
            return fetchAchvmnts(cmd);
        }

        public List<Achvmnts> SelectBySearch(string Search_key)
        {
            SqlCommand cmd = new SqlCommand("Select * from achievements where name=@Search", DALUtil.getConnection());
            cmd.Parameters.AddWithValue("@Search", Search_key);
            return fetchAchvmnts(cmd);
        }

        public Achvmnts SelectById(int id)
        {
            SqlCommand cmd = new SqlCommand("Select * from achievements where Id=@Id", DALUtil.getConnection());
            cmd.Parameters.AddWithValue("@Id", id);
            List<Achvmnts> temp = fetchAchvmnts(cmd);
            return (temp != null) ? temp[0] : null;
        }

        public Achvmnts SelectByIdForWeb(int? id)
        {
            SqlCommand cmd = new SqlCommand("Select * from achievements where Id=@Id and publish = '2'", DALUtil.getConnection());
            cmd.Parameters.AddWithValue("@Id", id);
            List<Achvmnts> temp = fetchAchvmnts(cmd);
            return (temp != null) ? temp[0] : null;
        }

        private List<Achvmnts> fetchAchvmnts(SqlCommand cmd)
        {
            SqlConnection con = cmd.Connection;
            List<Achvmnts> achvmnts = null;
            con.Open();
            using (con)
            {
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    achvmnts = new List<Achvmnts>();
                    while (dr.Read())
                    {
                        Achvmnts a = new Achvmnts();
                        a.db_Id = Convert.ToString(dr["id"]);
                        a.Name = Convert.ToString(dr["name"]);
                        a.Detail = Convert.ToString(dr["detail"]);
                        a.Picture = Convert.ToString(dr["picture"]);
                        a.Publish = Convert.ToString(dr["publish"]);
                        a.Date = Convert.ToString(dr["date"]);
                        a.Month = Convert.ToString(dr["month"]);
                        a.Year = Convert.ToString(dr["year"]);
                        a.Time = Convert.ToString(dr["time"]);
                        achvmnts.Add(a);
                    }
                    achvmnts.TrimExcess();
                }
            }
            return achvmnts;
        }
    }
}
