using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using Dal;
using Model;
namespace decoration
{
    public partial class MyDecoration : System.Web.UI.Page
    {
        string[] progress ={"家装咨询","现场量房","方案确认","签订合同","首期付款","完整家居",
                "现场包装","材料验收","进场施工","中期验收","交中期款","竣工验收","交付尾款",
                "家装保修"};
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                MyDecorationDao myDecorationDao = new MyDecorationDao();
                UserDao userDao = new UserDao();
                User user =userDao.selectUser(Request["openId"]);
                Session.Add("user", user);
                
                Model.MyDecoration myDecoration = myDecorationDao.selectMyDecorationByUserId(user.Id);
                //如果为null则 说明没有进入装修流程
                if (myDecoration == null)
                {
                    label_message.Text = "您还没有开始装修，现在下单!";
                }
                else
                {
                    Hashtable ta = new Hashtable();
                    for (int i = 0; i < progress.Length; i++)
                    {
                        ta.Add(progress[i], i + 1);
                    }
                    int currentprocess = Convert.ToInt32(ta[myDecoration.Process]);
                    for (int i = 1; i <= ta.Count; i++)
                    {
                        Label label = (Label)this.Master.FindControl("ContentPlaceHolder1").FindControl("l" + i);
                        System.Web.UI.HtmlControls.HtmlAnchor anchor = (System.Web.UI.HtmlControls.HtmlAnchor)this.Master.FindControl("ContentPlaceHolder1").FindControl("a" + i);
                        if (i < currentprocess)
                        {
                            label.Style.Add("color", "green");
                            label.Style.Add("onclick", "");

                        }
                        if (i == currentprocess)
                        {
                            label.Style.Add("color", "#FF4500");
                        }
                        if (i > currentprocess)
                        {

                            anchor.HRef = "";
                        }

                    }
                    label_message.Text = string.Format("您现在装修进度为:<font color='#FF4500'>{0}</font>!", myDecoration.Process);
                }
                label_name.Text = user.Name;
            }
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Server.Transfer("complaint.aspx");
        }

       

    }
}