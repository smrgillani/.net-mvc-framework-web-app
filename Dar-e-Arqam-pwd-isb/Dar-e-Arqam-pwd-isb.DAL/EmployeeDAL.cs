using Dar_e_Arqam_pwd_isb.ENT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace Dar_e_Arqam_pwd_isb.DAL
{
    public class EmployeeDAL
    {
        public List<Employees> SelectAllEmployees()
        {
            SqlCommand cmd = new SqlCommand("Select * from employees order by id", DALUtil.getConnection());
            return fetchEmployees(cmd);
        }

        public List<Employees> SelectBySearch(string Search_key)
        {
            SqlCommand cmd = new SqlCommand("Select * from employees where name=@Search", DALUtil.getConnection());
            cmd.Parameters.AddWithValue("@Search", Search_key);
            return fetchEmployees(cmd);
        }

        public Employees SelectById(int id)
        {
            SqlCommand cmd = new SqlCommand("Select * from employees where Id=@Id", DALUtil.getConnection());
            cmd.Parameters.AddWithValue("@Id", id);
            List<Employees> temp = fetchEmployees(cmd);
            return (temp != null) ? temp[0] : null;
        }

        private List<Employees> fetchEmployees(SqlCommand cmd)
        {
            SqlConnection con = cmd.Connection;
            List<Employees> employees = null;
            con.Open();
            using (con)
            {
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    employees = new List<Employees>();
                    while (dr.Read())
                    {
                        Employees e = new Employees();
                        e.db_Id = Convert.ToString(dr["id"]);
                        e.E_Id = Convert.ToString(dr["e_id"]);
                        e.E_name = Convert.ToString(dr["name"]);
                        e.E_dob = Convert.ToString(dr["dob"]);
                        e.E_cnic = Convert.ToString(dr["cnic"]);
                        e.E_gen = Convert.ToString(dr["gender"]);
                        e.E_email = Convert.ToString(dr["email"]);
                        e.E_c_num = Convert.ToString(dr["contact"]);
                        e.E_a_c_num = Convert.ToString(dr["alt_contact"]);
                        e.E_desig = Convert.ToString(dr["desig"]);
                        e.E_g_name = Convert.ToString(dr["gurdian_name"]);
                        e.E_g_cnic = Convert.ToString(dr["gurdian_cnic"]);
                        e.E_res_addr = Convert.ToString(dr["addr"]);
                        employees.Add(e);
                    }
                    employees.TrimExcess();
                }
            }
            return employees;
        }
    }
}
