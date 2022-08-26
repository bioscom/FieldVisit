using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

public partial class App_Prices_ReviewStatus : System.Web.UI.Page
{
    //string PreviewPath = "\\app\\FieldVisit\\App\\Prices\\";
    string PreviewPath = "/App/Prices/RedFlag/";
    string DestinationPath = "../Prices/RedFlag/";

    protected void Page_Load(object sender, EventArgs e)
    {
        LoadRecord();
    }

    private void LoadRecord()
    {
        long lPriceId = long.Parse(Request.QueryString["lPriceId"]);

        dtlView.DataSource = PriceHelper.dtGetPriceById(lPriceId);
        dtlView.DataBind();

        PreviewLoadedFile(PriceHelper.objGetPriceById(lPriceId));

        //PriceReviewerHelper.FormatReport(dtlView);
    }

    private void PreviewLoadedFile(byte[] o)
    {
        if (o != null)
        {
            string sFinalPath = DestinationPath + "Price.pdf";
            File.WriteAllBytes(sFinalPath, o);
            fileLoader.Attributes["src"] = "Price.pdf";
        }
        else
        {
            fileLoader.Attributes["src"] = "";
        }
    }

    private void PreviewLoadedFile(Price o)
    {
        if (o != null)
        {
            string sFinalPath = HttpContext.Current.Server.MapPath(DestinationPath + o.sFileName);
            if (o.bBlob != null)
            {
                File.WriteAllBytes(sFinalPath, o.bBlob);
                fileLoader.Attributes["src"] = PreviewPath + o.sFileName;

                OpenPDFHyperLink.NavigateUrl = PreviewPath + o.sFileName;
            }
        }
        else
        {
            fileLoader.Attributes["src"] = "";
        }
    }
}