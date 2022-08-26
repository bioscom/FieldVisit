using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Drawing;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System.IO;
using System.Web.UI;

/// <summary>
/// Summary description for ExcelDataHandler
/// </summary>
public class ExcelDataHandler
{
    FunctionMgt oFunctionMgt = new FunctionMgt();

	public ExcelDataHandler()
	{
		//
		// 
		//
	}
    public bool createVsmasis(ExcelPackage oPck)
    {
        try
        {
            ExcelWorksheet oWs = oPck.Workbook.Worksheets.Add("VSM As Is");
            oWs.View.ShowGridLines = true;
            oWs.Cells[1, 1].Value = "Project Name";
            oWs.Cells[1, 2].Value = "Process LT Unit";
            oWs.Cells[1, 3].Value = "Process VAT Unit";
            oWs.Cells[1, 4].Value = "Waste Category";
            oWs.Cells[1, 5].Value = "Supplier";
            oWs.Cells[1, 6].Value = "Customer";
            oWs.Cells[1, 7].Value = "Function";
            oWs.Cells[1, 8].Value = "Activity Decsription";
            oWs.Cells[1, 9].Value = "Process LT";
            oWs.Cells[1, 10].Value = "Process VAT";
            oWs.Cells[1, 11].Value = "Process LT Minutes";
            oWs.Cells[1, 12].Value = "Process VAT Minutes";
            oWs.Cells[1, 13].Value = "Input";
            oWs.Cells[1, 14].Value = "Output";
            oWs.Cells[1, 15].Value = "Improvement";
            oWs.Cells[1, 16].Value = "Waste Code";

            oWs.Column(1).Width = 70;
            oWs.Column(2).Width = 20;
            oWs.Column(3).Width = 20;
            oWs.Column(4).Width = 10;
            oWs.Column(5).Width = 50;
            oWs.Column(6).Width = 50;
            oWs.Column(7).Width = 15;
            oWs.Column(8).Width = 80;
            oWs.Column(9).Width = 10;
            oWs.Column(10).Width = 10;
            oWs.Column(11).Width = 10;
            oWs.Column(12).Width = 10;
            oWs.Column(13).Width = 70;
            oWs.Column(14).Width = 70;
            oWs.Column(15).Width = 70;
            oWs.Column(16).Width = 10;

            //int iRet = 2;
            List<Functions> lstFunction = oFunctionMgt.lstGetFunctions();

            //foreach (corporatePriority myPriority in myPriorities)
            //{
            //    oWs.Cells[iRet, 1].Value = myPriority.priority;
            //    oWs.Cells[iRet, 2].Value = myPriority.description;
            //    iRet += 1;
            //}

            oWs.Cells[1, 1, 1, 2].Style.Fill.PatternType = ExcelFillStyle.Solid; //must set this for bgcolor
            oWs.Cells[1, 1, 1, 2].Style.Fill.BackgroundColor.SetColor(Color.PaleGreen);
            oWs.Cells[1, 1, 1, 2].Style.Font.Color.SetColor(Color.Blue);
            oWs.Cells[1, 1, 1, 2].Style.Font.Bold = true;
        }
        catch (Exception ex)
        {
            appMonitor.logAppExceptions(ex);
        }

        return true;
    }

}