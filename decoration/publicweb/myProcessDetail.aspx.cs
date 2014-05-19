using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dal;
using Model;
namespace decoration
{
    public partial class myProcessDetail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                MyDecorationDao myDecorationDao = new MyDecorationDao();
                User user = (User)Session["user"];
                string currentProcess = Request.QueryString["p"];
                string[] progress ={"家装咨询","现场量房","方案确认","签订合同","首期付款","完整家居",
                "现场包装","材料验收","进场施工","中期验收","交中期款","竣工验收","交付尾款",
                "家装保修"};
                //Model.MyDecoration myDecoration = myDecorationDao.selectCurrentMyDecoration(user.Id, progress[Convert.ToInt32(currentProcess) - 1]);
               // label_process.Text = myDecoration.Process;
                label_process.Text = "现场量房";
                
                label.Text = getProcessInfo(Convert.ToInt32(currentProcess));
            }
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Server.Transfer("~/MyDecoration.aspx");
        }
        private string getProcessInfo(int currentProcess)
        {
            switch (currentProcess)
            {
                case 1:
                    return "客户向设计师咨询家装设计风格、费用、周期等。";
                case 2:
                    return "由设计师到客户拟装修的居室进行现场勘测，并进行综合的考察，以便更加科学、合理地进行家装设计。" + "<br/>测量内容包括：<br/>" +
"(1)定量测量：测量室内的长、宽，计算出每个用途不同的房间的面积。<br/>" +
"(2)定位测量：主要标明门、窗、暖气罩的位置(窗户要标明数量)。<br/>" +
"(3)高度测量：主要测量各房间的高度。";
                case 3:
                    return "根据客户选择的设计风格，由设计师进行家装设计，根据客户反馈，最终确定设计方案、图纸及相关预算,并由客户签字。";
                case 4:
                    return "在双方对设计方案及预算确认的前提下，签定装修合同，明确双方的权利与义务。";
                case 5:
                    return "按照合同约定交付工程首期款项。";
                case 6:
                    return "根据客户选定的装饰装修材料，由公司代为购买。包括主材、家具、配饰品等。客户也可选择由业之峰家具厂自行生产的成品家具。";
                case 7:
                    return "由客户、质检对施工的材料进行现场验收，签字确认。";
                case 8:
                    return "对施工区内的门窗、水表、电表等物品做相应的保护包装。";
                case 9:
                    return "经过前期洽谈和准备后，工程班组即可进入工地开始施工。";
                case 10:
                    return "隐蔽工程及各单项工程，如木工、水电等的验收。";
                case 11:
                    return "交纳合同约定中期款项及工程变更款项。";
                case 12:
                    return "由客户、设计师、工程监理、施工负责人参与，验收合格后在质量报告书上签字确认。";
                case 13:
                    return "按照工程及服务实际发生交纳全部剩余款项。";
                case 14:
                    return "按合同约定，由公司负责一定期限的家装工程的维修工作。";
                default:
                    return "";




            }
        }
    }
}