<%@ Page Title="" Language="C#" MasterPageFile="~/Global.Master" AutoEventWireup="true" CodeBehind="designerDetail.aspx.cs" Inherits="decoration.publicweb.designerDetail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style2
        {
        }
        .style4
        {
        }
        .style5
        {
            width: 73px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div  style="background-color:#ccc;height:2em;text-align:left; vertical-align:middle; width:100%"  ><font style="color:#FF4500; vertical-align:middle; ">&nbsp;&nbsp;<b>设计师简介</b></font></div>


    <table style="width: 100%; ">
        <tr>
            <td style="vertical-align:top;" class="style4" colspan="2" >
                &nbsp;
                &nbsp;
                &nbsp;
                <asp:Image ID="Image1" runat="server" />
               
                <asp:Label ID="lable_name" runat="server" ForeColor="#999999"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="vertical-align:top;" class="style5" >
                <span style="color: rgb(241, 120, 33); font-family: arial, sans-serif; font-size: 12px; font-style: normal; font-variant: normal; font-weight: normal; letter-spacing: normal; line-height: 26px; orphans: auto; text-align: start; text-indent: 0px; text-transform: none; white-space: normal; widows: auto; word-spacing: 0px; -webkit-text-stroke-width: 0px; background-color: rgb(255, 255, 255); display: inline !important; float: none;">
                地&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 区：</span></td>
            <td style="vertical-align:top;" class="style2">
                <asp:Label ID="lable_company" runat="server" ForeColor="#999999"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="vertical-align:top;" class="style5" >
                <span style="color: rgb(241, 120, 33); font-family: arial, sans-serif; font-size: 12px; font-style: normal; font-variant: normal; font-weight: normal; letter-spacing: normal; line-height: 26px; orphans: auto; text-align: start; text-indent: 0px; text-transform: none; white-space: normal; widows: auto; word-spacing: 0px; -webkit-text-stroke-width: 0px; background-color: rgb(255, 255, 255); display: inline !important; float: none;">
                联系方式：</span></td>
            <td style="vertical-align:top;" class="style2">
                <asp:Label ID="lable_tel" runat="server" ForeColor="#999999"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="vertical-align:top;" class="style5" >
                <span style="color: rgb(241, 120, 33); font-family: arial, sans-serif; font-size: 12px; font-style: normal; font-variant: normal; font-weight: normal; letter-spacing: normal; line-height: 26px; orphans: auto; text-align: start; text-indent: 0px; text-transform: none; white-space: normal; widows: auto; word-spacing: 0px; -webkit-text-stroke-width: 0px; background-color: rgb(255, 255, 255); display: inline !important; float: none;">
                设计心语：</span></td>
            <td style="vertical-align:top;" class="style2">
                <asp:Label ID="lable_sjxy" runat="server" ForeColor="#999999"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="vertical-align:top;" class="style5" >
                <span style="color: rgb(241, 120, 33); font-family: arial, sans-serif; font-size: 12px; font-style: normal; font-variant: normal; font-weight: normal; letter-spacing: normal; line-height: 26px; orphans: auto; text-align: start; text-indent: 0px; text-transform: none; white-space: normal; widows: auto; word-spacing: 0px; -webkit-text-stroke-width: 0px; background-color: rgb(255, 255, 255); display: inline !important; float: none;">
                设计理念：</span></td>
            <td style="vertical-align:top;" class="style2">
                <asp:Label ID="lable_sjln" runat="server" ForeColor="#999999"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="vertical-align:top;" class="style5" >
               
                <span style="color: rgb(241, 120, 33); font-family: arial, sans-serif; font-size: 12px; font-style: normal; font-variant: normal; font-weight: normal; letter-spacing: normal; line-height: 26px; orphans: auto; text-align: start; text-indent: 0px; text-transform: none; white-space: normal; widows: auto; word-spacing: 0px; -webkit-text-stroke-width: 0px; background-color: rgb(255, 255, 255); display: inline !important; float: none;">
                主要作品：</span></td>
            <td style="vertical-align:top;" class="style2">
               
                <asp:Label ID="lable_works" runat="server" ForeColor="#999999"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="vertical-align:top;" class="style5" >
               
                <span style="color: rgb(241, 120, 33); font-family: arial, sans-serif; font-size: 12px; font-style: normal; font-variant: normal; font-weight: normal; letter-spacing: normal; line-height: 26px; orphans: auto; text-align: start; text-indent: 0px; text-transform: none; white-space: normal; widows: auto; word-spacing: 0px; -webkit-text-stroke-width: 0px; background-color: rgb(255, 255, 255); display: inline !important; float: none;">
                个人简介：</span></td>
            <td style="vertical-align:top;" class="style2">
               
                <asp:Label ID="lable_summary" runat="server" ForeColor="#999999"></asp:Label>
            </td>
        </tr>
    </table>

</asp:Content>
