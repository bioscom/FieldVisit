using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using System.Drawing;
using System.Data;

public partial class App_IDD_CatLead : System.Web.UI.Page
{
    EIdd.CategoryMgt o = new EIdd.CategoryMgt();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (!string.IsNullOrEmpty(Request.QueryString["iCategoryId"].ToString()))
            {
                int categoryId = int.Parse(Request.QueryString["iCategoryId"].ToString());

                lblCategory.Text = o.objGetServiceByServiceId(categoryId).m_sCategory;
            }
        }
    }

    protected void ddlCategoryLead_ItemsRequested(object sender, RadComboBoxItemsRequestedEventArgs e)
    {
        EIdd.Utilities.Search(e.Text, ddlCategoryLead);
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(Request.QueryString["iCategoryId"].ToString()))
        {
            int categoryId = int.Parse(Request.QueryString["iCategoryId"].ToString());

            bool bRet = o.AssignCategoryLeadToCategory(int.Parse(ddlCategoryLead.SelectedValue), categoryId);
            if (bRet) { ajaxWebExtension.showJscriptAlertCx(Page, this, "Category Lead successfully added!!!"); }
        }
    }
}