$(document).ready(function () {
    $("#AddNewEmployee").click(function (event) {
        event.preventDefault();
        $.ajax({
            url: "/management/create",
            success: function (temp) {
                $("#dialog-add-form").html(temp);
                $("#dialog-add-form").dialog(
                              {
                                  modal: true,
                                  title: "Add New Employee",
                                  width: "970px",
                                  show: { effect: 'drop', direction: "up" },
                                  hide: { effect: 'drop', direction: "down" },
                                  draggable: false,
                                  buttons: {
                                      "Save": function () {
                                          var e_id = $("#E_Id"),
                                    e_name = $("#E_name"),
                                    e_dob = $("#E_dob"),
                                    e_cnic = $("#E_cnic"),
                                    e_gen = $("#E_gen"),
                                    e_email = $("#E_email"),
                                    e_c_num = $("#E_c_num"),
                                    e_a_c_num = $("#E_a_c_num"),
                                    e_desig = $("#E_desig"),
                                    e_g_name = $("#E_g_name"),
                                    e_g_cnic = $("#E_g_cnic"),
                                    e_res_addr = $("#E_res_addr"),
                                    allFields = $([]).add(e_id).add(e_name).add(e_dob).add(e_cnic).add(e_gen).add(e_email).add(e_c_num)
                                    .add(e_a_c_num).add(e_desig).add(e_g_name).add(e_g_cnic).add(e_res_addr),
                                    tips = $(".form_msgs");

                                          function updateTips(t) {
                                              tips.text(t).addClass("form_msg_highlight");
                                              setTimeout(function () {
                                                  tips.removeClass("form_msg_highlight", 1500);
                                              }, 500);
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

                                          function checkRegexp(o, regexp, n) {
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
                                          bValid = bValid && checkLength(e_id, "ID", 3, 120);
                                          bValid = bValid && checkRegexp(e_id, /^[a-zA-Z0-9]+$/, "Employee ID should consist of A to Z , 0 to 9 letters.");
                                          bValid = bValid && checkLength(e_name, "Name", 3, 120);
                                          bValid = bValid && checkRegexp(e_name, /^[a-zA-Z\s]+$/, "Name should consist of A to Z letters.");
                                          bValid = bValid && fixLength(e_dob, "Date Of Birth ", 10);
                                          bValid = bValid && checkRegexp(e_dob, /^[0-9'\-/]+$/, "Date Of Birth should consist 0 to 9 and '-' Or '/' letters.");
                                          bValid = bValid && fixLength(e_cnic, "CNIC number", 15);
                                          bValid = bValid && checkRegexp(e_cnic, /^[0-9+]{5}-[0-9+]{7}-[0-9]{1}$/, "Enter A Valid CNIC Number.");
                                          bValid = bValid && checkNull(e_gen, "Please choose the type for Gender");
                                          bValid = bValid && checkLength(e_email, "Email", 3, 80);
                                          bValid = bValid && checkRegexp(e_email, /^((([a-z]|\d|[!#\$%&'\*\+\-\/=\?\^_`{\|}~]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])+(\.([a-z]|\d|[!#\$%&'\*\+\-\/=\?\^_`{\|}~]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])+)*)|((\x22)((((\x20|\x09)*(\x0d\x0a))?(\x20|\x09)+)?(([\x01-\x08\x0b\x0c\x0e-\x1f\x7f]|\x21|[\x23-\x5b]|[\x5d-\x7e]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(\\([\x01-\x09\x0b\x0c\x0d-\x7f]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF]))))*(((\x20|\x09)*(\x0d\x0a))?(\x20|\x09)+)?(\x22)))@((([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])*([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])))\.)+(([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])*([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])))\.?$/i, "Please Enter A Valid Email Address");
                                          bValid = bValid && checkLength(e_c_num, "Contact Number", 10, 13);
                                          bValid = bValid && checkRegexp(e_c_num, /^((\+92)|(0092))-{0,1}\d{3}-{0,1}\d{7}$|^\d{11}$|^\d{4}-\d{7}$/, "Please Enter A Valid Contact Number.");
                                          bValid = bValid && checkLength(e_a_c_num, "Contact Number", 10, 13);
                                          bValid = bValid && checkRegexp(e_a_c_num, /^((\+92)|(0092))-{0,1}\d{3}-{0,1}\d{7}$|^\d{11}$|^\d{4}-\d{7}$/, "Please Enter A Valid Alternative Contact Number.");
                                          bValid = bValid && checkNull(e_desig, "Please choose the Designation for Employee");
                                          bValid = bValid && checkLength(e_g_name, "Guardian Name", 3, 120);
                                          bValid = bValid && checkRegexp(e_g_name, /^[a-zA-Z\s]+$/, "Guardian Name should consist of A to Z , 0 to 9 letters.");
                                          bValid = bValid && fixLength(e_g_cnic, "Guardian CNIC number", 15);
                                          bValid = bValid && checkRegexp(e_g_cnic, /^[0-9+]{5}-[0-9+]{7}-[0-9]{1}$/, "Enter A Valid CNIC Number.");
                                          bValid = bValid && checkLength(e_res_addr, "Residential Address", 10, 400);
                                          bValid = bValid && checkRegexp(e_res_addr, /^[\sa-zA-Z0-9'\.,-/]+$/, "Please don't use special letters for Residential Address.");
                                          if (bValid) {
                                              $('#dialog-form Form').submit();
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
        });
    });

$(".UpdateExistingEmployee").click(function (event) {
        event.preventDefault();
        $.ajax({
            url: $(this).attr('href'),
            success: function (temp) {
                $("#dialog-add-form").html(temp);
                $("#dialog-add-form").dialog(
                              {
                                  modal: true,
                                  title: "Update Employee Info",
                                  width: "970px",
                                  show: { effect: 'drop', direction: "up" },
                                  hide: { effect: 'drop', direction: "down" },
                                  draggable: false,
                                  buttons: {
                                      "Update": function () {
                                          var e_id = $("#E_Id"),
                                    e_name = $("#E_name"),
                                    e_dob = $("#E_dob"),
                                    e_cnic = $("#E_cnic"),
                                    e_gen = $("#E_gen"),
                                    e_email = $("#E_email"),
                                    e_c_num = $("#E_c_num"),
                                    e_a_c_num = $("#E_a_c_num"),
                                    e_desig = $("#E_desig"),
                                    e_g_name = $("#E_g_name"),
                                    e_g_cnic = $("#E_g_cnic"),
                                    e_res_addr = $("#E_res_addr"),
                                    allFields = $([]).add(e_id).add(e_name).add(e_dob).add(e_cnic).add(e_gen).add(e_email).add(e_c_num)
                                    .add(e_a_c_num).add(e_desig).add(e_g_name).add(e_g_cnic).add(e_res_addr),
                                    tips = $(".form_msgs");

                                          function updateTips(t) {
                                              tips.text(t).addClass("form_msg_highlight");
                                              setTimeout(function () {
                                                  tips.removeClass("form_msg_highlight", 1500);
                                              }, 500);
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

                                          function checkRegexp(o, regexp, n) {
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
                                          bValid = bValid && checkLength(e_id, "ID", 3, 120);
                                          bValid = bValid && checkRegexp(e_id, /^[a-zA-Z0-9]+$/, "Employee ID should consist of A to Z , 0 to 9 letters.");
                                          bValid = bValid && checkLength(e_name, "Name", 3, 120);
                                          bValid = bValid && checkRegexp(e_name, /^[a-zA-Z\s]+$/, "Name should consist of A to Z letters.");
                                          bValid = bValid && fixLength(e_dob, "Date Of Birth ", 10);
                                          bValid = bValid && checkRegexp(e_dob, /^[0-9'\-/]+$/, "Date Of Birth should consist 0 to 9 and '-' Or '/' letters.");
                                          bValid = bValid && fixLength(e_cnic, "CNIC number", 15);
                                          bValid = bValid && checkRegexp(e_cnic, /^[0-9+]{5}-[0-9+]{7}-[0-9]{1}$/, "Enter A Valid CNIC Number.");
                                          bValid = bValid && checkNull(e_gen, "Please choose the type for Gender");
                                          bValid = bValid && checkLength(e_email, "Email", 3, 80);
                                          bValid = bValid && checkRegexp(e_email, /^((([a-z]|\d|[!#\$%&'\*\+\-\/=\?\^_`{\|}~]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])+(\.([a-z]|\d|[!#\$%&'\*\+\-\/=\?\^_`{\|}~]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])+)*)|((\x22)((((\x20|\x09)*(\x0d\x0a))?(\x20|\x09)+)?(([\x01-\x08\x0b\x0c\x0e-\x1f\x7f]|\x21|[\x23-\x5b]|[\x5d-\x7e]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(\\([\x01-\x09\x0b\x0c\x0d-\x7f]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF]))))*(((\x20|\x09)*(\x0d\x0a))?(\x20|\x09)+)?(\x22)))@((([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])*([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])))\.)+(([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])*([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])))\.?$/i, "Please Enter A Valid Email Address");
                                          bValid = bValid && checkLength(e_c_num, "Contact Number", 10, 13);
                                          bValid = bValid && checkRegexp(e_c_num, /^((\+92)|(0092))-{0,1}\d{3}-{0,1}\d{7}$|^\d{11}$|^\d{4}-\d{7}$/, "Please Enter A Valid Contact Number.");
                                          bValid = bValid && checkLength(e_a_c_num, "Contact Number", 10, 13);
                                          bValid = bValid && checkRegexp(e_a_c_num, /^((\+92)|(0092))-{0,1}\d{3}-{0,1}\d{7}$|^\d{11}$|^\d{4}-\d{7}$/, "Please Enter A Valid Alternative Contact Number.");
                                          bValid = bValid && checkNull(e_desig, "Please choose the Designation for Employee");
                                          bValid = bValid && checkLength(e_g_name, "Guardian Name", 3, 120);
                                          bValid = bValid && checkRegexp(e_g_name, /^[a-zA-Z\s]+$/, "Guardian Name should consist of A to Z , 0 to 9 letters.");
                                          bValid = bValid && fixLength(e_g_cnic, "Guardian CNIC number", 15);
                                          bValid = bValid && checkRegexp(e_g_cnic, /^[0-9+]{5}-[0-9+]{7}-[0-9]{1}$/, "Enter A Valid CNIC Number.");
                                          bValid = bValid && checkLength(e_res_addr, "Residential Address", 10, 400);
                                          bValid = bValid && checkRegexp(e_res_addr, /^[\sa-zA-Z0-9'\.,-/]+$/, "Please don't use special letters for Residential Address.");
                                          if (bValid) {
                                              $('#dialog-form Form').submit();
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
        });
    });
    $("#dialog-error").dialog({
        autoOpen: false,
        title: "Error",
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
        height: 110,
        width: 450,
        show: { effect: 'drop', direction: "up" },
        modal: true,
        draggable: true,
    });
});