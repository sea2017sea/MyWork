<%@ Page Language="C#" AutoEventWireup="true" CodeFile="index.aspx.cs" Inherits="index" %>
<!DOCTYPE html>
<html lang="zh-CN">
<head runat="server">
<meta charset="utf-8">
<meta http-equiv="X-UA-Compatible" content="IE=edge">
<meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1" />
<meta name="keyword" content="" />
<meta name="description" content="" />
<title><%=shareTitle %></title>
<link href="include/css/style.css" rel="stylesheet" />
</head>
<body class="">
    <form runat="server">
<div class="banner">
	<img src="include/images/img02.jpg" />
</div>
<div class="list grids">
	<div class="grid">
		<div class="box"><img class="box-thumbnail" src="include/images/img03-1.jpg" /></div>
	</div>
	<div class="grid">
		<div class="box"><img class="box-thumbnail" src="include/images/img03-2.jpg" /></div>
	</div>
	<div class="grid">
		<div class="box"><img class="box-thumbnail" src="include/images/img03-3.jpg" /></div>
	</div>
	<div class="grid">
		<div class="box"><img class="box-thumbnail" src="include/images/img03-4.jpg" /></div>
	</div>
	<div class="grid">
		<div class="box"><img class="box-thumbnail" src="include/images/img03-1.jpg" /></div>
	</div>
	<div class="grid">
		<div class="box"><img class="box-thumbnail" src="include/images/img03-2.jpg" /></div>
	</div>
	<div class="grid">
		<div class="box"><img class="box-thumbnail" src="include/images/img03-3.jpg" /></div>
	</div>
	<div class="grid">
		<div class="box"><img class="box-thumbnail" src="include/images/img03-4.jpg" /></div>
	</div>
</div><!-- /.list -->

<div class="state01"  >
	<div class="mask"></div>
	<div class="dialog">
		<div class="share-content">
			<div class="logo"></div>
			<div class="share-content-text font-l">参与趣赞互动<br />领取现金奖励金</div>
			<div class="hongbao hbbegin">5</div>
			<div class="share-content-text">微信提现 消费抵用</div>
			<div class="share-operation">
				<a class="btn btn-primary btn-block btn-dialog btn-begin">开始互动</a>
			</div>
		</div>
	</div>
</div><!-- /.state01 -->

<div class="state02" style="display:none;">
	<div class="mask"></div>
	<div class="dialog">
		<div class="share-content">
			<div class="logo"></div>
			<div class="share-content-text font-l">恭喜您<br /><p class="phbend">获得5.00元奖励金</p></div>
			<div class="hongbao hbend">5</div>
			<div class="share-field">
				<input class="form-control data-mobile" type="text" placeholder="输入手机号" />
			</div>
			<div class="share-operation">
				<a class="btn btn-primary btn-block btn-dialog btn-done">下载趣赞提现</a>
			</div>
		</div>
	</div>
</div><!-- /.state02 -->

    <input type="hidden" id="hdShareSysNo" value="<%=shareSysNo %>"/>
    <input type="hidden" id="hdShareUserId" value="<%=shareUserId %>"/>
    <input type="hidden" id="hdSaveAnswer" value=""/>
<!-- <script src="js/zepto.min.js"></script> -->
<%--<script src="include/js/jquery2x.min.js"></script>--%>
<script src="static/js/zepto.js"></script>
<script src="static/js/common.js"></script>
<script src="static/js/question2.js"></script>
<script>

</script>
        </form>
</body>
</html>