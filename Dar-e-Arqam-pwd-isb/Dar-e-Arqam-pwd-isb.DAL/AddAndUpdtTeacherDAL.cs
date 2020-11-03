using Dar_e_Arqam_pwd_isb.ENT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace Dar_e_Arqam_pwd_isb.DAL
{
    public class AddAndUpdtTeacherDAL
    {
        public void AddTeacher(Teachers t)
        {
            SqlCommand cmd = new SqlCommand("INSERT into Teachers (t_id,name,dob,cnic,gender,email,contact,alt_contact,type,desig,dj,spcl_in_sbjct,gurdian_name,gurdian_cnic,addr,active_id,del_id,date,month,year,time) VALUES (@T_id,@Name,@Dob,@Cnic,@Gender,@Email,@Contact,@Alt_contact,@Type,@Desig,@Dj,@Spcl_in_sbjct,@G_name,@G_cnic,@Addr,@Active_id,@Del_id,@Date,@Month,@Year,@Time)", DALUtil.getConnection());
            cmd.Parameters.AddWithValue("@T_id", (t.T_Id == null) ? Convert.DBNull : t.T_Id);
            cmd.Parameters.AddWithValue("@Name", (t.T_name == null) ? Convert.DBNull : t.T_name);
            cmd.Parameters.AddWithValue("@Dob", (t.T_dob == null) ? Convert.DBNull : t.T_dob);
            cmd.Parameters.AddWithValue("@Cnic", (t.T_cnic == null) ? Convert.DBNull : t.T_cnic);
            cmd.Parameters.AddWithValue("@Gender", (t.T_gen == null) ? Convert.DBNull : t.T_gen);
            cmd.Parameters.AddWithValue("@Email", (t.T_email == null) ? Convert.DBNull : t.T_email);
            cmd.Parameters.AddWithValue("@Contact", (t.T_c_num == null) ? Convert.DBNull : t.T_c_num);
            cmd.Parameters.AddWithValue("@Alt_contact", (t.T_a_c_num == null) ? Convert.DBNull : t.T_a_c_num);
            cmd.Parameters.AddWithValue("@Type", (t.T_type == null) ? Convert.DBNull : t.T_type);
            cmd.Parameters.AddWithValue("@Desig", (t.T_desig == null) ? Convert.DBNull : t.T_desig);
            cmd.Parameters.AddWithValue("@Dj", (t.T_jd == null) ? Convert.DBNull : t.T_jd);
            cmd.Parameters.AddWithValue("@Spcl_in_sbjct", (t.T_spcl_in_sbjct == null) ? Convert.DBNull : t.T_spcl_in_sbjct);
            cmd.Parameters.AddWithValue("@G_name", (t.T_g_name == null) ? Convert.DBNull : t.T_g_name);
            cmd.Parameters.AddWithValue("@G_cnic", (t.T_g_cnic == null) ? Convert.DBNull : t.T_g_cnic);
            cmd.Parameters.AddWithValue("@Addr", (t.T_res_addr == null) ? Convert.DBNull : t.T_res_addr);
            cmd.Parameters.AddWithValue("@Active_id", (t.Active_id == null) ? Convert.DBNull : t.Active_id);
            cmd.Parameters.AddWithValue("@Del_id", (t.Del_id == null) ? Convert.DBNull : t.Del_id);
            cmd.Parameters.AddWithValue("@Date", (t.Date == null) ? Convert.DBNull : t.Date);
            cmd.Parameters.AddWithValue("@Month", (t.Month == null) ? Convert.DBNull : t.Month);
            cmd.Parameters.AddWithValue("@Year", (t.Year == null) ? Convert.DBNull : t.Year);
            cmd.Parameters.AddWithValue("@Time", (t.Time == null) ? Convert.DBNull : t.Time);
            Teacher(cmd);
        }

        public void UpdateTeacher(Teachers t, int id)
        {
            SqlCommand cmd = new SqlCommand("Update teachers Set t_id=@T_id , name=@Name , dob=@Dob , cnic=@Cnic , gender=@Gender , email=@Email , contact=@Contact , type=@Type , desig=@Desig , dj=@Dj , spcl_in_sbjct=@Spcl_in_sbjct , gurdian_name=@G_name , gurdian_cnic=@G_cnic , addr=@Addr Where id = @Id", DALUtil.getConnection());
            cmd.Parameters.AddWithValue("@Id", id);
            cmd.Parameters.AddWithValue("@T_id", (t.T_Id == null) ? Convert.DBNull : t.T_Id);
            cmd.Parameters.AddWithValue("@Name", (t.T_name == null) ? Convert.DBNull : t.T_name);
            cmd.Parameters.AddWithValue("@Dob", (t.T_dob == null) ? Convert.DBNull : t.T_dob);
            cmd.Parameters.AddWithValue("@Cnic", (t.T_cnic == null) ? Convert.DBNull : t.T_cnic);
            cmd.Parameters.AddWithValue("@Gender", (t.T_gen == null) ? Convert.DBNull : t.T_gen);
            cmd.Parameters.AddWithValue("@Email", (t.T_email == null) ? Convert.DBNull : t.T_email);
            cmd.Parameters.AddWithValue("@Contact", (t.T_c_num == null) ? Convert.DBNull : t.T_c_num);
            cmd.Parameters.AddWithValue("@Alt_contact", (t.T_a_c_num == null) ? Convert.DBNull : t.T_a_c_num);
            cmd.Parameters.AddWithValue("@Type", (t.T_type == null) ? Convert.DBNull : t.T_type);
            cmd.Parameters.AddWithValue("@Desig", (t.T_desig == null) ? Convert.DBNull : t.T_desig);
            cmd.Parameters.AddWithValue("@Dj", (t.T_jd == null) ? Convert.DBNull : t.T_jd);
            cmd.Parameters.AddWithValue("@Spcl_in_sbjct", (t.T_spcl_in_sbjct == null) ? Convert.DBNull : t.T_spcl_in_sbjct);
            cmd.Parameters.AddWithValue("@G_name", (t.T_g_name == null) ? Convert.DBNull : t.T_g_name);
            cmd.Parameters.AddWithValue("@G_cnic", (t.T_g_cnic == null) ? Convert.DBNull : t.T_g_cnic);
            cmd.Parameters.AddWithValue("@Addr", (t.T_res_addr == null) ? Convert.DBNull : t.T_res_addr);
            Teacher(cmd);
        }

        public void AsgnClsSub(ClassesOrSubjectsToTeacher cs, int id)
        {
            SqlCommand cmd = new SqlCommand("INSERT into asgnd_cls_sbjcts_to_tchr (T_id,classsubject_id,date,month,year,time) VALUES (@T_id,@CS_id,@Date,@Month,@Year,@Time)", DALUtil.getConnection());
            cmd.Parameters.AddWithValue("@T_id", id);
            cmd.Parameters.AddWithValue("@CS_id", (cs.Class_subject_id == null) ? Convert.DBNull : cs.Class_subject_id);
            cmd.Parameters.AddWithValue("@Date", (cs.Date == null) ? Convert.DBNull : cs.Date);
            cmd.Parameters.AddWithValue("@Month", (cs.Month == null) ? Convert.DBNull : cs.Month);
            cmd.Parameters.AddWithValue("@Year", (cs.Year == null) ? Convert.DBNull : cs.Year);
            cmd.Parameters.AddWithValue("@Time", (cs.Time == null) ? Convert.DBNull : cs.Time);
            Teacher(cmd);
        }

        internal void Teacher(SqlCommand cmd)
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
