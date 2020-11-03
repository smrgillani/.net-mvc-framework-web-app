$(document).ready(function () {
    $("#AddNewContactInfo").click(function (event) {
        event.preventDefault();
        $.ajax({
            url: $(this).attr('href'),
            success: function (temp) {
                $("#dialog-add-form").html(temp);
                $("#dialog-add-form").dialog(
                              {
                                  modal: true,
                                  title: "Add New Contact Info",
                                  width: "485px",
                                  show: { effect: 'drop', direction: "up" },
                                  hide: { effect: 'drop', direction: "down" },
                                  draggable: false,
                                  buttons: {
                                      "Save": function () {
                                          var title = $("#Title"),
                                 contact_c = $("#Contact_Cell"),
                                 contact_p = $("#Contact_Phone"),
                                 contact_e = $("#Contact_Email"),
                                 contact_w = $("#Contact_Website"),
                                 contact_l = $("#Contact_Location"),
                                 contact_a = $("#Contact_Address"),
                              allFields = $([]).add(title).add(contact_c).add(contact_p).add(contact_e).add(contact_w).add(contact_l).add(contact_a), tips = $(".form_msgs");

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
                                          bValid = bValid && checkLength(title, "Title ", 3, 1000);
                                          bValid = bValid && checkRegexp(title, /^[a-zA-Z0-9\s]+$/, "Title Of Contact Info should consist of A to Z , 0 to 9 letters.");
                                          bValid = bValid && checkLength(contact_c, "Cell Number ", 10, 13);
                                          bValid = bValid && checkRegexp(contact_c, /^((\+92)|(0092))-{0,1}\d{3}-{0,1}\d{7}$|^\d{11}$|^\d{4}-\d{7}$/, "Please Enter A Valid Cell Number. Example : +923119301092 ");
                                          bValid = bValid && checkLength(contact_p, "Phone Number ", 10, 12);
                                          bValid = bValid && checkRegexp(contact_p, /^((\+92)|(0092))-{0,1}\d{3}-{0,1}\d{7}$|^\d{11}$|^\d{4}-\d{7}$/, "Please Enter A Valid Phone Number. Example : +92515958853 ");
                                          bValid = bValid && checkLength(contact_e, "Email ", 3, 80);
                                          bValid = bValid && checkRegexp(contact_e, /^((([a-z]|\d|[!#\$%&'\*\+\-\/=\?\^_`{\|}~]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])+(\.([a-z]|\d|[!#\$%&'\*\+\-\/=\?\^_`{\|}~]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])+)*)|((\x22)((((\x20|\x09)*(\x0d\x0a))?(\x20|\x09)+)?(([\x01-\x08\x0b\x0c\x0e-\x1f\x7f]|\x21|[\x23-\x5b]|[\x5d-\x7e]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(\\([\x01-\x09\x0b\x0c\x0d-\x7f]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF]))))*(((\x20|\x09)*(\x0d\x0a))?(\x20|\x09)+)?(\x22)))@((([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])*([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])))\.)+(([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])*([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])))\.?$/i, "Please Enter A Valid Email Address");
                                          bValid = bValid && checkLength(contact_w, "Website ", 10, 1000);
                                          bValid = bValid && checkRegexp(contact_w, /((?:https?\:\/\/|www\.)(?:[-a-z0-9]+\.)*[-a-z0-9]+.*)/i , "Please Enter A Valid Website Address. Example : www.das-pwdisb.com.pk ");
                                          bValid = bValid && checkLength(contact_l, "Address Location ", 10, 3000);
                                          bValid = bValid && checkLength(contact_a, "Location Address ", 10, 400);
                                          bValid = bValid && checkRegexp(contact_a, /^[\sa-zA-Z0-9'\.,-/]+$/, "Please don't use special letters for Location Address.");
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
        });
    });

$(".UpdateExistingContactInfo").click(function (event) {
        event.preventDefault();
        $.ajax({
            url: $(this).attr('href'),
            success: function (temp) {
                $("#dialog-add-form").html(temp);
                $("#dialog-add-form").dialog(
                              {
                                  modal: true,
                                  title: "Update This Contact Info",
                                  width: "485px",
                                  show: { effect: 'drop', direction: "up" },
                                  hide: { effect: 'drop', direction: "down" },
                                  draggable: false,
                                  buttons: {
                                      "Update": function () {
                                          var title = $("#Title"),
                                 contact_c = $("#Contact_Cell"),
                                 contact_p = $("#Contact_Phone"),
                                 contact_e = $("#Contact_Email"),
                                 contact_w = $("#Contact_Website"),
                                 contact_l = $("#Contact_Location"),
                                 contact_a = $("#Contact_Address"),
                              allFields = $([]).add(title).add(contact_c).add(contact_p).add(contact_e).add(contact_w).add(contact_l).add(contact_a), tips = $(".form_msgs");

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
                                          bValid = bValid && checkLength(title, "Title ", 3, 1000);
                                          bValid = bValid && checkRegexp(title, /^[a-zA-Z0-9\s]+$/, "Title Of Contact Info should consist of A to Z , 0 to 9 letters.");
                                          bValid = bValid && checkLength(contact_c, "Cell Number ", 10, 13);
                                          bValid = bValid && checkRegexp(contact_c, /^((\+92)|(0092))-{0,1}\d{3}-{0,1}\d{7}$|^\d{11}$|^\d{4}-\d{7}$/, "Please Enter A Valid Cell Number. Example : +923119301092 ");
                                          bValid = bValid && checkLength(contact_p, "Phone Number ", 10, 12);
                                          bValid = bValid && checkRegexp(contact_p, /^((\+92)|(0092))-{0,1}\d{3}-{0,1}\d{7}$|^\d{11}$|^\d{4}-\d{7}$/, "Please Enter A Valid Phone Number. Example : +92515958853 ");
                                          bValid = bValid && checkLength(contact_e, "Email ", 3, 80);
                                          bValid = bValid && checkRegexp(contact_e, /^((([a-z]|\d|[!#\$%&'\*\+\-\/=\?\^_`{\|}~]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])+(\.([a-z]|\d|[!#\$%&'\*\+\-\/=\?\^_`{\|}~]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])+)*)|((\x22)((((\x20|\x09)*(\x0d\x0a))?(\x20|\x09)+)?(([\x01-\x08\x0b\x0c\x0e-\x1f\x7f]|\x21|[\x23-\x5b]|[\x5d-\x7e]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(\\([\x01-\x09\x0b\x0c\x0d-\x7f]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF]))))*(((\x20|\x09)*(\x0d\x0a))?(\x20|\x09)+)?(\x22)))@((([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])*([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])))\.)+(([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])*([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])))\.?$/i, "Please Enter A Valid Email Address");
                                          bValid = bValid && checkLength(contact_w, "Website ", 10, 1000);
                                          bValid = bValid && checkRegexp(contact_w, /((?:https?\:\/\/|www\.)(?:[-a-z0-9]+\.)*[-a-z0-9]+.*)/i, "Please Enter A Valid Website Address. Example : www.das-pwdisb.com.pk ");
                                          bValid = bValid && checkLength(contact_l, "Address Location ", 10, 3000);
                                          bValid = bValid && checkLength(contact_a, "Location Address ", 10, 400);
                                          bValid = bValid && checkRegexp(contact_a, /^[\sa-zA-Z0-9'\.,-/]+$/, "Please don't use special letters for Location Address.");
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
        });
});
$("#ChangeSettingsContactInfo").click(function (event) {
    event.preventDefault();
    $.ajax({
        url: $(this).attr('href'),
        success: function (temp) {
            $("#dialog-add-form").html(temp);
            $("#dialog-add-form").dialog(
                          {
                              modal: true,
                              title: "Change Settings Of Contact Info",
                              width: "450px",
                              show: { effect: 'drop', direction: "up" },
                              hide: { effect: 'drop', direction: "down" },
                              draggable: false,
                              buttons: {
                                  "Update": function () {
                                      var publish = $("#Publish"),
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
                                      bValid = bValid && checkNull(publish, "Please choose an option to publish this Contact Info !  ");
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
        height: 100,
        width: 550,
        show: { effect: 'drop', direction: "up" },
        modal: true,
        draggable: true,
    });
});