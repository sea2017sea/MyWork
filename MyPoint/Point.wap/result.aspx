<%@ Page Language="C#" AutoEventWireup="true" CodeFile="result.aspx.cs" Inherits="result" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta charset="UTF-8">
    <title>参与互动获抵用金</title>
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <meta name="format-detection" content="telephone=no" />
    <meta name="description" content="" />
    <meta name="viewport" content="user-scalable=no,initial-scale=1,maximum-scale=1,minimum-scale=1">
    <link rel="stylesheet" href="/static/css/result.css">
</head>

<body>

    <div class="result-box">
        <img src="/static/img/txt.png" class="img_txt_a" alt="Alternate Text" />
        <div class="honbao">
            <p><span><%=answerMoney %></span>元</p>
        </div>
        <img src="/static/img/txt2.png" class="img_txt_b" alt="Alternate Text" />
    </div>  
    <div class="bottom">
        <span>您有一笔奖励金已到账</span>
        <a href="download/PointAppRelease.apk" id="download">领取并下载趣赞</a>
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
    
<script src="/static/js/zepto.js"></script>
<script src="/static/js/common.js"></script>
<script src="/static/js/result.js"></script>
</html>
