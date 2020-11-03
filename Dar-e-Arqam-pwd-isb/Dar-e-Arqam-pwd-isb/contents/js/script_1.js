$(document).ready(function () {
    $("#AddNewEvent").click(function (event) {
        event.preventDefault();
        $.ajax({
            url: "/events/create",
            success: function (temp) {
                $("#dialog-add-form").html(temp);
                $("#dialog-add-form").dialog(
                              {
                                  modal: true,
                                  title: "Add New Event",
                                  width: "600px",
                                  show: { effect: 'drop', direction: "up" },
                                  hide: { effect: 'drop', direction: "down" },
                                  draggable: false,
                                  buttons: {
                                      "Save": function () {
                                          var name = $("#Name"),
                                          detail = $("#Detail"),
                                          picture = $("#Picture"),
                                       allFields = $([]).add(name).add(detail).add(picture), tips = $(".form_msgs");

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
                                          bValid = bValid && checkLength(name, "Title ", 3, 2000);
                                          bValid = bValid && checkRegexp(name, /^[a-zA-Z0-9\s]+$/, "Title of News should consist of A to Z , 0 to 9 letters.");
                                          bValid = bValid && checkLength(detail, "Detail of Event ", 3, 4000);
                                          bValid = bValid && checkRegexp(detail, /^[a-zA-Z0-9\s]+$/, "Details of News should consist of A to Z , 0 to 9 letters.");
                                          bValid = bValid && minLength(picture, "Please select a photo for event ! ", 1);
                                          bValid = bValid && checkRegexp(picture, /\.(gif|jpg|jpeg|png|Gif|JPG|JPEG|PNG)$/, "Only Jpg , Jpeg , png and gif exntention of image are allowed !");
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
    $(".UpdateExistingEvent").click(function (event) {
        event.preventDefault();
        $.ajax({
            url: $(this).attr('href'),
            success: function (temp) {
                $("#dialog-add-form").html(temp);
                $("#dialog-add-form").dialog(
                              {
                                  modal: true,
                                  title: "Update This News Or Update",
                                  width: "600px",
                                  show: { effect: 'drop', direction: "up" },
                                  hide: { effect: 'drop', direction: "down" },
                                  draggable: false,
                                  buttons: {
                                      "Save": function () {
                                          var name = $("#Name"),
                                              detail = $("#Detail"),
                                              picture = $("#Picture"),
                                           allFields = $([]).add(name).add(detail).add(picture), tips = $(".form_msgs");

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
                                          bValid = bValid && checkLength(name, "Title ", 3, 2000);
                                          bValid = bValid && checkRegexp(name, /^[a-zA-Z0-9\s]+$/, "Title of News should consist of A to Z , 0 to 9 letters.");
                                          bValid = bValid && checkLength(detail, "Title ", 3, 4000);
                                          bValid = bValid && checkRegexp(detail, /^[a-zA-Z0-9\s]+$/, "Details of event should consist of A to Z , 0 to 9 letters.");
                                          bValid = bValid && checkRegexp(picture, /\.(gif|jpg|jpeg|png|Gif|JPG|JPEG|PNG)$/, "Only Jpg , Jpeg , png and gif exntention of image are allowed !");
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
    $("#ChangeSettingsEvents").click(function (event) {
        event.preventDefault();
        $.ajax({
            url: $(this).attr('href'),
            success: function (temp) {
                $("#dialog-add-form").html(temp);
                $("#dialog-add-form").dialog(
                              {
                                  modal: true,
                                  title: "Change Settings Of Event",
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
                                          bValid = bValid && checkNull(publish, "Please choose an option to publish this event !  ");
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