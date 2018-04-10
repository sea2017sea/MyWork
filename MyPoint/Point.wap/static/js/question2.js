
var hdUserid = "0";// $("#hdShareUserId").val();
var hdShareUserId = $("#hdShareUserId").val();
var hdMoblie = "";
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
    $(".btn-done").live('click', function() {

        var hdMoblie = $.trim($(".data-mobile").val());

        //if (!hdMoblie.match(/^(13|15|17|18|14)[0-9]{9}$/)) {
        if (hdMoblie.length != 11) {
            alert("手机号码格式不正确");
            return;
        }
        var lsAns = $("#hdSaveAnswer").val();
        lsAns = "[" + lsAns.substring(0, lsAns.length - 1) + "]";
        //console.log(lsAns);

        $.ajax({
            type: "POST",
            contentType: "application/json",
            url: 'Ajax/indexAjax.aspx/AddAnswerRecordAjax',
            data: "{'shareUserId':" + hdShareUserId + ",'moblie':'" + hdMoblie + "','parameter':'" + lsAns + "'}",
            dataType: 'json',
            success: function(res) {
                common.loading(false);
                var data = eval("(" + res.d + ")");
                if (data.DoFlag == 1) {
                    //下载app链接
                    window.location.href = "http://a.app.qq.com/o/simple.jsp?pkgname=com.point.quzan";
                } else {
                    alert("保存答案失败");
                }
            }
        });
    });

    $(".box-thumbnail").live('click', function () {
        var childrenSubSysNo = $(this).attr('ChildrenSubSysNo');
        var sysNo = $(this).attr('SysNo');
        var subSysNo = $(this).attr('SubSysNo');

        var savaAns = $("#hdSaveAnswer").val();
        var lsAns = savaAns + "{\"SubSysNo\":" + subSysNo + ",\"AnsSysNo\":" + sysNo + "},";
        $("#hdSaveAnswer").val(lsAns);

        //console.log("info=>childrenSubSysNo:" + childrenSubSysNo);

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
    var jsonData = "{'inforSysNo':'" + hdInforSysNo + "'}";
    console.log(jsonData);
    $.ajax({
        type: "POST",
        contentType: "application/json",
        url: 'Ajax/indexAjax.aspx/QueryShareSubjectReq',
        data: jsonData,
        dataType: 'json',
        success: function (res) {
            common.loading(false);
            //console.log("res===", res);
            var data = eval("(" + res.d + ")");

            var amoney = data.SubjectEntities[0].AnswerMoney;
            //    amoney = 3;
            $(".hbbegin").html(amoney);
            $(".hbend").html(amoney);
            $(".phbend").html("获得" + data.SubjectEntities[0].StrAnswerMoney + "元奖励金");

            BindData(data);
            shareInit();
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



//分享注册
function shareInit() {
 
    var ShareTitle = $("#hdTitle").val();
    var ShareIntro =  "Point";
    var imageUrl = "http://wap.point-server.com/static/img/logo300.JPG";
    var shareurl = window.location.href;
    var jsonData = "{'shareurl':'" + shareurl + "'}";
    console.log(jsonData);
    console.log("'shareurl':" + shareurl);
    $.ajax({
        type: "POST",
        contentType: "application/json",
        url: 'Ajax/indexAjax.aspx/ShareConfig',
        data: jsonData,
        dataType: 'json',
        success: function (res) {
            common.loading(false);

            var data = eval("(" + res.d + ")");
            console.log("data");
            console.log( data);
            wx.config({
                debug: false, // 开启调试模式,调用的所有api的返回值会在客户端alert出来，若要查看传入的参数，可以在pc端打开，参数信息会通过log打出，仅在pc端时才会打印。
                appId: data.appid, // 必填，公众号的唯一标识
                timestamp: data.timestamp, // 必填，生成签名的时间戳
                nonceStr: data.nonceStr, // 必填，生成签名的随机串
                signature: data.signture,// 必填，签名，见附录1
                jsApiList: [
                    'checkJsApi',
                    'onMenuShareQQ',
                    'onMenuShareTimeline',
                    'onMenuShareWeibo',
                    'onMenuShareAppMessage']  // 必填，需要使用的JS接口列表，所有JS接口列表见附录2
            });

            wx.ready(function () {
                console.log("wx.ready");
                // var shareurl = shareurl
                wx.onMenuShareAppMessage({
                    title: ShareTitle,
                    desc: ShareIntro,
                    link: shareurl,
                    imgUrl: imageUrl,
                    trigger: function (res) {
                        //alert('用户点击发送给朋友');
                    },
                    success: function (res) {
                        // alert('已分享');
                    },
                    cancel: function (res) {
                        // alert('已取消');
                    },
                    fail: function (res) {
                        // alert(JSON.stringify(res));
                    }
                });
                // config信息验证后会执行ready方法，所有接口调用都必须在config接口获得结果之后，config是一个客户端的异步操作，所以如果需要在页面加载时就调用相关接口，则须把相关接口放在ready函数中调用来确保正确执行。对于用户触发时才调用的接口，则可以直接调用，不需要放在ready函数中。
                wx.onMenuShareQQ({
                    title: ShareTitle,
                    desc: ShareIntro,
                    link: shareurl,
                    imgUrl: imageUrl,
                    success: function () {
                        // 用户确认分享后执行的回调函数
                    },
                    cancel: function () {
                        // 用户取消分享后执行的回调函数
                    }
                });

                wx.onMenuShareWeibo({
                    title: ShareTitle,
                    desc: ShareIntro,
                    link: shareurl,
                    imgUrl: imageUrl,
                    success: function () {
                        // 用户确认分享后执行的回调函数
                    },
                    cancel: function () {
                        // 用户取消分享后执行的回调函数
                    }
                });
                wx.onMenuShareTimeline({
                    title: ShareTitle,
                    link: shareurl,
                    imgUrl: imageUrl,
                    success: function () {
                        // 用户确认分享后执行的回调函数
                    },
                    cancel: function () {
                        // 用户取消分享后执行的回调函数
                    }
                });
            });
           
        }
    });

    //return loadServiceJson({
    //    url: serviceURL.activeShareConfig.url,
    //    type: serviceURL.activeShareConfig.type,
    //    data: JSON.stringify(data)
    //})
    //.done(function (result) {
    //    if (result.Detail) {
            

    //    }
    //});
}