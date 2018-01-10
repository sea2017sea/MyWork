
$(function(){
    var strHtml = "";
    if(res != null && res.ArticleEntities.length > 0)
    {
        for(var i=0;i<res.ArticleEntities.length;i++)
        {
            var item = res.ArticleEntities[i];
            strHtml += '<div class="share-item"><div class="item-thumbnail"><img class="item-img" src="'+item.HeadPic +'" /></div>';
            strHtml += '<h3 class="item-title">'+item.Title +'</h3>';
            strHtml += '<div class="item-summary">'+item.Subtitle +'</div>';
            strHtml+='<div class="item-date">'+auther_name +' '+item.StrRowCeateDate  +'</div>'; 
            strHtml+='<div class="text-center"><div class="line"></div></div></div>';
        }
    }
    //console.log("html:"+strHtml);
    $(".share-list").html(strHtml);

    $(".btn-read").click(function () {

        console.log("Save");

        var mobile = $(".form-control").val();
        if (mobile.length <= 0) {
            alert("请输入手机号码");
            return;
        } else {
            if (!mobile.match(/^(13|15|17|18|14)[0-9]{9}$/)) {
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
                        console.log("res===", res);
                        var data = eval("(" + res.d + ")");
                        alert(data.DoResult);
                    }
                });
            }
        }
    });
});