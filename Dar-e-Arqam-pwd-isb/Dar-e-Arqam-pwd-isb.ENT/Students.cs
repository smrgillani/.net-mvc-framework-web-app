using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dar_e_Arqam_pwd_isb.ENT
{
    public class Students
    {
        //data1 relevent to applicant
        public string db_Id { get; set; }
        public string Aplicnt_Id { get; set; }
        public string Aplicnt_name { get; set; }
        public string Aplicnt_nnlty { get; set; }
        public string Aplicnt_c_grade { get; set; }
        public string Aplicnt_dob { get; set; }
        public string Aplicnt_pob { get; set; }
        public string Aplicnt_gender { get; set; }
        public string Aplicnt_c_addr { get; set; }
        public string Aplicnt_p_addr { get; set; }
        public string Aplicnt_h_phone { get; set; }
        public string Aplicnt_pp_photo { get; set; }

        //data for applicant in case of emergency 
        public string Aplicnt_emrgncy_p_name { get; set; }
        public string Aplicnt_emrgncy_p_rltn { get; set; }
        public string Aplicnt_emrgncy_p_cell { get; set; }
        public string Aplicnt_emrgncy_p_ldln { get; set; }
        public string Aplicnt_emrgncy_p_addr { get; set; }
        public string Aplicnt_emrgncy_p_email { get; set; }

        //data of applicant parents
        public string Aplicnt_f_name { get; set; }
        public string Aplicnt_f_ocptn { get; set; }
        public string Aplicnt_f_title { get; set; }
        public string Aplicnt_f_cell { get; set; }
        public string Aplicnt_f_bsns_name { get; set; }
        public string Aplicnt_f_bsns_addr { get; set; }
        public string Aplicnt_f_email { get; set; }
        public string Aplicnt_f_phone { get; set; }
        public string Aplicnt_m_name { get; set; }
        public string Aplicnt_m_cell { get; set; }
        public string Aplicnt_m_ldln { get; set; }

        //data2 relevent to applicant
        public string Aplicnt_b_one_name { get; set; }
        public string Aplicnt_b_one_grade { get; set; }
        public string Aplicnt_b_two_name { get; set; }
        public string Aplicnt_b_two_grade { get; set; }
        public string Aplicnt_b_thr_name { get; set; }
        public string Aplicnt_b_thr_grade { get; set; }
        public string Aplicnt_b_fou_name { get; set; }
        public string Aplicnt_b_fou_grade { get; set; }
        public string Aplicnt_b_prsnt_schl { get; set; }
        public string Aplicnt_b_date_atdnc { get; set; }
        public string Aplicnt_b_lng_ins { get; set; }

        //data3 relevent to applicant
        public string Aplicnt_p_schl_name_o { get; set; }
        public string Aplicnt_p_schl_strt_date_o { get; set; }
        public string Aplicnt_p_schl_end_date_o { get; set; }
        public string Aplicnt_p_schl_name_t { get; set; }
        public string Aplicnt_p_schl_strt_date_t { get; set; }
        public string Aplicnt_p_schl_end_date_t { get; set; }
        public string Aplicnt_phycl_emo_cndtn_ackwlg { get; set; }
        public string Aplicnt_spcl_intrst_hobby { get; set; }
        public string Source_of_acknwlge_abt_da { get; set; }
        public string Aplicnt_admsn_verify { get; set; }

        public string Publish_result { get; set; }
        public string Active_set { get; set; }
        public virtual ClassLevels ClassName { get; set; }
        public virtual Sub_Results Subresult { get; set; }

        public string Date { get; set; }
        public string Month { get; set; }
        public string Year { get; set; }
        public string Time { get; set; }
    }
}