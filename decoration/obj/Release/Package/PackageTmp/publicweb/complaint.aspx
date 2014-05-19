吃<%@ Page Title="" Language="C#" MasterPageFile="~/Global.Master" AutoEventWireup="true" CodeBehind="complaint.aspx.cs" Inherits="decoration.complaint" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <style type="text/css">
        .auto-style1 {
            width: 20%;
        }
          .style3
        {
            
             background-color:#FF4500;
             margin-top:1px;
        }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="style3" style="background-color:#ccc;height:2em;text-align:left; vertical-align:middle;"  ><font style="color:#FF4500; vertical-align:middle; ">&nbsp;&nbsp;<b>我要投诉</b></font></div>
    <table style="width:100%">
        <tr><td class="auto-style1">投诉阶段</td><td><select>
            
            <option>现场量房</option>
             <option>方案确认</option>
            <option>签订合同</option>

                                                 </select></td></tr>
        <tr><td class="auto-style1">内容</td><td>墙面不平整</td></tr>
        <tr><td colspan="2" class="auto-style1" style="text-align:center;">
            <asp:Button CssClass="style3" ID="Button1" Width="87%" Height="2.5em"  ForeColor="White"  BorderWidth="0" runat="server" Text="提交" /></td></tr>


    </table>
    
   
</asp:Content>
