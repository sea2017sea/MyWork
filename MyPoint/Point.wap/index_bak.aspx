<%@ Page Language="C#" AutoEventWireup="true" CodeFile="index_bak.aspx.cs" Inherits="index_bak" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="UTF-8">
    <title><%=shareTitle %></title>
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <meta name="format-detection" content="telephone=no" />
    <meta name="description" content="" />
    <meta name="viewport" content="user-scalable=no,initial-scale=1,maximum-scale=1,minimum-scale=1">
    <link rel="stylesheet" href="/static/css/index.css">
</head>

<body>
    
<div class="container-index">
    <img src="static/img/bg1.jpg" alt="">
    <div class="input-box">
        <input type="text" id="mobile" maxlength="11" placeholder="输入手机号">
        <a href="javascript:;" class="startBtn" id="startBtn"></a>
    </div>
</div>
    <input type="hidden" id="hdShareSysNo" value="<%=shareSysNo %>"/>
    <input type="hidden" id="hdShareUserId" value="<%=shareUserId %>"/>
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
<script src="/static/js/index.js"></script>
</html>
