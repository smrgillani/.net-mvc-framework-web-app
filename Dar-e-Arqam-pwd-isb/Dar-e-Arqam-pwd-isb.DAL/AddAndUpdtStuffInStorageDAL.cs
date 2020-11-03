using Dar_e_Arqam_pwd_isb.ENT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace Dar_e_Arqam_pwd_isb.DAL
{
    public class AddAndUpdtStuffInStorageDAL
    {
        public void AddStuffInStorage(StuffsInStorages ss)
        {
            SqlCommand cmd = new SqlCommand("INSERT into storage (name,user_file,date,month,year,time) VALUES (@Name,@File,@Date,@Month,@Year,@Time)", DALUtil.getConnection());
            cmd.Parameters.AddWithValue("@Name", (ss.Name == null) ? Convert.DBNull : ss.Name);
            cmd.Parameters.AddWithValue("@File", (ss.User_File == null) ? Convert.DBNull : ss.User_File);
            cmd.Parameters.AddWithValue("@Date", (ss.Date == null) ? Convert.DBNull : ss.Date);
            cmd.Parameters.AddWithValue("@Month", (ss.Month == null) ? Convert.DBNull : ss.Month);
            cmd.Parameters.AddWithValue("@Year", (ss.Year == null) ? Convert.DBNull : ss.Year);
            cmd.Parameters.AddWithValue("@Time", (ss.Time == null) ? Convert.DBNull : ss.Time);
            addstuffinstorage(cmd);
        }
        public void UpdateStuffInStorage(StuffsInStorages uss, int id)
        {
            SqlCommand cmd = new SqlCommand("Update storage Set name=@Name Where id=@Id", DALUtil.getConnection());
            cmd.Parameters.AddWithValue("@Id", id);
            cmd.Parameters.AddWithValue("@Name", (uss.Name == null) ? Convert.DBNull : uss.Name);
            addstuffinstorage(cmd);
        }
        public void UpdateStuffInStorage_file(StuffsInStorages uss, int id)
        {
            SqlCommand cmd = new SqlCommand("Update storage Set name=@Name , user_file=@File Where id=@Id", DALUtil.getConnection());
            cmd.Parameters.AddWithValue("@Id", id);
            cmd.Parameters.AddWithValue("@Name", (uss.Name == null) ? Convert.DBNull : uss.Name);
            cmd.Parameters.AddWithValue("@File", (uss.User_File == null) ? Convert.DBNull : uss.User_File);
            addstuffinstorage(cmd);
        }
        internal void addstuffinstorage(SqlCommand cmd)
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
