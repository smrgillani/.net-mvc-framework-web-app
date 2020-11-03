using Dar_e_Arqam_pwd_isb.ENT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace Dar_e_Arqam_pwd_isb.DAL
{
    public class ParentDAL
    {
        public List<Students> SelectAllParents()
        {
            SqlCommand cmd = new SqlCommand("Select * from Students order by id", DALUtil.getConnection());
            return fetchParents(cmd);
        }

        public List<Students> SelectBySearch(string Search_key)
        {
            SqlCommand cmd = new SqlCommand("Select * from Students where father_name=@Search", DALUtil.getConnection());
            cmd.Parameters.AddWithValue("@Search", Search_key);
            return fetchParents(cmd);
        }

        public Students SelectById(int id)
        {
            SqlCommand cmd = new SqlCommand("Select * from Students where Id=@Id", DALUtil.getConnection());
            cmd.Parameters.AddWithValue("@Id", id);
            List<Students> temp = fetchParents(cmd);
            return (temp != null) ? temp[0] : null;
        }

        private List<Students> fetchParents(SqlCommand cmd)
        {
            SqlConnection con = cmd.Connection;
            List<Students> parents = null;
            con.Open();
            using (con)
            {
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    parents = new List<Students>();
                    while (dr.Read())
                    {
                        Students p = new Students();
                        p.db_Id = Convert.ToString(dr["id"]);
                        p.Aplicnt_Id = Convert.ToString(dr["reg_id"]);
                        p.Aplicnt_f_name = Convert.ToString(dr["father_name"]);
                        p.Aplicnt_f_ocptn = Convert.ToString(dr["ocptn"]);
                        p.Aplicnt_f_title = Convert.ToString(dr["title"]);
                        p.Aplicnt_f_cell = Convert.ToString(dr["father_c_num"]);
                        p.Aplicnt_f_bsns_name = Convert.ToString(dr["name_of_bsns"]);
                        p.Aplicnt_f_bsns_addr = Convert.ToString(dr["addr_of_bsns"]);
                        p.Aplicnt_f_email = Convert.ToString(dr["father_email"]);
                        p.Aplicnt_f_phone = Convert.ToString(dr["father_ll_num"]);
                        p.Aplicnt_m_name  = Convert.ToString(dr["mother_name"]);
                        p.Aplicnt_m_cell = Convert.ToString(dr["mother_c_num"]);
                        p.Aplicnt_m_ldln = Convert.ToString(dr["mother_ll_num"]);
                        parents.Add(p);
                    }
                    parents.TrimExcess();
                }
            }
            return parents;
        }
    }
}
