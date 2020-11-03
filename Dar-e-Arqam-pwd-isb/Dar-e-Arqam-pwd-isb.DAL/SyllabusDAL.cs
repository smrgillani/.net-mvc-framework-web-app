using Dar_e_Arqam_pwd_isb.ENT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace Dar_e_Arqam_pwd_isb.DAL
{
    public class SyllabusDAL
    {
        public List<Syllabuses> SelectAllSyllabuses()
        {
            SqlCommand cmd = new SqlCommand("Select * from syllabus order by id", DALUtil.getConnection());
            return fetchSyllabuses(cmd);
        }

        public List<Syllabuses> SelectBySearch(string Search_key)
        {
            SqlCommand cmd = new SqlCommand("Select * from syllabus where name_of_lvl=@Search", DALUtil.getConnection());
            cmd.Parameters.AddWithValue("@Search", Search_key);
            return fetchSyllabuses(cmd);
        }

        public Syllabuses SelectById(int id)
        {
            SqlCommand cmd = new SqlCommand("Select * from syllabus where Id=@Id", DALUtil.getConnection());
            cmd.Parameters.AddWithValue("@Id", id);
            List<Syllabuses> temp = fetchSyllabuses(cmd);
            return (temp != null) ? temp[0] : null;
        }

        private List<Syllabuses> fetchSyllabuses(SqlCommand cmd)
        {
            SqlConnection con = cmd.Connection;
            List<Syllabuses> syllabuses = null;
            con.Open();
            using (con)
            {
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    syllabuses = new List<Syllabuses>();
                    while (dr.Read())
                    {
                        Syllabuses s = new Syllabuses();
                        s.db_Id = Convert.ToString(dr["id"]);
                        s.Name_of_lvl = Convert.ToString(dr["name_of_lvl"]);
                        s.Detail_of_syllabus = Convert.ToString(dr["detail_of_syllabus"]);
                        s.Publish = Convert.ToString(dr["publish"]);
                        syllabuses.Add(s);
                    }
                    syllabuses.TrimExcess();
                }
            }
            return syllabuses;
        }
    }
}
