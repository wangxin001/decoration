using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using Dal;
using Model;
namespace decoration.publicweb
{
    public partial class designer : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                this.designDropDownListBind();
                this.repeaterDataBind("c1");
            }
        }
        /// <summary>
        /// 设计师数据显示数据绑定
        /// </summary>
        public void repeaterDataBind(string company)
        {
            PagedDataSource dataSource = new PagedDataSource();
            DesignerDao designerDao = new DesignerDao();
            List<Designer> list = designerDao.getDesignersByArea(company);
            if (list == null||list.Count == 0)
            {
                Label_message.Text = "没有查询到您要找的信息!";
                Label_message.Style.Add("color", "#FF4500");
                lblCurrentPage.Text = "";
                HyperLinkPre.Text = "";
                HyperLinkLast.Text = "";
                Repeater1.DataSource = null;
                Repeater1.DataBind();
            }
            else
            {
                HyperLinkPre.Text = "上一页";
                HyperLinkLast.Text = "下一页";
                dataSource.DataSource = list;
                dataSource.AllowPaging = true;
                dataSource.PageSize = 6;
                int CurPage;
                if (Request.QueryString["Page"] != null)
                {
                    CurPage = Convert.ToInt32(Request.QueryString["Page"]);
                }
                else
                {

                    CurPage = 1;
                }
                dataSource.CurrentPageIndex = CurPage - 1;
                lblCurrentPage.Text = string.Format("当前第{0}/{1}页", CurPage,dataSource.PageCount);
                if (!dataSource.IsFirstPage)
                {
                    HyperLinkPre.NavigateUrl = Request.CurrentExecutionFilePath + "?Page=" + Convert.ToString(CurPage - 1);
                }
                if (!dataSource.IsLastPage)
                {
                    HyperLinkLast.NavigateUrl = Request.CurrentExecutionFilePath + "?Page=" + Convert.ToString(CurPage + 1);
                }
                Repeater1.DataSource = dataSource;
                Repeater1.DataBind();
                Label_message.Text = "";
            }
        }
        /// <summary>
        /// 查询设计师数据地区条件的数据绑定
        /// </summary>
        public void designDropDownListBind()
        {
            DataSet ds = new DataSet();
            ds.ReadXml(Server.MapPath("~/App_Data/company.xml"));
            DataView dv = new DataView(ds.Tables[0]);
            foreach (DataRowView row in dv)
            {
                this.areaDropDownList.Items.Add(new ListItem(row["name"].ToString(), row["id"].ToString()));
            }
        }

        protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if ((e.Item.ItemIndex + 1) % 2 == 0)
            {
                //e.Item.Controls.Add(new LiteralControl("<br/>"));
            }
        }

        protected void search_button_Click(object sender, EventArgs e)
        {
            string area = areaDropDownList.SelectedValue;
            this.repeaterDataBind(area);

        }
    }
}