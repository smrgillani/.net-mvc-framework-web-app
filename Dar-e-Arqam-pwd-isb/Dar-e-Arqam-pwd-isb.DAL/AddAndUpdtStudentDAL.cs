using Dar_e_Arqam_pwd_isb.ENT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace Dar_e_Arqam_pwd_isb.DAL
{
    public class AddAndUpdtStudentDAL
    {
        public void AddStudent(Students s)
        {
            SqlCommand cmd = new SqlCommand("INSERT into Students (reg_id,name,ntnlty,grade,dob,pob,gender,c_h_addr,p_h_addr,stdnt_h_ph_ll,stdnt_pp_s_pic,emrgncy_p_name,emrgncy_p_rltn,emrgncy_p_c_num,emrgncy_p_ll_num,emrgncy_p_addr,emrgncy_p_email,father_name,ocptn,title,father_c_num,name_of_bsns,addr_of_bsns,father_email,father_ll_num,mother_name,mother_c_num,mother_ll_num,first_bro_name,first_bro_g,scnd_bro_name,scnd_bro_g,thrd_bro_name,thrd_bro_g,four_bro_name,four_bro_g,psn,doa,loi,first_schl_name,first_schl_d_from,first_schl_d_to,scnd_schl_name,scnd_schl_d_from,scnd_schl_d_to,xplntn_abt_stdnt,hobby_spcl_intrst,knwldg_source_of_da,verify,date,month,year,time) VALUES (@Reg_id,@Name,@Ntnlty,@Grade,@Dob,@Pob,@Gender,@C_h_addr,@P_h_addr,@Stdnt_h_ph_ll,@Stdnt_pp_s_pic,@Emrgncy_p_name,@Emrgncy_p_rltn,@Emrgncy_p_c_num,@Emrgncy_p_ll_num,@Emrgncy_p_addr,@Emrgncy_p_email,@Father_name,@Ocptn,@Title,@Father_c_num,@Name_of_bsns,@Addr_of_bsns,@Father_email,@Father_ll_num,@Mother_name,@Mother_c_num,@Mother_ll_num,@First_bro_name,@First_bro_g,@Scnd_bro_name,@Scnd_bro_g,@Thrd_bro_name,@Thrd_bro_g,@Four_bro_name,@Four_bro_g,@Psn,@Doa,@Loi,@First_schl_name,@First_schl_d_from,@First_schl_d_to,@Scnd_schl_name,@Scnd_schl_d_from,@Scnd_schl_d_to,@Xplntn_abt_stdnt,@Hobby_spcl_intrst,@Knwldg_source_of_da,@Verify,@Date,@Month,@Year,@Time)", DALUtil.getConnection());
            cmd.Parameters.AddWithValue("@Reg_id", (s.Aplicnt_Id == null) ? Convert.DBNull : s.Aplicnt_Id);
            cmd.Parameters.AddWithValue("@Name", (s.Aplicnt_name == null) ? Convert.DBNull : s.Aplicnt_name);
            cmd.Parameters.AddWithValue("@Ntnlty", (s.Aplicnt_nnlty == null) ? Convert.DBNull : s.Aplicnt_nnlty);
            cmd.Parameters.AddWithValue("@Grade", (s.Aplicnt_c_grade == null) ? Convert.DBNull : s.Aplicnt_c_grade);
            cmd.Parameters.AddWithValue("@Dob", (s.Aplicnt_dob == null) ? Convert.DBNull : s.Aplicnt_dob);
            cmd.Parameters.AddWithValue("@Pob", (s.Aplicnt_pob == null) ? Convert.DBNull : s.Aplicnt_pob);
            cmd.Parameters.AddWithValue("@Gender", (s.Aplicnt_gender == null) ? Convert.DBNull : s.Aplicnt_gender);
            cmd.Parameters.AddWithValue("@C_h_addr", (s.Aplicnt_c_addr == null) ? Convert.DBNull : s.Aplicnt_c_addr);
            cmd.Parameters.AddWithValue("@P_h_addr", (s.Aplicnt_p_addr == null) ? Convert.DBNull : s.Aplicnt_p_addr);
            cmd.Parameters.AddWithValue("@Stdnt_h_ph_ll", (s.Aplicnt_h_phone == null) ? Convert.DBNull : s.Aplicnt_h_phone);
            cmd.Parameters.AddWithValue("@stdnt_pp_s_pic", (s.Aplicnt_pp_photo == null) ? Convert.DBNull : s.Aplicnt_pp_photo);
            cmd.Parameters.AddWithValue("@Emrgncy_p_name", (s.Aplicnt_emrgncy_p_name == null) ? Convert.DBNull : s.Aplicnt_emrgncy_p_name);
            cmd.Parameters.AddWithValue("@Emrgncy_p_rltn", (s.Aplicnt_emrgncy_p_rltn == null) ? Convert.DBNull : s.Aplicnt_emrgncy_p_rltn);
            cmd.Parameters.AddWithValue("@Emrgncy_p_c_num", (s.Aplicnt_emrgncy_p_cell == null) ? Convert.DBNull : s.Aplicnt_emrgncy_p_cell);
            cmd.Parameters.AddWithValue("@Emrgncy_p_ll_num", (s.Aplicnt_emrgncy_p_ldln == null) ? Convert.DBNull : s.Aplicnt_emrgncy_p_ldln);
            cmd.Parameters.AddWithValue("@Emrgncy_p_addr", (s.Aplicnt_emrgncy_p_addr == null) ? Convert.DBNull : s.Aplicnt_emrgncy_p_addr);
            cmd.Parameters.AddWithValue("@Emrgncy_p_email", (s.Aplicnt_emrgncy_p_email == null) ? Convert.DBNull : s.Aplicnt_emrgncy_p_email);
            cmd.Parameters.AddWithValue("@Father_name", (s.Aplicnt_f_name == null) ? Convert.DBNull : s.Aplicnt_f_name);
            cmd.Parameters.AddWithValue("@Ocptn", (s.Aplicnt_f_ocptn == null) ? Convert.DBNull : s.Aplicnt_f_ocptn);
            cmd.Parameters.AddWithValue("@Title", (s.Aplicnt_f_title == null) ? Convert.DBNull : s.Aplicnt_f_title);
            cmd.Parameters.AddWithValue("@Father_c_num", (s.Aplicnt_f_cell == null) ? Convert.DBNull : s.Aplicnt_f_cell);
            cmd.Parameters.AddWithValue("@Name_of_bsns", (s.Aplicnt_f_bsns_name == null) ? Convert.DBNull : s.Aplicnt_f_bsns_name);
            cmd.Parameters.AddWithValue("@Addr_of_bsns", (s.Aplicnt_f_bsns_addr == null) ? Convert.DBNull : s.Aplicnt_f_bsns_addr);
            cmd.Parameters.AddWithValue("@Father_email", (s.Aplicnt_f_email == null) ? Convert.DBNull : s.Aplicnt_f_email);
            cmd.Parameters.AddWithValue("@Father_ll_num", (s.Aplicnt_f_phone == null) ? Convert.DBNull : s.Aplicnt_f_phone);
            cmd.Parameters.AddWithValue("@Mother_name", (s.Aplicnt_m_name == null) ? Convert.DBNull : s.Aplicnt_m_name);
            cmd.Parameters.AddWithValue("@Mother_c_num", (s.Aplicnt_m_cell == null) ? Convert.DBNull : s.Aplicnt_m_cell);
            cmd.Parameters.AddWithValue("@Mother_ll_num", (s.Aplicnt_m_ldln == null) ? Convert.DBNull : s.Aplicnt_m_ldln);
            cmd.Parameters.AddWithValue("@First_bro_name", (s.Aplicnt_b_one_name == null) ? Convert.DBNull : s.Aplicnt_b_one_name);
            cmd.Parameters.AddWithValue("@First_bro_g", (s.Aplicnt_b_one_grade == null) ? Convert.DBNull : s.Aplicnt_b_one_grade);
            cmd.Parameters.AddWithValue("@Scnd_bro_name", (s.Aplicnt_b_two_name == null) ? Convert.DBNull : s.Aplicnt_b_two_name);
            cmd.Parameters.AddWithValue("@Scnd_bro_g", (s.Aplicnt_b_two_grade == null) ? Convert.DBNull : s.Aplicnt_b_two_grade);
            cmd.Parameters.AddWithValue("@Thrd_bro_name", (s.Aplicnt_b_thr_name == null) ? Convert.DBNull : s.Aplicnt_b_thr_name);
            cmd.Parameters.AddWithValue("@Thrd_bro_g", (s.Aplicnt_b_thr_grade == null) ? Convert.DBNull : s.Aplicnt_b_thr_grade);
            cmd.Parameters.AddWithValue("@Four_bro_name", (s.Aplicnt_b_fou_name == null) ? Convert.DBNull : s.Aplicnt_b_fou_name);
            cmd.Parameters.AddWithValue("@Four_bro_g", (s.Aplicnt_b_fou_grade == null) ? Convert.DBNull : s.Aplicnt_b_fou_grade);
            cmd.Parameters.AddWithValue("@Psn", (s.Aplicnt_b_prsnt_schl == null) ? Convert.DBNull : s.Aplicnt_b_prsnt_schl);
            cmd.Parameters.AddWithValue("@Doa", (s.Aplicnt_b_date_atdnc == null) ? Convert.DBNull : s.Aplicnt_b_date_atdnc);
            cmd.Parameters.AddWithValue("@Loi", (s.Aplicnt_b_lng_ins == null) ? Convert.DBNull : s.Aplicnt_b_lng_ins);
            cmd.Parameters.AddWithValue("@First_schl_name", (s.Aplicnt_p_schl_name_o == null) ? Convert.DBNull : s.Aplicnt_p_schl_name_o);
            cmd.Parameters.AddWithValue("@First_schl_d_from", (s.Aplicnt_p_schl_strt_date_o == null) ? Convert.DBNull : s.Aplicnt_p_schl_strt_date_o);
            cmd.Parameters.AddWithValue("@First_schl_d_to", (s.Aplicnt_p_schl_end_date_o == null) ? Convert.DBNull : s.Aplicnt_p_schl_end_date_o);
            cmd.Parameters.AddWithValue("@Scnd_schl_name", (s.Aplicnt_p_schl_name_t == null) ? Convert.DBNull : s.Aplicnt_p_schl_name_t);
            cmd.Parameters.AddWithValue("@Scnd_schl_d_from", (s.Aplicnt_p_schl_strt_date_t == null) ? Convert.DBNull : s.Aplicnt_p_schl_strt_date_t);
            cmd.Parameters.AddWithValue("@Scnd_schl_d_to", (s.Aplicnt_p_schl_end_date_t == null) ? Convert.DBNull : s.Aplicnt_p_schl_end_date_t);
            cmd.Parameters.AddWithValue("@Xplntn_abt_stdnt", (s.Aplicnt_phycl_emo_cndtn_ackwlg == null) ? Convert.DBNull : s.Aplicnt_phycl_emo_cndtn_ackwlg);
            cmd.Parameters.AddWithValue("@Hobby_spcl_intrst", (s.Aplicnt_spcl_intrst_hobby == null) ? Convert.DBNull : s.Aplicnt_spcl_intrst_hobby);
            cmd.Parameters.AddWithValue("@Knwldg_source_of_da", (s.Source_of_acknwlge_abt_da == null) ? Convert.DBNull : s.Source_of_acknwlge_abt_da);
            cmd.Parameters.AddWithValue("@Verify", (s.Aplicnt_admsn_verify == null) ? Convert.DBNull : s.Aplicnt_admsn_verify);
            cmd.Parameters.AddWithValue("@Date", (s.Date == null) ? Convert.DBNull : s.Date);
            cmd.Parameters.AddWithValue("@Month", (s.Month == null) ? Convert.DBNull : s.Month);
            cmd.Parameters.AddWithValue("@Year", (s.Year == null) ? Convert.DBNull : s.Year);
            cmd.Parameters.AddWithValue("@Time", (s.Time == null) ? Convert.DBNull : s.Time);
            addstudent(cmd);
        }

        public void UpdateStudent(Students s, int id)
        {
            SqlCommand cmd = new SqlCommand("Update students Set reg_id=@Reg_id,name=@Name,ntnlty=@Ntnlty,grade=@Grade,dob=@Dob,pob=@Pob,gender=@Gender,c_h_addr=@C_h_addr,p_h_addr=@P_h_addr,stdnt_h_ph_ll=@Stdnt_h_ph_ll,emrgncy_p_name=@Emrgncy_p_name,emrgncy_p_rltn=@Emrgncy_p_rltn,emrgncy_p_c_num=@Emrgncy_p_c_num,emrgncy_p_ll_num=@Emrgncy_p_ll_num,emrgncy_p_addr=@Emrgncy_p_addr,emrgncy_p_email=@Emrgncy_p_email,father_name=@Father_name,ocptn=@Ocptn,title=@Title,father_c_num=@Father_c_num,name_of_bsns=@Name_of_bsns,addr_of_bsns=@Addr_of_bsns,father_email=@Father_email,father_ll_num=@Father_ll_num,mother_name=@Mother_name,mother_c_num=@Mother_c_num,mother_ll_num=@Mother_ll_num,first_bro_name=@First_bro_name,first_bro_g=@First_bro_g,scnd_bro_name=@Scnd_bro_name,scnd_bro_g=@Scnd_bro_g,thrd_bro_name=@Thrd_bro_name,thrd_bro_g=@Thrd_bro_g,four_bro_name=@Four_bro_name,four_bro_g=@Four_bro_g,psn=@Psn,doa=@Doa,first_schl_name=@First_schl_name,first_schl_d_from=@First_schl_d_from,first_schl_d_to=@First_schl_d_to,scnd_schl_name=@Scnd_schl_name,scnd_schl_d_from=@Scnd_schl_d_from,scnd_schl_d_to=@Scnd_schl_d_to,xplntn_abt_stdnt=@Xplntn_abt_stdnt,hobby_spcl_intrst=@Hobby_spcl_intrst,knwldg_source_of_da=@Knwldg_source_of_da Where id=@Id", DALUtil.getConnection());
            cmd.Parameters.AddWithValue("@Id", id);
            cmd.Parameters.AddWithValue("@Reg_id", (s.Aplicnt_Id == null) ? Convert.DBNull : s.Aplicnt_Id);
            cmd.Parameters.AddWithValue("@Name", (s.Aplicnt_name == null) ? Convert.DBNull : s.Aplicnt_name);
            cmd.Parameters.AddWithValue("@Ntnlty", (s.Aplicnt_nnlty == null) ? Convert.DBNull : s.Aplicnt_nnlty);
            cmd.Parameters.AddWithValue("@Grade", (s.Aplicnt_c_grade == null) ? Convert.DBNull : s.Aplicnt_c_grade);
            cmd.Parameters.AddWithValue("@Dob", (s.Aplicnt_dob == null) ? Convert.DBNull : s.Aplicnt_dob);
            cmd.Parameters.AddWithValue("@Pob", (s.Aplicnt_pob == null) ? Convert.DBNull : s.Aplicnt_pob);
            cmd.Parameters.AddWithValue("@Gender", (s.Aplicnt_gender == null) ? Convert.DBNull : s.Aplicnt_gender);
            cmd.Parameters.AddWithValue("@C_h_addr", (s.Aplicnt_c_addr == null) ? Convert.DBNull : s.Aplicnt_c_addr);
            cmd.Parameters.AddWithValue("@P_h_addr", (s.Aplicnt_p_addr == null) ? Convert.DBNull : s.Aplicnt_p_addr);
            cmd.Parameters.AddWithValue("@Stdnt_h_ph_ll", (s.Aplicnt_h_phone == null) ? Convert.DBNull : s.Aplicnt_h_phone);
            cmd.Parameters.AddWithValue("@Emrgncy_p_name", (s.Aplicnt_emrgncy_p_name == null) ? Convert.DBNull : s.Aplicnt_emrgncy_p_name);
            cmd.Parameters.AddWithValue("@Emrgncy_p_rltn", (s.Aplicnt_emrgncy_p_rltn == null) ? Convert.DBNull : s.Aplicnt_emrgncy_p_rltn);
            cmd.Parameters.AddWithValue("@Emrgncy_p_c_num", (s.Aplicnt_emrgncy_p_cell == null) ? Convert.DBNull : s.Aplicnt_emrgncy_p_cell);
            cmd.Parameters.AddWithValue("@Emrgncy_p_ll_num", (s.Aplicnt_emrgncy_p_ldln == null) ? Convert.DBNull : s.Aplicnt_emrgncy_p_ldln);
            cmd.Parameters.AddWithValue("@Emrgncy_p_addr", (s.Aplicnt_emrgncy_p_addr == null) ? Convert.DBNull : s.Aplicnt_emrgncy_p_addr);
            cmd.Parameters.AddWithValue("@Emrgncy_p_email", (s.Aplicnt_emrgncy_p_email == null) ? Convert.DBNull : s.Aplicnt_emrgncy_p_email);
            cmd.Parameters.AddWithValue("@Father_name", (s.Aplicnt_f_name == null) ? Convert.DBNull : s.Aplicnt_f_name);
            cmd.Parameters.AddWithValue("@Ocptn", (s.Aplicnt_f_ocptn == null) ? Convert.DBNull : s.Aplicnt_f_ocptn);
            cmd.Parameters.AddWithValue("@Title", (s.Aplicnt_f_title == null) ? Convert.DBNull : s.Aplicnt_f_title);
            cmd.Parameters.AddWithValue("@Father_c_num", (s.Aplicnt_f_cell == null) ? Convert.DBNull : s.Aplicnt_f_cell);
            cmd.Parameters.AddWithValue("@Name_of_bsns", (s.Aplicnt_f_bsns_name == null) ? Convert.DBNull : s.Aplicnt_f_bsns_name);
            cmd.Parameters.AddWithValue("@Addr_of_bsns", (s.Aplicnt_f_bsns_addr == null) ? Convert.DBNull : s.Aplicnt_f_bsns_addr);
            cmd.Parameters.AddWithValue("@Father_email", (s.Aplicnt_f_email == null) ? Convert.DBNull : s.Aplicnt_f_email);
            cmd.Parameters.AddWithValue("@Father_ll_num", (s.Aplicnt_f_phone == null) ? Convert.DBNull : s.Aplicnt_f_phone);
            cmd.Parameters.AddWithValue("@Mother_name", (s.Aplicnt_m_name == null) ? Convert.DBNull : s.Aplicnt_m_name);
            cmd.Parameters.AddWithValue("@Mother_c_num", (s.Aplicnt_m_cell == null) ? Convert.DBNull : s.Aplicnt_m_cell);
            cmd.Parameters.AddWithValue("@Mother_ll_num", (s.Aplicnt_m_ldln == null) ? Convert.DBNull : s.Aplicnt_m_ldln);
            cmd.Parameters.AddWithValue("@First_bro_name", (s.Aplicnt_b_one_name == null) ? Convert.DBNull : s.Aplicnt_b_one_name);
            cmd.Parameters.AddWithValue("@First_bro_g", (s.Aplicnt_b_one_grade == null) ? Convert.DBNull : s.Aplicnt_b_one_grade);
            cmd.Parameters.AddWithValue("@Scnd_bro_name", (s.Aplicnt_b_two_name == null) ? Convert.DBNull : s.Aplicnt_b_two_name);
            cmd.Parameters.AddWithValue("@Scnd_bro_g", (s.Aplicnt_b_two_grade == null) ? Convert.DBNull : s.Aplicnt_b_two_grade);
            cmd.Parameters.AddWithValue("@Thrd_bro_name", (s.Aplicnt_b_thr_name == null) ? Convert.DBNull : s.Aplicnt_b_thr_name);
            cmd.Parameters.AddWithValue("@Thrd_bro_g", (s.Aplicnt_b_thr_grade == null) ? Convert.DBNull : s.Aplicnt_b_thr_grade);
            cmd.Parameters.AddWithValue("@Four_bro_name", (s.Aplicnt_b_fou_name == null) ? Convert.DBNull : s.Aplicnt_b_fou_name);
            cmd.Parameters.AddWithValue("@Four_bro_g", (s.Aplicnt_b_fou_grade == null) ? Convert.DBNull : s.Aplicnt_b_fou_grade);
            cmd.Parameters.AddWithValue("@Psn", (s.Aplicnt_b_prsnt_schl == null) ? Convert.DBNull : s.Aplicnt_b_prsnt_schl);
            cmd.Parameters.AddWithValue("@Doa", (s.Aplicnt_b_date_atdnc == null) ? Convert.DBNull : s.Aplicnt_b_date_atdnc);
            cmd.Parameters.AddWithValue("@Loi", (s.Aplicnt_b_lng_ins == null) ? Convert.DBNull : s.Aplicnt_b_lng_ins);
            cmd.Parameters.AddWithValue("@First_schl_name", (s.Aplicnt_p_schl_name_o == null) ? Convert.DBNull : s.Aplicnt_p_schl_name_o);
            cmd.Parameters.AddWithValue("@First_schl_d_from", (s.Aplicnt_p_schl_strt_date_o == null) ? Convert.DBNull : s.Aplicnt_p_schl_strt_date_o);
            cmd.Parameters.AddWithValue("@First_schl_d_to", (s.Aplicnt_p_schl_end_date_o == null) ? Convert.DBNull : s.Aplicnt_p_schl_end_date_o);
            cmd.Parameters.AddWithValue("@Scnd_schl_name", (s.Aplicnt_p_schl_name_t == null) ? Convert.DBNull : s.Aplicnt_p_schl_name_t);
            cmd.Parameters.AddWithValue("@Scnd_schl_d_from", (s.Aplicnt_p_schl_strt_date_t == null) ? Convert.DBNull : s.Aplicnt_p_schl_strt_date_t);
            cmd.Parameters.AddWithValue("@Scnd_schl_d_to", (s.Aplicnt_p_schl_end_date_t == null) ? Convert.DBNull : s.Aplicnt_p_schl_end_date_t);
            cmd.Parameters.AddWithValue("@Xplntn_abt_stdnt", (s.Aplicnt_phycl_emo_cndtn_ackwlg == null) ? Convert.DBNull : s.Aplicnt_phycl_emo_cndtn_ackwlg);
            cmd.Parameters.AddWithValue("@Hobby_spcl_intrst", (s.Aplicnt_spcl_intrst_hobby == null) ? Convert.DBNull : s.Aplicnt_spcl_intrst_hobby);
            cmd.Parameters.AddWithValue("@Knwldg_source_of_da", (s.Source_of_acknwlge_abt_da == null) ? Convert.DBNull : s.Source_of_acknwlge_abt_da);
            addstudent(cmd);
        }

        public void PublishStudent(Students ps, int id)
        {
            SqlCommand cmd = new SqlCommand("Update Students Set result_set=@Publish_result Where id = @Id", DALUtil.getConnection());
            cmd.Parameters.AddWithValue("@Id", id);
            cmd.Parameters.AddWithValue("@Publish_result", (ps.Publish_result == null) ? Convert.DBNull : ps.Publish_result);
            addstudent(cmd);
        }

        public void PublishAllStudents(Students pas)
        {
            SqlCommand cmd = new SqlCommand("Update Students Set result_set=@Publish_result", DALUtil.getConnection());
            cmd.Parameters.AddWithValue("@Publish_result", (pas.Publish_result == null) ? Convert.DBNull : pas.Publish_result);
            addstudent(cmd);
        }

        public void AddSubjectsObtainMarksForResult(List<SubjectResults> sr)
        {
            foreach (SubjectResults srd in sr)
            {
                SqlCommand cmd = new SqlCommand("INSERT into result_details (sub_r_id,student_id,subject_id,obtain_marks,status,date,month,year,time) VALUES (@Sub_r_id,@Student_id,@Subject_id,@Obtain_marks,@Status,@Date,@Month,@Year,@Time)", DALUtil.getConnection());
                cmd.Parameters.AddWithValue("@Sub_r_id", (srd.Sub_r_id == null) ? Convert.DBNull : srd.Sub_r_id);
                cmd.Parameters.AddWithValue("@Student_id", (srd.Student_id == null) ? Convert.DBNull : srd.Student_id);
                cmd.Parameters.AddWithValue("@Subject_id", (srd.Subject_id == null) ? Convert.DBNull : srd.Subject_id);
                cmd.Parameters.AddWithValue("@Obtain_marks", srd.Obtn_marks);
                cmd.Parameters.AddWithValue("@Status", srd.Status);
                cmd.Parameters.AddWithValue("@Date", (srd.Date == null) ? Convert.DBNull : srd.Date);
                cmd.Parameters.AddWithValue("@Month", (srd.Month == null) ? Convert.DBNull : srd.Month);
                cmd.Parameters.AddWithValue("@Year", (srd.Year == null) ? Convert.DBNull : srd.Year);
                cmd.Parameters.AddWithValue("@Time", (srd.Time == null) ? Convert.DBNull : srd.Time);
                addstudent(cmd);
            }
        }

        public void UpdtSubjectsObtainMarksForResult(List<SubjectResults> sr)
        {
            foreach (SubjectResults srd in sr)
            {
                SqlCommand cmd = new SqlCommand("Update result_details Set obtain_marks=@Obtain_marks , status=@Status where id=@Id", DALUtil.getConnection());
                cmd.Parameters.AddWithValue("@Id", srd.Id);
                cmd.Parameters.AddWithValue("@Obtain_marks", srd.Obtn_marks);
                cmd.Parameters.AddWithValue("@Status", srd.Status);
                addstudent(cmd);
            }
        }

        public void AddResultPosition(ResultsPositions rs)
        {
            SqlCommand cmd = new SqlCommand("INSERT into Position_in_rslt (sub_result_id,student_id,class_section,position,date,month,year,time) VALUES (@Sub_r_id,@Student_id,@Class_Section,@Obtn_Pstn,@Date,@Month,@Year,@Time)", DALUtil.getConnection());
            cmd.Parameters.AddWithValue("@Sub_r_id", (rs.Sub_r_id == null) ? Convert.DBNull : rs.Sub_r_id);
            cmd.Parameters.AddWithValue("@Student_id", (rs.Student_id == null) ? Convert.DBNull : rs.Student_id);
            cmd.Parameters.AddWithValue("@Class_Section", (rs.Class_Section == null) ? Convert.DBNull : rs.Class_Section);
            cmd.Parameters.AddWithValue("@Obtn_Pstn", rs.Obtn_Pstn);
            cmd.Parameters.AddWithValue("@Date", (rs.Date == null) ? Convert.DBNull : rs.Date);
            cmd.Parameters.AddWithValue("@Month", (rs.Month == null) ? Convert.DBNull : rs.Month);
            cmd.Parameters.AddWithValue("@Year", (rs.Year == null) ? Convert.DBNull : rs.Year);
            cmd.Parameters.AddWithValue("@Time", (rs.Time == null) ? Convert.DBNull : rs.Time);
            addstudent(cmd);
        }

        public void DeleteSubjectResult(int sid, int rid)
        {
            SqlCommand cmd = new SqlCommand("Delete From result_details Where student_id=@Sid and sub_r_id=@Rid", DALUtil.getConnection());
            cmd.Parameters.AddWithValue("@Sid", sid);
            cmd.Parameters.AddWithValue("@Rid", rid);
            addstudent(cmd);
        }

        public void DeleteResultPosition(int id)
        {
            SqlCommand cmd = new SqlCommand("Delete From Position_in_rslt Where id=@Id", DALUtil.getConnection());
            cmd.Parameters.AddWithValue("@Id", id);
            addstudent(cmd);
        }

        internal void addstudent(SqlCommand cmd)
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
