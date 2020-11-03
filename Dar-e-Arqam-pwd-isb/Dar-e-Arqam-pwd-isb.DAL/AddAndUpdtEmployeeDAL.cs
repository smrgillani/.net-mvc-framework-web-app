using Dar_e_Arqam_pwd_isb.ENT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace Dar_e_Arqam_pwd_isb.DAL
{
    public class AddAndUpdtEmployeeDAL
    {
        public void AddEmployee(Employees e)
        {
            SqlCommand cmd = new SqlCommand("INSERT into employees (e_id,name,dob,cnic,gender,email,contact,alt_contact,desig,gurdian_name,gurdian_cnic,addr,date,month,year,time) VALUES (@E_id,@Name,@Dob,@Cnic,@Gender,@Email,@Contact,@Alt_contact,@Desig,@G_name,@G_cnic,@Addr,@Date,@Month,@Year,@Time)", DALUtil.getConnection());
            cmd.Parameters.AddWithValue("@E_id", (e.E_Id == null) ? Convert.DBNull : e.E_Id);
            cmd.Parameters.AddWithValue("@Name", (e.E_name == null) ? Convert.DBNull : e.E_name);
            cmd.Parameters.AddWithValue("@Dob", (e.E_dob == null) ? Convert.DBNull : e.E_dob);
            cmd.Parameters.AddWithValue("@Cnic", (e.E_cnic == null) ? Convert.DBNull : e.E_cnic);
            cmd.Parameters.AddWithValue("@Gender", (e.E_gen == null) ? Convert.DBNull : e.E_gen);
            cmd.Parameters.AddWithValue("@Email", (e.E_email == null) ? Convert.DBNull : e.E_email);
            cmd.Parameters.AddWithValue("@Contact", (e.E_c_num == null) ? Convert.DBNull : e.E_c_num);
            cmd.Parameters.AddWithValue("@Alt_contact", (e.E_a_c_num == null) ? Convert.DBNull : e.E_a_c_num);
            cmd.Parameters.AddWithValue("@Desig", (e.E_desig == null) ? Convert.DBNull : e.E_desig);
            cmd.Parameters.AddWithValue("@G_name", (e.E_g_name == null) ? Convert.DBNull : e.E_g_name);
            cmd.Parameters.AddWithValue("@G_cnic", (e.E_g_cnic == null) ? Convert.DBNull : e.E_g_cnic);
            cmd.Parameters.AddWithValue("@Addr", (e.E_res_addr == null) ? Convert.DBNull : e.E_res_addr);
            cmd.Parameters.AddWithValue("@Date", (e.Date == null) ? Convert.DBNull : e.Date);
            cmd.Parameters.AddWithValue("@Month", (e.Month == null) ? Convert.DBNull : e.Month);
            cmd.Parameters.AddWithValue("@Year", (e.Year == null) ? Convert.DBNull : e.Year);
            cmd.Parameters.AddWithValue("@Time", (e.Time == null) ? Convert.DBNull : e.Time);
            addemployee(cmd);
        }
        public void UpdateEmployee(Employees ue, int id)
        {
            SqlCommand cmd = new SqlCommand("Update employees Set e_id=@E_id,name=@Name,dob=@Dob,cnic=@Cnic,gender=@Gender,email=@Email,contact=@Contact,alt_contact=@Alt_contact,desig=@Desig,gurdian_name=@G_name,gurdian_cnic=@G_cnic,addr=@Addr Where id=@Id", DALUtil.getConnection());
            cmd.Parameters.AddWithValue("@Id", id);
            cmd.Parameters.AddWithValue("@E_id", (ue.E_Id == null) ? Convert.DBNull : ue.E_Id);
            cmd.Parameters.AddWithValue("@Name", (ue.E_name == null) ? Convert.DBNull : ue.E_name);
            cmd.Parameters.AddWithValue("@Dob", (ue.E_dob == null) ? Convert.DBNull : ue.E_dob);
            cmd.Parameters.AddWithValue("@Cnic", (ue.E_cnic == null) ? Convert.DBNull : ue.E_cnic);
            cmd.Parameters.AddWithValue("@Gender", (ue.E_gen == null) ? Convert.DBNull : ue.E_gen);
            cmd.Parameters.AddWithValue("@Email", (ue.E_email == null) ? Convert.DBNull : ue.E_email);
            cmd.Parameters.AddWithValue("@Contact", (ue.E_c_num == null) ? Convert.DBNull : ue.E_c_num);
            cmd.Parameters.AddWithValue("@Alt_contact", (ue.E_a_c_num == null) ? Convert.DBNull : ue.E_a_c_num);
            cmd.Parameters.AddWithValue("@Desig", (ue.E_desig == null) ? Convert.DBNull : ue.E_desig);
            cmd.Parameters.AddWithValue("@G_name", (ue.E_g_name == null) ? Convert.DBNull : ue.E_g_name);
            cmd.Parameters.AddWithValue("@G_cnic", (ue.E_g_cnic == null) ? Convert.DBNull : ue.E_g_cnic);
            cmd.Parameters.AddWithValue("@Addr", (ue.E_res_addr == null) ? Convert.DBNull : ue.E_res_addr);
            addemployee(cmd);
        }
        internal void addemployee(SqlCommand cmd)
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
