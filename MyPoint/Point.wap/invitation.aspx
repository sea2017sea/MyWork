<%@ Page Language="C#" AutoEventWireup="true" CodeFile="invitation.aspx.cs" Inherits="invitation" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta charset="UTF-8">
    <title>邀请好友</title>
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <meta name="format-detection" content="telephone=no" />
    <meta name="description" content="" />
    <meta name="viewport" content="user-scalable=no,initial-scale=1,maximum-scale=1,minimum-scale=1">
    <link rel="stylesheet" href="/static/css/invitation.css">
</head>

<body>
    
<div class="container-index">
    <img src="static/img/bg1.jpg" alt="">
    <div class="input-box">
        <a href="download/PointAppRelease.apk" class="startBtn" id="A1"></a>
    </div>
    
<%--    　<div class="btnList">
               <ul>
                   <li id="a"><a href="http://app.qq.com/?isappinstalled=1#id=detail&appid=1104762859">应用下载</a></li> <!--默认apk下载地址，除微信外浏览器都支持-->
                   
                   <li id="Li1"><a href="http://fusion.qq.com/app_download?appid=1104762859&platform=qzone&via=QZ.MOBILEDETAIL.QRCODE">应用下载22222</a></li>
                   <li id="b"><a href="market://search?q=pname:com.zq.qk">应用平台下载</a></li> <!--调用安卓下载地址，会判断手机内已装应用商店下载弹框-->
                   <li><span>下载APP即可使用优惠券大礼包</span></li>
                <ul>
    </div>--%>

</div>

<script type="text/javascript">
    (function (doc, win) {
        var docEl = doc.documentElement,
            resizeEvt = 'orientationchange' in window ? 'orientationchange' : 'resize',
            recalc = function () {
                var clientWidth = docEl.clientWidth;
                if (!clientWidth) return;
                if (clientWidth > 640) clientWidth = 640;
                docEl.style.fontSize = 20 * (clientWidth / 320) + 'px';
            };
        if (!doc.addEventListener) return;
        win.addEventListener(resizeEvt, recalc, false);
        doc.addEventListener('DOMContentLoaded', recalc, false);
    })(document, window);
    
</script>
</body>
    
</html>
