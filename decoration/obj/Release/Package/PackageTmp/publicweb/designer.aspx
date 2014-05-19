<%@ Page Title="" Language="C#" MasterPageFile="~/Global.Master" AutoEventWireup="true" CodeBehind="designer.aspx.cs" Inherits="decoration.publicweb.designer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<style type="text/css">
       
        .style1
    {
        text-align: center;
        }
        .style3
        {
            
             background-color:#FF4500;
             margin-top:1px;
        }
        .text{
            border:1px solid #ccc;
            width:85%;
            height:2.5em;
            
        }
       
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="style3" style="background-color:#ccc;height:2em;text-align:left; vertical-align:middle;"  ><font style="color:#FF4500; vertical-align:middle; ">&nbsp;&nbsp;<b>设计师团队</b></font></div>
<div style="text-align: right">
    <asp:DropDownList ID="areaDropDownList" runat="server">
    </asp:DropDownList>
    

   &nbsp;&nbsp;
    <asp:Button Height="1.5em" CssClass="style3" BorderWidth="0" ID="search_button" 
        runat="server" Text="搜索" onclick="search_button_Click" />
    </div>

    <br />
    <asp:Label ID="Label_message" runat="server"></asp:Label>
    <table style="width:100%;">
      <asp:Repeater ID="Repeater1" runat="server" 
                    onitemdatabound="Repeater1_ItemDataBound">
             <ItemTemplate>

        <tr >
            <td style=" width:30%">
            <a href="designerDetail.aspx?id=<%#DataBinder.Eval(Container.DataItem,"id") %>"> <img style=" border:0;" src="designerimage/<%# DataBinder.Eval(Container.DataItem,"pic") %>" /> 
            </a>
            </td>
            
            <td style=" width:70%; vertical-align:top;">
            <font color="#FF4500"> <%# DataBinder.Eval(Container.DataItem,"name") %></font><br />
             <font color="#cccccc"><%# DataBinder.Eval(Container.DataItem,"sjxy") %></font>
            </td>
            
        </tr>
        </ItemTemplate>
        </asp:Repeater>
        <tr>
            <td  style="text-align: right" colspan="2">
                <asp:Label ID="lblCurrentPage" runat="server" Text=""></asp:Label>
                <asp:HyperLink ID="HyperLinkPre" runat="server">上一页</asp:HyperLink>&nbsp;
                <asp:HyperLink ID="HyperLinkLast" runat="server">下一页</asp:HyperLink>
            </td>
        </tr>
    </table>
    

</asp:Content>
