using Dar_e_Arqam_pwd_isb.ENT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace Dar_e_Arqam_pwd_isb.DAL
{
    public class EventsDAL
    {
        public List<Events> SelectAllEvents()
        {
            SqlCommand cmd = new SqlCommand("Select * from events order by id", DALUtil.getConnection());
            return fetchEvents(cmd);
        }

        public List<Events> SelectAllEventsForWeb()
        {
            SqlCommand cmd = new SqlCommand("Select * from events where publish = '2' order by id", DALUtil.getConnection());
            return fetchEvents(cmd);
        }

        public Events SelectByIdForWeb(int? id)
        {
            SqlCommand cmd = new SqlCommand("Select * from events where Id=@Id and publish = '2'", DALUtil.getConnection());
            cmd.Parameters.AddWithValue("@Id", id);
            List<Events> temp = fetchEvents(cmd);
            return (temp != null) ? temp[0] : null;
        }

        public List<Events> SelectBySearch(string Search_key)
        {
            SqlCommand cmd = new SqlCommand("Select * from events where name=@Search", DALUtil.getConnection());
            cmd.Parameters.AddWithValue("@Search", Search_key);
            return fetchEvents(cmd);
        }

        public Events SelectById(int id)
        {
            SqlCommand cmd = new SqlCommand("Select * from events where Id=@Id", DALUtil.getConnection());
            cmd.Parameters.AddWithValue("@Id", id);
            List<Events> temp = fetchEvents(cmd);
            return (temp != null) ? temp[0] : null;
        }

        private List<Events> fetchEvents(SqlCommand cmd)
        {
            SqlConnection con = cmd.Connection;
            List<Events> events = null;
            con.Open();
            using (con)
            {
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    events = new List<Events>();
                    while (dr.Read())
                    {
                        Events e = new Events();
                        e.db_Id = Convert.ToString(dr["id"]);
                        e.Name = Convert.ToString(dr["name"]);
                        e.Picture = Convert.ToString(dr["picture"]);
                        e.Detail = Convert.ToString(dr["detail"]);
                        e.Publish = Convert.ToString(dr["publish"]);
                        e.Date = Convert.ToString(dr["Date"]);
                        e.Month = Convert.ToString(dr["Month"]);
                        e.Year = Convert.ToString(dr["Year"]);
                        e.Time = Convert.ToString(dr["Time"]);
                        events.Add(e);
                    }
                    events.TrimExcess();
                }
            }
            return events;
        }
    }
}
