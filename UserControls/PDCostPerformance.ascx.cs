using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UserControl_PDCostPerformance : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }

    protected void Page_Init(object sender, EventArgs e)
    {
        Department _oDepartment = new Department();

        //Repeater1.DataSource = _oDepartment.dtGetPdccDeparments();
        //Repeater1.DataBind();

        list.DataSource = _oDepartment.dtGetPdccDeparments();
        list.DataBind();
    }
    protected void list_ItemDataBound(object sender, DataListItemEventArgs e)
    {

    }
}