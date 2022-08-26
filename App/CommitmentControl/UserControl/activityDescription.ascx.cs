using System;
using System.Web.UI.WebControls;
using System.Data;

public partial class App_BONGACCP_UserControl_activityDescription : System.Web.UI.UserControl
{
    ActivityDetailsMgt dtlMgt = new ActivityDetailsMgt();

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    public void LoadDetails(long lCommitmentId)
    {
        DataTable dt = dtlMgt.dtGetCommitmentDetailsByCommitmentId(lCommitmentId);
        if (dt.Rows.Count > 0)
        {
            detailsGrdView.DataSource = dt;
            detailsGrdView.DataBind();
        }
        else
        {
            detailsGrdView.DataSource = null;
            detailsGrdView.DataBind();
        }
    }


    decimal sumFooterTotalAmount = 0; decimal sumFooterTotalRate = 0; decimal sumFooterTotalQty = 0; decimal tTotal = 0;
    protected void detailsGrdView_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            decimal Quantity = string.IsNullOrEmpty(((Label) e.Row.FindControl("lblQuantity")).Text) ? 0 :  Convert.ToDecimal(((Label) e.Row.FindControl("lblQuantity")).Text);
            decimal Rate = string.IsNullOrEmpty(((Label) e.Row.FindControl("lblRate")).Text) ? 0 : Convert.ToDecimal(((Label) e.Row.FindControl("lblRate")).Text);
            Label Amount = ((Label) e.Row.FindControl("lblAmount"));
            tTotal = Quantity * Rate;
            Amount.Text = stringRoutine.formatAsBankMoney(tTotal);

            sumFooterTotalAmount += tTotal;
        }

        if (e.Row.RowType == DataControlRowType.Footer)
        {
            Label lblTotalAmount = (Label) e.Row.FindControl("lblTotal");
            lblTotalAmount.Text = stringRoutine.formatAsBankMoney(sumFooterTotalAmount);
        }
    }
}