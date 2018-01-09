<%@ Page Language="C#" AutoEventWireup="true" CodeFile="question.aspx.cs" Inherits="question" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta charset="UTF-8">
    <title>参与互动获抵用金</title>
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <meta name="format-detection" content="telephone=no" />
    <meta name="description" content="" />
    <meta name="viewport" content="user-scalable=no,initial-scale=1,maximum-scale=1,minimum-scale=1">
    <link rel="stylesheet" href="/static/css/quesiton.css">
</head>

<body>
    
    <div class="question_content">
        
        <div id="question_box">
           <%-- <div class="title">
                <i></i>
                <div class="txt">
                     <img src="/static/img/goods.jpg" alt="Alternate Text" />
                </div>
            </div>
            <div class="list">
                <ul>
                    <li class="active">
                        <a href="#">
                            <img src="/static/img/goods.jpg" alt="Alternate Text" />
                            <p>这是波阿伯啊</p>
                        </a>
                    </li>
                    <li>
                        <a href="#">
                            <img src="/static/img/goods.jpg" alt="Alternate Text" />
                            <p>这是波阿伯啊</p>
                        </a>
                    </li>
                </ul>
            </div>--%>
        </div>  
        <div class="bottom">
            <span class="txt_zan">趣赞</span>
            <span class="txt_desc">点击图片选定答案即获高额奖励金</span>
        </div>  
    </div>
    
    <input type="hidden" id="hdUserid" value="<%=userid %>"/>
    <input type="hidden" id="hdMoblie" value="<%=moblie %>"/>
    <input type="hidden" id="hdShareSysNo" value="<%=shareSysNo %>"/>
    <input type="hidden" id="hdShareUserId" value="<%=shareUserId %>"/>
    <input type="hidden" id="hdSaveAnswer" value=""/>

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
<script src="/static/js/quesiton.js"></script>
</html>
