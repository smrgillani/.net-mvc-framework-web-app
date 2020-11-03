using Dar_e_Arqam_pwd_isb.ENT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace Dar_e_Arqam_pwd_isb.DAL
{
    public class UsersDAL
    {
        public List<Logins> SelectAllUsers()
        {
            SqlCommand cmd = new SqlCommand("Select * from Login_user order by id", DALUtil.getConnection());
            return fetchUsers(cmd);
        }

        private List<Logins> fetchUsers(SqlCommand cmd)
        {
            SqlConnection con = cmd.Connection;
            List<Logins> logins = null;
            con.Open();
            using (con)
            {
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    logins = new List<Logins>();
                    while (dr.Read())
                    {
                        Logins li = new Logins();
                        li.Username = Convert.ToString(dr["username"]);
                        li.Password = Convert.ToString(dr["password"]);
                        logins.Add(li);
                    }
                    logins.TrimExcess();
                }
            }
            return logins;
        }
    }
}
