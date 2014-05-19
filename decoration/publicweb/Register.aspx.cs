using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dal;
using Model;
namespace decoration.publicweb
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                password.Attributes["value"] = password.Text;
                username.Attributes.Add("onfocus", "username()");
                username.Attributes.Add("onblur", "username2()");
                password.Attributes.Add("onfocus", "password()");
                password.Attributes.Add("onblur", "password2()");
                wx.Attributes.Add("onfocus", "wx()");
                wx.Attributes.Add("onblur", "wx2()");
            }
        }

        protected void loginbutton_Click(object sender, EventArgs e)
        {
            User user = new User();
            UserDao userDao = new UserDao();
            string usernamevalue = username.Text;
            string passwordvalue = password.Text;
            string wxvalue = wx.Text;
            if (string.IsNullOrEmpty(usernamevalue))
            {
                message_lable.Text = "请输入用户名!";
                message_lable.Style.Add("color", "red");
            }
            else if (string.IsNullOrEmpty(passwordvalue)||passwordvalue.Equals("***"))
            {
                message_lable.Text = "请输入密码!";
                message_lable.Style.Add("color", "red");
            }
            else if (string.IsNullOrEmpty(wxvalue)||wxvalue.Equals("微信号"))
            {
                message_lable.Text = "请输入微信号!";
                message_lable.Style.Add("color", "red");
            }
            else if (!userDao.isUserNameExist(usernamevalue))
            {
                message_lable.Text = "用户名已存在!";
                message_lable.Style.Add("color", "red");
            }
            else
            {

                user.Username = usernamevalue;
                user.Password = passwordvalue;
                user.Wxid = wxvalue;
               
                bool rs = userDao.insertUser(user);
                if (rs)
                {
                    message_lable.Text = "恭喜您!注册成功!正在返回登录页面...";
                    message_lable.Style.Add("color", "red");
                    Session.Add("user", user);
                    Server.Transfer("../Login.aspx");
                }
                else
                {
                    message_lable.Text = "系统忙请重新输入!";
                    message_lable.Style.Add("color", "red");
                }
            }
        }
    }
}