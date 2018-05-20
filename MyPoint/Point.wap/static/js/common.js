var common = {
    loading : function (flag) {
        if(flag){
            var html = [];
            html.push('<div class="touchweb_mask"><div class="loading"><div class="gif_img"></div></div></div>');
            $("body").append(html.join(""));
        }else{
            if($(".touchweb_mask").length > 0){
                $(".touchweb_mask").remove();
            }
        }
    },
    downLoadDialog: function () {
        var html = [];
        html.push('<div class="touchweb_mask"><div class="bg_open_app">');
        html.push(' <a href="javascript:;" id="downLoadBtn" name="打开趣赞"></a> </div></div>');
        $("body").append(html.join(""));
        $("#downLoadBtn").unbind().bind("click", function () {
            common.downLoadAppUrl();
        });
    },
    versions: function() {
        var u = navigator.userAgent, app = navigator.appVersion;
        return {
            trident: u.indexOf('Trident') > -1, //IE内核
            presto: u.indexOf('Presto') > -1, //opera内核
            webKit: u.indexOf('AppleWebKit') > -1, //苹果、谷歌内核
            gecko: u.indexOf('Gecko') > -1 && u.indexOf('KHTML') == -1, //火狐内核
            mobile: !!u.match(/AppleWebKit.*Mobile.*/) || !!u.match(/AppleWebKit/), //是否为移动终端
            ios: !!u.match(/\(i[^;]+;( U;)? CPU.+Mac OS X/), //ios终端
            android: u.indexOf('Android') > -1 || u.indexOf('Linux') > -1, //android终端或者uc浏览器
            iPhone: u.indexOf('iPhone') > -1 || u.indexOf('Mac') > -1, //是否为iPhone或者QQHD浏览器
            iPad: u.indexOf('iPad') > -1, //是否iPad
            webApp: u.indexOf('Safari') == -1, //是否web应该程序，没有头部与底部
            WChat: u.indexOf('MicroMessenger') > -1, //是否为微信浏览器
            test: "aaa"
        };
    }(),
    downLoadAppUrl: function () {
         if (common.versions.ios == true || common.versions.iPhone == true || common.versions.iPad == true) {
             window.location.href = "download/PointAppRelease.apk";  //ios 下载链接
         }else{
             window.location.href = "download/PointAppRelease.apk";  //安卓下载链接
         }
    },
    getQueryHrefString: function(url, name) {
        var reg = new RegExp("(^|&)" + name + "=([^&]*)(&|$)", "i");
        var str = url.split("?")[1];
        var r = str.match(reg);
        if (r != null) return decodeURIComponent(unescape(r[2])); return null;
    }

};


//分享注册
function shareInit(shareurl, ShareTitle, ShareIntro) {


    console.log("common url:" + shareurl + " shareTitle:" + shareTitle + " shareIntro:" + shareIntro);

    var imageUrl = "http://wap.point-server.com/static/img/logo300.JPG";
    //  var shareurl = window.location.href;
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
            console.log(data);
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
}