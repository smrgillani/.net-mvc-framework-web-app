using Dar_e_Arqam_pwd_isb.ENT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace Dar_e_Arqam_pwd_isb.DAL
{
    public class AddAndUpdtGradeSectionDAL
    {
        public void AddSection(GradesSections gs)
        {
            SqlCommand cmd = new SqlCommand("INSERT into gradesections (class_level_id,name,settings,date,month,year,time) VALUES (@Class_level_id,@Name,'1',@Date,@Month,@Year,@Time)", DALUtil.getConnection());
            cmd.Parameters.AddWithValue("@Class_level_id", (gs.Class_Level_id == null) ? Convert.DBNull : gs.Class_Level_id);
            cmd.Parameters.AddWithValue("@Name", (gs.Name == null) ? Convert.DBNull : gs.Name);
            cmd.Parameters.AddWithValue("@Date", (gs.Date == null) ? Convert.DBNull : gs.Date);
            cmd.Parameters.AddWithValue("@Month", (gs.Month == null) ? Convert.DBNull : gs.Month);
            cmd.Parameters.AddWithValue("@Year", (gs.Year == null) ? Convert.DBNull : gs.Year);
            cmd.Parameters.AddWithValue("@Time", (gs.Time == null) ? Convert.DBNull : gs.Time);
            _section(cmd);
        }
        public void UpdateSection(GradesSections ugs, int id)
        {
            SqlCommand cmd = new SqlCommand("Update gradesections Set name=@Name Where id=@Id", DALUtil.getConnection());
            cmd.Parameters.AddWithValue("@Id", id);
            cmd.Parameters.AddWithValue("@Name", (ugs.Name == null) ? Convert.DBNull : ugs.Name);
            _section(cmd);
        }
        public void SettingsSection(GradesSections ps, int id)
        {
            SqlCommand cmd = new SqlCommand("Update gradesections Set settings=@Settings Where id = @Id", DALUtil.getConnection());
            cmd.Parameters.AddWithValue("@Id", id);
            cmd.Parameters.AddWithValue("@Settings", (ps.Settings == null) ? Convert.DBNull : ps.Settings);
            _section(cmd);
        }
        internal void _section(SqlCommand cmd)
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
