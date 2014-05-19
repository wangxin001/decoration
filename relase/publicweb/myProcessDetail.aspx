<%@ Page Title="" Language="C#" MasterPageFile="~/Global.Master" AutoEventWireup="true" CodeBehind="myProcessDetail.aspx.cs" Inherits="decoration.myProcessDetail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
      
        
        body
        {
            font-family:normal;
          
        }
        .style3
        {
            width: 21%;
            text-align: right;
            color: #FF4500;
            text-decoration: none;
            height: 10%;
        }
        .style4
        {
            width: 6%;
            text-align: right;
            color: #FF4500;
            text-decoration: none;
            height: 10%;
        }
        .auto-style1 {
            width: 28%;
            text-align: right;
            color: #FF4500;
            text-decoration: none;
            height: 10%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table style="width:100%; ">
        <tr style=" background:#FF4500 ">
           <td colspan="2">
           
         <asp:Label ID="label_process" runat="server" ForeColor="Black"></asp:Label></b>
           
           </td>
        </tr>
        <tr>
            <td  colspan="2">
             &nbsp;&nbsp;
                <asp:Label ID="label" runat="server"></asp:Label>
            </td>
            
        </tr>
        <tr>
            <td class="auto-style1">
              <p>  开始时间</p></td>
            <td class="style2">
                2014-19-19</td>
        </tr>
        <tr>
            <td class="auto-style1">
                <p> 结束时间</p></td>
            <td class="style2">
                2014-19-19</td>
        </tr>
        <tr>
            <td class="auto-style1">
                 <p>说明</p></td>
            <td class="style2">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style1">
                 <p>投诉</p></td>
            <td class="style2">
                无</td>
        </tr>
        
    </table>
    
</asp:Content>
