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