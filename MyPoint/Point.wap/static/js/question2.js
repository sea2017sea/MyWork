
var hdUserid = "0";// $("#hdShareUserId").val();
var hdMoblie = '';
var hdInforSysNo = "";
$(function () {

    var isBegin =  $("#hdIsBegin").val();
    
    if (isBegin == 0)
    {
        $(".state01").show();
    }

    hdInforSysNo = $("#hdShareSysNo").val();

    loadQuestion();
    $(".btn-begin").live('click', function () {
        $("#hdIsBegin").val("1");
        $(".state01").hide();
    });

    
    //提交答案
    $(".btn-done").live('click', function () {

        var hdMoblie = $.trim($(".data-mobile").val());

        if (!hdMoblie.match(/^(13|15|17|18|14)[0-9]{9}$/)) {
            alert("手机号码格式不正确");
            return;
        }
        var lsAns = $("#hdSaveAnswer").val();
        lsAns = "[" + lsAns.substring(0, lsAns.length - 1) + "]";
        console.log(lsAns);

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

                  //  alert("数据提交成功");
                    //下载链接
                    window.location.href = "https://www.baidu.com/";
                } else {
                    alert("保存答案失败");
                }
            }
        });

    })

    $(".box-thumbnail").live('click', function () {
        var childrenSubSysNo = $(this).attr('ChildrenSubSysNo');
        var sysNo = $(this).attr('SysNo');
        var subSysNo = $(this).attr('SubSysNo');


        var savaAns = $("#hdSaveAnswer").val();
        var lsAns = savaAns + "{\"SubSysNo\":" + subSysNo + ",\"AnsSysNo\":" + sysNo + "},";
        $("#hdSaveAnswer").val(lsAns);



        console.log("info=>childrenSubSysNo:" + childrenSubSysNo);

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
                    BindData(data);
                }
            });
        }
        else {//已经全部回答完毕

            $(".state02").show();
        }
    });


});
function loadQuestion() {


    $.ajax({
        type: "POST",
        contentType: "application/json",
        url: 'Ajax/indexAjax.aspx/QueryShareSubjectReq',
        data: "{'inforSysNo':" + hdInforSysNo + "}",
        dataType: 'json',
        success: function (res) {
            common.loading(false);
            console.log("res===", res);
            var data = eval("(" + res.d + ")");

            var amoney = data.SubjectEntities[0].AnswerMoney;
            //    amoney = 3;
            $(".hbbegin").html(amoney);
            $(".hbend").html(amoney);
            $(".phbend").html("获得" + data.SubjectEntities[0].StrAnswerMoney + "元奖励金");

            BindData(data);


          

        }
    });
}


function BindData(data)
{
    if (data.DoFlag == 1) {
        //没有回答过问题
        if (data.SubjectEntities != null) {

            var strTitle = '<img src="' + data.SubjectEntities[0].ProblemNameUrl + '" />';
            $(".banner").html(strTitle);
            var htmlData = "";

            var anent = data.SubjectEntities[0].AnswerEntities;
            if (anent != null) {
                for (var i = 0; i < anent.length; i++) {
                    htmlData += '<div class="grid"><div class="box"><img class="box-thumbnail" style="cursor: pointer;"   SubSysNo=\"' + anent[i].SubSysNo + '\" SysNo=\"' + anent[i].SysNo + '\" ChildrenSubSysNo=\"' + anent[i].ChildrenSubSysNo + '\"   src="' + anent[i].AnswerNameUrl + '" /></div></div>';
                }
                $(".list").html(htmlData);
            }
            else {
                alert("已经答过了？");
            }
        } else {
            common.downLoadDialog();
        }
    } else {
        alert("获取题目失败");
    }
}