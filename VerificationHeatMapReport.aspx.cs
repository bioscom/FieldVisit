using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class VerificationHeatMapReport : aspnetPage
{
    //Set Colours
    string styleRed = "style='background-color:RED; padding: 5px;text-align: center;vertical-align: middle;'";
    string styleBronze = "style='background-color:#965A38; padding: 5px;text-align: center;vertical-align: middle;'"; //BRONZE
    string styleSilver = "style='background-color:#A8A8A8; padding: 5px;text-align: center;vertical-align: middle;'";
    string styleGold = "style='background-color:#C98910; padding: 5px;text-align: center;vertical-align: middle;'";
    string styleNV = "style='background-color:Transparent; padding: 5px;text-align: center;vertical-align: middle;'";

    //string verticalText = "style ='text-align: center;vertical-align: middle;padding-top: 10px;white-space: nowrap;-webkit-transform: rotate(-90deg);  -moz-transform: rotate(-90deg);'";
    string verticalText = "style ='text-align:center;vertical-align: middle;width: 100px; height:120px; margin: 0px;font:bold; padding: 0px;padding-left: 3px;padding-right: 3px;padding-top: 10px;-webkit-transform: rotate(-90deg);  -moz-transform: rotate(-90deg);'";
    string style5 = "style ='font-size:16.0pt; text-align: center;vertical-align: middle;font:bold; margin: 0px;padding: 0px;padding-left: 3px;padding-right: 3px;padding-top: 10px;'";
    string textAlignment = "style='padding: 5px;text-align: left;vertical-align: middle;font:bold'";

    string styleDistrict = "style='background-color:#87CEEB; padding: 5px;text-align: left; vertical-align: middle;font:bold'"; //skyblue 
    string styleFacilities = "style='background-color:#FFB6C1; padding: 5px;text-align: left; vertical-align: middle;font:bold'"; //skyblue 


    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            btnUpdate.Visible = false;
            LoadYear();
            cVerificationHeatMapHelper.getMonths(ddlMonth);
            cVerificationHeatMapHelper.getMonths(ddlMonthTo);

            //get into the PROD_VERIFICATION table, look for the higest two years and higest months
            int i = 0;
            List<VerificationYearMonth> YearMonths = cVerificationHeatMapHelper.lstGetVerification();
            foreach (VerificationYearMonth oYearMonth in YearMonths)
            {
                if (i == 0)
                {
                    ddlMonthTo.SelectedValue = oYearMonth.iMonth.ToString();
                    ddlYearTo.SelectedValue = oYearMonth.iYear.ToString();
                }
                else
                {
                    ddlMonth.SelectedValue = oYearMonth.iMonth.ToString();
                    ddlYear.SelectedValue = oYearMonth.iYear.ToString();
                }
                i++;
                if (i > 1) break;
            }

            LoadReport();

            if(oSessnx.getOnlineUser.m_iRoleIdFieldVisit == (int) appUsersRoles.userRole.admin)
            {
                btnUpdate.Visible = true;
            }
        }
        //Response.Redirect("~/VerificationHeatMapReport.aspx?iMnt=" + ddlMonth.SelectedValue + "&iYr=" + ddlYear.SelectedValue);
    }

    protected void btnFilter_Click(object sender, EventArgs e)
    {
        LoadReport();
    }

    private void LoadReport()
    {
        List<cVerificationHeatMap> lstVerification = cVerificationHeatMapHelper.lstGetVerificationByMonthYear(int.Parse(ddlMonth.SelectedValue), int.Parse(ddlYear.SelectedValue));
        RenderToPage(lstVerification);
    }

    protected void btnExport_Click(object sender, EventArgs e)
    {
        List<cVerificationHeatMap> lstVerification = cVerificationHeatMapHelper.lstGetVerificationByMonthYear(int.Parse(ddlMonth.SelectedValue), int.Parse(ddlYear.SelectedValue));
        ExporttoExcel(lstVerification);

        //List<NTR> oNTR = oNtrHelper.lstReportNtrByMonthYear(ddlMonth.SelectedItem.Text, int.Parse(ddlYear.SelectedValue));
        //List<NTR> oNTRWithAction = oNtrHelper.lstGetNtrByMonthYearWithActions(ddlMonth.SelectedItem.Text, int.Parse(ddlYear.SelectedValue));
        //ExporttoExcel(oNTR, oNTRWithAction);
    }

    private void RenderToPage(List<cVerificationHeatMap> lstVerification)
    {
        System.Text.StringBuilder sb = new System.Text.StringBuilder();

        sb.Append(@"<!DOCTYPE HTML PUBLIC ""-//W3C//DTD HTML 4.0 Transitional//EN"">");
        //sets font
        sb.Append("<font style='font-size:12.0pt; font-family:Calibri;'>");
        //sb.Append("<BR><BR><BR>");
        //sets the table border, cell spacing, border color, font of the text, background, foreground, font height
        sb.Append("<Table border='1' " +
          "borderColor='#eee' cellSpacing='0' cellPadding='0' " +
          "style='font-size:12.0pt; font-family:Calibri; background:white;'> " +
          "<tr><td colspan='12'></td></tr>" +
          "<tr style='font-size:18.0pt'><td colspan='12'><b>RPI VERIFICATION HEAT MAP</b></td></tr>" +
          "<tr><td colspan='12'></td></tr>" +
          "<TR>");

        sb.Append("<tr>");

        sb.Append("<td colspan='4'>");
        sb.Append("");
        sb.Append("</td>");

        sb.Append("<td colspan='4'>");
        sb.Append(mMonthEnuem.getMonth(int.Parse(ddlMonth.SelectedValue)) + " - " + mMonthEnuem.getMonth(int.Parse(ddlMonth.SelectedValue) + 2) + " " + ddlYear.SelectedValue);
        sb.Append("</td>");

        sb.Append("<td colspan='4'>");
        sb.Append(mMonthEnuem.getMonth(int.Parse(ddlMonthTo.SelectedValue)) + " - " + mMonthEnuem.getMonth(int.Parse(ddlMonthTo.SelectedValue) + 2) + " " + ddlYearTo.SelectedValue);
        sb.Append("</td>");

        sb.Append("</tr>");


        sb.Append("<tr>");
        
        sb.Append("<td colspan='4'>");
        sb.Append("<div " + style5 + ">");
        sb.Append("RPI VERIFICATION");
        sb.Append("</div>");
        sb.Append("</td>");

        sb.Append("<td>");
        sb.Append("<div " + verticalText + ">");
        sb.Append("STANDARDISED WORK");
        sb.Append("</div>");
        sb.Append("</td>");

        sb.Append("<td>");
        sb.Append("<div " + verticalText + ">");
        sb.Append("GO SEE");
        sb.Append("</div>");
        sb.Append("</td>");

        sb.Append("<td>");
        sb.Append("<div " + verticalText + ">");
        sb.Append("STRUCTURED DAY");
        sb.Append("</div>");
        sb.Append("</td>");

        sb.Append("<td>");
        sb.Append("<div " + verticalText + ">");
        sb.Append("MAINTENANCE CONSUMABLES");
        sb.Append("</div>");
        sb.Append("</td>");

        sb.Append("<td>");
        sb.Append("<div " + verticalText + ">");
        sb.Append("STANDARDISED WORK");
        sb.Append("</div>");
        sb.Append("</td>");

        sb.Append("<td>");
        sb.Append("<div " + verticalText + ">");
        sb.Append("GO SEE");
        sb.Append("</div>");
        sb.Append("</td>");

        sb.Append("<td>");
        sb.Append("<div " + verticalText + ">");
        sb.Append("STRUCTURED DAY");
        sb.Append("</div>");
        sb.Append("</td>");

        sb.Append("<td>");
        sb.Append("<div " + verticalText + ">");
        sb.Append("MAINTENANCE CONSUMABLES");
        sb.Append("</div>");
        sb.Append("</td>");

        sb.Append("</tr>");


        sb.Append("<tr>");

        sb.Append("<td style='width:120px'>");
        sb.Append("<div " + textAlignment + ">");
        sb.Append("ASSETS");
        sb.Append("</div>");
        sb.Append("</td>");

        sb.Append("<td>");
        sb.Append("<div " + styleDistrict + ">");
        sb.Append("DISTRICTS");
        sb.Append("</div>");
        sb.Append("</td>");

        sb.Append("<td>");
        sb.Append("<div " + styleFacilities + ">");
        sb.Append("FACILITIES");
        sb.Append("</div>");
        sb.Append("</td>");

        sb.Append("<td>");
        sb.Append("<div " + textAlignment + ">");
        sb.Append("TYPE");
        sb.Append("</div>");
        sb.Append("</td>");

        sb.Append("<td colspan='4'>");
        sb.Append("");
        sb.Append("</td>");

        sb.Append("<td colspan='4'>");
        sb.Append("");
        sb.Append("</td>");

        sb.Append("</tr>");

        sb.Append("</TR>");

        List<Assets> lstAssets = Assets.lstGetAssets();
        foreach (Assets oAsset in lstAssets)
        {
            //write in new row
            sb.Append("<TR>");

            sb.Append("<Td colspan='12'>");
            sb.Append("<div " + textAlignment + ">");
            sb.Append(oAsset.sAsset);
            sb.Append("</div>");
            sb.Append("</Td>");

            sb.Append("</TR>");

            //List<cVerificationHeatMap> lstVerificationByAssetTo = cVerificationHeatMapHelper.lstGetVerificationByMonthYearAsset(int.Parse(ddlMonthTo.SelectedValue), int.Parse(ddlYearTo.SelectedValue), oAsset.iAssetId);
            List<cVerificationHeatMap> lstVerificationByAsset = cVerificationHeatMapHelper.lstGetVerificationByMonthYearAsset(int.Parse(ddlMonth.SelectedValue), int.Parse(ddlYear.SelectedValue), oAsset.iAssetId);
            foreach (cVerificationHeatMap oVerified in lstVerificationByAsset)
            {
                cVerificationHeatMap tVerification = cVerificationHeatMapHelper.objGetVerificationByMonthYear(oVerified.iFacilityId, int.Parse(ddlMonthTo.SelectedValue), int.Parse(ddlYearTo.SelectedValue));

                string StandardisedWorkStyle = ""; string GoSeeStyle = ""; string StructuredDayStyle = ""; string MtceConsumablesStyle = "";
                string tStandardisedWorkStyle = styleNV; string tGoSeeStyle = styleNV; string tStructuredDayStyle = styleNV; string tMtceConsumablesStyle = styleNV;

                if (oVerified.iStandardisedWork == (int)mVerificationEnuem.mVerification.Red) StandardisedWorkStyle = styleRed;
                else if (oVerified.iStandardisedWork == (int)mVerificationEnuem.mVerification.Bronze) StandardisedWorkStyle = styleBronze;
                else if (oVerified.iStandardisedWork == (int)mVerificationEnuem.mVerification.Silver) StandardisedWorkStyle = styleSilver;
                else if (oVerified.iStandardisedWork == (int)mVerificationEnuem.mVerification.Gold) StandardisedWorkStyle = styleGold;
                else if (oVerified.iStandardisedWork == (int)mVerificationEnuem.mVerification.NV) StandardisedWorkStyle = styleNV;
                else if (oVerified.iStandardisedWork == (int)mVerificationEnuem.mVerification.NA) StandardisedWorkStyle = styleNV;

                if (oVerified.iGoSee == (int)mVerificationEnuem.mVerification.Red) GoSeeStyle = styleRed;
                else if (oVerified.iGoSee == (int)mVerificationEnuem.mVerification.Bronze) GoSeeStyle = styleBronze;
                else if (oVerified.iGoSee == (int)mVerificationEnuem.mVerification.Silver) GoSeeStyle = styleSilver;
                else if (oVerified.iGoSee == (int)mVerificationEnuem.mVerification.Gold) GoSeeStyle = styleGold;
                else if (oVerified.iGoSee == (int)mVerificationEnuem.mVerification.NV) GoSeeStyle = styleNV;
                else if (oVerified.iGoSee == (int)mVerificationEnuem.mVerification.NA) GoSeeStyle = styleNV;

                if (oVerified.iStructuredDay == (int)mVerificationEnuem.mVerification.Red) StructuredDayStyle = styleRed;
                else if (oVerified.iStructuredDay == (int)mVerificationEnuem.mVerification.Bronze) StructuredDayStyle = styleBronze;
                else if (oVerified.iStructuredDay == (int)mVerificationEnuem.mVerification.Silver) StructuredDayStyle = styleSilver;
                else if (oVerified.iStructuredDay == (int)mVerificationEnuem.mVerification.Gold) StructuredDayStyle = styleGold;
                else if (oVerified.iStructuredDay == (int)mVerificationEnuem.mVerification.NV) StructuredDayStyle = styleNV;
                else if (oVerified.iStructuredDay == (int)mVerificationEnuem.mVerification.NA) StructuredDayStyle = styleNV;

                if (oVerified.iMtceConsumables == (int)mVerificationEnuem.mVerification.Red) MtceConsumablesStyle = styleRed;
                else if (oVerified.iMtceConsumables == (int)mVerificationEnuem.mVerification.Bronze) MtceConsumablesStyle = styleBronze;
                else if (oVerified.iMtceConsumables == (int)mVerificationEnuem.mVerification.Silver) MtceConsumablesStyle = styleSilver;
                else if (oVerified.iMtceConsumables == (int)mVerificationEnuem.mVerification.Gold) MtceConsumablesStyle = styleGold;
                else if (oVerified.iMtceConsumables == (int)mVerificationEnuem.mVerification.NV) MtceConsumablesStyle = styleNV;
                else if (oVerified.iMtceConsumables == (int)mVerificationEnuem.mVerification.NA) MtceConsumablesStyle = styleNV;


                if (tVerification.iStandardisedWork == (int)mVerificationEnuem.mVerification.Red) tStandardisedWorkStyle = styleRed;
                else if (tVerification.iStandardisedWork == (int)mVerificationEnuem.mVerification.Bronze) tStandardisedWorkStyle = styleBronze;
                else if (tVerification.iStandardisedWork == (int)mVerificationEnuem.mVerification.Silver) tStandardisedWorkStyle = styleSilver;
                else if (tVerification.iStandardisedWork == (int)mVerificationEnuem.mVerification.Gold) tStandardisedWorkStyle = styleGold;
                else if (tVerification.iStandardisedWork == (int)mVerificationEnuem.mVerification.NV) tStandardisedWorkStyle = styleNV;
                else if (tVerification.iStandardisedWork == (int)mVerificationEnuem.mVerification.NA) tStandardisedWorkStyle = styleNV;

                if (tVerification.iGoSee == (int)mVerificationEnuem.mVerification.Red) tGoSeeStyle = styleRed;
                else if (tVerification.iGoSee == (int)mVerificationEnuem.mVerification.Bronze) tGoSeeStyle = styleBronze;
                else if (tVerification.iGoSee == (int)mVerificationEnuem.mVerification.Silver) tGoSeeStyle = styleSilver;
                else if (tVerification.iGoSee == (int)mVerificationEnuem.mVerification.Gold) tGoSeeStyle = styleGold;
                else if (tVerification.iGoSee == (int)mVerificationEnuem.mVerification.NV) tGoSeeStyle = styleNV;
                else if (tVerification.iGoSee == (int)mVerificationEnuem.mVerification.NA) tGoSeeStyle = styleNV;

                if (tVerification.iStructuredDay == (int)mVerificationEnuem.mVerification.Red) tStructuredDayStyle = styleRed;
                else if (tVerification.iStructuredDay == (int)mVerificationEnuem.mVerification.Bronze) tStructuredDayStyle = styleBronze;
                else if (tVerification.iStructuredDay == (int)mVerificationEnuem.mVerification.Silver) tStructuredDayStyle = styleSilver;
                else if (tVerification.iStructuredDay == (int)mVerificationEnuem.mVerification.Gold) tStructuredDayStyle = styleGold;
                else if (tVerification.iStructuredDay == (int)mVerificationEnuem.mVerification.NV) tStructuredDayStyle = styleNV;
                else if (tVerification.iStructuredDay == (int)mVerificationEnuem.mVerification.NA) tStructuredDayStyle = styleNV;

                if (tVerification.iMtceConsumables == (int)mVerificationEnuem.mVerification.Red) tMtceConsumablesStyle = styleRed;
                else if (tVerification.iMtceConsumables == (int)mVerificationEnuem.mVerification.Bronze) tMtceConsumablesStyle = styleBronze;
                else if (tVerification.iMtceConsumables == (int)mVerificationEnuem.mVerification.Silver) tMtceConsumablesStyle = styleSilver;
                else if (tVerification.iMtceConsumables == (int)mVerificationEnuem.mVerification.Gold) tMtceConsumablesStyle = styleGold;
                else if (tVerification.iMtceConsumables == (int)mVerificationEnuem.mVerification.NV) tMtceConsumablesStyle = styleNV;
                else if (tVerification.iMtceConsumables == (int)mVerificationEnuem.mVerification.NA) tMtceConsumablesStyle = styleNV;


                sb.Append("<TR>");
                sb.Append("<Td>");
                //sb.Append("<div " + textAlignment + ">");
                //sb.Append(oAsset.sAsset);
                //sb.Append("</div>");
                sb.Append("</Td>");

                sb.Append("<Td>");
                sb.Append("<div " + styleDistrict + ">");
                sb.Append(oVerified.sDistricts);
                sb.Append("</div>");
                sb.Append("</Td>");

                sb.Append("<Td>");
                sb.Append("<div " + styleFacilities + ">");
                sb.Append(oVerified.sFacilities);
                sb.Append("</div>");
                sb.Append("</Td>");

                string[] sType = oVerified.sFacilities.Split(' ');
                int iRet = sType.Length;

                sb.Append("<Td>");
                if (iRet == 1) sb.Append("");
                else sb.Append(sType[iRet - 1].ToString());
                sb.Append("</Td>");


                sb.Append("<Td " + StandardisedWorkStyle + ">");
                sb.Append(mVerificationEnuem.VerificationDesc((mVerificationEnuem.mVerification)oVerified.iStandardisedWork));
                sb.Append("</Td>");
                
                sb.Append("<Td " + GoSeeStyle + ">");
                sb.Append(mVerificationEnuem.VerificationDesc((mVerificationEnuem.mVerification)oVerified.iGoSee));
                sb.Append("</Td>");
                
                sb.Append("<Td " + StructuredDayStyle + ">");
                sb.Append(mVerificationEnuem.VerificationDesc((mVerificationEnuem.mVerification)oVerified.iStructuredDay));
                sb.Append("</Td>");

                sb.Append("<Td " + MtceConsumablesStyle + ">");
                sb.Append(mVerificationEnuem.VerificationDesc((mVerificationEnuem.mVerification)oVerified.iMtceConsumables));
                sb.Append("</Td>");
                


                sb.Append("<Td " + tStandardisedWorkStyle + ">");
                sb.Append(mVerificationEnuem.VerificationDesc((mVerificationEnuem.mVerification)tVerification.iStandardisedWork));
                sb.Append("</Td>");

                sb.Append("<Td " + tGoSeeStyle + ">");
                sb.Append(mVerificationEnuem.VerificationDesc((mVerificationEnuem.mVerification)tVerification.iGoSee));
                sb.Append("</Td>");

                sb.Append("<Td " + tStructuredDayStyle + ">");
                sb.Append(mVerificationEnuem.VerificationDesc((mVerificationEnuem.mVerification)tVerification.iStructuredDay));
                sb.Append("</Td>");

                sb.Append("<Td " + tMtceConsumablesStyle + ">");
                sb.Append(mVerificationEnuem.VerificationDesc((mVerificationEnuem.mVerification)tVerification.iMtceConsumables));
                sb.Append("</Td>");

                sb.Append("</TR>");
            }
        }

        sb.Append("<tr>");

        sb.Append("<td colspan='5'>");
        sb.Append("LEGEND");
        sb.Append("</td>");

        sb.Append("</tr>");

        sb.Append("<tr>");

        sb.Append("<td " + styleRed + ">");
        sb.Append("Red");
        sb.Append("</td>");

        sb.Append("<td colspan='4'>");
        sb.Append("Basics not in Place");
        sb.Append("</td>");

        sb.Append("</tr>");

        sb.Append("<tr>");

        sb.Append("<td " + styleBronze + ">");
        sb.Append("Bronze");
        sb.Append("</td>");

        sb.Append("<td colspan='4'>");
        sb.Append("Basics in Place");
        sb.Append("</td>");

        sb.Append("</tr>");

        sb.Append("<tr>");

        sb.Append("<td " + styleSilver + ">");
        sb.Append("Silver");
        sb.Append("</td>");

        sb.Append("<td colspan='4'>");
        sb.Append("Basics in Place and Process is Running");
        sb.Append("</td>");

        sb.Append("</tr>");

        sb.Append("<tr>");

        sb.Append("<td " + styleGold + ">");
        sb.Append("Gold");
        sb.Append("</td>");

        sb.Append("<td colspan='4'>");
        sb.Append("Basics in Place, Process is Running and Sustained");
        sb.Append("</td>");

        sb.Append("</tr>");

        sb.Append("<tr>");

        sb.Append("<td " + styleNV + ">");
        sb.Append("NV");
        sb.Append("</td>");

        sb.Append("<td colspan='4'>");
        sb.Append("Not Verified");
        sb.Append("</td>");

        sb.Append("</tr>");

        sb.Append("<tr>");

        sb.Append("<td " + styleNV + ">");
        sb.Append("NA");
        sb.Append("</td>");

        sb.Append("<td colspan='4'>");
        sb.Append("Not Applicable");
        sb.Append("</td>");

        sb.Append("</tr>");

        sb.Append("</Table>");

        //Get the actions
        //sb.Append("<br>");

        sb.Append("</font>");

        ViewLiteral.Text = sb.ToString();
    }

    private void ExporttoExcel(List<cVerificationHeatMap> lstVerification)
    {
        HttpContext.Current.Response.Clear();
        HttpContext.Current.Response.ClearContent();
        HttpContext.Current.Response.ClearHeaders();
        HttpContext.Current.Response.Buffer = true;
        HttpContext.Current.Response.ContentType = "application/ms-excel";
        HttpContext.Current.Response.Write(@"<!DOCTYPE HTML PUBLIC ""-//W3C//DTD HTML 4.0 Transitional//EN"">");
        HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment;filename=Reports.xls");

        HttpContext.Current.Response.Charset = "utf-8";
        HttpContext.Current.Response.ContentEncoding = System.Text.Encoding.GetEncoding("windows-1250");
        //sets font
        HttpContext.Current.Response.Write("<font style='font-size:12.0pt; font-family:Calibri;'>");
        HttpContext.Current.Response.Write("<BR><BR><BR>");

        HttpContext.Current.Response.Write("<Table border='1' " +
          "borderColor='#eee' cellSpacing='0' cellPadding='0' " +
          "style='font-size:12.0pt; font-family:Calibri; background:white;'> " +
          "<tr><td colspan='12'></td></tr>" +
          "<tr style='font-size:18.0pt'><td colspan='12'><b>RPI VERIFICATION HEAT MAP</b></td></tr>"
          //"<tr><td colspan='12'></td></tr>" +
          //"<TR>"
          );

        HttpContext.Current.Response.Write("<tr>");

        HttpContext.Current.Response.Write("<td colspan='4'>");
        HttpContext.Current.Response.Write("");
        HttpContext.Current.Response.Write("</td>");

        HttpContext.Current.Response.Write("<td colspan='4'>");
        HttpContext.Current.Response.Write(mMonthEnuem.getMonth(int.Parse(ddlMonth.SelectedValue)) + " - " + mMonthEnuem.getMonth(int.Parse(ddlMonth.SelectedValue) + 2) + " " + ddlYear.SelectedValue);
        HttpContext.Current.Response.Write("</td>");

        HttpContext.Current.Response.Write("<td colspan='4'>");
        HttpContext.Current.Response.Write(mMonthEnuem.getMonth(int.Parse(ddlMonthTo.SelectedValue)) + " - " + mMonthEnuem.getMonth(int.Parse(ddlMonthTo.SelectedValue) + 2) + " " + ddlYearTo.SelectedValue);
        HttpContext.Current.Response.Write("</td>");

        HttpContext.Current.Response.Write("</tr>");


        HttpContext.Current.Response.Write("<tr>");

        HttpContext.Current.Response.Write("<td colspan='4'>");
        HttpContext.Current.Response.Write("<div " + style5 + ">");
        HttpContext.Current.Response.Write("RPI VERIFICATION");
        HttpContext.Current.Response.Write("</div>");
        HttpContext.Current.Response.Write("</td>");

        HttpContext.Current.Response.Write("<td " + verticalText + ">");
        HttpContext.Current.Response.Write("<div>");
        HttpContext.Current.Response.Write("STANDARDISED WORK");
        HttpContext.Current.Response.Write("</div>");
        HttpContext.Current.Response.Write("</td>");

        HttpContext.Current.Response.Write("<td " + verticalText + ">");
        HttpContext.Current.Response.Write("<div>");
        HttpContext.Current.Response.Write("GO SEE");
        HttpContext.Current.Response.Write("</div>");
        HttpContext.Current.Response.Write("</td>");

        HttpContext.Current.Response.Write("<td " + verticalText + ">");
        HttpContext.Current.Response.Write("<div>");
        HttpContext.Current.Response.Write("STRUCTURED DAY");
        HttpContext.Current.Response.Write("</div>");
        HttpContext.Current.Response.Write("</td>");

        HttpContext.Current.Response.Write("<td " + verticalText + ">");
        HttpContext.Current.Response.Write("<div>");
        HttpContext.Current.Response.Write("MAINTENANCE CONSUMABLES");
        HttpContext.Current.Response.Write("</div>");
        HttpContext.Current.Response.Write("</td>");

        HttpContext.Current.Response.Write("<td " + verticalText + ">");
        HttpContext.Current.Response.Write("<div>");
        HttpContext.Current.Response.Write("STANDARDISED WORK");
        HttpContext.Current.Response.Write("</div>");
        HttpContext.Current.Response.Write("</td>");

        HttpContext.Current.Response.Write("<td " + verticalText + ">");
        HttpContext.Current.Response.Write("<div>");
        HttpContext.Current.Response.Write("GO SEE");
        HttpContext.Current.Response.Write("</div>");
        HttpContext.Current.Response.Write("</td>");

        HttpContext.Current.Response.Write("<td " + verticalText + ">");
        HttpContext.Current.Response.Write("<div>");
        HttpContext.Current.Response.Write("STRUCTURED DAY");
        HttpContext.Current.Response.Write("</div>");
        HttpContext.Current.Response.Write("</td>");

        HttpContext.Current.Response.Write("<td " + verticalText + ">");
        HttpContext.Current.Response.Write("<div>");
        HttpContext.Current.Response.Write("MAINTENANCE CONSUMABLES");
        HttpContext.Current.Response.Write("</div>");
        HttpContext.Current.Response.Write("</td>");

        HttpContext.Current.Response.Write("</tr>");


        HttpContext.Current.Response.Write("<tr>");

        HttpContext.Current.Response.Write("<td style='width:120px'>");
        HttpContext.Current.Response.Write("<div " + textAlignment + ">");
        HttpContext.Current.Response.Write("ASSETS");
        HttpContext.Current.Response.Write("</div>");
        HttpContext.Current.Response.Write("</td>");

        HttpContext.Current.Response.Write("<td>");
        HttpContext.Current.Response.Write("<div " + styleDistrict + ">");
        HttpContext.Current.Response.Write("DISTRICTS");
        HttpContext.Current.Response.Write("</div>");
        HttpContext.Current.Response.Write("</td>");

        HttpContext.Current.Response.Write("<td>");
        HttpContext.Current.Response.Write("<div " + styleFacilities + ">");
        HttpContext.Current.Response.Write("FACILITIES");
        HttpContext.Current.Response.Write("</div>");
        HttpContext.Current.Response.Write("</td>");

        HttpContext.Current.Response.Write("<td>");
        HttpContext.Current.Response.Write("<div " + textAlignment + ">");
        HttpContext.Current.Response.Write("TYPE");
        HttpContext.Current.Response.Write("</div>");
        HttpContext.Current.Response.Write("</td>");

        HttpContext.Current.Response.Write("<td colspan='4'>");
        HttpContext.Current.Response.Write("");
        HttpContext.Current.Response.Write("</td>");

        HttpContext.Current.Response.Write("<td colspan='4'>");
        HttpContext.Current.Response.Write("");
        HttpContext.Current.Response.Write("</td>");

        HttpContext.Current.Response.Write("</tr>");

        HttpContext.Current.Response.Write("</TR>");

        List<Assets> lstAssets = Assets.lstGetAssets();
        foreach (Assets oAsset in lstAssets)
        {
            //write in new row
            HttpContext.Current.Response.Write("<TR>");

            HttpContext.Current.Response.Write("<Td colspan='12'>");
            HttpContext.Current.Response.Write("<div " + textAlignment + ">");
            HttpContext.Current.Response.Write(oAsset.sAsset);
            HttpContext.Current.Response.Write("</div>");
            HttpContext.Current.Response.Write("</Td>");

            HttpContext.Current.Response.Write("</TR>");

            //List<cVerificationHeatMap> lstVerificationByAssetTo = cVerificationHeatMapHelper.lstGetVerificationByMonthYearAsset(int.Parse(ddlMonthTo.SelectedValue), int.Parse(ddlYearTo.SelectedValue), oAsset.iAssetId);
            List<cVerificationHeatMap> lstVerificationByAsset = cVerificationHeatMapHelper.lstGetVerificationByMonthYearAsset(int.Parse(ddlMonth.SelectedValue), int.Parse(ddlYear.SelectedValue), oAsset.iAssetId);
            foreach (cVerificationHeatMap oVerified in lstVerificationByAsset)
            {
                cVerificationHeatMap tVerification = cVerificationHeatMapHelper.objGetVerificationByMonthYear(oVerified.iFacilityId, int.Parse(ddlMonthTo.SelectedValue), int.Parse(ddlYearTo.SelectedValue));

                string StandardisedWorkStyle = ""; string GoSeeStyle = ""; string StructuredDayStyle = ""; string MtceConsumablesStyle = "";
                string tStandardisedWorkStyle = styleNV; string tGoSeeStyle = styleNV; string tStructuredDayStyle = styleNV; string tMtceConsumablesStyle = styleNV;

                if (oVerified.iStandardisedWork == (int)mVerificationEnuem.mVerification.Red) StandardisedWorkStyle = styleRed;
                else if (oVerified.iStandardisedWork == (int)mVerificationEnuem.mVerification.Bronze) StandardisedWorkStyle = styleBronze;
                else if (oVerified.iStandardisedWork == (int)mVerificationEnuem.mVerification.Silver) StandardisedWorkStyle = styleSilver;
                else if (oVerified.iStandardisedWork == (int)mVerificationEnuem.mVerification.Gold) StandardisedWorkStyle = styleGold;
                else if (oVerified.iStandardisedWork == (int)mVerificationEnuem.mVerification.NV) StandardisedWorkStyle = styleNV;
                else if (oVerified.iStandardisedWork == (int)mVerificationEnuem.mVerification.NA) StandardisedWorkStyle = styleNV;

                if (oVerified.iGoSee == (int)mVerificationEnuem.mVerification.Red) GoSeeStyle = styleRed;
                else if (oVerified.iGoSee == (int)mVerificationEnuem.mVerification.Bronze) GoSeeStyle = styleBronze;
                else if (oVerified.iGoSee == (int)mVerificationEnuem.mVerification.Silver) GoSeeStyle = styleSilver;
                else if (oVerified.iGoSee == (int)mVerificationEnuem.mVerification.Gold) GoSeeStyle = styleGold;
                else if (oVerified.iGoSee == (int)mVerificationEnuem.mVerification.NV) GoSeeStyle = styleNV;
                else if (oVerified.iGoSee == (int)mVerificationEnuem.mVerification.NA) GoSeeStyle = styleNV;

                if (oVerified.iStructuredDay == (int)mVerificationEnuem.mVerification.Red) StructuredDayStyle = styleRed;
                else if (oVerified.iStructuredDay == (int)mVerificationEnuem.mVerification.Bronze) StructuredDayStyle = styleBronze;
                else if (oVerified.iStructuredDay == (int)mVerificationEnuem.mVerification.Silver) StructuredDayStyle = styleSilver;
                else if (oVerified.iStructuredDay == (int)mVerificationEnuem.mVerification.Gold) StructuredDayStyle = styleGold;
                else if (oVerified.iStructuredDay == (int)mVerificationEnuem.mVerification.NV) StructuredDayStyle = styleNV;
                else if (oVerified.iStructuredDay == (int)mVerificationEnuem.mVerification.NA) StructuredDayStyle = styleNV;

                if (oVerified.iMtceConsumables == (int)mVerificationEnuem.mVerification.Red) MtceConsumablesStyle = styleRed;
                else if (oVerified.iMtceConsumables == (int)mVerificationEnuem.mVerification.Bronze) MtceConsumablesStyle = styleBronze;
                else if (oVerified.iMtceConsumables == (int)mVerificationEnuem.mVerification.Silver) MtceConsumablesStyle = styleSilver;
                else if (oVerified.iMtceConsumables == (int)mVerificationEnuem.mVerification.Gold) MtceConsumablesStyle = styleGold;
                else if (oVerified.iMtceConsumables == (int)mVerificationEnuem.mVerification.NV) MtceConsumablesStyle = styleNV;
                else if (oVerified.iMtceConsumables == (int)mVerificationEnuem.mVerification.NA) MtceConsumablesStyle = styleNV;


                if (tVerification.iStandardisedWork == (int)mVerificationEnuem.mVerification.Red) tStandardisedWorkStyle = styleRed;
                else if (tVerification.iStandardisedWork == (int)mVerificationEnuem.mVerification.Bronze) tStandardisedWorkStyle = styleBronze;
                else if (tVerification.iStandardisedWork == (int)mVerificationEnuem.mVerification.Silver) tStandardisedWorkStyle = styleSilver;
                else if (tVerification.iStandardisedWork == (int)mVerificationEnuem.mVerification.Gold) tStandardisedWorkStyle = styleGold;
                else if (tVerification.iStandardisedWork == (int)mVerificationEnuem.mVerification.NV) tStandardisedWorkStyle = styleNV;
                else if (tVerification.iStandardisedWork == (int)mVerificationEnuem.mVerification.NA) tStandardisedWorkStyle = styleNV;

                if (tVerification.iGoSee == (int)mVerificationEnuem.mVerification.Red) tGoSeeStyle = styleRed;
                else if (tVerification.iGoSee == (int)mVerificationEnuem.mVerification.Bronze) tGoSeeStyle = styleBronze;
                else if (tVerification.iGoSee == (int)mVerificationEnuem.mVerification.Silver) tGoSeeStyle = styleSilver;
                else if (tVerification.iGoSee == (int)mVerificationEnuem.mVerification.Gold) tGoSeeStyle = styleGold;
                else if (tVerification.iGoSee == (int)mVerificationEnuem.mVerification.NV) tGoSeeStyle = styleNV;
                else if (tVerification.iGoSee == (int)mVerificationEnuem.mVerification.NA) tGoSeeStyle = styleNV;

                if (tVerification.iStructuredDay == (int)mVerificationEnuem.mVerification.Red) tStructuredDayStyle = styleRed;
                else if (tVerification.iStructuredDay == (int)mVerificationEnuem.mVerification.Bronze) tStructuredDayStyle = styleBronze;
                else if (tVerification.iStructuredDay == (int)mVerificationEnuem.mVerification.Silver) tStructuredDayStyle = styleSilver;
                else if (tVerification.iStructuredDay == (int)mVerificationEnuem.mVerification.Gold) tStructuredDayStyle = styleGold;
                else if (tVerification.iStructuredDay == (int)mVerificationEnuem.mVerification.NV) tStructuredDayStyle = styleNV;
                else if (tVerification.iStructuredDay == (int)mVerificationEnuem.mVerification.NA) tStructuredDayStyle = styleNV;

                if (tVerification.iMtceConsumables == (int)mVerificationEnuem.mVerification.Red) tMtceConsumablesStyle = styleRed;
                else if (tVerification.iMtceConsumables == (int)mVerificationEnuem.mVerification.Bronze) tMtceConsumablesStyle = styleBronze;
                else if (tVerification.iMtceConsumables == (int)mVerificationEnuem.mVerification.Silver) tMtceConsumablesStyle = styleSilver;
                else if (tVerification.iMtceConsumables == (int)mVerificationEnuem.mVerification.Gold) tMtceConsumablesStyle = styleGold;
                else if (tVerification.iMtceConsumables == (int)mVerificationEnuem.mVerification.NV) tMtceConsumablesStyle = styleNV;
                else if (tVerification.iMtceConsumables == (int)mVerificationEnuem.mVerification.NA) tMtceConsumablesStyle = styleNV;


                HttpContext.Current.Response.Write("<TR>");
                HttpContext.Current.Response.Write("<Td>");
                //HttpContext.Current.Response.Write("<div " + textAlignment + ">");
                //HttpContext.Current.Response.Write(oAsset.sAsset);
                //HttpContext.Current.Response.Write("</div>");
                HttpContext.Current.Response.Write("</Td>");

                HttpContext.Current.Response.Write("<Td " + styleDistrict + ">");
                HttpContext.Current.Response.Write("<div>");
                HttpContext.Current.Response.Write(oVerified.sDistricts);
                HttpContext.Current.Response.Write("</div>");
                HttpContext.Current.Response.Write("</Td>");

                HttpContext.Current.Response.Write("<Td " + styleFacilities + ">");
                HttpContext.Current.Response.Write("<div>");
                HttpContext.Current.Response.Write(oVerified.sFacilities);
                HttpContext.Current.Response.Write("</div>");
                HttpContext.Current.Response.Write("</Td>");

                string[] sType = oVerified.sFacilities.Split(' ');
                int iRet = sType.Length;

                HttpContext.Current.Response.Write("<Td>");
                if (iRet == 1) HttpContext.Current.Response.Write("");
                else HttpContext.Current.Response.Write(sType[iRet - 1].ToString());
                HttpContext.Current.Response.Write("</Td>");


                HttpContext.Current.Response.Write("<Td " + StandardisedWorkStyle + ">");
                HttpContext.Current.Response.Write(mVerificationEnuem.VerificationDesc((mVerificationEnuem.mVerification)oVerified.iStandardisedWork));
                HttpContext.Current.Response.Write("</Td>");

                HttpContext.Current.Response.Write("<Td " + GoSeeStyle + ">");
                HttpContext.Current.Response.Write(mVerificationEnuem.VerificationDesc((mVerificationEnuem.mVerification)oVerified.iGoSee));
                HttpContext.Current.Response.Write("</Td>");

                HttpContext.Current.Response.Write("<Td " + StructuredDayStyle + ">");
                HttpContext.Current.Response.Write(mVerificationEnuem.VerificationDesc((mVerificationEnuem.mVerification)oVerified.iStructuredDay));
                HttpContext.Current.Response.Write("</Td>");

                HttpContext.Current.Response.Write("<Td " + MtceConsumablesStyle + ">");
                HttpContext.Current.Response.Write(mVerificationEnuem.VerificationDesc((mVerificationEnuem.mVerification)oVerified.iMtceConsumables));
                HttpContext.Current.Response.Write("</Td>");



                HttpContext.Current.Response.Write("<Td " + tStandardisedWorkStyle + ">");
                HttpContext.Current.Response.Write(mVerificationEnuem.VerificationDesc((mVerificationEnuem.mVerification)tVerification.iStandardisedWork));
                HttpContext.Current.Response.Write("</Td>");

                HttpContext.Current.Response.Write("<Td " + tGoSeeStyle + ">");
                HttpContext.Current.Response.Write(mVerificationEnuem.VerificationDesc((mVerificationEnuem.mVerification)tVerification.iGoSee));
                HttpContext.Current.Response.Write("</Td>");

                HttpContext.Current.Response.Write("<Td " + tStructuredDayStyle + ">");
                HttpContext.Current.Response.Write(mVerificationEnuem.VerificationDesc((mVerificationEnuem.mVerification)tVerification.iStructuredDay));
                HttpContext.Current.Response.Write("</Td>");

                HttpContext.Current.Response.Write("<Td " + tMtceConsumablesStyle + ">");
                HttpContext.Current.Response.Write(mVerificationEnuem.VerificationDesc((mVerificationEnuem.mVerification)tVerification.iMtceConsumables));
                HttpContext.Current.Response.Write("</Td>");

                HttpContext.Current.Response.Write("</TR>");
            }
        }

        HttpContext.Current.Response.Write("<tr>");

        HttpContext.Current.Response.Write("<td colspan='5'>");
        HttpContext.Current.Response.Write("LEGEND");
        HttpContext.Current.Response.Write("</td>");

        HttpContext.Current.Response.Write("</tr>");

        HttpContext.Current.Response.Write("<tr>");

        HttpContext.Current.Response.Write("<td " + styleRed + ">");
        HttpContext.Current.Response.Write("Red");
        HttpContext.Current.Response.Write("</td>");

        HttpContext.Current.Response.Write("<td colspan='4'>");
        HttpContext.Current.Response.Write("Basics not in Place");
        HttpContext.Current.Response.Write("</td>");

        HttpContext.Current.Response.Write("</tr>");

        HttpContext.Current.Response.Write("<tr>");

        HttpContext.Current.Response.Write("<td " + styleBronze + ">");
        HttpContext.Current.Response.Write("Bronze");
        HttpContext.Current.Response.Write("</td>");

        HttpContext.Current.Response.Write("<td colspan='4'>");
        HttpContext.Current.Response.Write("Basics in Place");
        HttpContext.Current.Response.Write("</td>");

        HttpContext.Current.Response.Write("</tr>");

        HttpContext.Current.Response.Write("<tr>");

        HttpContext.Current.Response.Write("<td " + styleSilver + ">");
        HttpContext.Current.Response.Write("Silver");
        HttpContext.Current.Response.Write("</td>");

        HttpContext.Current.Response.Write("<td colspan='4'>");
        HttpContext.Current.Response.Write("Basics in Place and Process is Running");
        HttpContext.Current.Response.Write("</td>");

        HttpContext.Current.Response.Write("</tr>");

        HttpContext.Current.Response.Write("<tr>");

        HttpContext.Current.Response.Write("<td " + styleGold + ">");
        HttpContext.Current.Response.Write("Gold");
        HttpContext.Current.Response.Write("</td>");

        HttpContext.Current.Response.Write("<td colspan='4'>");
        HttpContext.Current.Response.Write("Basics in Place, Process is Running and Sustained");
        HttpContext.Current.Response.Write("</td>");

        HttpContext.Current.Response.Write("</tr>");

        HttpContext.Current.Response.Write("<tr>");

        HttpContext.Current.Response.Write("<td " + styleNV + ">");
        HttpContext.Current.Response.Write("NV");
        HttpContext.Current.Response.Write("</td>");

        HttpContext.Current.Response.Write("<td colspan='4'>");
        HttpContext.Current.Response.Write("Not Verified");
        HttpContext.Current.Response.Write("</td>");

        HttpContext.Current.Response.Write("</tr>");

        HttpContext.Current.Response.Write("<tr>");

        HttpContext.Current.Response.Write("<td " + styleNV + ">");
        HttpContext.Current.Response.Write("NA");
        HttpContext.Current.Response.Write("</td>");

        HttpContext.Current.Response.Write("<td colspan='4'>");
        HttpContext.Current.Response.Write("Not Applicable");
        HttpContext.Current.Response.Write("</td>");

        HttpContext.Current.Response.Write("</tr>");

        HttpContext.Current.Response.Write("</Table>");

        //Get the actions
        //HttpContext.Current.Response.Write("<br>");

        HttpContext.Current.Response.Write("</font>");
        HttpContext.Current.Response.Flush();
        HttpContext.Current.Response.End();
    }

    private void LoadYear()
    {
        List<int> iYears = cVerificationHeatMapHelper.lstYears();
        foreach (int iYear in iYears)
        {
            ddlYear.Items.Add(iYear.ToString());
            ddlYearTo.Items.Add(iYear.ToString());
        }
    }

    
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/VerificationHeatMap.aspx");
    }
}