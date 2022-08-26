using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class App_FlareWaiver_Facilities : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            PopulateTreeViewControl();

            rblAGG.Items.Add(new ListItem(commonEnums.yesNoDesc((commonEnums.YesNo)commonEnums.YesNo.Yes), ((int)commonEnums.YesNo.Yes).ToString()));
            rblAGG.Items.Add(new ListItem(commonEnums.yesNoDesc((commonEnums.YesNo)commonEnums.YesNo.No), ((int)commonEnums.YesNo.No).ToString()));
            rblAGG1.Items.Add(new ListItem(commonEnums.yesNoDesc((commonEnums.YesNo)commonEnums.YesNo.Yes), ((int)commonEnums.YesNo.Yes).ToString()));
            rblAGG1.Items.Add(new ListItem(commonEnums.yesNoDesc((commonEnums.YesNo)commonEnums.YesNo.No), ((int)commonEnums.YesNo.No).ToString()));
        }
    }

    private void PopulateTreeViewControl()
    {
        mnuTreeView.Nodes.Clear();
        Area oArea = new Area();
        try
        {
            TreeNode parentNode = null;
            List<Area> lstArea = Area.lstGetAreas();
            foreach (Area oF in lstArea)
            {
                parentNode = new TreeNode(oF.m_sAREA, oF.m_iIDAREA.ToString());

                List<Facility> lstFacilities = Facility.lstGetFacilitiesByArea(oF.m_iIDAREA);
                foreach (Facility oFacl in lstFacilities)
                {
                    TreeNode childNode = new TreeNode(oFacl.m_sFacility + " - " + oFacl.m_sCode + " (Has AGG? " + commonEnums.yesNoDesc((commonEnums.YesNo)oFacl.m_iAgg) + ")", oFacl.m_iFacilityId.ToString());
                    parentNode.ChildNodes.Add(childNode);

                    //List<BITeams> lstTeams = BITeams.lstGetTeamsByDepartment(oDept.m_iDepartmentId);
                    //foreach (BITeams oT in lstTeams)
                    //{
                    //    TreeNode childNodeT = new TreeNode(oT.m_sTeam, oT.m_iTeamId.ToString());
                    //    childNode.ChildNodes.Add(childNodeT);
                    //}
                }
                parentNode.Expand();
                mnuTreeView.Nodes.Add(parentNode);
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
        if (mnuTreeView.SelectedNode.Depth == 0)
        {
            lblArea.Text = mnuTreeView.SelectedNode.Text;
            pnlAdd.Visible = true;
            pnlUpdate.Visible = false;
        }
        else if (mnuTreeView.SelectedNode.Depth == 1)
        {
            lblFacility.Text = mnuTreeView.SelectedNode.Text;
            pnlUpdate.Visible = true;
            pnlAdd.Visible = false;

            Facility oF = Facility.objGetFacilityById(int.Parse(mnuTreeView.SelectedNode.Value));
            txtFacilityUpt.Text = oF.m_sFacility;
            txtCodeUpt.Text = oF.m_sCode;
            rblAGG1.SelectedValue = oF.m_iAgg.ToString();
        }

        //ResponseHelper.Redirect(mnuTreeView.SelectedNode.Value, "_blank", "menubar=1,width=700,height=500");
    }

    protected void lnkAddDepartment_Click(object sender, EventArgs e)
    {
        BIDepartments o = new BIDepartments();

        //o.m_iFunctionId = int.Parse(mnuTreeView.SelectedNode.Value);
        //o.m_sDepartment = txtDepartment.Text;

        //bool bRet = BIDepartments.AddNewDepartment(o);
        //if (bRet)
        //{
        //    ajaxWebExtension.showJscriptAlertCx(Page, this, txtDepartment.Text + " was successfully added to " + mnuTreeView.SelectedNode.Text + " business unit");
        //}
    }
    protected void lnkAddTeam_Click(object sender, EventArgs e)
    {
        BITeams o = new BITeams();

        o.m_iDepartmentId = int.Parse(mnuTreeView.SelectedNode.Value);
        //o.m_sTeam = txtTeam.Text;

        //bool bRet = BITeams.AddNewTeam(o);
        //if (bRet)
        //{
        //    ajaxWebExtension.showJscriptAlertCx(Page, this, txtTeam.Text + " was successfully added to " + mnuTreeView.SelectedNode.Text + " department");
        //}
    }
    protected void lnkAddFacility_Click(object sender, EventArgs e)
    {
        Facility o = new Facility();
        o.m_iAreaId =  int.Parse(mnuTreeView.SelectedNode.Value);
        o.m_sFacility = txtFacility.Text;
        o.m_sCode = txtCode.Text;
        o.m_iAgg = int.Parse(rblAGG.SelectedValue);

        bool bRet = Facility.AddFacility(o);
        if (bRet) ajaxWebExtension.showJscriptAlert(Page, this, "Successful!");
        PopulateTreeViewControl();
    }
    protected void lnkUpdateFacility_Click(object sender, EventArgs e)
    {
        Facility o = new Facility();
        o.m_iAreaId = int.Parse(mnuTreeView.SelectedNode.Parent.Value);
        o.m_sFacility = txtFacilityUpt.Text;
        o.m_sCode = txtCodeUpt.Text;
        o.m_iFacilityId = int.Parse(mnuTreeView.SelectedNode.Value);
        o.m_iAgg = int.Parse(rblAGG1.SelectedValue);

        bool bRet = Facility.UpdateFacility(o);
        if (bRet) ajaxWebExtension.showJscriptAlert(Page, this, "Update Successful!!!");
        PopulateTreeViewControl();
    }
}