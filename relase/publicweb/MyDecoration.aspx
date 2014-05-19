<%@ Page Title="" Language="C#" MasterPageFile="~/Global.Master" AutoEventWireup="true" CodeBehind="MyDecoration.aspx.cs" Inherits="decoration.MyDecoration" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<meta name="viewport" content="width=device-width, initial-scale=1,minimum-scale=1.0,maximum-scale=1.0 ,user-scalable=no">
<script type="text/javascript" src="js/scroll.js"></script>
    <style type="text/css">

a,img{border:0;}

.scroll{width:100%;height:181px;margin:0; position:relative;overflow:hidden;}
.mod_01{float:left;width:100%;}
.mod_01 img{display:block;width:100%;height:181px;}
.dotModule_new{padding:0 5px;height:11px;line-height:6px;-webkit-border-radius:11px;background:rgba(45,45,45,0.5);position:absolute;bottom:5px;right:1px;z-index:11;}
#slide_01_dot{text-align:center;margin:0 0 0 0;}
#slide_01_dot span{display:inline-block;margin:0 3px;width:5px;height:5px;vertical-align:middle;background:#f7f7f7;-webkit-border-radius:5px;}
#slide_01_dot .selected{background:#66ff33;}

        .auto-style1 {
            background-color:#ccc;
            height: 7px;
             vertical-align:middle;
        }
        .date
        {
            color:red;
            font-size:1em;
            text-align:right;
             
        }
         .content
        {
            color:red;
            font-size:1em;
           
             
        }
         .date2
        {
            color:green;
            font-size:1em;
            text-align:right;
            
        }
         .content2
        {
            color:green;
            font-size:1em;
           
             
        }

    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  
    <table style="width:100%;">
    <tr><td class="auto-style1"><font style="color:#FF4500; vertical-align:middle; ">&nbsp;&nbsp;<b>装修进度</b></font></td></tr>
        <tr>
            <td>
                <h5 style="color: rgb(100, 110, 122); font-family: arial, sans-serif; font-style: normal; font-variant: normal; letter-spacing: normal; line-height: normal; orphans: auto; text-indent: 0px; text-transform: none; white-space: normal; widows: auto; word-spacing: 0px; -webkit-text-stroke-width: 0px; background-color: rgb(255, 255, 255);">
                      <a runat="server" id="a1" href="myProcessDetail.aspx?p=1" style=" text-decoration:none;"> <asp:Label ID="l1" runat="server" Text="家装咨询"></asp:Label></a>
                    －<a runat="server" id="a2" href="myProcessDetail.aspx?p=2" style=" text-decoration:none;"><asp:Label ID="l2" runat="server" Text="现场量房"></asp:Label></a>
                    －<a runat="server" id="a3" href="myProcessDetail.aspx?p=3" style=" text-decoration:none;"><asp:Label ID="l3" runat="server" Text="方案确认"></asp:Label></a>
                    －<a runat="server" id="a4" href="myProcessDetail.aspx?p=4" style=" text-decoration:none;"><asp:Label ID="l4" runat="server" Text="签订合同"></asp:Label></a>
                    －<a runat="server" id="a5" href="myProcessDetail.aspx?p=5" style=" text-decoration:none;"><asp:Label ID="l5" runat="server" Text="首期付款"></asp:Label></a>
                    －<a runat="server" id="a6" href="myProcessDetail.aspx?p=6" style=" text-decoration:none;"><asp:Label ID="l6" runat="server" Text="完整家居"></asp:Label></a>
                    －<a runat="server" id="a7" href="myProcessDetail.aspx?p=7" style=" text-decoration:none;"><asp:Label ID="l7" runat="server" Text="现场包装"></asp:Label></a>
                    －<a runat="server" id="a8" href="myProcessDetail.aspx?p=8" style=" text-decoration:none;"><asp:Label ID="l8" runat="server" Text="材料验收"></asp:Label></a>
                    －<a runat="server" id="a9" href="myProcessDetail.aspx?p=9" style=" text-decoration:none;"><asp:Label ID="l9" runat="server" Text="进场施工"></asp:Label></a>
                    －<a runat="server" id="a10" href="myProcessDetail.aspx?p=10" style=" text-decoration:none;"><asp:Label ID="l10" runat="server" Text="中期验收"></asp:Label></a>
                    －<a runat="server" id="a11" href="myProcessDetail.aspx?p=11'" style=" text-decoration:none;"><asp:Label ID="l11" runat="server" Text="交中期款"></asp:Label></a>
                    －<a runat="server" id="a12" href="myProcessDetail.aspx?p=12" style=" text-decoration:none;"><asp:Label ID="l12" runat="server" Text="竣工验收"></asp:Label></a>
                    －<a runat="server" id="a13" href="myProcessDetail.aspx?p=13" style=" text-decoration:none;"><asp:Label ID="l13" runat="server" Text="交付尾款"></asp:Label></a>
                    －<a runat="server" id="a14" href="myProcessDetail.aspx?p=14" style=" text-decoration:none;"><asp:Label ID="l14" runat="server" Text="家装保修"></asp:Label></a>
                     </h5><br/><br/>
                欢迎您&nbsp;<asp:Label ID="label_name" runat="server"></asp:Label>&nbsp;&nbsp;<font><a href="message.aspx">您有(3)条未读消息</a></font><br/><br/>
                <asp:Label ID="label_message" runat="server" Text=""> </asp:Label><br/><br/>
               <font color="red"> 本阶段注意事项:</font>由客户、设计师、工程监理、施工负责人参与，验收合格后在质量报告书上签字确认。
                <table style="width:80%; border:0px;">
                    <tr>
                        <td colspan="3" class="auto-style1"><font style="color:#FF4500; vertical-align:middle; ">&nbsp;&nbsp;<b>实景图片</b></font></td>
                    </tr>
                    <tr>
                        <td colspan="3"><div class="scroll">
	<div class="slide_01" id="slide_01">
		<div class="mod_01"><a href="#"><img width="50%" src="images/111.png" alt="实景照片"></a></div>
		<div class="mod_01"><a href="#"><img width="100%" src="images/222.png" alt="实景照片"></a></div>
		<div class="mod_01"><a href="#"><img width="100%" src="images/333.png" alt="实景照片"></a></div>
		
	</div>
	
