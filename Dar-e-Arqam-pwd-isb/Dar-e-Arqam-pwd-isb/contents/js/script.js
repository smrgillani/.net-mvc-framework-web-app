$(document).ready(function () {
    $("#AddNewTeacher").click(function (event) {
        event.preventDefault();
        $.ajax({
            url: $(this).attr('href'),
            success: function (temp) {
                $("#dialog-form").html(temp);
                $("#T_dob,#T_jd").datepicker();
                $("#dialog-form").dialog(
                              {
                                  modal: true,
                                  title: "Add New Teacher",
                                  width: "970px",
                                  show: { effect: 'drop', direction: "up" },
                                  hide: { effect: 'drop', direction: "down" },
                                  draggable: false,
                                  buttons: {
                                      "Save": function () {
                                        var t_id = $("#T_Id"),
                                        t_name = $("#T_name"),
                                        t_dob = $("#T_dob"),
                                        t_cnic = $("#T_cnic"),
                                        t_gen = $("#T_gen"),
                                        t_email = $("#T_email"),
                                        t_c_num = $("#T_c_num"),
                                        t_a_c_num = $("#T_a_c_num"),
                                        t_type = $("#T_type"),
                                        t_jd = $("#T_jd"),
                                        t_spcl_in_sbjct = $("#T_spcl_in_sbjct"),
                                        t_desig = $("#T_desig"),
                                        t_g_name = $("#T_g_name"),
                                        t_g_cnic = $("#T_g_cnic"),
                                        t_res_addr = $("#T_res_addr"),
                                        allFields = $([]).add(t_id).add(t_name).add(t_dob).add(t_cnic).add(t_gen).add(t_email).add(t_c_num)
                                        .add(t_a_c_num).add(t_type).add(t_jd).add(t_spcl_in_sbjct).add(t_desig).add(t_g_name).add(t_g_cnic).add(t_res_addr),
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

                                          function checkNull(o , n) {
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
                                          bValid = bValid && checkLength(t_id, "ID", 3, 120);
                                          bValid = bValid && checkRegexp(t_id, /^[a-zA-Z0-9]+$/, "Teacher ID should consist of A to Z , 0 to 9 letters.");
                                          bValid = bValid && checkLength(t_name, "Name", 3, 120);
                                          bValid = bValid && checkRegexp(t_name, /^[a-zA-Z\s]+$/, "Name should consist of A to Z letters.");
                                          bValid = bValid && fixLength(t_dob, "Date Of Birth ", 10);
                                          bValid = bValid && checkRegexp(t_dob, /^[0-9'\-/]+$/, "Date Of Birth should consist 0 to 9 and '-' Or '/' letters.");
                                          bValid = bValid && fixLength(t_cnic, "CNIC number", 15);
                                          bValid = bValid && checkRegexp(t_cnic, /^[0-9+]{5}-[0-9+]{7}-[0-9]{1}$/, "Enter A Valid CNIC Number.");
                                          bValid = bValid && checkNull(t_gen, "Please choose the type for Gender");
                                          bValid = bValid && checkLength(t_email, "Email", 3, 80);
                                          bValid = bValid && checkRegexp(t_email, /^((([a-z]|\d|[!#\$%&'\*\+\-\/=\?\^_`{\|}~]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])+(\.([a-z]|\d|[!#\$%&'\*\+\-\/=\?\^_`{\|}~]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])+)*)|((\x22)((((\x20|\x09)*(\x0d\x0a))?(\x20|\x09)+)?(([\x01-\x08\x0b\x0c\x0e-\x1f\x7f]|\x21|[\x23-\x5b]|[\x5d-\x7e]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(\\([\x01-\x09\x0b\x0c\x0d-\x7f]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF]))))*(((\x20|\x09)*(\x0d\x0a))?(\x20|\x09)+)?(\x22)))@((([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])*([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])))\.)+(([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])*([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])))\.?$/i, "Please Enter A Valid Email Address");
                                          bValid = bValid && checkLength(t_c_num, "Contact Number", 10, 13);
                                          bValid = bValid && checkRegexp(t_c_num, /^((\+92)|(0092))-{0,1}\d{3}-{0,1}\d{7}$|^\d{11}$|^\d{4}-\d{7}$/, "Please Enter A Valid Contact Number.");
                                          bValid = bValid && checkLength(t_a_c_num, "Contact Number", 10, 13);
                                          bValid = bValid && checkRegexp(t_a_c_num, /^((\+92)|(0092))-{0,1}\d{3}-{0,1}\d{7}$|^\d{11}$|^\d{4}-\d{7}$/, "Please Enter A Valid Alternative Contact Number.");
                                          bValid = bValid && checkNull(t_type, "Please choose the Type for Teacher");
                                          bValid = bValid && checkNull(t_desig, "Please choose the Designation for Teacher");
                                          bValid = bValid && fixLength(t_jd, "Date Of Joining ", 10);
                                          bValid = bValid && checkRegexp(t_jd, /^[0-9'\-/]+$/, "Date Of Joining should consist 0 to 9 and '-' Or '/' letters.");
                                          bValid = bValid && checkLength(t_spcl_in_sbjct, "Subject ", 3, 220);
                                          bValid = bValid && checkRegexp(t_spcl_in_sbjct, /^[a-zA-Z0-9]+$/, "Subject should consist of A to Z , 0 to 9 letters.");
                                          bValid = bValid && checkLength(t_g_name, "Guardian Name", 3, 120);
                                          bValid = bValid && checkRegexp(t_g_name, /^[a-zA-Z\s]+$/, "Guardian Name should consist of A to Z , 0 to 9 letters.");
                                          bValid = bValid && fixLength(t_g_cnic, "Guardian CNIC number", 15);
                                          bValid = bValid && checkRegexp(t_g_cnic, /^[0-9+]{5}-[0-9+]{7}-[0-9]{1}$/, "Enter A Valid CNIC Number.");
                                          bValid = bValid && checkLength(t_res_addr, "Residential Address", 10 , 400);
                                          bValid = bValid && checkRegexp(t_res_addr, /^[\sa-zA-Z0-9'\.,-/]+$/, "Please don't use special letters for Residential Address.");
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

$(".UpdateExistingTeacher").click(function (event) {
            event.preventDefault();
            $.ajax({
                url: $(this).attr('href'),
                success: function (temp) {
                    $("#dialog-form").html(temp);
                    $("#T_dob").datepicker();
                    $("#dialog-form").dialog(
                                  {
                                      modal: true,
                                      title: "Update Teacher",
                                      width: "970px",
                                      show: { effect: 'drop', direction: "up" },
                                      hide: { effect: 'drop', direction: "down" },
                                      draggable: false,
                                      buttons: {
                                          "Update": function () {
                                              var t_id = $("#T_Id"),
                                        t_name = $("#T_name"),
                                        t_dob = $("#T_dob"),
                                        t_cnic = $("#T_cnic"),
                                        t_gen = $("#T_gen"),
                                        t_email = $("#T_email"),
                                        t_c_num = $("#T_c_num"),
                                        t_a_c_num = $("#T_a_c_num"),
                                        t_type = $("#T_type"),
                                        t_jd = $("#T_jd"),
                                        t_spcl_in_sbjct = $("#T_spcl_in_sbjct"),
                                        t_desig = $("#T_desig"),
                                        t_g_name = $("#T_g_name"),
                                        t_g_cnic = $("#T_g_cnic"),
                                        t_res_addr = $("#T_res_addr"),
                                        allFields = $([]).add(t_id).add(t_name).add(t_dob).add(t_cnic).add(t_gen).add(t_email).add(t_c_num)
                                        .add(t_a_c_num).add(t_type).add(t_jd).add(t_spcl_in_sbjct).add(t_desig).add(t_g_name).add(t_g_cnic).add(t_res_addr),
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
                                              bValid = bValid && checkLength(t_id, "ID", 3, 120);
                                              bValid = bValid && checkRegexp(t_id, /^[a-zA-Z0-9]+$/, "Teacher ID should consist of A to Z , 0 to 9 letters.");
                                              bValid = bValid && checkLength(t_name, "Name", 3, 120);
                                              bValid = bValid && checkRegexp(t_name, /^[a-zA-Z\s]+$/, "Name should consist of A to Z letters.");
                                              bValid = bValid && fixLength(t_dob, "Date Of Birth ", 10);
                                              bValid = bValid && checkRegexp(t_dob, /^[0-9'\-/]+$/, "Date Of Birth should consist 0 to 9 and '-' Or '/' letters.");
                                              bValid = bValid && fixLength(t_cnic, "CNIC number", 15);
                                              bValid = bValid && checkRegexp(t_cnic, /^[0-9+]{5}-[0-9+]{7}-[0-9]{1}$/, "Enter A Valid CNIC Number.");
                                              bValid = bValid && checkNull(t_gen, "Please choose the type for Gender");
                                              bValid = bValid && checkLength(t_email, "Email", 3, 80);
                                              bValid = bValid && checkRegexp(t_email, /^((([a-z]|\d|[!#\$%&'\*\+\-\/=\?\^_`{\|}~]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])+(\.([a-z]|\d|[!#\$%&'\*\+\-\/=\?\^_`{\|}~]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])+)*)|((\x22)((((\x20|\x09)*(\x0d\x0a))?(\x20|\x09)+)?(([\x01-\x08\x0b\x0c\x0e-\x1f\x7f]|\x21|[\x23-\x5b]|[\x5d-\x7e]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(\\([\x01-\x09\x0b\x0c\x0d-\x7f]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF]))))*(((\x20|\x09)*(\x0d\x0a))?(\x20|\x09)+)?(\x22)))@((([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])*([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])))\.)+(([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])*([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])))\.?$/i, "Please Enter A Valid Email Address");
                                              bValid = bValid && checkLength(t_c_num, "Contact Number", 10, 13);
                                              bValid = bValid && checkRegexp(t_c_num, /^((\+92)|(0092))-{0,1}\d{3}-{0,1}\d{7}$|^\d{11}$|^\d{4}-\d{7}$/, "Please Enter A Valid Contact Number.");
                                              bValid = bValid && checkLength(t_a_c_num, "Contact Number", 10, 13);
                                              bValid = bValid && checkRegexp(t_a_c_num, /^((\+92)|(0092))-{0,1}\d{3}-{0,1}\d{7}$|^\d{11}$|^\d{4}-\d{7}$/, "Please Enter A Valid Alternative Contact Number.");
                                              bValid = bValid && checkNull(t_type, "Please choose the Type for Teacher");
                                              bValid = bValid && checkNull(t_desig, "Please choose the Designation for Teacher");
                                              bValid = bValid && fixLength(t_jd, "Date Of Joining ", 10);
                                              bValid = bValid && checkRegexp(t_jd, /^[0-9'\-/]+$/, "Date Of Joining should consist 0 to 9 and '-' Or '/' letters.");
                                              bValid = bValid && checkLength(t_spcl_in_sbjct, "Subject ", 3, 220);
                                              bValid = bValid && checkRegexp(t_spcl_in_sbjct, /^[a-zA-Z0-9]+$/, "Subject should consist of A to Z , 0 to 9 letters.");
                                              bValid = bValid && checkLength(t_g_name, "Guardian Name", 3, 120);
                                              bValid = bValid && checkRegexp(t_g_name, /^[a-zA-Z\s]+$/, "Guardian Name should consist of A to Z , 0 to 9 letters.");
                                              bValid = bValid && fixLength(t_g_cnic, "Guardian CNIC number", 15);
                                              bValid = bValid && checkRegexp(t_g_cnic, /^[0-9+]{5}-[0-9+]{7}-[0-9]{1}$/, "Enter A Valid CNIC Number.");
                                              bValid = bValid && checkLength(t_res_addr, "Residential Address", 10, 400);
                                              bValid = bValid && checkRegexp(t_res_addr, /^[\sa-zA-Z0-9'\.,-/]+$/, "Please don't use special letters for Residential Address.");
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
$("#AsgnNewSub").click(function (event) {
    event.preventDefault();
    $.ajax({
        url: $(this).attr('href'),
        success: function (temp) {
            $("#dialog-form").html(temp);
            $("#T_dob").datepicker();
            $("#dialog-form").dialog(
                          {
                              modal: true,
                              title: "Assign New Subject",
                              width: "300px",
                              show: { effect: 'drop', direction: "up" },
                              hide: { effect: 'drop', direction: "down" },
                              draggable: false,
                              buttons: {
                                  "Save": function () {
                                      var class_subject_id = $("#Class_subject_id"),
                                      allFields = $([]).add(class_subject_id),
                                      tips = $(".form_msgs");

                                      function updateTips(t) {
                                          tips.text(t).addClass("form_msg_highlight");
                                          setTimeout(function () {
                                              tips.removeClass("form_msg_highlight", 1500);
                                          }, 500);
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
                                      bValid = bValid && checkNull(class_subject_id, "Please Choose A Subject !");
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
        width: 390,
        show: { effect: 'drop', direction: "up" },
        modal: true,
        draggable: true,
    });
});