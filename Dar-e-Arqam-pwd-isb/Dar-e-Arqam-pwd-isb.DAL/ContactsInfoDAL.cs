using Dar_e_Arqam_pwd_isb.ENT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace Dar_e_Arqam_pwd_isb.DAL
{
    public class ContactsInfoDAL
    {
        public List<ContactsInfo> SelectAllContactsInfo()
        {
            SqlCommand cmd = new SqlCommand("Select * from contact_info order by id", DALUtil.getConnection());
            return fetchContactsInfo(cmd);
        }

        public ContactsInfo SelectContactInfoForWeb()
        {
            SqlCommand cmd = new SqlCommand("Select * from contact_info where publish = '2' order by id", DALUtil.getConnection());
            List<ContactsInfo> temp = fetchContactsInfo(cmd);
            return (temp != null) ? temp[0] : null;
        }

        public List<ContactsInfo> SelectBySearch(string Search_key)
        {
            SqlCommand cmd = new SqlCommand("Select * from contact_info where title=@Search", DALUtil.getConnection());
            cmd.Parameters.AddWithValue("@Search", Search_key);
            return fetchContactsInfo(cmd);
        }

        public ContactsInfo SelectById(int id)
        {
            SqlCommand cmd = new SqlCommand("Select * from contact_info where Id=@Id", DALUtil.getConnection());
            cmd.Parameters.AddWithValue("@Id", id);
            List<ContactsInfo> temp = fetchContactsInfo(cmd);
            return (temp != null) ? temp[0] : null;
        }

        private List<ContactsInfo> fetchContactsInfo(SqlCommand cmd)
        {
            SqlConnection con = cmd.Connection;
            List<ContactsInfo> contactsinfo = null;
            con.Open();
            using (con)
            {
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    contactsinfo = new List<ContactsInfo>();
                    while (dr.Read())
                    {
                        ContactsInfo ci = new ContactsInfo();
                        ci.db_Id = Convert.ToString(dr["id"]);
                        ci.Title = Convert.ToString(dr["title"]);
                        ci.Contact_Cell = Convert.ToString(dr["contact_c"]);
                        ci.Contact_Phone = Convert.ToString(dr["contact_p"]);
                        ci.Contact_Email = Convert.ToString(dr["contact_e"]);
                        ci.Contact_Website = Convert.ToString(dr["contact_w"]);
                        ci.Contact_Location = Convert.ToString(dr["contact_l"]);
                        ci.Contact_Address = Convert.ToString(dr["contact_a"]);
                        ci.Publish = Convert.ToString(dr["publish"]);
                        contactsinfo.Add(ci);
                    }
                    contactsinfo.TrimExcess();
                }
            }
            return contactsinfo;
        }
    }
}
