using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class App_FLBM_UserControl_CompetenceControl : System.Web.UI.UserControl
{
    Group oGroup = new Group();
    Competencies oCompetencies = new Competencies();
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            //Load Groups
            var LstGroups = oGroup.LstGroups();
            foreach (Group lstGroup in LstGroups)
            {
                ddlGroup.Items.Add(new ListItem(lstGroup.sGroups, lstGroup.iGroupId.ToString()));
            }

            PopulateTreeViewControl();
        }
    }

    //public void Page_Init()
    //{
        
    //}

    private void PopulateTreeViewControl()
    {
        Group oGroup = new Group();
        Competencies oCompetencies = new Competencies();
        try
        {
            TreeNode parentNode = null;
            List<Group> lstGrops = oGroup.LstGroups();
            

            foreach (Group group in lstGrops)
            {
                parentNode = new TreeNode(group.sGroups, group.iGroupId.ToString());

                List<Competencies> lstCompetencies = oCompetencies.LstCompetenciesByGroup(group.iGroupId);
                foreach (Competencies oCompetency in lstCompetencies)
                {
                    TreeNode childNode = new TreeNode(oCompetency.sCompetence, oCompetency.sUrl);
                    parentNode.ChildNodes.Add(childNode);
                }

                parentNode.Collapse();
                mnuTreeView.Nodes.Add(parentNode);
            }
        }
        catch (Exception ex)
        {
            appMonitor.logAppExceptions(ex);
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }
    }

    protected void mnuTreeView_SelectedNodeChanged(object sender, EventArgs e)
    {
        ResponseHelper.Redirect(mnuTreeView.SelectedNode.Value, "_blank", "menubar=1,width=700,height=500");
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        oCompetencies.iGroupId = int.Parse(ddlGroup.SelectedValue);
        oCompetencies.sCompetence = txtCompetence.Text;
        oCompetencies.sCompetenceDescription = txtDescription.Text;
        oCompetencies.sUrl = txtUrl.Text;

        bool bRet = oCompetencies.CreateCompetence(oCompetencies);
        if(bRet)
        {
            mnuTreeView.Nodes.Clear();
            PopulateTreeViewControl();
            ajaxWebExtension.showJscriptAlert(Page, this, "Competence Successfully added to, " + ddlGroup.SelectedItem.Text + "group.");
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