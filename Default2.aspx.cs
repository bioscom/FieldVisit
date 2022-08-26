using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Default2 : System.Web.UI.Page
{
    Search obj = new Search();
    readonly OpportunityCostHelper _opportunityCostHelper = new OpportunityCostHelper();
    protected void Page_Load(object sender, EventArgs e)
    {
        DataTable dt = _opportunityCostHelper.dtGetStories();

        //DataSet ds1 = obj.GetRecord();
        string s1;
        s1 = "<table>";
        string sAMount = "";

        foreach (DataRow dr in dt.Rows)
        {
            sAMount = !string.IsNullOrEmpty(dr["AMTSAVED"].ToString()) ? stringRoutine.formatAsBankMoney(decimal.Parse(dr["AMTSAVED"].ToString())) : "";
            s1 += "<tr>";
            s1 += "<td>";
            s1 += "<strong><a href=Somepage.aspx style=font-family: fantasy; font-size: large; font-weight:bold; font-style: normal; color: Yellow>" + dr["TITLE"].ToString() + "</a></strong>";
            s1 += "<strong><font color='Red'>    Amount Saved: $ " + sAMount + "</font></strong>";
            s1 += "<br/>"; s1 += "<br/>";
            s1 += dr["STORY"].ToString();
            s1 += "<br/>";
            s1 += "</td>";
            s1 += "</tr>";
        }

        s1 += "</table>";
        //lt1.Text = s1.ToString();
        //lt2.Text = s1.ToString();
    }
}