using Dar_e_Arqam_pwd_isb.ENT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace Dar_e_Arqam_pwd_isb.DAL
{
    public class AddAndUpdtDiaryDAL
    {
        public void AddDiary(Diaries d)
        {
            SqlCommand cmd = new SqlCommand("INSERT into diary (diary_date,settings,date,month,year,time) VALUES (@Diary_date,'2',@Date,@Month,@Year,@Time)", DALUtil.getConnection());
            cmd.Parameters.AddWithValue("@Diary_date", (d.Diary_date == null) ? Convert.DBNull : d.Diary_date);
            cmd.Parameters.AddWithValue("@Date", (d.Date == null) ? Convert.DBNull : d.Date);
            cmd.Parameters.AddWithValue("@Month", (d.Month == null) ? Convert.DBNull : d.Month);
            cmd.Parameters.AddWithValue("@Year", (d.Year == null) ? Convert.DBNull : d.Year);
            cmd.Parameters.AddWithValue("@Time", (d.Time == null) ? Convert.DBNull : d.Time);
            _diary(cmd);
        }
        public void UpdateDiary(Diaries ud, int id)
        {
            SqlCommand cmd = new SqlCommand("Update diary Set diary_date=@Diary_date Where id=@Id", DALUtil.getConnection());
            cmd.Parameters.AddWithValue("@Id", id);
            cmd.Parameters.AddWithValue("@Diary_date", (ud.Diary_date == null) ? Convert.DBNull : ud.Diary_date);
            _diary(cmd);
        }
        public void SettingsDiary(Diaries pd, int id)
        {
            SqlCommand cmd = new SqlCommand("Update diary Set settings=@Settings Where id = @Id", DALUtil.getConnection());
            cmd.Parameters.AddWithValue("@Id", id);
            cmd.Parameters.AddWithValue("@Settings", (pd.Settings == null) ? Convert.DBNull : pd.Settings);
            _diary(cmd);
        }
        internal void _diary(SqlCommand cmd)
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