</div>

<script type="text/javascript">
    if (document.getElementById("slide_01")) {
        var slide_01 = new ScrollPic();
        slide_01.scrollContId = "slide_01"; //内容容器ID
        slide_01.dotListId = "slide_01_dot"; //点列表ID
        slide_01.dotOnClassName = "selected";
        slide_01.arrLeftId = "sl_left"; //左箭头ID
        slide_01.arrRightId = "sl_right"; //右箭头ID
        slide_01.frameWidth = 100%;
        slide_01.pageWidth = 100%;
        slide_01.upright = false;
        slide_01.speed = 10;
        slide_01.space = 30;
        slide_01.initialize(); //初始化
    }
</script></td>
                       
                    </tr>
                    <tr><td>
                    <table style="width:100%;">
                    <tr><td colspan="2" class="auto-style1"><font style="color:#FF4500; vertical-align:middle;  ">&nbsp;&nbsp;<b>待解决问题</b></font></td></tr>
                    <tr><td class="content">1,工长没有上班,几天没看见了</td><td class="date"> 2014-04-12</td></tr>
                    <tr><td class="content">2,工人技术不好，要求换人</td><td class="date">2014-04-12</td></tr>
                    <tr><td class="content">3,瓷砖铺的不平，多处鼓包</td><td class="date">2014-04-12</td></tr>
                    </table></td></tr>
                    <tr><td>
                    <table style="width:100%;">
                    <tr><td colspan="2" class="auto-style1"><font style="color:#FF4500; vertical-align:middle;  ">&nbsp;&nbsp;<b>已解决问题</b></font></td></tr>
                    <tr><td class="content2">1,工长没有上班,几天没看见了</td><td class="date2"> 2014-04-12</td></tr>
                    <tr><td class="content2">2,工人技术不好，要求换人</td><td class="date2">2014-04-12</td></tr>
                    <tr><td class="content2">3,瓷砖铺的不平，多处鼓包</td><td class="date2">2014-04-12</td></tr>
                    <tr><td class="content2">4,工长没有上班,几天没看见了</td><td class="date2"> 2014-04-12</td></tr>
                    <tr><td class="content2">5,工人技术不好，要求换人</td><td class="date2">2014-04-12</td></tr>
                    <tr><td class="content2">6,瓷砖铺的不平，多处鼓包</td><td class="date2">2014-04-12</td></tr>
                    </table></td></tr>
                <tr><td>
                <p><asp:LinkButton ID="LinkButton1" runat="server" onclick="LinkButton1_Click">我要投诉</asp:LinkButton>
                    
                </p>
            </td>
        </tr>
    </table>
</asp:Content>
