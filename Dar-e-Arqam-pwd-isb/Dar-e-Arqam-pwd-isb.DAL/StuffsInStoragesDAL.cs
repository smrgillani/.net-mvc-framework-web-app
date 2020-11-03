using Dar_e_Arqam_pwd_isb.ENT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace Dar_e_Arqam_pwd_isb.DAL
{
    public class StuffsInStoragesDAL
    {
        public List<StuffsInStorages> SelectAllStuffsInStorages()
        {
            SqlCommand cmd = new SqlCommand("Select * from storage order by id", DALUtil.getConnection());
            return fetchStuffsInStorages(cmd);
        }

        public List<StuffsInStorages> SelectBySearch(string Search_key)
        {
            SqlCommand cmd = new SqlCommand("Select * from storage where name=@Search", DALUtil.getConnection());
            cmd.Parameters.AddWithValue("@Search", Search_key);
            return fetchStuffsInStorages(cmd);
        }

        public StuffsInStorages SelectById(int id)
        {
            SqlCommand cmd = new SqlCommand("Select * from storage where Id=@Id", DALUtil.getConnection());
            cmd.Parameters.AddWithValue("@Id", id);
            List<StuffsInStorages> temp = fetchStuffsInStorages(cmd);
            return (temp != null) ? temp[0] : null;
        }

        private List<StuffsInStorages> fetchStuffsInStorages(SqlCommand cmd)
        {
            SqlConnection con = cmd.Connection;
            List<StuffsInStorages> stuffsinstorages = null;
            con.Open();
            using (con)
            {
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    stuffsinstorages = new List<StuffsInStorages>();
                    while (dr.Read())
                    {
                        StuffsInStorages ss = new StuffsInStorages();
                        ss.db_Id = Convert.ToString(dr["id"]);
                        ss.Name = Convert.ToString(dr["name"]);
                        ss.User_File = Convert.ToString(dr["user_file"]);
                        stuffsinstorages.Add(ss);
                    }
                    stuffsinstorages.TrimExcess();
                }
            }
            return stuffsinstorages;
        }
    }
}
