using Dar_e_Arqam_pwd_isb.ENT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace Dar_e_Arqam_pwd_isb.DAL
{
    public class ClassLevelsDAL
    {
        public List<ClassLevels> SelectAllClassLevels()
        {
            SqlCommand cmd = new SqlCommand("Select * from class_levels order by id", DALUtil.getConnection());
            return fetchClassLevels(cmd);
        }

        public List<ClassLevels> SelectAllClassLevelsWithSubjects()
        {
            SqlCommand cmd = new SqlCommand("Select * from class_levels order by id", DALUtil.getConnection());
            return fetchClassLevelsWithSubject(cmd);
        }

        public List<ClassLevels> SelectBySearch(string Search_key)
        {
            SqlCommand cmd = new SqlCommand("Select * from class_levels where name=@Search", DALUtil.getConnection());
            cmd.Parameters.AddWithValue("@Search", Search_key);
            return fetchClassLevels(cmd);
        }

        public ClassLevels SelectById(int id)
        {
            SqlCommand cmd = new SqlCommand("Select * from class_levels where Id=@Id", DALUtil.getConnection());
            cmd.Parameters.AddWithValue("@Id", id);
            List<ClassLevels> temp = fetchClassLevels(cmd);
            return (temp != null) ? temp[0] : null;
        }

        private List<ClassLevels> fetchClassLevels(SqlCommand cmd)
        {
            SqlConnection con = cmd.Connection;
            List<ClassLevels> classlevels = null;
            con.Open();
            using (con)
            {
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    classlevels = new List<ClassLevels>();
                    while (dr.Read())
                    {
                        ClassLevels cl = new ClassLevels();
                        cl.db_Id = Convert.ToString(dr["id"]);
                        cl.Name = Convert.ToString(dr["name"]);
                        cl.Range = Convert.ToString(dr["range"]);
                        classlevels.Add(cl);
                    }
                    classlevels.TrimExcess();
                }
            }
            return classlevels;
        }

        private List<ClassLevels> fetchClassLevelsWithSubject(SqlCommand cmd)
        {
            SqlConnection con = cmd.Connection;
            List<ClassLevels> classlevels = null;
            con.Open();
            using (con)
            {
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    classlevels = new List<ClassLevels>();
                    while (dr.Read())
                    {
                        ClassLevels cl = new ClassLevels();
                        cl.db_Id = Convert.ToString(dr["id"]);
                        cl.Name = Convert.ToString(dr["name"]);
                        cl.Range = Convert.ToString(dr["range"]);
                        cl.SubjectsId = SelectSubjectsOfClassLevel(Convert.ToInt32(cl.db_Id));
                        classlevels.Add(cl);
                    }
                    classlevels.TrimExcess();
                }
            }
            return classlevels;
        }

        public List<Subjects> SelectSubjectsOfClassLevel(int id)
        {
            SqlCommand cmd = new SqlCommand("Select * from subjects where classlevel_id=@Id", DALUtil.getConnection());
            cmd.Parameters.AddWithValue("@Id", id);
            return fetchSubjects(cmd);
        }

        private List<Subjects> fetchSubjects(SqlCommand cmd)
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
    }
}
