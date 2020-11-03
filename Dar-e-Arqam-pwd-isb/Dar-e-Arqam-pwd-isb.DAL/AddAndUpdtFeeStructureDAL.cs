using Dar_e_Arqam_pwd_isb.ENT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace Dar_e_Arqam_pwd_isb.DAL
{
    public class AddAndUpdtFeeStructureDAL
    {
        public void AddFeeStructure(FeeStructures fs)
        {
            SqlCommand cmd = new SqlCommand("INSERT into fee_structures (name_of_level,reg_fee,monthly_fee,date,month,year,time) VALUES (@Name_of_lvl,@Reg_fee,@Monthly_fee,@Date,@Month,@Year,@Time)", DALUtil.getConnection());
            cmd.Parameters.AddWithValue("@Name_of_lvl", (fs.Name_of_lvl == null) ? Convert.DBNull : fs.Name_of_lvl);
            cmd.Parameters.AddWithValue("@Reg_fee", (fs.Reg_fee == null) ? Convert.DBNull : fs.Reg_fee);
            cmd.Parameters.AddWithValue("@Monthly_fee", (fs.Monthly_fee == null) ? Convert.DBNull : fs.Monthly_fee);
            cmd.Parameters.AddWithValue("@Date", (fs.Date == null) ? Convert.DBNull : fs.Date);
            cmd.Parameters.AddWithValue("@Month", (fs.Month == null) ? Convert.DBNull : fs.Month);
            cmd.Parameters.AddWithValue("@Year", (fs.Year == null) ? Convert.DBNull : fs.Year);
            cmd.Parameters.AddWithValue("@Time", (fs.Time == null) ? Convert.DBNull : fs.Time);
            addfeestructure(cmd);
        }
        public void UpdateFeeStructure(FeeStructures ufs, int id)
        {
            SqlCommand cmd = new SqlCommand("Update fee_structures Set name_of_level=@Name_of_lvl , reg_fee = @Reg_fee , monthly_fee=@Monthly_fee Where id=@Id", DALUtil.getConnection());
            cmd.Parameters.AddWithValue("@Id", id);
            cmd.Parameters.AddWithValue("@Name_of_lvl", (ufs.Name_of_lvl == null) ? Convert.DBNull : ufs.Name_of_lvl);
            cmd.Parameters.AddWithValue("@Reg_fee", (ufs.Reg_fee == null) ? Convert.DBNull : ufs.Reg_fee);
            cmd.Parameters.AddWithValue("@Monthly_fee", (ufs.Monthly_fee == null) ? Convert.DBNull : ufs.Monthly_fee);
            addfeestructure(cmd);
        }
        public void PublishFeeStructure(FeeStructures pfs, int id)
        {
            SqlCommand cmd = new SqlCommand("Update fee_structures Set publish=@Publish Where id = @Id", DALUtil.getConnection());
            cmd.Parameters.AddWithValue("@Id", id);
            cmd.Parameters.AddWithValue("@Publish", (pfs.Publish == null) ? Convert.DBNull : pfs.Publish);
            addfeestructure(cmd);
        }
        internal void addfeestructure(SqlCommand cmd)
        {
            SqlConnection con = cmd.Connection;
            con.Open();
            using (con)
            {
                cmd.ExecuteNonQuery();
            }
        }
    }
}
