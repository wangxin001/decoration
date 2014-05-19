using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dal;
using Model;
namespace decoration.publicweb
{
    public partial class designerDetail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                string id = Request.QueryString["id"];
                DesignerDao designerDao = new DesignerDao();
                Designer designer = designerDao.getDesignerById(id);
                Image1.ImageUrl = "designerimage/" + designer.Pic;
                lable_name.Text = designer.Name;
                lable_company.Text = designer.Company;
                lable_sjln.Text = designer.Sjln;
                lable_sjxy.Text = designer.Sjxy;
                lable_summary.Text = designer.Summary;
                lable_tel.Text = designer.Tel;
                lable_works.Text = designer.Works;
            }

        }
    }
}