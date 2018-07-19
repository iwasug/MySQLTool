/// <reference path="iwa.js" />

var pathname = window.location.pathname;
var BaseUrl = "";
$(document).ready(function () {
    BaseUrl = $("#BaseUrl").val();
    if (pathname.toUpperCase() != '/HOME/LOGIN') {
        $.sessionTimeout({
            keepAliveUrl: BaseUrl + '/Home/Index',
            logoutUrl: BaseUrl +'/Home/Logout',
            redirUrl: BaseUrl + '/Home/Login',
            //warnAfter: 6000,
            warnAfter: 180000,
            redirAfter: 190000,
            //redirAfter: 7000,
            countdownMessage: 'Logout Otomatis {timer} seconds.'
        });
    }
});
var progressbox = bootbox.dialog({
    show: false,
    closeButton: false,
    size: "small",
    animate: true,
    //message: '<div style="text-align:center;"><img src="483.gif" class="img-responsive prg" /></div>'
    //message: '<div class="progress progress-striped active"><div class="bar" style="width: 100%;"></div></div>'
    message: '<button class="btn btn-lg btn-warning" style="display: block; width: 100%;"><span class="glyphicon glyphicon-refresh spinning"></span> Loading...     </button>'
});

function POSTAjax(Url, Data, forgeryId)
{
    var respon = "";
    progressbox.modal("show");
    $.ajax({
        type: "POST",
        url: BaseUrl + "/" + Url,
        data: Data,
        async: false,
        contentType: "application/json; charset=utf-8",
        dataType: 'json',
        headers: {
            'VerificationToken': forgeryId
        },
        success: function (response) {
            progressbox.modal("hide");
            respon = response.status;
        },
        error: function (response) {
            bootbox.alert(response.error);
        }
    });
    return respon;
}
function parseJsonDate(jsonDateString) {
    var dateString = jsonDateString.substr(6);
    var currentTime = new Date(parseInt(dateString));
    var month = (1 + currentTime.getMonth()).toString();
    month = month.length > 1 ? month : '0' + month;
    var day = currentTime.getDate().toString();
    day = day.length > 1 ? day : '0' + day;
    var year = currentTime.getFullYear();
    var date = year + "-" + month + "-" + day;
    return date;
}