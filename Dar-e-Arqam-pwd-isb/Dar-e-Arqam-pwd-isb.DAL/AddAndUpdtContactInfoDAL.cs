using Dar_e_Arqam_pwd_isb.ENT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace Dar_e_Arqam_pwd_isb.DAL
{
    public class AddAndUpdtContactInfoDAL
    {
        public void AddContactInfo(ContactsInfo ci)
        {
            SqlCommand cmd = new SqlCommand("INSERT into contact_info (title,contact_c,contact_p,contact_e,contact_w,contact_l,contact_a,date,month,year,time) VALUES (@Title,@Contact_C,@Contact_P,@Contact_E,@Contact_W,@Contact_L,@Contact_A,@Date,@Month,@Year,@Time)", DALUtil.getConnection());
            cmd.Parameters.AddWithValue("@Title", (ci.Title == null) ? Convert.DBNull : ci.Title);
            cmd.Parameters.AddWithValue("@Contact_C", (ci.Contact_Cell == null) ? Convert.DBNull : ci.Contact_Cell);
            cmd.Parameters.AddWithValue("@Contact_P", (ci.Contact_Phone == null) ? Convert.DBNull : ci.Contact_Phone);
            cmd.Parameters.AddWithValue("@Contact_E", (ci.Contact_Email == null) ? Convert.DBNull : ci.Contact_Email);
            cmd.Parameters.AddWithValue("@Contact_W", (ci.Contact_Website == null) ? Convert.DBNull : ci.Contact_Website);
            cmd.Parameters.AddWithValue("@Contact_L", (ci.Contact_Location == null) ? Convert.DBNull : ci.Contact_Location);
            cmd.Parameters.AddWithValue("@Contact_A", (ci.Contact_Address == null) ? Convert.DBNull : ci.Contact_Address);
            cmd.Parameters.AddWithValue("@Date", (ci.Date == null) ? Convert.DBNull : ci.Date);
            cmd.Parameters.AddWithValue("@Month", (ci.Month == null) ? Convert.DBNull : ci.Month);
            cmd.Parameters.AddWithValue("@Year", (ci.Year == null) ? Convert.DBNull : ci.Year);
            cmd.Parameters.AddWithValue("@Time", (ci.Time == null) ? Convert.DBNull : ci.Time);
            contactInfo(cmd);
        }

        public void UpdateContactInfo(ContactsInfo uci, int id)
        {
            SqlCommand cmd = new SqlCommand("Update contact_info Set title=@Title , contact_c=@Contact_C , contact_p=@Contact_P , contact_e=@Contact_E , contact_w=@Contact_W , contact_l=@Contact_L , contact_a=@Contact_A Where id = @Id", DALUtil.getConnection());
            cmd.Parameters.AddWithValue("@Id", id);
            cmd.Parameters.AddWithValue("@Title", (uci.Title == null) ? Convert.DBNull : uci.Title);
            cmd.Parameters.AddWithValue("@Contact_C", (uci.Contact_Cell == null) ? Convert.DBNull : uci.Contact_Cell);
            cmd.Parameters.AddWithValue("@Contact_P", (uci.Contact_Phone == null) ? Convert.DBNull : uci.Contact_Phone);
            cmd.Parameters.AddWithValue("@Contact_E", (uci.Contact_Email == null) ? Convert.DBNull : uci.Contact_Email);
            cmd.Parameters.AddWithValue("@Contact_W", (uci.Contact_Website == null) ? Convert.DBNull : uci.Contact_Website);
            cmd.Parameters.AddWithValue("@Contact_L", (uci.Contact_Location == null) ? Convert.DBNull : uci.Contact_Location);
            cmd.Parameters.AddWithValue("@Contact_A", (uci.Contact_Address == null) ? Convert.DBNull : uci.Contact_Address);
            contactInfo(cmd);
        }

        public void PublishContactInfo(ContactsInfo pci, int id)
        {
            SqlCommand cmd = new SqlCommand("Update contact_info Set publish=@Publish Where id = @Id", DALUtil.getConnection());
            cmd.Parameters.AddWithValue("@Id", id);
            cmd.Parameters.AddWithValue("@Publish", (pci.Publish == null) ? Convert.DBNull : pci.Publish);
            contactInfo(cmd);
        }

        public void DeleteContactInfo(int id)
        {
            SqlCommand cmd = new SqlCommand("Delete From contact_info Where id=@Id", DALUtil.getConnection());
            cmd.Parameters.AddWithValue("@Id", id);
            contactInfo(cmd);
        }

        internal void contactInfo(SqlCommand cmd)
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
