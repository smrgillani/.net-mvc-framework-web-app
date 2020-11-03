$(document).ready(function () {
    $("#AddNewFeeStructure").click(function (event) {
        event.preventDefault();
        $.ajax({
            url: "/feestructure/create",
            success: function (temp) {
                $("#dialog-add-form").html(temp);
                $("#dialog-add-form").dialog(
                              {
                                  modal: true,
                                  title: "Add New Fee Structure",
                                  width: "500px",
                                  show: { effect: 'drop', direction: "down" },
                                  hide: { effect: 'drop', direction: "up" },
                                  draggable: false,
                                  buttons: {
                                      "Save": function () {
                                          var name_of_lvl = $("#Name_of_lvl"),
                                      reg_fee = $("#Reg_fee"),
                                      monthly_fee = $("#Monthly_fee"),
                                   allFields = $([]).add(name_of_lvl).add(reg_fee).add(monthly_fee), tips = $(".form_msgs");

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
                                          bValid = bValid && checkNull(name_of_lvl, "Please choose a class level ! ");
                                          bValid = bValid && checkNull(reg_fee, "Registration Fee ", 3, 1000);
                                          bValid = bValid && checkRegexp(reg_fee, /^[0-9\s]+$/, "Name Of Star should consist of 0 to 9 letters.");
                                          bValid = bValid && checkLength(monthly_fee, "Tuition Fee ", 3, 1000);
                                          bValid = bValid && checkRegexp(monthly_fee, /^[0-9\s]+$/, "Tuition Fee should consist of 0 to 9 letters.");
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
    $(".UpdateExistingFeeStructure").click(function (event) {
        event.preventDefault();
        $.ajax({
            url: $(this).attr('href'),
            success: function (temp) {
                $("#dialog-add-form").html(temp);
                $("#dialog-add-form").dialog(
                              {
                                  modal: true,
                                  title: "Update This Fee Structure",
                                  width: "500px",
                                  show: { effect: 'drop', direction: "down" },
                                  hide: { effect: 'drop', direction: "up" },
                                  draggable: false,
                                  buttons: {
                                      "Update": function () {
                                          var name_of_lvl = $("#Name_of_lvl"),
                                      reg_fee = $("#Reg_fee"),
                                      monthly_fee = $("#Monthly_fee"),
                                   allFields = $([]).add(name_of_lvl).add(reg_fee).add(monthly_fee), tips = $(".form_msgs");

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
                                          bValid = bValid && checkNull(name_of_lvl, "Please choose a class level ! ");
                                          bValid = bValid && checkNull(reg_fee, "Registration Fee ", 3, 1000);
                                          bValid = bValid && checkRegexp(reg_fee, /^[0-9\s]+$/, "Name Of Star should consist of 0 to 9 letters.");
                                          bValid = bValid && checkLength(monthly_fee, "Tuition Fee ", 3, 1000);
                                          bValid = bValid && checkRegexp(monthly_fee, /^[0-9\s]+$/, "Tuition Fee should consist of 0 to 9 letters.");
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