<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="web.aspx.cs" Inherits="decoration.publicweb.web" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:HyperLink ID="HyperLink1" runat="server" 
            NavigateUrl="~/publicweb/activity.aspx">活动</asp:HyperLink><br />
        <asp:HyperLink ID="HyperLink2" runat="server" 
            NavigateUrl="~/publicweb/decorationManual.aspx">家装手册</asp:HyperLink><br />
        <asp:HyperLink ID="HyperLink3" runat="server" 
            NavigateUrl="~/publicweb/DesignCase.aspx">设计案例</asp:HyperLink><br />
        <asp:HyperLink ID="HyperLink4" runat="server" 
            NavigateUrl="~/publicweb/designer.aspx">设计师</asp:HyperLink><br />
        <asp:HyperLink ID="HyperLink5" runat="server" 
            NavigateUrl="~/publicweb/intruduction.aspx">集团简介</asp:HyperLink><br />
        <asp:HyperLink ID="HyperLink6" runat="server" 
            NavigateUrl="~/publicweb/process.aspx">家装流程</asp:HyperLink><br />
    
        <br />
        <asp:HyperLink ID="HyperLink7" runat="server" NavigateUrl="~/Login.aspx">系统登录</asp:HyperLink>
&nbsp; 用户名:qq 密码:qq</div>
    </form>
</body>
</html>
