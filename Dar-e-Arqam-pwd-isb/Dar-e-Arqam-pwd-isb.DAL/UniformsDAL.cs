using Dar_e_Arqam_pwd_isb.ENT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace Dar_e_Arqam_pwd_isb.DAL
{
    public class UniformsDAL
    {
        public List<Uniforms> SelectAllUniforms()
        {
            SqlCommand cmd = new SqlCommand("Select * from uniform order by id", DALUtil.getConnection());
            return fetchUniforms(cmd);
        }

        public List<Uniforms> SelectBySearch(string Search_key)
        {
            SqlCommand cmd = new SqlCommand("Select * from uniform where name=@Search", DALUtil.getConnection());
            cmd.Parameters.AddWithValue("@Search", Search_key);
            return fetchUniforms(cmd);
        }

        public Uniforms SelectById(int id)
        {
            SqlCommand cmd = new SqlCommand("Select * from uniform where Id=@Id", DALUtil.getConnection());
            cmd.Parameters.AddWithValue("@Id", id);
            List<Uniforms> temp = fetchUniforms(cmd);
            return (temp != null) ? temp[0] : null;
        }

        private List<Uniforms> fetchUniforms(SqlCommand cmd)
        {
            SqlConnection con = cmd.Connection;
            List<Uniforms> uniforms = null;
            con.Open();
            using (con)
            {
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    uniforms = new List<Uniforms>();
                    while (dr.Read())
                    {
                        Uniforms u = new Uniforms();
                        u.db_Id = Convert.ToString(dr["id"]);
                        u.Name = Convert.ToString(dr["name"]);
                        u.Class_lvl_id = Convert.ToString(dr["class_lvl_id"]);
                        u.Picture = Convert.ToString(dr["picture"]);
                        u.Publish = Convert.ToString(dr["publish"]);
                        uniforms.Add(u);
                    }
                    uniforms.TrimExcess();
                }
            }
            return uniforms;
        }
    }
}
