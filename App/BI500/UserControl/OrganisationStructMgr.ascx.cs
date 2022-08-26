using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


public partial class App_BI500_UserControl_OrganisationStructMgr : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    public void Init_Page()
    {
        PopulateTreeViewControl();
    }
    private void PopulateTreeViewControl()
    {
        FunctionMgt oFun = new FunctionMgt();
        try
        {
            TreeNode parentNode = null;
            List<Functions> lstFunc = oFun.lstGetFunctions();
            foreach (Functions oF in lstFunc)
            {
                if (oF.m_sFunction.ToUpper() != "N/A".ToUpper())
                {
                    parentNode = new TreeNode(oF.m_sFunction, oF.m_iFunctionId.ToString());

                    List<BIDepartments> lstDepartments = BIDepartments.lstGetDeparmentsByFunction(oF.m_iFunctionId);
                    foreach (BIDepartments oDept in lstDepartments)
                    {
                        TreeNode childNode = new TreeNode(oDept.m_sDepartment, oDept.m_iDepartmentId.ToString());
                        parentNode.ChildNodes.Add(childNode);

                        List<BITeams> lstTeams = BITeams.lstGetTeamsByDepartment(oDept.m_iDepartmentId);
                        foreach (BITeams oT in lstTeams)
                        {
                            TreeNode childNodeT = new TreeNode(oT.m_sTeam, oT.m_iTeamId.ToString());
                            childNode.ChildNodes.Add(childNodeT);
                        }
                    }

                    parentNode.Collapse();
                    mnuTreeView.Nodes.Add(parentNode);
                }
            }
        }
        catch (Exception ex)
        {
            //appMonitor.logAppExceptions(ex);
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }
    }
    protected void mnuTreeView_SelectedNodeChanged(object sender, EventArgs e)
    {
        if(mnuTreeView.SelectedNode.Depth == 0)
        {
            lblBusinessUnit.Text = mnuTreeView.SelectedNode.Text;
            pnlDepartment.Visible = true;
            pnlTeam.Visible = false;
        }
        else if (mnuTreeView.SelectedNode.Depth == 1)
        {
            lblDepartment.Text = mnuTreeView.SelectedNode.Text;
            pnlTeam.Visible = true;
            pnlDepartment.Visible = false;
        }
        
        //ResponseHelper.Redirect(mnuTreeView.SelectedNode.Value, "_blank", "menubar=1,width=700,height=500");
    }
    
    protected void lnkAddDepartment_Click(object sender, EventArgs e)
    {
        BIDepartments o = new BIDepartments();

        o.m_iFunctionId = int.Parse(mnuTreeView.SelectedNode.Value);
        o.m_sDepartment = txtDepartment.Text;

        bool bRet = BIDepartments.AddNewDepartment(o);
        if (bRet)
        {
            ajaxWebExtension.showJscriptAlertCx(Page, this, txtDepartment.Text + " was successfully added to " + mnuTreeView.SelectedNode.Text + " business unit");
        }
    }
    protected void lnkAddTeam_Click(object sender, EventArgs e)
    {
        BITeams o = new BITeams();

        o.m_iDepartmentId = int.Parse(mnuTreeView.SelectedNode.Value);
        o.m_sTeam = txtTeam.Text;

        bool bRet = BITeams.AddNewTeam(o);
        if (bRet)
        {
            ajaxWebExtension.showJscriptAlertCx(Page, this, txtTeam.Text + " was successfully added to " + mnuTreeView.SelectedNode.Text + " department");
        }
    }
}


public static class ResponseHelper
{
    public static void Redirect(string url, string target, string windowFeatures)
    {
        HttpContext context = HttpContext.Current;

        if ((String.IsNullOrEmpty(target) || target.Equals("_self", StringComparison.OrdinalIgnoreCase)) && String.IsNullOrEmpty(windowFeatures))
        {

            context.Response.Redirect(url);
        }
        else
        {
            Page page = (Page)context.Handler;
            if (page == null)
            {
                throw new InvalidOperationException("Cannot redirect to new window outside Page context.");
            }
            url = page.ResolveClientUrl(url);

            string script;
            if (!String.IsNullOrEmpty(windowFeatures))
            {
                script = @"window.open(""{0}"", ""{1}"", ""{2}"");";
            }
            else
            {
                script = @"window.open(""{0}"", ""{1}"");";
            }

            script = String.Format(script, url, target, windowFeatures);
            ScriptManager.RegisterStartupScript(page, typeof(Page), "Redirect", script, true);
        }
    }
}