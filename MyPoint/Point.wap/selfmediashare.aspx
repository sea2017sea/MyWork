<%@ Page Language="C#" AutoEventWireup="true" CodeFile="selfmediashare.aspx.cs" Inherits="selfmediashare" %>

<!DOCTYPE html>
<html lang="zh-CN">
<head runat="server">
<meta charset="utf-8">
<meta http-equiv="X-UA-Compatible" content="IE=edge">
<meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1" />
<meta name="keyword" content="" />
<meta name="description" content="" />
<title></title>
<link href="include/css/style.css" rel="stylesheet" />
</head>
<body class="">
<form id="form1" runat="server">
<div class="share">
	<div class="share-logo"></div>
	<div class="share-txt"><%= author_name %>在趣赞发布了最新内容<br />邀请您赶快来阅读</div>
	<div class="share-form">
		<div class="form-group">
			<div class="form-field field-phone">
				<input class="form-control" type="text" placeholder="输入手机号" />
			</div>
		</div>
		<div class="form-group">
			<a class="btn btn-primary btn-read btn-block" style="height:auto!important;line-height:0.7rem">阅读全文</a>
		</div>
	</div>
</div><!-- /.share -->

<div class="share-list">

<%--	<div class="share-item">
		<div class="item-thumbnail">
			<img class="item-img" src="include/images/img01.jpg" />
		</div>
		<h3 class="item-title">2017秋天流行穿长不穿短这些单品一定要够长才时髦！！！</h3>
		<div class="item-summary">2017秋季时装周发布的品牌新品作为引领潮流的风向标，无论从上衣外套亦或下装配饰，全都默契的流行起“穿长不穿短”。回顾明星潮人们的近期私服街拍，造型精髓也都紧跟潮流，统统集中在一个“长”字上。</div>
		<div class="item-date">王力宏 2017-09-12</div>
		<div class="text-center"><div class="line"></div></div>
	</div><!-- /.share-item -->
	<div class="share-item">
		<div class="item-thumbnail">
			<img class="item-img" src="include/images/img01.jpg" />
		</div>
		<h3 class="item-title">2017秋天流行穿长不穿短这些单品一定要够长才时髦！！！</h3>
		<div class="item-summary">2017秋季时装周发布的品牌新品作为引领潮流的风向标，无论从上衣外套亦或下装配饰，全都默契的流行起“穿长不穿短”。回顾明星潮人们的近期私服街拍，造型精髓也都紧跟潮流，统统集中在一个“长”字上。</div>
		<div class="item-date">王力宏 2017-09-12</div>
		<div class="text-center"><div class="line"></div></div>
	</div><!-- /.share-item -->--%>


</div>
    

<!-- <script src="js/zepto.min.js"></script> -->
<script src="include/js/jquery2x.min.js"></script>
<script src="static/js/zepto.js"></script>
    
<script src="static/js/common.js"></script>
<script src="static/js/selfmediashare.js"></script>
<script>
 var auther_name = "<%= author_name%>";
    var res = eval('(<%=res_str%>)');
    var aiticle_id = "<%=article_id%>";
    var AuthorSysNo = "<%=author_id%>";

</script>
    </form>
</body>
    
</html>