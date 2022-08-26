using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Drawing;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System.IO;
using System.Web.UI;

public class WorkDone
{
    public string sFunction { get; set; }
    public int iEliminate { get; set; }
    public int iIdentify { get; set; }
    public int iSustain { get; set; }
    public int TotalProjects { get; set; }
    
	public WorkDone()
	{
		//
		// 
		//
	}

    public WorkDone(DataRow dr)
    {
        sFunction = dr["FUNCTION"].ToString();
        iEliminate = int.Parse(dr["ELIMINATE"].ToString());
        iIdentify = int.Parse(dr["IDENTIFY"].ToString());
        iSustain = int.Parse(dr["SUSTAIN"].ToString());
        TotalProjects = int.Parse(dr["TOTALPROJINHOPPER"].ToString());
    }
}

public class ProjectMaturationPhase
{
    public long lProjectId { get; set; }
    public string sFunction { get; set; }
    public string sProject { get; set; }
    public int iYear { get; set; }
        
    public ProjectMaturationPhase()
    {

    }

    public ProjectMaturationPhase(DataRow dr)
    {
        lProjectId = long.Parse(dr["IDPROJECT"].ToString());
        sFunction = dr["FUNCTION"].ToString();
        sProject = dr["TITLE"].ToString();
        iYear = int.Parse(dr["YYEAR"].ToString());
    }
}

public class ExportDashBoardData
{
    MainProjectHelper oMainProjectHelper = new MainProjectHelper();
    BenefitActualsHelper oBenefitActualsHelper = new BenefitActualsHelper();
    IdentifyHelper oIdentifyHelper = new IdentifyHelper();
    EliminateHelper oEliminateHelper = new EliminateHelper();
    SustainHelper oSustainHelper = new SustainHelper();
    FunctionMgt oFunctionMgt = new FunctionMgt();

