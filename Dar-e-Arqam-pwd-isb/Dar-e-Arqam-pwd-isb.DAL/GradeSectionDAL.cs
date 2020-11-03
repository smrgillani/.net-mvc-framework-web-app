using Dar_e_Arqam_pwd_isb.ENT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace Dar_e_Arqam_pwd_isb.DAL
{
    public class GradeSectionDAL
    {
        public List<GradesSections> SelectAll(int id)
        {
            SqlCommand cmd = new SqlCommand("Select * from gradesections where class_level_id=@Id order by id desc", DALUtil.getConnection());
            cmd.Parameters.AddWithValue("@Id", id);
            return fetchSection(cmd);
        }

        public List<GradesSections> SelectAllActive(int id)
        {
            SqlCommand cmd = new SqlCommand("Select * from gradesections where publish = '2' order by id desc", DALUtil.getConnection());
            return fetchSection(cmd);
        }

        public List<GradesSections> SelectBySearch(string Search_key)
        {
            SqlCommand cmd = new SqlCommand("Select * from gradesections where name=@Search", DALUtil.getConnection());
            cmd.Parameters.AddWithValue("@Search", Search_key);
            return fetchSection(cmd);
        }

        public GradesSections SelectById(int id)
        {
            SqlCommand cmd = new SqlCommand("Select * from gradesections where Id=@Id", DALUtil.getConnection());
            cmd.Parameters.AddWithValue("@Id", id);
            List<GradesSections> temp = fetchSection(cmd);
            return (temp != null) ? temp[0] : null;
        }

        private List<GradesSections> fetchSection(SqlCommand cmd)
        {
            SqlConnection con = cmd.Connection;
            List<GradesSections> gradessections = null;
            con.Open();
            using (con)
            {
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    gradessections = new List<GradesSections>();
                    while (dr.Read())
                    {
                        GradesSections gs = new GradesSections();
                        gs.db_Id = Convert.ToString(dr["id"]);
                        gs.Class_Level_id = Convert.ToString(dr["class_level_id"]);
                        gs.Class_name = new ClassLevelsDAL().SelectById(Convert.ToInt32(dr["class_level_id"]));
                        gs.Name = Convert.ToString(dr["name"]);
                        gs.Settings = Convert.ToString(dr["settings"]);
                        gradessections.Add(gs);
                    }
                    gradessections.TrimExcess();
                }
            }
            return gradessections;
        }
    }
}
