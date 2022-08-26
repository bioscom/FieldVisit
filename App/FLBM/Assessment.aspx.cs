using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class App_FLBM_Assessment : aspnetPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (!string.IsNullOrEmpty(Request.QueryString["lAssessId"]))
            {
                long lAssessId = long.Parse(Request.QueryString["lAssessId"]);
                KnowledgeControl1.Visible = false;
                KnowledgeControlEdt1.RetrieveAssessment(lAssessId);
            }
            else
            {
                //KnowledgeControl1.Visible = true;
                KnowledgeControlEdt1.Visible = false;
                KnowledgeControl1.BeginAssessment();
            }
            //else
            //{
            //    Assessors oAssessor = new Assessors();
            //    if (oAssessor.DtGetAssessorByUserId(oSessnx.getOnlineUser.m_iUserId).Rows.Count == 0)
            //    {
            //        KnowledgeControl1.NoAssessmentRight();
            //        //Response.Redirect("~/App/FLBM/Default.aspx");
            //    }
            //    else
            //    {
            //        KnowledgeControl1.BeginAssessment();
            //    }               
            //}
        }
    }
}