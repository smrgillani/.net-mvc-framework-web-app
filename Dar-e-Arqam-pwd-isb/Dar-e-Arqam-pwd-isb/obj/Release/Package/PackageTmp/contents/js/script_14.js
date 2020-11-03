$(document).ready(function () {
    $(".UpdateExistingParent").click(function (event) {
        event.preventDefault();
        $.ajax({
            url: $(this).attr('href'),
            success: function (temp) {
                $("#dialog-form").html(temp);
                $("#dialog-form").dialog(
                              {
                                  modal: true,
                                  title: "Update Parent Info",
                                  width: "970px",
                                  show: { effect: 'drop', direction: "up" },
                                  hide: { effect: 'drop', direction: "down" },
                                  draggable: false,
                                  buttons: {
                                      "Update": function () {
                                              var aplicnt_f_name = $("#Aplicnt_f_name"),
                                                    aplicnt_f_ocptn = $("#Aplicnt_f_ocptn"),
                                                    aplicnt_f_title = $("#Aplicnt_f_title"),
                                                    aplicnt_f_cell = $("#Aplicnt_f_cell"),
                                                    aplicnt_f_bsns_name = $("#Aplicnt_f_bsns_name"),
                                                    aplicnt_f_bsns_addr = $("#Aplicnt_f_bsns_addr"),
                                                    aplicnt_f_email = $("#Aplicnt_f_email"),
                                                    aplicnt_f_phone = $("#Aplicnt_f_phone"),
                                                    aplicnt_m_name = $("#Aplicnt_m_name"),
                                                    aplicnt_m_cell = $("#Aplicnt_m_cell"),
                                                    aplicnt_m_ldln = $("#Aplicnt_m_ldln"),
   allFields = $([]).add(aplicnt_f_name).add(aplicnt_f_ocptn).add(aplicnt_f_title).add(aplicnt_f_cell).add(aplicnt_f_bsns_name).add(aplicnt_f_bsns_addr).add(aplicnt_f_email).add(aplicnt_f_phone).add(aplicnt_m_name).add(aplicnt_m_cell).add(aplicnt_m_ldln), tips = $(".form_msgs");

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

                                              function checkOptn(o, n, max) {
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
                                                  var bValid = true;
                                                  allFields.removeClass("form_error_alrt");
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
                                                  bValid = bValid && checkLength(aplicnt_m_name, "Mother Name ", 3, 150);
                                                  bValid = bValid && checkRegexp(aplicnt_m_name, /^[a-zA-Z0-9\s]+$/, "Mother name should consist of A to Z , 0 to 9 letters.");
                                                  bValid = bValid && checkLength(aplicnt_m_cell, "Cell number ", 10, 13);
                                                  bValid = bValid && checkRegexp(aplicnt_m_cell, /^((\+92)|(0092))-{0,1}\d{3}-{0,1}\d{7}$|^\d{11}$|^\d{4}-\d{7}$/, "Please Enter A Valid Cell Number. Example +923119301092");
                                                  bValid = bValid && checkOptn(aplicnt_m_ldln, "Phone (Landline) ", 13);
                                                  bValid = bValid && checkRegexp(aplicnt_m_ldln, /^((\+92)|(0092))-{0,1}\d{3}-{0,1}\d{7}$|^\d{11}$|^\d{4}-\d{7}$/, "Please Enter A Valid Number. Example : 92512615630");
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
        width: 400,
        show: { effect: 'drop', direction: "up" },
        modal: true,
        draggable: true,
    });
});
