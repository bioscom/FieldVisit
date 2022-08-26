using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class App_Lean_UserControl_BenefitPotential : System.Web.UI.UserControl
{
    public void Init_Control(long lRecommendationId)
    {
        RecommendationId.Value = lRecommendationId.ToString();
        LoadPotentialBenefits(lRecommendationId);
    }

    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        long lRecommendationId = long.Parse(RecommendationId.Value);
        if ((PotentialId.Value == null) || (PotentialId.Value == ""))
        {
            //Insert
            LoadPotentialBenefits(lRecommendationId);
        }
        else
        {
            //Update
            LoadPotentialBenefits(lRecommendationId);
        }
    }

    public void LoadPotentialBenefits(long lRecommendationId)
    {

    }
}