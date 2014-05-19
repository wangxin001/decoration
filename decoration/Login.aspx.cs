using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dal;
using Model;
using System.Web.Security;
namespace decoration
{
    public partial class Login : System.Web.UI.Page
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
               
                
            }
        }

        protected void loginbutton_Click(object sender, EventArgs e)
        {
            UserDao userDao = new UserDao();
            User user=null;
            string usernamevalue = username.Text;
            string passwordvalue = password.Text;
            user = userDao.selectUser(usernamevalue, passwordvalue);
            if (user == null)
            {
                message_lable.Text = "用户名或密码错误!";
                message_lable.Style.Add("color", "red");
            }
            else
            {
                FormsAuthentication.SetAuthCookie(usernamevalue, true);
                Session.Add("user", user);
                Server.Transfer("MyDecoration.aspx");
            }

        }

      

      
    }
}