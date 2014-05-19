<%@ Page Title="" Language="C#" MasterPageFile="~/Global.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="decoration.Login" %>
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
        <script type="text/javascript">
            function username() {
                var val = document.getElementById("ctl00_ContentPlaceHolder1_username").value;
               
                if (val == "用户名") {
                    document.getElementById("ctl00_ContentPlaceHolder1_username").value = "";
                }
            }
            function username2() {
                var val = document.getElementById("ctl00_ContentPlaceHolder1_username").value;

                if (val == "") {
                    document.getElementById("ctl00_ContentPlaceHolder1_username").value = "用户名";
                }
            }

            function password() {
                var val = document.getElementById("ctl00_ContentPlaceHolder1_password").value;

                if (val == "***") {
                    document.getElementById("ctl00_ContentPlaceHolder1_password").value = "";
                }
            }
            function password2() {
                var val = document.getElementById("ctl00_ContentPlaceHolder1_password").value;

                if (val == "") {
                    document.getElementById("ctl00_ContentPlaceHolder1_password").value = "***";
                }
            }
            function clear() {
                document.getElementById("ctl00_ContentPlaceHolder1_username").value = "";
                document.getElementById("ctl00_ContentPlaceHolder1_password").value = "";
            }
        
        </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style=" margin:0 em auto" align="center">
  
<div class="style3" style="background-color:#ccc;height:2em;text-align:left; vertical-align:middle;"  ><font style="color:#FF4500; vertical-align:middle; ">&nbsp;&nbsp;<b>登录</b></font></div>
<div>
   <p> <asp:TextBox  CssClass="text"  ID="username" runat="server">用户名</asp:TextBox></p>
   <p>
       <asp:TextBox  CssClass="text" ID="password" runat="server" 
           TextMode="Password">***</asp:TextBox>
    </p>
    <asp:Label ID="message_lable" runat="server"></asp:Label>
    <p>
        <asp:Button class="style3" Width="87%" Height="2.5em" ID="loginbutton" 
            runat="server" ForeColor="White" Text="登录" BorderWidth="0" 
            onclick="loginbutton_Click" />
    </p>
    
        <asp:Button  class="style3" Width="87%" Height="2.5em" ID="clear" 
            ForeColor="White" BorderWidth="0"
            runat="server" Text="注册" PostBackUrl="~/publicweb/Register.aspx"  />
   <p></p>
    </div>
</div>
</asp:Content>
