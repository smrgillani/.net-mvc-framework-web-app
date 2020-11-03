$(document).ready(function () {
    $("#AddNewResult").click(function (event) {
        event.preventDefault();
        $.ajax({
            url: "/result/create",
            success: function (temp) {
                $("#dialog-add-form").html(temp);
                $("#dialog-add-form").dialog(
                              {
                                  modal: true,
                                  title: "Add New Result",
                                  width: "350px",
                                  show: { effect: 'drop', direction: "up" },
                                  hide: { effect: 'drop', direction: "down" },
                                  draggable: false,
                                  buttons: {
                                      "Save": function () {

                                          var name = $("#Name"),
                              allFields = $([]).add(name),tips = $(".form_msgs");

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
                                          bValid = bValid && checkLength(name, "Session Year ", 3,500);
                                          bValid = bValid && checkRegexp(name, /^[0-9\s]+$/, "Session Year should consist of 0 to 9 letters.");
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
    $(".UpdateExistingResult").click(function (event) {
        event.preventDefault();
        $.ajax({
            url: $(this).attr('href'),
            success: function (temp) {
                $("#dialog-add-form").html(temp);
                $("#dialog-add-form").dialog(
                              {
                                  modal: true,
                                  title: "Update Result",
                                  width: "350px",
                                  show: { effect: 'drop', direction: "up" },
                                  hide: { effect: 'drop', direction: "down" },
                                  draggable: false,
                                  buttons: {
                                      "Update": function () {

                                          var name = $("#Name"),
                              allFields = $([]).add(name), tips = $(".form_msgs");

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
                                          bValid = bValid && checkLength(name, "Session Year ", 3, 500);
                                          bValid = bValid && checkRegexp(name, /^[0-9\s]+$/, "Session Year should consist of 0 to 9 letters.");
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

    $("#AddNewSubResult").click(function (event) {
        event.preventDefault();
        $.ajax({
            url: $(this).attr('href'),
            success: function (temp) {
                $("#dialog-add-form").html(temp);
                $("#dialog-add-form").dialog(
                              {
                                  modal: true,
                                  title: "Add New Sub Result",
                                  width: "350px",
                                  show: { effect: 'drop', direction: "up" },
                                  hide: { effect: 'drop', direction: "down" },
                                  draggable: false,
                                  buttons: {
                                      "Save": function () {
                                          var name = $("#name"),
                              allFields = $([]).add(name), tips = $(".form_msgs");

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
                                          bValid = bValid && checkLength(name, "Name ", 3, 500);
                                          bValid = bValid && checkRegexp(name, /^[a-zA-Z0-9\s]+$/, "Sub Result name should consist of A to Z , 0 to 9 letters.");
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

    $(".ChangeSettingsOfResult").click(function (event) {
        event.preventDefault();
        $.ajax({
            url: $(this).attr('href'),
            success: function (temp) {
                $("#dialog-add-form").html(temp);
                $("#dialog-add-form").dialog(
                              {
                                  modal: true,
                                  title: "Publish Or Block The Result",
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
                                          bValid = bValid && checkNull(publish, "Please choose an option to publish this result  !  ");
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
$(".addttlmrksofsbjcts").click(function (event) {
        event.preventDefault();
        $.ajax({
            url: $(this).attr('href'),
            success: function (temp) {
                $("#dialog-add-form").html(temp);
                $("#dialog-add-form").dialog(
                              {
                                  modal: true,
                                  title: "Add Subjects Total Marks ",
                                  width: "485px",
                                  show: { effect: 'drop', direction: "up" },
                                  hide: { effect: 'drop', direction: "down" },
                                  draggable: false,
                                  buttons: {
                                      "Save": function () {

                                          var name = $("#SubjectsTotalMarks__Subject_id"),
                              allFields = $([]).add(name), tips = $(".form_msgs");

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
                                          bValid = bValid && checkNull(name, "Please choose a subject !  ");
                                          //bValid = bValid && checkLength(name, "Session Year ", 3, 500);
                                          //bValid = bValid && checkRegexp(name, /^[0-9\s]+$/, "Session Year should consist of 0 to 9 letters.");
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
$(".editttlmrksofsbjcts").click(function (event) {
    event.preventDefault();
    $.ajax({
        url: $(this).attr('href'),
        success: function (temp) {
            $("#dialog-add-form").html(temp);
            $("#dialog-add-form").dialog(
                          {
                              modal: true,
                              title: "Update Subjects Total Marks ",
                              width: "485px",
                              show: { effect: 'drop', direction: "up" },
                              hide: { effect: 'drop', direction: "down" },
                              draggable: false,
                              buttons: {
                                  "Update": function () {

                                      var name = $("#Name"),
                          allFields = $([]).add(name), tips = $(".form_msgs");

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
                                      //bValid = bValid && checkLength(name, "Session Year ", 3, 500);
                                      //bValid = bValid && checkRegexp(name, /^[0-9\s]+$/, "Session Year should consist of 0 to 9 letters.");
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