    public void ExportProjectsWorkDoneByFunction(ExcelPackage oPck, int iYear)
    {
        ExcelWorksheet oWs = oPck.Workbook.Worksheets.Add("Project Work Done");
        oWs.View.ShowGridLines = true;
        oWs.Cells[1, 1].Value = "Functions";
        oWs.Cells[1, 2].Value = "Identify";
        oWs.Cells[1, 3].Value = "Eliminate";
        oWs.Cells[1, 4].Value = "Sustain";
        oWs.Cells[1, 5].Value = "Total No of Projects";

        oWs.Column(1).Width = 25;
        oWs.Column(2).Width = 10;
        oWs.Column(3).Width = 10;
        oWs.Column(4).Width = 10;
        oWs.Column(5).Width = 20;

        int iRet = 2;
        List<WorkDone> sWorkDone = oMainProjectHelper.lstWorkDone(iYear);
        foreach (WorkDone oWorkDone in sWorkDone)
        {
            oWs.Cells[iRet, 1].Value = oWorkDone.sFunction;
            oWs.Cells[iRet, 2].Value = oWorkDone.iIdentify;
            oWs.Cells[iRet, 3].Value = oWorkDone.iEliminate;
            oWs.Cells[iRet, 4].Value = oWorkDone.iSustain;
            oWs.Cells[iRet, 5].Value = oWorkDone.TotalProjects;
            iRet += 1;
        }

        oWs.Cells[1, 1, 1, 5].Style.Fill.PatternType = ExcelFillStyle.Solid; //must set this for bgcolor
        oWs.Cells[1, 1, 1, 5].Style.Fill.BackgroundColor.SetColor(Color.PaleGreen);
        oWs.Cells[1, 1, 1, 5].Style.Font.Color.SetColor(Color.Blue);
        oWs.Cells[1, 1, 1, 5].Style.Font.Bold = true;
    }
    public void ExportProjectsMaturationPhase(ExcelPackage oPck, int iYear)
    {
        ExcelWorksheet oWs = oPck.Workbook.Worksheets.Add("Project Status - % Workdone CI Project Maturation Phase");
        oWs.View.ShowGridLines = true;
        oWs.Cells[1, 1].Value = "Projects";
        oWs.Cells[1, 2].Value = "Function";
        oWs.Cells[1, 3].Value = "Year";
        oWs.Cells[1, 4].Value = "Identify";
        oWs.Cells[1, 5].Value = "Eliminate";
        oWs.Cells[1, 6].Value = "Sustain";

        oWs.Column(1).Width = 25;
        oWs.Column(2).Width = 10;
        oWs.Column(3).Width = 10;
        oWs.Column(4).Width = 10;
        oWs.Column(5).Width = 20;
        oWs.Column(6).Width = 20;

        DataTable dt = oMainProjectHelper.dtGetFunctionWorkDoneByYear(iYear);

        int iRet = 2;
        List<ProjectMaturationPhase> sProjectMaturationPhase = oMainProjectHelper.lstProjectMaturationPhase(iYear);
        foreach (ProjectMaturationPhase oProjectMaturationPhase in sProjectMaturationPhase)
        {
            oWs.Cells[iRet, 1].Value = oProjectMaturationPhase.sProject;
            oWs.Cells[iRet, 2].Value = oProjectMaturationPhase.sFunction;
            oWs.Cells[iRet, 3].Value = oProjectMaturationPhase.iYear;
            oWs.Cells[iRet, 4].Value = oIdentifyHelper.IdentifyWorkDoneByProjectYear(oProjectMaturationPhase.lProjectId, iYear);
            oWs.Cells[iRet, 5].Value = oEliminateHelper.EliminateWorkDoneByProjectYear(oProjectMaturationPhase.lProjectId, iYear);
            oWs.Cells[iRet, 6].Value = oSustainHelper.SustainWorkDoneByProjectYear(oProjectMaturationPhase.lProjectId, iYear);
            iRet += 1;            
        }

        oWs.Cells[1, 1, 1, 6].Style.Fill.PatternType = ExcelFillStyle.Solid; //must set this for bgcolor
        oWs.Cells[1, 1, 1, 6].Style.Fill.BackgroundColor.SetColor(Color.PaleGreen);
        oWs.Cells[1, 1, 1, 6].Style.Font.Color.SetColor(Color.Blue);
        oWs.Cells[1, 1, 1, 6].Style.Font.Bold = true;
    }
    public void ExportBenefit(ExcelPackage oPck)
    {
        try
        {
            ExcelWorksheet oWs = oPck.Workbook.Worksheets.Add("Benefit");
            oWs.View.ShowGridLines = true;
            oWs.Cells[1, 1].Value = "Year";
            oWs.Cells[1, 2].Value = "Cost Reduction ($)";
            oWs.Cells[1, 3].Value = "Cycle Time(Days)";
            oWs.Cells[1, 4].Value = "Number*";
            oWs.Cells[1, 5].Value = "No of Projects";

            oWs.Column(1).Width = 10;
            oWs.Column(2).Width = 20;
            oWs.Column(3).Width = 20;
            oWs.Column(4).Width = 10;
            oWs.Column(5).Width = 20;

            DataTable dt = oMainProjectHelper.dtGetYear();
            int iRet = 2;
            foreach (DataRow dr in dt.Rows)
            {
                int iYear = int.Parse(dr["YYEAR"].ToString());

                oWs.Cells[iRet, 1].Value = iYear;
                oWs.Cells[iRet, 2].Value = oMainProjectHelper.iTotalCostReductionPerYear(iYear).ToString();
                oWs.Cells[iRet, 3].Value = oMainProjectHelper.iTotalCycleTimeReductionPerYear(iYear).ToString();
                oWs.Cells[iRet, 4].Value = oMainProjectHelper.iNumberofProductionBarrelPerYear(iYear).ToString();
                oWs.Cells[iRet, 5].Value = oMainProjectHelper.iTotalProjectsByYear(iYear).ToString();
                iRet += 1;
            }

            oWs.Cells[1, 1, 1, 5].Style.Fill.PatternType = ExcelFillStyle.Solid; //must set this for bgcolor
            oWs.Cells[1, 1, 1, 5].Style.Fill.BackgroundColor.SetColor(Color.PaleGreen);
            oWs.Cells[1, 1, 1, 5].Style.Font.Color.SetColor(Color.Blue);
            oWs.Cells[1, 1, 1, 5].Style.Font.Bold = true;
        }
        catch (Exception ex)
        {
            appMonitor.logAppExceptions(ex);
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }
    }
    public void ExportCompletedOngoingProjects(ExcelPackage oPck, int iYear)
    {
        int iTotalProjects = 0;
        int iTotalCompletedProjects = 0;
        int iTotalOngoingStalledProjects = 0;

        decimal iTotalActualCostReduction = 0;
        decimal iTotalActualCycleTime = 0;
        decimal iTotalActualBarrel = 0;

        decimal iTotalPotentialCostReduction = 0;
        decimal iTotalPotentialCycleTime = 0;
        decimal iTotalPotentialBarrel = 0;

        FunctionMgt oFunctionMgt = new FunctionMgt();

        ExcelWorksheet oWs = oPck.Workbook.Worksheets.Add("Completed and Ongoing Projects");
        oWs.View.ShowGridLines = true;

        oWs.Cells[1, 3, 1, 5].Style.Fill.PatternType = ExcelFillStyle.Solid;
        oWs.Cells[1, 3, 1, 5].Style.Fill.BackgroundColor.SetColor(Color.Yellow);
        oWs.Cells[1, 4].Value = "Actual Benefits";

        oWs.Cells[1, 7, 1, 9].Style.Fill.PatternType = ExcelFillStyle.Solid;
        oWs.Cells[1, 7, 1, 9].Style.Fill.BackgroundColor.SetColor(Color.Yellow);
        oWs.Cells[1, 8].Value = "Potential Benefits";

        oWs.Cells[2, 1].Value = "Functions";
        oWs.Cells[2, 2].Value = "Completed";

        oWs.Cells[2, 3].Value = "Cost Reduction($1,000,000)";
        oWs.Cells[2, 4].Value = "Cycle Time";
        oWs.Cells[2, 5].Value = "Barrel";

        oWs.Cells[2, 6].Value = "Ongoing";

        oWs.Cells[2, 7].Value = "Cost Reduction($1,000,000)";
        oWs.Cells[2, 8].Value = "Cycle Time";
        oWs.Cells[2, 9].Value = "Barrel";
        oWs.Cells[2, 10].Value = "Total No of Projects";

        oWs.Column(1).Width = 25;
        oWs.Column(2).Width = 12;

        oWs.Column(3).Width = 20;
        oWs.Column(4).Width = 15;
        oWs.Column(5).Width = 10;

        oWs.Column(6).Width = 10;

        oWs.Column(7).Width = 20;
        oWs.Column(8).Width = 15;
        oWs.Column(9).Width = 10;

        oWs.Column(10).Width = 20;

        DataTable dt = oMainProjectHelper.dtGetProjectFunctions(iYear);

        int iRet = 3;
        foreach (DataRow dr in dt.Rows)
        {
            int iFunctionId = int.Parse(dr["FUNCTIONID"].ToString());

            MainProjectHelper.CompletedOngoingProjects oCompletedOngoingProjects = oMainProjectHelper.objGetCompletedAndOngoingProjects(iYear, iFunctionId);

            oWs.Cells[iRet, 1].Value = oFunctionMgt.objGetFunctionById(iFunctionId).m_sFunction;
            oWs.Cells[iRet, 2].Value = oCompletedOngoingProjects.iCompleted;

            oWs.Cells[iRet, 3].Value = oCompletedOngoingProjects.dActualBenefitCR / 1000000;
            oWs.Cells[iRet, 4].Value = oCompletedOngoingProjects.dActualBenefitCT;
            oWs.Cells[iRet, 5].Value = oCompletedOngoingProjects.dActualBenefitBRRL;

            oWs.Cells[iRet, 6].Value = oCompletedOngoingProjects.iOngoingStalled;

            oWs.Cells[iRet, 7].Value = oCompletedOngoingProjects.dPotentialBenefitCR / 1000000;
            oWs.Cells[iRet, 8].Value = oCompletedOngoingProjects.dPotentialBenefitCT;
            oWs.Cells[iRet, 9].Value = oCompletedOngoingProjects.dPotentialBenefitBRRL;

            oWs.Cells[iRet, 10].Value = oCompletedOngoingProjects.iTotalProjects;

            iTotalCompletedProjects += oCompletedOngoingProjects.iCompleted;
            iTotalOngoingStalledProjects += oCompletedOngoingProjects.iOngoingStalled;
            iTotalProjects += oCompletedOngoingProjects.iTotalProjects;

            iTotalActualCostReduction += oCompletedOngoingProjects.dActualBenefitCR;
            iTotalActualCycleTime += oCompletedOngoingProjects.dActualBenefitCT;
            iTotalActualBarrel += oCompletedOngoingProjects.dActualBenefitBRRL;

            iTotalPotentialCostReduction += oCompletedOngoingProjects.dPotentialBenefitCR;
            iTotalPotentialCycleTime += oCompletedOngoingProjects.dPotentialBenefitCT;
            iTotalPotentialBarrel += oCompletedOngoingProjects.dPotentialBenefitBRRL;

            iRet += 1;
        }

        oWs.Cells[2, 1, 2, 10].Style.Fill.PatternType = ExcelFillStyle.Solid; //must set this for bgcolor
        oWs.Cells[2, 1, 2, 10].Style.Fill.BackgroundColor.SetColor(Color.PaleGreen);
        oWs.Cells[2, 1, 2, 10].Style.Font.Color.SetColor(Color.Blue);
        oWs.Cells[2, 1, 2, 10].Style.Font.Bold = true;

        //iRet += 1;
        oWs.Cells[iRet, 1].Value = "Total";
        oWs.Cells[iRet, 2].Value = iTotalCompletedProjects;

        oWs.Cells[iRet, 3].Value = iTotalActualCostReduction / 1000000;
        oWs.Cells[iRet, 4].Value = iTotalActualCycleTime;
        oWs.Cells[iRet, 5].Value = iTotalActualBarrel;

        oWs.Cells[iRet, 6].Value = iTotalOngoingStalledProjects;

        oWs.Cells[iRet, 7].Value = iTotalPotentialCostReduction / 1000000;
        oWs.Cells[iRet, 8].Value = iTotalPotentialCycleTime;
        oWs.Cells[iRet, 9].Value = iTotalPotentialBarrel;

        oWs.Cells[iRet, 10].Value = iTotalProjects;

        oWs.Cells[iRet, 1, iRet, 10].Style.Fill.PatternType = ExcelFillStyle.Solid; //must set this for bgcolor
        oWs.Cells[iRet, 1, iRet, 10].Style.Fill.BackgroundColor.SetColor(Color.PaleGreen);
        oWs.Cells[iRet, 1, iRet, 10].Style.Font.Color.SetColor(Color.Blue);
        oWs.Cells[iRet, 1, iRet, 10].Style.Font.Bold = true;
    }
    public void ExportProjectsBenefit(ExcelPackage oPck, int iYear)
    {
        ExcelWorksheet oWs = oPck.Workbook.Worksheets.Add("Projects and Benetifs - " + iYear);
        oWs.View.ShowGridLines = true;
        oWs.Cells[1, 1].Value = "Project";
        oWs.Cells[1, 2].Value = "Year";
        oWs.Cells[1, 3].Value = "Cycle Time Savings";
        oWs.Cells[1, 4].Value = "Cost Savings";
        oWs.Cells[1, 5].Value = "Prod. Barrel";
        oWs.Cells[1, 6].Value = "Comments";

        oWs.Column(1).Width = 25;
        oWs.Column(2).Width = 10;
        oWs.Column(3).Width = 10;
        oWs.Column(4).Width = 10;
        oWs.Column(5).Width = 20;
        oWs.Column(6).Width = 50;

        int iRet = 2;
        List<BenefitActuals> lstBenefitActuals = oBenefitActualsHelper.lstGetProjectBenefitsByYear(iYear);
        foreach (BenefitActuals oBenefitActuals in lstBenefitActuals)
        {
            oWs.Cells[iRet, 1].Value = oMainProjectHelper.objGetLeanProjectsByProjectId(oBenefitActuals.lProjectId).sTitle;
            oWs.Cells[iRet, 2].Value = iYear;
            oWs.Cells[iRet, 3].Value = oBenefitActuals.sCTSavings;
            oWs.Cells[iRet, 4].Value = oBenefitActuals.sCostSavings;
            oWs.Cells[iRet, 5].Value = oBenefitActuals.sProductionBarrel;
            oWs.Cells[iRet, 6].Value = oBenefitActuals.sComments;
            iRet += 1;
        }

        oWs.Cells[1, 1, 1, 6].Style.Fill.PatternType = ExcelFillStyle.Solid; //must set this for bgcolor
        oWs.Cells[1, 1, 1, 6].Style.Fill.BackgroundColor.SetColor(Color.PaleGreen);
        oWs.Cells[1, 1, 1, 6].Style.Font.Color.SetColor(Color.Blue);
        oWs.Cells[1, 1, 1, 6].Style.Font.Bold = true;
    }
    public string ByteToString(byte[] HighLight)
    {
        string sWklyHighlight = "";

        if (HighLight != null)
        {
            MemoryStream stream = new MemoryStream(HighLight);
            StreamReader reader = new StreamReader(stream);
            sWklyHighlight = reader.ReadToEnd();
        }

        return sWklyHighlight;
    }
}
