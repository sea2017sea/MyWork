$(function () {
    loadQuestion();

    $(".imgAnswerUrl").live('click', function () {

        var hdUserid = $("#hdUserid").val();
        var hdMoblie = $("#hdMoblie").val();
        var hdInforSysNo = $("#hdShareSysNo").val();
        var hdShareUserId = $("#hdShareUserId").val();
        var childrenSubSysNo = $(this).attr('ChildrenSubSysNo'); 
        var sysNo = $(this).attr('SysNo'); 
        var subSysNo = $(this).attr('SubSysNo');

        var savaAns = $("#hdSaveAnswer").val();
        var lsAns = savaAns + "{\"SubSysNo\":" + subSysNo + ",\"AnsSysNo\":" + sysNo + "},";
        $("#hdSaveAnswer").val(lsAns);
        
        if (childrenSubSysNo > 0) {
            //依然存在题目
            $.ajax({
                type: "POST",
                contentType: "application/json",
                url: 'Ajax/indexAjax.aspx/QuerySubjectSonAjax',
                data: "{'userid':" + hdUserid + ",'moblie':'" + hdMoblie + "','inforSysNo':" + hdInforSysNo + ",'subSonSysNo':" + childrenSubSysNo + "}",
                dataType: 'json',
                success: function (res) {
                    common.loading(false);
                    //console.log("res===", res);
                    var data = eval("(" + res.d + ")");
                    if (data.DoFlag == 1) {
                        //if (data.IsAnswer == 1) {
                        //    //已经回答过当前问题
                        //    if (data.SubjectEntities != null) {
                        //        var htmlData = "<div>";
                        //        htmlData += "<img class=\"title\" src=\"" + data.SubjectEntities[0].ProblemNameUrl + "\" alt=\"Alternate Text\" />";
                        //        htmlData += "</div>";
                        //        $("#question_box").html(htmlData);
                        //        common.downLoadDialog();
                        //    } else {
                        //        common.downLoadDialog();
                        //    }
                        //} else {
                            //没有回答过问题
                            if (data.SubjectEntities != null) {
                                var htmlData = "<div>";
                                htmlData += "<img class=\"title\" src=\"" + data.SubjectEntities[0].ProblemNameUrl + "\" alt=\"Alternate Text\" />";
                                htmlData += "</div>";
                                htmlData += "<div class=\"list\"><ul>";

                                var anent = data.SubjectEntities[0].AnswerEntities;
                                for (var i = 0; i < anent.length; i++) {
                                    htmlData += "<li class=\"active\">";
                                    htmlData += "<a href=\"#\">";
                                    htmlData += "<img class=\"imgAnswerUrl\" SubSysNo=\"" + anent[i].SubSysNo + "\" SysNo=\"" + anent[i].SysNo + "\" ChildrenSubSysNo=\"" + anent[i].ChildrenSubSysNo + "\" src=\"" + anent[i].AnswerNameUrl + "\" alt=\"Alternate Text\" />";
                                    htmlData += "</a></li>";
                                }

                                htmlData += "</ul></div>";
                                $("#question_box").html(htmlData);
                            } else {
                                common.downLoadDialog();
                            }
                        }
                    //} else {
                    //    alert("获取题目失败");
                    //}
                }
            });

        } else {
            //不存在题目了，则保存答案
            lsAns = "[" + lsAns.substring(0,lsAns.length - 1) + "]";
            $.ajax({
                type: "POST",
                contentType: "application/json",
                url: 'Ajax/indexAjax.aspx/AddAnswerRecordAjax',
                data: "{'userid':" + hdUserid + ",'moblie':'" + hdMoblie + "','parameter':'" + lsAns + "'}",
                dataType: 'json',
                success: function (res) {
                    common.loading(false);
                    var data = eval("(" + res.d + ")");
                    if (data.DoFlag == 1) {
                        window.location.href = "/result.aspx?AnswerMoney=" + data.StrAnswerMoney + "&ShareSysNo=" + hdInforSysNo + "&ShareUserId=" + hdShareUserId;
                    } else {
                        alert("保存答案失败");
                    }
                }
            });

        }
    });
    
}); 

function loadQuestion() {
    var hdUserid = $("#hdUserid").val();
    var hdMoblie = $("#hdMoblie").val();
    var hdInforSysNo = $("#hdShareSysNo").val();

    $.ajax({
        type: "POST",
        contentType: "application/json",
        url: 'Ajax/indexAjax.aspx/QuerySubjectAjax',
        data: "{'userid':" + hdUserid + ",'moblie':'" + hdMoblie + "','inforSysNo':" + hdInforSysNo + "}",
        dataType: 'json',
        success: function (res) {
            common.loading(false);
            //console.log("res===", res);
            var data = eval("(" + res.d + ")");
            if (data.DoFlag == 1) {
                if (data.IsAnswer == 1) {
                    //已经回答过当前问题
                    if (data.SubjectEntities != null) {
                        var htmlData = "<div>";
                        htmlData += "<img class=\"title\" src=\"" + data.SubjectEntities[0].ProblemNameUrl + "\" alt=\"Alternate Text\" />";
                        htmlData += "</div>";
                        $("#question_box").html(htmlData);
                        common.downLoadDialog();
                    } else {
                        common.downLoadDialog();
                    }
                } else {
                    //没有回答过问题
                    if (data.SubjectEntities != null) {
                        var htmlData = "<div>";
                        htmlData += "<img class=\"title\" src=\"" + data.SubjectEntities[0].ProblemNameUrl + "\" alt=\"Alternate Text\" />";
                        htmlData += "</div>";
                        htmlData += "<div class=\"list\"><ul>";

                        var anent = data.SubjectEntities[0].AnswerEntities;
                        for (var i = 0; i < anent.length; i++) {
                            htmlData += "<li class=\"active\">";
                            htmlData += "<a href=\"#\">";
                            htmlData += "<img class=\"imgAnswerUrl\" SubSysNo=\"" + anent[i].SubSysNo + "\" SysNo=\"" + anent[i].SysNo + "\" ChildrenSubSysNo=\"" + anent[i].ChildrenSubSysNo + "\" src=\"" + anent[i].AnswerNameUrl + "\" alt=\"Alternate Text\" />";
                            htmlData += "</a></li>";
                        }
                        
                        htmlData += "</ul></div>";
                        $("#question_box").html(htmlData);
                    } else {
                        common.downLoadDialog();
                    }
                }
            } else {
                alert("获取题目失败");
            }
        }
    });
}