$(document).ready(function () {
    $("#AddNewDocument").click(function (event) {
        event.preventDefault();
        $.ajax({
            url: $(this).attr('href'),
            success: function (temp) {
                $("#dialog-add-form").html(temp);
                $("#dialog-add-form").dialog(
                              {
                                  modal: true,
                                  title: "Add New Document Or File",
                                  width: "500px",
                                  show: { effect: 'drop', direction: "up" },
                                  hide: { effect: 'drop', direction: "down" },
                                  draggable: false,
                                  buttons: {
                                      "Save": function () {
                                          var name = $("#Name"),
                                          file = $("#User_File"),
                                       allFields = $([]).add(name).add(file), tips = $(".form_msgs");

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
                                          bValid = bValid && checkLength(name, "Name ", 3, 2000);
                                          bValid = bValid && checkRegexp(name, /^[a-zA-Z0-9\s]+$/, "Name should consist of A to Z , 0 to 9 letters.");
                                          bValid = bValid && minLength(file, "Please select a document or file ! ", 1);
                                          bValid = bValid && checkRegexp(file, /\.(pdf|xls|xlsx|doc|docx|ppt|pptx|zip|rar|PDF|XLS|XLSX|DOC|DOCX|PPT|PPTX|ZIP|RAR)$/, "Only pdf , xls , xlsx , doc , docx , ppt , pptx , zip and rar exntention of document or file are allowed !");
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

$("#AddNewPicture").click(function (event) {
        event.preventDefault();
        $.ajax({
            url: $(this).attr('href'),
            success: function (temp) {
                $("#dialog-add-form").html(temp);
                $("#dialog-add-form").dialog(
                              {
                                  modal: true,
                                  title: "Add New Picture",
                                  width: "500px",
                                  show: { effect: 'drop', direction: "up" },
                                  hide: { effect: 'drop', direction: "down" },
                                  draggable: false,
                                  buttons: {
                                      "Save": function () {
                                          var name = $("#Name"),
                                          file = $("#User_File"),
                                       allFields = $([]).add(name).add(file), tips = $(".form_msgs");

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
                                          bValid = bValid && checkLength(name, "Name ", 3, 2000);
                                          bValid = bValid && checkRegexp(name, /^[a-zA-Z0-9\s]+$/, "Name should consist of A to Z , 0 to 9 letters.");
                                          bValid = bValid && minLength(file, "Please select a photo ! ", 1);
                                          bValid = bValid && checkRegexp(file, /\.(gif|jpg|jpeg|png|Gif|JPG|JPEG|PNG)$/, "Only Jpg , Jpeg , png and gif exntention of image are allowed !");
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

$(".UpdateExisting_Image").click(function (event) {
    event.preventDefault();
    $.ajax({
        url: $(this).attr('href'),
        success: function (temp) {
            $("#dialog-add-form").html(temp);
            $("#dialog-add-form").dialog(
                          {
                              modal: true,
                              title: "Update Image",
                              width: "500px",
                              show: { effect: 'drop', direction: "up" },
                              hide: { effect: 'drop', direction: "down" },
                              draggable: false,
                              buttons: {
                                  "Update": function () {
                                      var name = $("#Name"),
                                      file = $("#User_File"),
                                   allFields = $([]).add(name).add(file), tips = $(".form_msgs");

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
                                      bValid = bValid && checkLength(name, "Name ", 3, 2000);
                                      bValid = bValid && checkRegexp(name, /^[a-zA-Z0-9\s]+$/, "Name should consist of A to Z , 0 to 9 letters.");
                                      bValid = bValid && checkRegexp(file, /\.(gif|jpg|jpeg|png|Gif|JPG|JPEG|PNG)$/, "Only Jpg , Jpeg , png and gif exntention of image are allowed !");
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

$(".UpdateExisting_Package").click(function (event) {
    event.preventDefault();
    $.ajax({
        url: $(this).attr('href'),
        success: function (temp) {
            $("#dialog-add-form").html(temp);
            $("#dialog-add-form").dialog(
                          {
                              modal: true,
                              title: "Update File",
                              width: "500px",
                              show: { effect: 'drop', direction: "up" },
                              hide: { effect: 'drop', direction: "down" },
                              draggable: false,
                              buttons: {
                                  "Update": function () {
                                      var name = $("#Name"),
                                      file = $("#User_File"),
                                   allFields = $([]).add(name).add(file), tips = $(".form_msgs");

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
                                      bValid = bValid && checkLength(name, "Name ", 3, 2000);
                                      bValid = bValid && checkRegexp(name, /^[a-zA-Z0-9\s]+$/, "Name should consist of A to Z , 0 to 9 letters.");
                                      bValid = bValid && checkRegexp(file, /\.(zip|rar|ZIP|RAR)$/, "Only Rar and Zip exntention of file are allowed !");
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
})
$(".UpdateExisting_Document").click(function (event) {
    event.preventDefault();
    $.ajax({
        url: $(this).attr('href'),
        success: function (temp) {
            $("#dialog-add-form").html(temp);
            $("#dialog-add-form").dialog(
                          {
                              modal: true,
                              title: "Update Document",
                              width: "500px",
                              show: { effect: 'drop', direction: "up" },
                              hide: { effect: 'drop', direction: "down" },
                              draggable: false,
                              buttons: {
                                  "Update": function () {
                                      var name = $("#Name"),
                                      file = $("#User_File"),
                                   allFields = $([]).add(name).add(file), tips = $(".form_msgs");

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
                                      bValid = bValid && checkLength(name, "Name ", 3, 2000);
                                      bValid = bValid && checkRegexp(name, /^[a-zA-Z0-9\s]+$/, "Name should consist of A to Z , 0 to 9 letters.");
                                      bValid = bValid && checkRegexp(file, /\.(pdf|xls|xlsx|doc|docx|ppt|pptx|PDF|XLS|XLSX|DOC|DOCX|PPT|PPTX)$/, "Only pdf , xls , xlsx , doc , docx , ppt , pptx , zip and rar exntention of document or file are allowed !");
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