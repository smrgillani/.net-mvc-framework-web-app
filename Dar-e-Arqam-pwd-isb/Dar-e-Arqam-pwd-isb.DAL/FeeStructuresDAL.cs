using Dar_e_Arqam_pwd_isb.ENT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace Dar_e_Arqam_pwd_isb.DAL
{
    public class FeeStructuresDAL
    {
        public List<FeeStructures> SelectAllFeeStructures()
        {
            SqlCommand cmd = new SqlCommand("Select * from fee_structures order by id", DALUtil.getConnection());
            return fetchFeeStructures(cmd);
        }

        public List<FeeStructures> SelectBySearch(string Search_key)
        {
            SqlCommand cmd = new SqlCommand("Select * from fee_structures where name_of_level=@Search", DALUtil.getConnection());
            cmd.Parameters.AddWithValue("@Search", Search_key);
            return fetchFeeStructures(cmd);
        }

        public FeeStructures SelectById(int id)
        {
            SqlCommand cmd = new SqlCommand("Select * from fee_structures where Id=@Id", DALUtil.getConnection());
            cmd.Parameters.AddWithValue("@Id", id);
            List<FeeStructures> temp = fetchFeeStructures(cmd);
            return (temp != null) ? temp[0] : null;
        }

        private List<FeeStructures> fetchFeeStructures(SqlCommand cmd)
        {
            SqlConnection con = cmd.Connection;
            List<FeeStructures> feestructures = null;
            con.Open();
            using (con)
            {
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    feestructures = new List<FeeStructures>();
                    while (dr.Read())
                    {
                        FeeStructures fs = new FeeStructures();
                        fs.db_Id = Convert.ToString(dr["id"]);
                        fs.Name_of_lvl = Convert.ToString(dr["name_of_level"]);
                        fs.Reg_fee = Convert.ToString(dr["reg_fee"]);
                        fs.Monthly_fee = Convert.ToString(dr["monthly_fee"]);
                        feestructures.Add(fs);
                    }
                    feestructures.TrimExcess();
                }
            }
            return feestructures;
        }
    }
}
