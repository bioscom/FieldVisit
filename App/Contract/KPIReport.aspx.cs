using System;

public partial class App_Contract_KPIReport : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            KPIReport1.TripStartDate.setDate(DateTime.Parse(Request.QueryString["dt"]).ToString("dd/MM/yyyy"));
            KPIReport1.TripStartDate.ImageBtn.Enabled = false;
            KPIReport1.TripStartDate.txtDateTextBox.Enabled = false;

            WhatWhyConsequences1.TripStartDate.setDate(DateTime.Parse(Request.QueryString["dt"]).ToString("dd/MM/yyyy"));
            WhatWhyConsequences1.TripStartDate.ImageBtn.Enabled = false;
            WhatWhyConsequences1.TripStartDate.txtDateTextBox.Enabled = false;

            KPIReport1.LoadData();
            WhatWhyConsequences1.LoadDataLessonLearnt();
        }
    }
}