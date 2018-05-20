$(function () {
    var hdShareSysNo = $("#hdShareSysNo").val();
    var hdShareUserId = $("#hdShareUserId").val();

    if (hdShareSysNo <= 0 || hdShareUserId <= 0) {
        alert("参数错误");
        return;
    }

    $("#startBtn").click(function () {
        var mobile = $("#mobile").val();
        if (mobile.length <= 0) {
            alert("请输入手机号码");
            return;
        } else {
            //if (!mobile.match(/^(13|15|17|18|14)[0-9]{9}$/)) {
            //    alert("手机号码格式不正确");
            //    return;
            //} 
            if (mobile.length != 11) {
                alert("手机号码格式不正确");
                return;
            }else {
                common.loading(true);
                $.ajax({
                    type: "POST",
                    contentType: "application/json",
                    url: 'Ajax/indexAjax.aspx/QueryMemberInfoByMobileAjax',
                    data: "{'mobile':"+ mobile +"}",
                    dataType: 'json',
                    success: function (res) {
                        common.loading(false);
                        console.log("res===", res);
                        var data = eval("(" + res.d + ")");
                        if (data.DoFlag == 1) {
                            window.location.href = "/question.aspx?userid=" + data.DoResult + "&ShareSysNo=" + hdShareSysNo + "&ShareUserId=" + hdShareUserId;
                        } else {
                            window.location.href = "/question.aspx?moblie=" + mobile + "&ShareSysNo=" + hdShareSysNo + "&ShareUserId=" + hdShareUserId;
                            //common.downLoadDialog();
                        }
                    }
                });
            }
        }
    });
});