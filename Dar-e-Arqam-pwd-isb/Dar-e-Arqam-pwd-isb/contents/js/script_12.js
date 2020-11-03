$(document).ready(function () {
    $("#Student_Aplicnt_dob,#Student_Aplicnt_b_date_atdnc,#Student_Aplicnt_p_schl_strt_date_o,#Student_Aplicnt_p_schl_end_date_o,#Student_Aplicnt_p_schl_strt_date_t,#Student_Aplicnt_p_schl_end_date_t").datepicker();
var aplicnt_id = $("#Student_Aplicnt_Id"),
         aplicnt_name = $("#Student_Aplicnt_name"),
         aplicnt_nnlty = $("#Student_Aplicnt_nnlty"),
         aplicnt_c_grade = $("#Student_Aplicnt_c_grade"),
         aplicnt_dob = $("#Student_Aplicnt_dob"),
         aplicnt_pob = $("#Student_Aplicnt_pob"),
         aplicnt_gender = $("#Student_Aplicnt_gender"),
         aplicnt_c_addr = $("#Student_Aplicnt_c_addr"),
         aplicnt_p_addr = $("#Student_Aplicnt_p_addr"),
         aplicnt_h_phone = $("#Student_Aplicnt_h_phone"),
         aplicnt_pp_photo = $("#Student_Aplicnt_pp_photo"),
         aplicnt_emrgncy_p_name = $("#Student_Aplicnt_emrgncy_p_name"),
         aplicnt_emrgncy_p_rltn = $("#Student_Aplicnt_emrgncy_p_rltn"),
         aplicnt_emrgncy_p_cell = $("#Student_Aplicnt_emrgncy_p_cell"),
         aplicnt_emrgncy_p_ldln = $("#Student_Aplicnt_emrgncy_p_ldln"),
         aplicnt_emrgncy_p_addr = $("#Student_Aplicnt_emrgncy_p_addr"),
         aplicnt_emrgncy_p_email = $("#Student_Aplicnt_emrgncy_p_email"),
         aplicnt_f_name = $("#Student_Aplicnt_f_name"),
         aplicnt_f_ocptn = $("#Student_Aplicnt_f_ocptn"),
         aplicnt_f_title = $("#Student_Aplicnt_f_title"),
         aplicnt_f_cell = $("#Student_Aplicnt_f_cell"),
         aplicnt_f_bsns_name = $("#Student_Aplicnt_f_bsns_name"),
         aplicnt_f_bsns_addr = $("#Student_Aplicnt_f_bsns_addr"),
         aplicnt_f_email = $("#Student_Aplicnt_f_email"),
         aplicnt_f_phone = $("#Student_Aplicnt_f_phone"),
         aplicnt_m_name = $("#Student_Aplicnt_m_name"),
         aplicnt_m_cell = $("#Student_Aplicnt_m_cell"),
         aplicnt_m_ldln = $("#Student_Aplicnt_m_ldln"),
         aplicnt_b_one_name = $("#Student_Aplicnt_b_one_name"),
         aplicnt_b_one_grade = $("#Student_Aplicnt_b_one_grade"),
         aplicnt_b_two_name = $("#Student_Aplicnt_b_two_name"),
         aplicnt_b_two_grade = $("#Student_Aplicnt_b_two_grade"),
         aplicnt_b_thr_name = $("#Student_Aplicnt_b_thr_name"),
         aplicnt_b_thr_grade = $("#Student_Aplicnt_b_thr_grade"),
         aplicnt_b_fou_name = $("#Student_Aplicnt_b_fou_name"),
         aplicnt_b_fou_grade = $("#Student_Aplicnt_b_fou_grade"),
         aplicnt_b_prsnt_schl = $("#Student_Aplicnt_b_prsnt_schl"),
         aplicnt_b_date_atdnc = $("#Student_Aplicnt_b_date_atdnc"),
         aplicnt_b_lng_ins = $("#Student_Aplicnt_b_lng_ins"),
         aplicnt_p_schl_name_o = $("#Student_Aplicnt_p_schl_name_o"),
         aplicnt_p_schl_strt_date_o = $("#Student_Aplicnt_p_schl_strt_date_o"),
         aplicnt_p_schl_end_date_o = $("#Student_Aplicnt_p_schl_end_date_o"),
         aplicnt_p_schl_name_t = $("#Student_Aplicnt_p_schl_name_t"),
         aplicnt_p_schl_strt_date_t = $("#Student_Aplicnt_p_schl_strt_date_t"),
         aplicnt_p_schl_end_date_t = $("#Student_Aplicnt_p_schl_end_date_t"),
         aplicnt_phycl_emo_cndtn_ackwlg = $("#Student_Aplicnt_phycl_emo_cndtn_ackwlg"),
         aplicnt_spcl_intrst_hobby = $("#Student_Aplicnt_spcl_intrst_hobby"),
         source_of_acknwlge_abt_da = $("#Student_Source_of_acknwlge_abt_da"),
        allFields = $([]).add(aplicnt_id).add(aplicnt_name).add(aplicnt_nnlty).add(aplicnt_c_grade).add(aplicnt_dob).add(aplicnt_pob).add(aplicnt_gender).add(aplicnt_c_addr).add(aplicnt_p_addr).add(aplicnt_h_phone).add(aplicnt_pp_photo).add(aplicnt_emrgncy_p_name).add(aplicnt_emrgncy_p_rltn).add(aplicnt_emrgncy_p_cell).add(aplicnt_emrgncy_p_ldln).add(aplicnt_emrgncy_p_addr).add(aplicnt_emrgncy_p_email).add(aplicnt_f_name).add(aplicnt_f_ocptn).add(aplicnt_f_title).add(aplicnt_f_cell).add(aplicnt_f_bsns_name).add(aplicnt_f_bsns_addr).add(aplicnt_f_email).add(aplicnt_f_phone)
        .add(aplicnt_m_name).add(aplicnt_m_cell).add(aplicnt_m_ldln).add(aplicnt_b_one_name).add(aplicnt_b_one_grade).add(aplicnt_b_two_name).add(aplicnt_b_two_grade).add(aplicnt_b_thr_name).add(aplicnt_b_thr_grade).add(aplicnt_b_fou_name).add(aplicnt_b_fou_grade).add(aplicnt_b_prsnt_schl).add(aplicnt_b_date_atdnc).add(aplicnt_b_lng_ins).add(aplicnt_p_schl_name_o).add(aplicnt_p_schl_strt_date_o).add(aplicnt_p_schl_end_date_o).add(aplicnt_p_schl_name_t).add(aplicnt_p_schl_strt_date_t).add(aplicnt_p_schl_end_date_t).add(aplicnt_phycl_emo_cndtn_ackwlg).add(aplicnt_spcl_intrst_hobby)
        .add(source_of_acknwlge_abt_da), tips = $(".form_msgs");

        function updateTips(t) {
            tips.text(t).addClass("form_msg_highlight");
            setTimeout(function () {
                tips.removeClass("form_msg_highlight", 5000);
            }, 5000);
        }

        function checkLength(o, n, min, max) {
            if (o.val().length > max || o.val().length < min) {
                o.addClass("form_error_alrt");
                updateTips("Enter " + n + "and Length of " + n + " must be between " +
                  min + " and " + max + ".");
                o.focus();
                return false;
            } else {
                o.removeClass("form_error_alrt");
                return true;
            }
        }

        function fixLength(o, n, max) {
            if (o.val().length != max) {
                o.addClass("form_error_alrt");
                updateTips("Enter " + n + " and Length of " + n + " must be " + max + ".");
                o.focus();
                return false;
            } else {
                o.removeClass("form_error_alrt");
                return true;
            }
        }

        function minLength(o, n, min) {
            if (o.val().length < min) {
                o.addClass("form_error_alrt");
                updateTips(n);
                o.focus();
                return false;
            } else {
                o.removeClass("form_error_alrt");
                return true;
            }
        }

        function checkOptn(o, n , max) {
            if (o.val().length > max) {
                o.addClass("form_error_alrt");
                updateTips("Enter " + n + " and Length of " + n + " must be " + max + ".");
                o.focus();
                return false;
            } else {
                o.removeClass("form_error_alrt");
                return true;
            }
        }

        function limitLength(o, n, max) {
            if (o.val().length > max) {
                o.addClass("form_error_alrt");
                updateTips("Enter " + n + " and Length of " + n + " consist of " + max + " letters.");
                o.focus();
                return false;
            } else {
                o.removeClass("form_error_alrt");
                return true;
            }
        }

        function checkRegexp(o, regexp, n) {
            if (o.val().length > 0) {
                if (!(regexp.test(o.val()))) {
                    o.addClass("form_error_alrt");
                    updateTips(n);
                    o.focus();
                    return false;
                } else {
                    o.removeClass("form_error_alrt");
                    return true;
                }
            }
            else {
                return true;
            }
        }

        function checkNull(o, n) {
            if (o.val() == 0) {
                o.addClass("form_error_alrt");
                updateTips(n);
                o.focus();
                return false;
            } else {
                o.removeClass("form_error_alrt");
                return true;
            }
        }

        $("#submit_admsn_form").click(function (event) {
        var bValid = true;
            allFields.removeClass("form_error_alrt");
            bValid = bValid && checkLength(aplicnt_id, "Reg ID ", 3, 20);

            bValid = bValid && checkRegexp(aplicnt_id, /^[0-9]+$/, "Registration ID should consist of 0 to 9 letters.");

            bValid = bValid && checkLength(aplicnt_name, "Applicant Name ", 3, 150);

            bValid = bValid && checkRegexp(aplicnt_name, /^[a-zA-Z0-9\s]+$/, "Applicant name should consist of A to Z , 0 to 9 letters.");

            bValid = bValid && checkLength(aplicnt_nnlty, "Applicant Nationalty ", 3, 150);

            bValid = bValid && checkRegexp(aplicnt_nnlty, /^[a-zA-Z\s]+$/, "Applicant Nationalty should consist of A to Z letters.");

            bValid = bValid && checkNull(aplicnt_c_grade, "Please choose a Grade for applicant.");

            bValid = bValid && fixLength(aplicnt_dob, "Date Of Birth ", 10);

            bValid = bValid && checkRegexp(aplicnt_dob, /^[0-9'\-/]+$/, "Date Of Birth should consist 0 to 9 and '-' Or '/' letters.");

            bValid = bValid && checkLength(aplicnt_pob, "Place Of Birth ", 3, 150);

            bValid = bValid && checkRegexp(aplicnt_pob, /^[a-zA-Z\s]+$/, "Place Of Birth should consist of A to Z letters.");
            bValid = bValid && checkNull(aplicnt_gender, "Please Choose a Gender for applicant.");

            bValid = bValid && checkLength(aplicnt_c_addr, "Current Home Address ", 3, 450);
            bValid = bValid && checkRegexp(aplicnt_c_addr, /^[\sa-zA-Z0-9'\.,-/]+$/, "Please don't use special letters for Current Home Address of applicant.");

            bValid = bValid && checkLength(aplicnt_p_addr, "Permanent Home Address ", 3, 450);
            bValid = bValid && checkRegexp(aplicnt_p_addr, /^[\sa-zA-Z0-9'\.,-/]+$/, "Please don't use special letters for Permanent Home Address of applicant.");

            bValid = bValid && checkOptn(aplicnt_h_phone, "Home Phone ", 11);
            bValid = bValid && checkRegexp(aplicnt_h_phone, /^((\+92)|(0092))-{0,1}\d{3}-{0,1}\d{7}$|^\d{11}$|^\d{4}-\d{7}$/, "Please Enter A Valid Number. Example : 92512615630");

            bValid = bValid && checkRegexp(aplicnt_pp_photo, /\.(gif|jpg|jpeg|png|Gif|JPG|JPEG|PNG)$/, "Only Jpg , Jpeg , png and gif exntention of image are allowed !");

            bValid = bValid && checkLength(aplicnt_emrgncy_p_name, "Person Name ", 3, 150);
            bValid = bValid && checkRegexp(aplicnt_emrgncy_p_name, /^[a-zA-Z0-9\s]+$/, "Person name should consist of A to Z , 0 to 9 letters.");

            bValid = bValid && checkLength(aplicnt_emrgncy_p_rltn, "Relation ", 3, 150);
            bValid = bValid && checkRegexp(aplicnt_emrgncy_p_rltn, /^[a-zA-Z\s]+$/, "Relation should consist of A to Z letters.");

            bValid = bValid && checkLength(aplicnt_emrgncy_p_cell, "Cell number ", 10, 13);
            bValid = bValid && checkRegexp(aplicnt_emrgncy_p_cell, /^((\+92)|(0092))-{0,1}\d{3}-{0,1}\d{7}$|^\d{11}$|^\d{4}-\d{7}$/, "Please Enter A Valid Cell Number. Example +923119301092");

            bValid = bValid && checkOptn(aplicnt_emrgncy_p_ldln, "Landline ", 13);
            bValid = bValid && checkRegexp(aplicnt_emrgncy_p_ldln, /^((\+92)|(0092))-{0,1}\d{3}-{0,1}\d{7}$|^\d{11}$|^\d{4}-\d{7}$/, "Please Enter A Valid Number. Example : 92512615630");

            bValid = bValid && checkOptn(aplicnt_emrgncy_p_addr, "Address ", 450);
            bValid = bValid && checkRegexp(aplicnt_emrgncy_p_addr, /^[\sa-zA-Z0-9'\.,-/]+$/, "Please don't use special letters for Address.");

            bValid = bValid && checkOptn(aplicnt_emrgncy_p_email, "Email ", 80);
            bValid = bValid && checkRegexp(aplicnt_emrgncy_p_email, /^((([a-z]|\d|[!#\$%&'\*\+\-\/=\?\^_`{\|}~]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])+(\.([a-z]|\d|[!#\$%&'\*\+\-\/=\?\^_`{\|}~]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])+)*)|((\x22)((((\x20|\x09)*(\x0d\x0a))?(\x20|\x09)+)?(([\x01-\x08\x0b\x0c\x0e-\x1f\x7f]|\x21|[\x23-\x5b]|[\x5d-\x7e]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(\\([\x01-\x09\x0b\x0c\x0d-\x7f]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF]))))*(((\x20|\x09)*(\x0d\x0a))?(\x20|\x09)+)?(\x22)))@((([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])*([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])))\.)+(([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])*([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])))\.?$/i, "Please Enter A Valid Email Address");
            bValid = bValid && checkLength(aplicnt_f_name, "Father Name ", 3, 150);
            bValid = bValid && checkRegexp(aplicnt_f_name, /^[a-zA-Z0-9\s]+$/, "Father name should consist of A to Z , 0 to 9 letters.");
            bValid = bValid && checkOptn(aplicnt_f_ocptn, "Occupation ", 150);
            bValid = bValid && checkRegexp(aplicnt_f_ocptn, /^[a-zA-Z\s]+$/, "Occupation should consist of A to Z letters.");            
            bValid = bValid && checkOptn(aplicnt_f_title, "Title ", 150);
            bValid = bValid && checkRegexp(aplicnt_f_title, /^[a-zA-Z\s]+$/, "Title should consist of A to Z letters.");
            bValid = bValid && checkLength(aplicnt_f_cell, "Cell number ", 10, 13);
            bValid = bValid && checkRegexp(aplicnt_f_cell, /^((\+92)|(0092))-{0,1}\d{3}-{0,1}\d{7}$|^\d{11}$|^\d{4}-\d{7}$/, "Please Enter A Valid Cell Number. Example +923119301092");
            bValid = bValid && checkOptn(aplicnt_f_bsns_name, "Name Of Business ", 150);
            bValid = bValid && checkRegexp(aplicnt_f_bsns_name, /^[a-zA-Z0-9\s]+$/, "Name Of Business should consist of A to Z , 0 to 9 letters.");
            bValid = bValid && checkOptn(aplicnt_f_bsns_addr, "Business Address ", 450);
            bValid = bValid && checkRegexp(aplicnt_f_bsns_addr, /^[\sa-zA-Z0-9'\.,-/]+$/, "Please don't use special letters for Business Address.");
            bValid = bValid && checkOptn(aplicnt_f_email, "Email ", 80);
            bValid = bValid && checkRegexp(aplicnt_f_email, /^((([a-z]|\d|[!#\$%&'\*\+\-\/=\?\^_`{\|}~]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])+(\.([a-z]|\d|[!#\$%&'\*\+\-\/=\?\^_`{\|}~]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])+)*)|((\x22)((((\x20|\x09)*(\x0d\x0a))?(\x20|\x09)+)?(([\x01-\x08\x0b\x0c\x0e-\x1f\x7f]|\x21|[\x23-\x5b]|[\x5d-\x7e]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(\\([\x01-\x09\x0b\x0c\x0d-\x7f]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF]))))*(((\x20|\x09)*(\x0d\x0a))?(\x20|\x09)+)?(\x22)))@((([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])*([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])))\.)+(([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])*([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])))\.?$/i, "Please Enter A Valid Email Address");
            bValid = bValid && checkOptn(aplicnt_f_phone, "Phone(Landline) ", 13);
            bValid = bValid && checkRegexp(aplicnt_f_phone, /^((\+92)|(0092))-{0,1}\d{3}-{0,1}\d{7}$|^\d{11}$|^\d{4}-\d{7}$/, "Please Enter A Valid Number. Example : 92512615630");
            bValid = bValid && checkOptn(aplicnt_m_name, "Mother Name ", 150);
            bValid = bValid && checkRegexp(aplicnt_m_name, /^[a-zA-Z0-9\s]+$/, "Mother name should consist of A to Z , 0 to 9 letters.");
            bValid = bValid && checkOptn(aplicnt_m_cell, "Cell number ", 13);
            bValid = bValid && checkRegexp(aplicnt_m_cell, /^((\+92)|(0092))-{0,1}\d{3}-{0,1}\d{7}$|^\d{11}$|^\d{4}-\d{7}$/, "Please Enter A Valid Cell Number. Example +923119301092");
            bValid = bValid && checkOptn(aplicnt_m_ldln, "Phone (Landline) ", 13);
            bValid = bValid && checkRegexp(aplicnt_m_ldln, /^((\+92)|(0092))-{0,1}\d{3}-{0,1}\d{7}$|^\d{11}$|^\d{4}-\d{7}$/, "Please Enter A Valid Number. Example : 92512615630");
            bValid = bValid && checkOptn(aplicnt_b_one_name, "Name ", 150);
            bValid = bValid && checkRegexp(aplicnt_b_one_name, /^[a-zA-Z0-9\s]+$/, "Name should consist of A to Z , 0 to 9 letters.");
            bValid = bValid && checkOptn(aplicnt_b_one_grade, "Grade ", 150);
            bValid = bValid && checkRegexp(aplicnt_b_one_grade, /^[a-zA-Z0-9\s]+$/, "Grade should consist of A to Z , 0 to 9 letters.");
            bValid = bValid && checkOptn(aplicnt_b_two_name, "Name ", 150);
            bValid = bValid && checkRegexp(aplicnt_b_two_name, /^[a-zA-Z0-9\s]+$/, "Name should consist of A to Z , 0 to 9 letters.");
            bValid = bValid && checkOptn(aplicnt_b_two_grade, "Grade ", 150);
            bValid = bValid && checkRegexp(aplicnt_b_two_grade, /^[a-zA-Z0-9\s]+$/, "Grade should consist of A to Z , 0 to 9 letters.");
            bValid = bValid && checkOptn(aplicnt_b_thr_name, "Name ", 150);
            bValid = bValid && checkRegexp(aplicnt_b_thr_name, /^[a-zA-Z0-9\s]+$/, "Name should consist of A to Z , 0 to 9 letters.");
            bValid = bValid && checkOptn(aplicnt_b_thr_grade, "Grade ", 150);
            bValid = bValid && checkRegexp(aplicnt_b_thr_grade, /^[a-zA-Z0-9\s]+$/, "Grade should consist of A to Z , 0 to 9 letters.");
            bValid = bValid && checkOptn(aplicnt_b_fou_name, "Name ", 150);
            bValid = bValid && checkRegexp(aplicnt_b_fou_name, /^[a-zA-Z0-9\s]+$/, "Name should consist of A to Z , 0 to 9 letters.");
            bValid = bValid && checkOptn(aplicnt_b_fou_grade, "Grade ", 150);
            bValid = bValid && checkRegexp(aplicnt_b_fou_grade, /^[a-zA-Z0-9\s]+$/, "Grade should consist of A to Z , 0 to 9 letters.");
            bValid = bValid && checkOptn(aplicnt_b_prsnt_schl, "Present School Name ", 350);
            bValid = bValid && checkRegexp(aplicnt_b_prsnt_schl, /^[a-zA-Z0-9\s]+$/, "Present School Name should consist of A to Z , 0 to 9 letters.");
            bValid = bValid && checkOptn(aplicnt_b_date_atdnc, "Date of Attendence ", 10);
            bValid = bValid && checkRegexp(aplicnt_b_date_atdnc, /^[0-9'\-/]+$/, "Date of Attendence should consist 0 to 9 and '-' Or '/' letters.");

            bValid = bValid && checkOptn(aplicnt_b_lng_ins, "Language of Instruction ", 150);
            bValid = bValid && checkRegexp(aplicnt_b_lng_ins, /^[a-zA-Z0-9\s]+$/, "Language of Instruction should consist of A to Z , 0 to 9 letters.");

            bValid = bValid && checkOptn(aplicnt_p_schl_name_o, "School Name ", 350);
            bValid = bValid && checkRegexp(aplicnt_p_schl_name_o, /^[a-zA-Z0-9\s]+$/, "School Name should consist of A to Z , 0 to 9 letters.");

            bValid = bValid && checkOptn(aplicnt_p_schl_strt_date_o, "Date ", 10);
            bValid = bValid && checkRegexp(aplicnt_p_schl_strt_date_o, /^[0-9'\-/]+$/, "Date should consist 0 to 9 and '-' Or '/' letters.");

            bValid = bValid && checkOptn(aplicnt_p_schl_end_date_o, "Date ", 10);
            bValid = bValid && checkRegexp(aplicnt_p_schl_end_date_o, /^[0-9'\-/]+$/, "Date should consist 0 to 9 and '-' Or '/' letters.");

            bValid = bValid && checkOptn(aplicnt_p_schl_name_t, "School Name ", 350);
            bValid = bValid && checkRegexp(aplicnt_p_schl_name_t, /^[a-zA-Z0-9\s]+$/, "School Name should consist of A to Z , 0 to 9 letters.");

            bValid = bValid && checkOptn(aplicnt_p_schl_strt_date_t, "Date ", 10);
            bValid = bValid && checkRegexp(aplicnt_p_schl_strt_date_t, /^[0-9'\-/]+$/, "Date should consist 0 to 9 and '-' Or '/' letters.");

            bValid = bValid && checkOptn(aplicnt_p_schl_end_date_t, "Date ", 10);
            bValid = bValid && checkRegexp(aplicnt_p_schl_end_date_t, /^[0-9'\-/]+$/, "Date should consist 0 to 9 and '-' Or '/' letters.");

            bValid = bValid && checkOptn(aplicnt_phycl_emo_cndtn_ackwlg, "explanation about student physical or emotional condition ", 450);
            bValid = bValid && checkRegexp(aplicnt_phycl_emo_cndtn_ackwlg, /^[\sa-zA-Z0-9'\.,-/]+$/, "Please don't use special letters for explanation about student physical or emotional condition.");

            bValid = bValid && checkOptn(aplicnt_spcl_intrst_hobby, "Applicant Hobby or special interest  ", 450);
            bValid = bValid && checkRegexp(aplicnt_spcl_intrst_hobby, /^[\sa-zA-Z0-9'\.,-/]+$/, "Please don't use special letters.");

            bValid = bValid && checkOptn(source_of_acknwlge_abt_da, "the source have some to know about Dar-e-Arqam ", 450);
            bValid = bValid && checkRegexp(source_of_acknwlge_abt_da, /^[\sa-zA-Z0-9'\.,-/]+$/, "Please don't use special letters.");

        if (bValid) {
            $('#adm_forms').submit();
        }
        });
        $("#ChangeSettingsStudent").click(function (event) {
            event.preventDefault();
            $.ajax({
                url: $(this).attr('href'),
                success: function (temp) {
                    $("#dialog-add-form").html(temp);
                    $("#dialog-add-form").dialog(
                                  {
                                      modal: true,
                                      title: "Change Settings Of Student",
                                      width: "450px",
                                      show: { effect: 'drop', direction: "up" },
                                      hide: { effect: 'drop', direction: "down" },
                                      draggable: false,
                                      buttons: {
                                          "Update": function () {
                                              var publish = $("#Publish_result"),
                                               allFields = $([]).add(publish), tips = $(".form_msgs");

                                              function updateTips(t) {
                                                  tips.text(t).addClass("form_msg_highlight");
                                                  setTimeout(function () {
                                                      tips.removeClass("form_msg_highlight", 5000);
                                                  }, 5000);
                                              }

                                              function checkNull(o, n) {
                                                  if (o.val() == 0) {
                                                      o.addClass("form_error_alrt");
                                                      updateTips(n);
                                                      o.focus();
                                                      return false;
                                                  } else {
                                                      o.removeClass("form_error_alrt");
                                                      return true;
                                                  }
                                              }

                                              var bValid = true;
                                              allFields.removeClass("form_error_alrt");
                                              bValid = bValid && checkNull(publish, "Please choose an option to publish this student result  !  ");
                                              if (bValid) {
                                                  $('#dialog-add-form Form').submit();
                                              }
                                          },
                                          "Cancel": function () {
                                              $(this).dialog("close");
                                          }
                                      }
                                  }
                          );
                },
                error: function (xhr, ajaxOptions, thrownError) {
                    $("#dialog-error").dialog('open');
                }
            }
                    );
        });

        $(".AddResultOfSubjects").click(function (event) {
            event.preventDefault();
            $.ajax({
                url: $(this).attr('href'),
                success: function (temp) {
                    $("#dialog-add-form").html(temp);
                    $("#dialog-add-form").dialog(
                                  {
                                      modal: true,
                                      title: "Add Subjects Obtained Marks To Result",
                                      width: "540px",
                                      show: { effect: 'drop', direction: "up" },
                                      hide: { effect: 'drop', direction: "down" },
                                      draggable: false,
                                      buttons: {
                                          "Save": function () {
                                              var subjectresult_sub_r_id = $("#SubjectResult_Sub_r_id"),
                                                  subjectresult_subject = $("#SubjectResult_Subject"),
                                                  subjectresult_total_marks = $("#SubjectResult_Total_marks"),
                                                  subjectResult_obtn_marks = $(".obtn_marks"),
                                                  subjectResult_status = $(".status"),
                                               allFields = $([]).add(subjectresult_sub_r_id).add(subjectresult_subject).add(subjectresult_total_marks).add(subjectResult_obtn_marks).add(subjectResult_status), tips = $(".form_msgs");

                                              function updateTips(t) {
                                                  tips.text(t).addClass("form_msg_highlight");
                                                  setTimeout(function () {
                                                      tips.removeClass("form_msg_highlight", 5000);
                                                  }, 5000);
                                              }

                                              function checkNull(o, n) {
                                                  if (o.val() == -1) {
                                                      o.addClass("form_error_alrt");
                                                      updateTips(n);
                                                      o.focus();
                                                      return false;
                                                  } else {
                                                      o.removeClass("form_error_alrt");
                                                      return true;
                                                  }
                                              }

                                              function checkLength(o, n, min, max) {
                                                  if (o.val().length > max || o.val().length < min) {
                                                      o.addClass("form_error_alrt");
                                                      updateTips("Enter " + n + "and Length of " + n + " must be between " +
                                                        min + " and " + max + ".");
                                                      o.focus();
                                                      return false;
                                                  } else {
                                                      o.removeClass("form_error_alrt");
                                                      return true;
                                                  }
                                              }
                                              
                                              function checkRegexp(o, regexp, n) {
                                                  if (o.val().length > 0) {
                                                      if (!(regexp.test(o.val()))) {
                                                          o.addClass("form_error_alrt");
                                                          updateTips(n);
                                                          o.focus();
                                                          return false;
                                                      } else {
                                                          o.removeClass("form_error_alrt");
                                                          return true;
                                                      }
                                                  }
                                                  else {
                                                      return true;
                                                  }
                                              }

                                              var bValid = true;
                                              allFields.removeClass("form_error_alrt");
                                              //bValid = bValid && checkNull(subjectresult_sub_r_id, "Please choose a result !  ");
                                              //bValid = bValid && checkNull(subjectresult_subject, "Please choose a subject !  ");
                                              //bValid = bValid && checkLength(subjectresult_total_marks, "Total Marks ", 1, 8);
                                              //bValid = bValid && checkRegexp(subjectresult_total_marks, /^[0-9'\.]+$/, "Total Marks should consist of 0 to 9 letters.");
                                              //bValid = bValid && checkLength(subjectResult_obtn_marks, "Obtain Marks ", 1, 8);
                                              //bValid = bValid && checkRegexp(subjectResult_obtn_marks, /^[0-9'\.]+$/, "Obtain Marks should consist of 0 to 9 letters.");
                                              //bValid = bValid && checkNull(subjectResult_status, "Please choose a status !  ");
                                              if (bValid) {
                                                  $('#dialog-add-form Form').submit();
                                              }
                                          },
                                          "Cancel": function () {
                                              $(this).dialog("close");
                                          }
                                      }
                                  }
                          );
                },
                error: function (xhr, ajaxOptions, thrownError) {
                    $("#dialog-error").dialog('open');
                }
            }
                    );
        });
        $(".UpdateResultOfSubjects").click(function (event) {
            event.preventDefault();
            $.ajax({
                url: $(this).attr('href'),
                success: function (temp) {
                    $("#dialog-add-form").html(temp);
                    $("#dialog-add-form").dialog(
                                  {
                                      modal: true,
                                      title: "Update Result Of Subjects",
                                      width: "540px",
                                      show: { effect: 'drop', direction: "up" },
                                      hide: { effect: 'drop', direction: "down" },
                                      draggable: false,
                                      buttons: {
                                          "Update": function () {
                                                  var subjectresult_sub_r_id = $("#SubjectResult_Sub_r_id"),
                                                      subjectresult_subject = $("#SubjectResult_Subject"),
                                                      subjectresult_total_marks = $("#SubjectResult_Total_marks"),
                                                      subjectResult_obtn_marks = $("#SubjectResult_Obtn_marks"),
                                                   allFields = $([]).add(subjectresult_sub_r_id).add(subjectresult_subject).add(subjectresult_total_marks).add(subjectResult_obtn_marks), tips = $(".form_msgs");

                                                  function updateTips(t) {
                                                      tips.text(t).addClass("form_msg_highlight");
                                                      setTimeout(function () {
                                                          tips.removeClass("form_msg_highlight", 5000);
                                                      }, 5000);
                                                  }

                                                  function checkNull(o, n) {
                                                      if (o.val() == 0) {
                                                          o.addClass("form_error_alrt");
                                                          updateTips(n);
                                                          o.focus();
                                                          return false;
                                                      } else {
                                                          o.removeClass("form_error_alrt");
                                                          return true;
                                                      }
                                                  }

                                                  function checkLength(o, n, min, max) {
                                                      if (o.val().length > max || o.val().length < min) {
                                                          o.addClass("form_error_alrt");
                                                          updateTips("Enter " + n + "and Length of " + n + " must be between " +
                                                            min + " and " + max + ".");
                                                          o.focus();
                                                          return false;
                                                      } else {
                                                          o.removeClass("form_error_alrt");
                                                          return true;
                                                      }
                                                  }
                                              
                                                  function checkRegexp(o, regexp, n) {
                                                      if (o.val().length > 0) {
                                                          if (!(regexp.test(o.val()))) {
                                                              o.addClass("form_error_alrt");
                                                              updateTips(n);
                                                              o.focus();
                                                              return false;
                                                          } else {
                                                              o.removeClass("form_error_alrt");
                                                              return true;
                                                          }
                                                      }
                                                      else {
                                                          return true;
                                                      }
                                                  }

                                                  var bValid = true;
                                                  allFields.removeClass("form_error_alrt");
                                                  //bValid = bValid && checkNull(subjectresult_sub_r_id, "Please choose a result !  ");
                                                  //bValid = bValid && checkLength(subjectresult_subject, "Subject Name ", 1, 80);
                                                  //bValid = bValid && checkRegexp(subjectresult_subject, /^[a-zA-Z0-9\s]+$/, "Subject Name should consist of 0 to 9 letters.");
                                                  //bValid = bValid && checkLength(subjectresult_total_marks, "Total Marks ", 1, 5);
                                                  //bValid = bValid && checkRegexp(subjectresult_total_marks, /^[0-9]+$/, "Total Marks should consist of 0 to 9 letters.");
                                                  //bValid = bValid && checkLength(subjectResult_obtn_marks, "Obtain Marks ", 1, 5);
                                                  //bValid = bValid && checkRegexp(subjectResult_obtn_marks, /^[0-9]+$/, "Obtain Marks should consist of 0 to 9 letters.");
                                                  if (bValid) {
                                                      $('#dialog-add-form Form').submit();
                                                  }
                                          },
                                          "Cancel": function () {
                                              $(this).dialog("close");
                                          }
                                      }
                                  }
                          );
                },
                error: function (xhr, ajaxOptions, thrownError) {
                    $("#dialog-error").dialog('open');
                }
            }
                    );
        });
        $("#AddPositionOfResult").click(function (event) {
            event.preventDefault();
            $.ajax({
                url: $(this).attr('href'),
                success: function (temp) {
                    $("#dialog-add-form").html(temp);
                    $("#dialog-add-form").dialog(
                                  {
                                      modal: true,
                                      title: "Add Position Of Result",
                                      width: "450px",
                                      show: { effect: 'drop', direction: "up" },
                                      hide: { effect: 'drop', direction: "down" },
                                      draggable: false,
                                      buttons: {
                                          "Save": function () {
                                              var result_position_sub_r_id = $("#Result_Position_Sub_r_id"),
                                                  result_position_class_section = $("#Result_Position_Class_Section"),
                                                  result_position_obtn_pstn = $("#Result_Position_Obtn_Pstn"),
                                               allFields = $([]).add(result_position_sub_r_id).add(result_position_class_section).add(result_position_obtn_pstn), tips = $(".form_msgs");

                                              function updateTips(t) {
                                                  tips.text(t).addClass("form_msg_highlight");
                                                  setTimeout(function () {
                                                      tips.removeClass("form_msg_highlight", 5000);
                                                  }, 5000);
                                              }

                                              function checkNull(o, n) {
                                                  if (o.val() == 0) {
                                                      o.addClass("form_error_alrt");
                                                      updateTips(n);
                                                      o.focus();
                                                      return false;
                                                  } else {
                                                      o.removeClass("form_error_alrt");
                                                      return true;
                                                  }
                                              }

                                              function checkLength(o, n, min, max) {
                                                  if (o.val().length > max || o.val().length < min) {
                                                      o.addClass("form_error_alrt");
                                                      updateTips("Enter " + n + "and Length of " + n + " must be between " +
                                                        min + " and " + max + ".");
                                                      o.focus();
                                                      return false;
                                                  } else {
                                                      o.removeClass("form_error_alrt");
                                                      return true;
                                                  }
                                              }

                                              function checkRegexp(o, regexp, n) {
                                                  if (o.val().length > 0) {
                                                      if (!(regexp.test(o.val()))) {
                                                          o.addClass("form_error_alrt");
                                                          updateTips(n);
                                                          o.focus();
                                                          return false;
                                                      } else {
                                                          o.removeClass("form_error_alrt");
                                                          return true;
                                                      }
                                                  }
                                                  else {
                                                      return true;
                                                  }
                                              }

                                              var bValid = true;
                                              allFields.removeClass("form_error_alrt");
                                              bValid = bValid && checkNull(result_position_sub_r_id, "Please choose a result !  ");
                                              bValid = bValid && checkLength(result_position_class_section, "Class Section ", 1, 3);
                                              bValid = bValid && checkRegexp(result_position_class_section, /^[a-zA-Z\s]+$/, "Class Section should consist of A to Z letters.");
                                              bValid = bValid && checkLength(result_position_obtn_pstn, "Position ", 1, 5);
                                              bValid = bValid && checkRegexp(result_position_obtn_pstn, /^[a-zA-Z0-9\s]+$/, "Position should consist of A to Z And 0 to 9 letters.");
                                              if (bValid) {
                                                  $('#dialog-add-form Form').submit();
                                              }
                                          },
                                          "Cancel": function () {
                                              $(this).dialog("close");
                                          }
                                      }
                                  }
                          );
                },
                error: function (xhr, ajaxOptions, thrownError) {
                    $("#dialog-error").dialog('open');
                }
            }
                    );
        });
        $(".ViewResultsOfStudent").click(function (event) {
            event.preventDefault();
            $.ajax({
                url: $(this).attr('href'),
                success: function (temp) {
                    $("#dialog-add-form").html(temp);
                    $("#dialog-add-form").dialog(
                                  {
                                      modal: true,
                                      title: "Result",
                                      width: "975px",
                                      show: { effect: 'drop', direction: "up" },
                                      hide: { effect: 'drop', direction: "down" },
                                      draggable: false,
                                      buttons : false
                                  }
                          );
                },
                error: function (xhr, ajaxOptions, thrownError) {
                    $("#dialog-error").dialog('open');
                }
            }
                    );
        });

        $("#dialog-error").dialog({
            autoOpen: false,
            title: "Message",
            resizable: false,
            height: 100,
            width: 850,
            show: { effect: 'drop', direction: "up" },
            modal: true,
            draggable: true,
        });

        $("#dialog-msg").dialog({
            autoOpen: false,
            title: "Message",
            resizable: false,
            height: 100,
            width: 520,
            show: { effect: 'drop', direction: "up" },
            modal: true,
            draggable: true,
        });
});