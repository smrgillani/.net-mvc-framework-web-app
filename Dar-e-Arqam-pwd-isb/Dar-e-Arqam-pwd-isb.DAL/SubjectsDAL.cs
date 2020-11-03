using Dar_e_Arqam_pwd_isb.ENT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace Dar_e_Arqam_pwd_isb.DAL
{
    public class SubjectsDAL
    {
        public List<Subjects> SelectAllSubjects()
        {
            SqlCommand cmd = new SqlCommand("Select * from subjects order by id", DALUtil.getConnection());
            return fetchSubject(cmd);
        }

        public List<Subjects> SelectBySearch(string Search_key)
        {
            SqlCommand cmd = new SqlCommand("Select * from subjects where name=@Search", DALUtil.getConnection());
            cmd.Parameters.AddWithValue("@Search", Search_key);
            return fetchSubject(cmd);
        }

        public Subjects SelectById(int id)
        {
            SqlCommand cmd = new SqlCommand("Select * from subjects where Id=@Id", DALUtil.getConnection());
            cmd.Parameters.AddWithValue("@Id", id);
            List<Subjects> temp = fetchSubject(cmd);
            return (temp != null) ? temp[0] : null;
        }

        private List<Subjects> fetchSubject(SqlCommand cmd)
        {
            SqlConnection con = cmd.Connection;
            List<Subjects> subjects = null;
            con.Open();
            using (con)
            {
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    subjects = new List<Subjects>();
                    while (dr.Read())
                    {
                        Subjects s = new Subjects();
                        s.db_Id = Convert.ToString(dr["id"]);
                        s.ClassLevel = Convert.ToString(dr["classlevel_id"]);
                        s.Name = Convert.ToString(dr["name"]);
                        s.ClassName = SelectClassLevelOfSubject(Convert.ToInt32(s.ClassLevel));
                        subjects.Add(s);
                    }
                    subjects.TrimExcess();
                }
            }
            return subjects;
        }

        public List<Subjects> SelectSubjectsOfClassById(int id)
        {
            SqlCommand cmd = new SqlCommand("Select * from subjects where classlevel_id=@Id", DALUtil.getConnection());
            cmd.Parameters.AddWithValue("@Id", id);
            return fetchSubjectsOfClass(cmd);
        }

        private List<Subjects> fetchSubjectsOfClass(SqlCommand cmd)
        {
            SqlConnection con = cmd.Connection;
            List<Subjects> subjects = null;
            con.Open();
            using (con)
            {
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    subjects = new List<Subjects>();
                    while (dr.Read())
                    {
                        Subjects s = new Subjects();
                        s.db_Id = Convert.ToString(dr["id"]);
                        s.Name = Convert.ToString(dr["name"]);
                        subjects.Add(s);
                    }
                    subjects.TrimExcess();
                }
            }
            return subjects;
        }

        public ClassLevels SelectClassLevelOfSubject(int id)
        {
            SqlCommand cmd = new SqlCommand("Select * from class_levels where Id=@Id", DALUtil.getConnection());
            cmd.Parameters.AddWithValue("@Id", id);
            List<ClassLevels> temp = fetchClsLvl(cmd);
            return (temp != null) ? temp[0] : null;
        }

        private List<ClassLevels> fetchClsLvl(SqlCommand cmd)
        {
            SqlConnection con = cmd.Connection;
            List<ClassLevels> class_level = null;
            con.Open();
            using (con)
            {
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    class_level = new List<ClassLevels>();
                    while (dr.Read())
                    {
                        ClassLevels cl = new ClassLevels();
                        cl.db_Id = Convert.ToString(dr["id"]);
                        cl.Name = Convert.ToString(dr["name"]);
                        class_level.Add(cl);
                    }
                    class_level.TrimExcess();
                }
            }
            return class_level;
        }
    }
}
