
$(function(){

    var strHtml = "";
 

    if(res != null && res.ArticleEntities.length>0)
    {
        for(var i=0;i<res.ArticleEntities.length;i++)
        {
            var item = res.ArticleEntities[i];

            if (i == 0) {
                shareIntro = item.Title;
            }
            strHtml += '<div class="share-item"><div class="item-thumbnail"><img class="item-img" src="'+item.HeadPic +'" /></div>';
            strHtml += '<h3 class="item-title">'+item.Title +'</h3>';
            strHtml += '<div class="item-summary">'+item.Subtitle +'</div>';
            strHtml+='<div class="item-date">'+auther_name +' '+item.StrRowCeateDate  +'</div>'; 
            strHtml+='<div class="text-center"><div class="line"></div></div></div>';
        }
    }
    //console.log("html:"+strHtml);
    $(".share-list").html(strHtml);

    shareInit(window.location.href, shareTitle, shareIntro);
    $(".btn-read").click(function () {

        //console.log("Save");

        var mobile = $(".form-control").val();
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
            } else {
                common.loading(true);
                $.ajax({
                    type: "POST",
                    contentType: "application/json",
                    url: 'Ajax/indexAjax.aspx/SaveSelfMediaShare',
                    data: "{'mobile':"+ mobile +",'authID':"+AuthorSysNo+",'articleID':"+aiticle_id+"}",
                    dataType: 'json',
                    success: function (res) {
                        common.loading(false);
                        //console.log("res===", res);
                        var data = eval("(" + res.d + ")");
                        if (data.DoFlag == 1) {
                            //下载app链接
                            window.location.href = "http://a.app.qq.com/o/simple.jsp?pkgname=com.point.quzan";
                        } else {
                            alert(data.DoResult);
                        }
                    }
                });
            }
        }
    });
});


////分享注册
//function shareInit(shareurl, ShareTitle, ShareIntro) {

//    //var ShareTitle = $("#hdTitle").val();
//    //var ShareIntro = "Point";
//    var imageUrl = "http://wap.point-server.com/static/img/logo300.JPG";
//  //  var shareurl = window.location.href;
//    var jsonData = "{'shareurl':'" + shareurl + "'}";
//    console.log(jsonData);
//    console.log("'shareurl':" + shareurl);
//    $.ajax({
//        type: "POST",
//        contentType: "application/json",
//        url: 'Ajax/indexAjax.aspx/ShareConfig',
//        data: jsonData,
//        dataType: 'json',
//        success: function (res) {
//            common.loading(false);

//            var data = eval("(" + res.d + ")");
//            console.log("data");
//            console.log(data);
//            wx.config({
//                debug: false, // 开启调试模式,调用的所有api的返回值会在客户端alert出来，若要查看传入的参数，可以在pc端打开，参数信息会通过log打出，仅在pc端时才会打印。
//                appId: data.appid, // 必填，公众号的唯一标识
//                timestamp: data.timestamp, // 必填，生成签名的时间戳
//                nonceStr: data.nonceStr, // 必填，生成签名的随机串
//                signature: data.signture,// 必填，签名，见附录1
//                jsApiList: [
//                    'checkJsApi',
//                    'onMenuShareQQ',
//                    'onMenuShareTimeline',
//                    'onMenuShareWeibo',
//                    'onMenuShareAppMessage']  // 必填，需要使用的JS接口列表，所有JS接口列表见附录2
//            });

//            wx.ready(function () {
//                console.log("wx.ready");
//                // var shareurl = shareurl
//                wx.onMenuShareAppMessage({
//                    title: ShareTitle,
//                    desc: ShareIntro,
//                    link: shareurl,
//                    imgUrl: imageUrl,
//                    trigger: function (res) {
//                        //alert('用户点击发送给朋友');
//                    },
//                    success: function (res) {
//                        // alert('已分享');
//                    },
//                    cancel: function (res) {
//                        // alert('已取消');
//                    },
//                    fail: function (res) {
//                        // alert(JSON.stringify(res));
//                    }
//                });
//                // config信息验证后会执行ready方法，所有接口调用都必须在config接口获得结果之后，config是一个客户端的异步操作，所以如果需要在页面加载时就调用相关接口，则须把相关接口放在ready函数中调用来确保正确执行。对于用户触发时才调用的接口，则可以直接调用，不需要放在ready函数中。
//                wx.onMenuShareQQ({
//                    title: ShareTitle,
//                    desc: ShareIntro,
//                    link: shareurl,
//                    imgUrl: imageUrl,
//                    success: function () {
//                        // 用户确认分享后执行的回调函数
//                    },
//                    cancel: function () {
//                        // 用户取消分享后执行的回调函数
//                    }
//                });

//                wx.onMenuShareWeibo({
//                    title: ShareTitle,
//                    desc: ShareIntro,
//                    link: shareurl,
//                    imgUrl: imageUrl,
//                    success: function () {
//                        // 用户确认分享后执行的回调函数
//                    },
//                    cancel: function () {
//                        // 用户取消分享后执行的回调函数
//                    }
//                });
//                wx.onMenuShareTimeline({
//                    title: ShareTitle,
//                    link: shareurl,
//                    imgUrl: imageUrl,
//                    success: function () {
//                        // 用户确认分享后执行的回调函数
//                    },
//                    cancel: function () {
//                        // 用户取消分享后执行的回调函数
//                    }
//                });
//            });

//        }
//    });
//}