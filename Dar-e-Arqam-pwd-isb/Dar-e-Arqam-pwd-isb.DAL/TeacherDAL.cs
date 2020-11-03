using Dar_e_Arqam_pwd_isb.ENT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace Dar_e_Arqam_pwd_isb.DAL
{
    public class TeacherDAL
    {
        public List<Teachers> SelectAllTeachers()
        {
            SqlCommand cmd = new SqlCommand("Select * from teachers where active_id = '0' and del_id = '0' order by id", DALUtil.getConnection());
            return fetchTeachers(cmd);
        }

        public List<Teachers> SelectAllActiveTeachers()
        {
            SqlCommand cmd = new SqlCommand("Select * from teachers where active_id = '2' and del_id = '0' order by id", DALUtil.getConnection());
            return fetchTeachers(cmd);
        }

        public List<Teachers> SelectAllOldTeachers()
        {
            SqlCommand cmd = new SqlCommand("Select * from teachers where active_id = '1' and del_id = '0' order by id", DALUtil.getConnection());
            return fetchTeachers(cmd);
        }

        public List<Teachers> SelectAllTrashTeachers()
        {
            SqlCommand cmd = new SqlCommand("Select * from teachers where active_id = '0' and del_id = '1' order by id", DALUtil.getConnection());
            return fetchTeachers(cmd);
        }
        
        public List<Teachers> SelectBySearch(string Search_key)
        {
            SqlCommand cmd = new SqlCommand("Select * from teachers where name=@Search and active_id = '0' and del_id = '0' order by id", DALUtil.getConnection());
            cmd.Parameters.AddWithValue("@Search", Search_key);
            return fetchTeachers(cmd);
        }

        public List<Teachers> SelectActiveBySearch(string Search_key)
        {
            SqlCommand cmd = new SqlCommand("Select * from teachers where name=@Search and active_id = '2' and del_id = '0' order by id", DALUtil.getConnection());
            cmd.Parameters.AddWithValue("@Search", Search_key);
            return fetchTeachers(cmd);
        }

        public List<Teachers> SelectOldBySearch(string Search_key)
        {
            SqlCommand cmd = new SqlCommand("Select * from teachers where name=@Search and active_id = '1' and del_id = '0' order by id", DALUtil.getConnection());
            cmd.Parameters.AddWithValue("@Search", Search_key);
            return fetchTeachers(cmd);
        }

        public List<Teachers> SelectTrashBySearch(string Search_key)
        {
            SqlCommand cmd = new SqlCommand("Select * from teachers where name=@Search and active_id = '0' and del_id = '1' order by id", DALUtil.getConnection());
            cmd.Parameters.AddWithValue("@Search", Search_key);
            return fetchTeachers(cmd);
        }

        public Teachers SelectById(int id)
        {
            SqlCommand cmd = new SqlCommand("Select * from teachers where Id=@Id", DALUtil.getConnection());
            cmd.Parameters.AddWithValue("@Id", id);
            List<Teachers> temp = fetchTeachers(cmd);
            return (temp != null) ? temp[0] : null;
        }

        private List<Teachers> fetchTeachers(SqlCommand cmd)
        {
            SqlConnection con = cmd.Connection;
            List<Teachers> teachers = null;
            con.Open();
            using (con)
            {
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    teachers = new List<Teachers>();
                    while (dr.Read())
                    {
                        Teachers t = new Teachers();
                        t.db_Id = Convert.ToString(dr["id"]);
                        t.T_Id = Convert.ToString(dr["t_id"]);
                        t.T_name = Convert.ToString(dr["Name"]);
                        t.T_dob = Convert.ToString(dr["dob"]);
                        t.T_cnic = Convert.ToString(dr["cnic"]);
                        t.T_gen = Convert.ToString(dr["gender"]);
                        t.T_email = Convert.ToString(dr["email"]);
                        t.T_c_num = Convert.ToString(dr["contact"]);
                        t.T_a_c_num = Convert.ToString(dr["alt_contact"]);
                        t.T_type = Convert.ToString(dr["type"]);
                        t.T_desig = Convert.ToString(dr["desig"]);
                        t.T_jd = Convert.ToString(dr["dj"]);
                        t.T_spcl_in_sbjct = Convert.ToString(dr["spcl_in_sbjct"]);
                        t.T_g_name = Convert.ToString(dr["gurdian_name"]);
                        t.T_g_cnic = Convert.ToString(dr["gurdian_cnic"]);
                        t.T_res_addr = Convert.ToString(dr["addr"]);
                        t.Date =  Convert.ToString(dr["date"]);
                        t.Month = Convert.ToString(dr["month"]);
                        t.Year = Convert.ToString(dr["year"]);
                        t.Time = Convert.ToString(dr["time"]);
                        teachers.Add(t);
                    }
                    teachers.TrimExcess();
                }
            }
            return teachers;
        }
    }
}
