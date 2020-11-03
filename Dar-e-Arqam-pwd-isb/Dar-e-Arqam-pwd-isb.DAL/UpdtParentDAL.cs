using Dar_e_Arqam_pwd_isb.ENT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace Dar_e_Arqam_pwd_isb.DAL
{
    public class UpdtParentDAL
    {
        public void UpdateParent(Students p, int id)
        {
            SqlCommand cmd = new SqlCommand("Update students Set father_name=@Father_name,ocptn=@Ocptn,title=@Title,father_c_num=@Father_c_num,name_of_bsns=@Name_of_bsns,addr_of_bsns=@Addr_of_bsns,father_email=@Father_email,father_ll_num=@Father_ll_num,mother_name=@Mother_name,mother_c_num=@Mother_c_num,mother_ll_num=@Mother_ll_num Where id=@Id", DALUtil.getConnection());
            cmd.Parameters.AddWithValue("@Id", id);
            cmd.Parameters.AddWithValue("@Father_name", (p.Aplicnt_f_name == null) ? Convert.DBNull : p.Aplicnt_f_name);
            cmd.Parameters.AddWithValue("@Ocptn", (p.Aplicnt_f_ocptn == null) ? Convert.DBNull : p.Aplicnt_f_ocptn);
            cmd.Parameters.AddWithValue("@Title", (p.Aplicnt_f_title == null) ? Convert.DBNull : p.Aplicnt_f_title);
            cmd.Parameters.AddWithValue("@Father_c_num", (p.Aplicnt_f_cell == null) ? Convert.DBNull : p.Aplicnt_f_cell);
            cmd.Parameters.AddWithValue("@Name_of_bsns", (p.Aplicnt_f_bsns_name == null) ? Convert.DBNull : p.Aplicnt_f_bsns_name);
            cmd.Parameters.AddWithValue("@Addr_of_bsns", (p.Aplicnt_f_bsns_addr == null) ? Convert.DBNull : p.Aplicnt_f_bsns_addr);
            cmd.Parameters.AddWithValue("@Father_email", (p.Aplicnt_f_email == null) ? Convert.DBNull : p.Aplicnt_f_email);
            cmd.Parameters.AddWithValue("@Father_ll_num", (p.Aplicnt_f_phone == null) ? Convert.DBNull : p.Aplicnt_f_phone);
            cmd.Parameters.AddWithValue("@Mother_name", (p.Aplicnt_m_name == null) ? Convert.DBNull : p.Aplicnt_m_name);
            cmd.Parameters.AddWithValue("@Mother_c_num", (p.Aplicnt_m_cell == null) ? Convert.DBNull : p.Aplicnt_m_cell);
            cmd.Parameters.AddWithValue("@Mother_ll_num", (p.Aplicnt_m_ldln == null) ? Convert.DBNull : p.Aplicnt_m_ldln);
            addParent(cmd);
        }

        internal void addParent(SqlCommand cmd)
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
