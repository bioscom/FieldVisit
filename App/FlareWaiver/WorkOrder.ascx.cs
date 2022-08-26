using System;
using System.Web.UI.WebControls;

public partial class UserControl_WorkOrder : System.Web.UI.UserControl
{
    ViewFile oViewFile = new ViewFile();

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    public void InitWorkOrder()
    {
        
    }

    public void LoadFileFromWorkOrder(string sFileName)
    {
        oViewFile.LoadFileFromWorkOrder(sFileName);
        workOrderFileNameHF.Value = sFileName;
        fileLoader.Attributes["src"] = "WorkOrder.pdf";
    }

    public HiddenField WorkOrderFileName
    {
        get
        {
            return workOrderFileNameHF;
        }
    }
}