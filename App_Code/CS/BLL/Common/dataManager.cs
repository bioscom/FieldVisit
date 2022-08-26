using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.IO;
using Microsoft.VisualBasic;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System.Drawing;

public class dataManager
{
    public const short c_dbDefaultNumb = 0;
    //private bool bDisposed = false;    //' Field to handle multiple calls to Dispose gracefully.        

    //public const string c_dbDefaultText = "N=N?";
    //public const string c_sItemSpliter = "__";
    //public const byte c_xItemSplitex = 3;

    public struct dbItemErrorList
    {
        public string sErrorList; //Errors Found
        public int iItems; //No of Items found
    }

    public struct dbReMapItem
    {
        public string sItem;
        public long lItem;
        public int iItem;
    }

    public bool dataIsInvalid(object oData)
    {
        bool bRet = true;
        try
        {
            if (oData != null)
            {
                if (oData.ToString().Trim() != "")
                {
                    bRet = false;
                }
            }
        }
        catch (Exception ex)
        {
            appMonitor.logAppExceptions(ex);
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }
        return bRet;
    }
    public bool isNotDbMasterData(List<string> oList, string sDatax)
    {
        bool bRet = true;
        try
        {
            foreach (string sList in oList)
            {
                if (sList.Trim().ToUpper() == sDatax.Trim().ToUpper())
                {
                    bRet = false;
                    break;
                }
            }
            //if (oList.Exists(sFind => oList.Contains(sFind.ToUpper() = sDatax.ToUpper())))
            //{
            //    bRet = false;
            //}
        }
        catch (Exception ex)
        {
            appMonitor.logAppExceptions(ex);
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }
        return bRet;
    }
    public long getDbMasterId(List<dbReMapItem> oList, string sDatax)
    {
        long lRet = 0;
        try
        {
            var isaac = oList.ToArray().Where(pac => pac.sItem == sDatax).FirstOrDefault();
            lRet = isaac.lItem;
        }
        catch (Exception ex)
        {
            appMonitor.logAppExceptions(ex);
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }
        return lRet;
    }
    public int getDbId(List<dbReMapItem> oList, string sDatax)
    {
        int iRet = 0;
        try
        {
            var isaac = oList.ToArray().Where(pac => pac.sItem == sDatax).FirstOrDefault();
            iRet = isaac.iItem;
        }
        catch (Exception ex)
        {
            appMonitor.logAppExceptions(ex);
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }
        return iRet;
    }
    public static string modifyDbStringEx(object oData)
    {
        string sRet = "";
        try
        {
            if (oData != DBNull.Value)
            {
                sRet = oData.ToString();
            }

            if (sRet.Length == 0) sRet = "";
        }
        catch (Exception ex)
        {
            appMonitor.logAppExceptions(ex);
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }
        return sRet;
    }

    public static string modifyDbStringEx(Object oData, string sDefault)
    {
        string sRet = sDefault;
        try
        {
            if (oData != DBNull.Value)
            {
                if (oData != null)
                {
                    sRet = (String)oData;
                }
            }
            if (sRet.Length == 0) sRet = sDefault;
        }
        catch (Exception ex)
        {
            appMonitor.logAppExceptions(ex);
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }
        return sRet;
    }
    public Nullable<Single> modifyXlsNumber(object oData)
    {
        Nullable<Single> gRet = null;
        try
        {
            if (oData != DBNull.Value)
            {
                if (oData != null)
                {
                    if (Information.IsNumeric(oData))
                    {
                        gRet = Single.Parse(oData.ToString());
                    }
                }
            }
        }
        catch (Exception ex)
        {
            appMonitor.logAppExceptions(ex);
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }
        return gRet;
    }
    public bool testXlsNumberForNumeric(object oData)
    {
        bool gRet = true;
        try
        {
            if (oData != DBNull.Value)
            {
                if (oData != null)
                {
                    if (!Information.IsNumeric(oData))
                    {
                        gRet = false;
                    }
                }
            }
        }
        catch (Exception ex)
        {
            appMonitor.logAppExceptions(ex);
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }
        return gRet;
    }

    public static DateTime modifyDbDate(object oData)
    {
        DateTime dtRet = DateTime.Today.Date;
        try
        {
            if (oData != DBNull.Value)
            {
                string gtest = oData.ToString();
                dtRet = DateTime.Parse(oData.ToString());
            }
            if (!Information.IsDate(oData)) dtRet = DateTime.Today.Date;
        }
        catch (Exception ex)
        {
            appMonitor.logAppExceptions(ex);
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }
        return dtRet;
    }
    public bool testXlsDateForValidity(object oData)
    {
        bool gRet = true;
        try
        {
            if (oData != DBNull.Value)
            {
                if (oData != null)
                {
                    if (!Information.IsDate(oData))
                    {
                        gRet = false;
                    }
                }
            }
        }
        catch (Exception ex)
        {
            appMonitor.logAppExceptions(ex);
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }
        return gRet;
    }
        
}

public class BulkLoading
{
    MainProjectHelper oMainProjectHelper = new MainProjectHelper();
    LkUpLeanTimeHelper oLkUpLeanTimeHelper = new LkUpLeanTimeHelper();
    LkUpWasteCategoryHelper oLkUpWasteCategoryHelper = new LkUpWasteCategoryHelper();
    FunctionMgt oFunctionMgt = new FunctionMgt();
    VSMASISHelper oVSMASISHelper = new VSMASISHelper();
    VSMASIS oVSMASIS = new VSMASIS();
    Recommendations oRecommendations = new Recommendations();
    RecommendationsHelper oRecommendationsHelper = new RecommendationsHelper();
    dataManager oDataManager = new dataManager();
    public BulkLoading()
    {

    }
    public dataManager.dbItemErrorList verifyVSMAsIsBulkLoad(string sFilePath, string sErrFile, string sErrorList, int iYear)
    {
        dataManager.dbItemErrorList myErrors = new dataManager.dbItemErrorList();
        int iRet = 0;
        try
        {
            System.IO.FileInfo oExcelFile = new System.IO.FileInfo(sFilePath);
            System.IO.StreamWriter oSw;
            oSw = System.IO.File.AppendText(sErrFile);

            ExcelPackage oPackage = new ExcelPackage(oExcelFile);
            ExcelWorksheet oWs = oPackage.Workbook.Worksheets[1];
            List<string> oError = new List<String>();

            //Get the list of projects in the database for the year specified.
            List<string> sProjects = new List<string>();
            List<MainProjects> oMainProjects = oMainProjectHelper.lstGetLeanProjectsByYear(iYear);
            foreach (MainProjects oMainProject in oMainProjects)
            {
                sProjects.Add(oMainProject.sTitle);
            }

            //Get the list of Process LT Units.
            List<string> sLeanTimeUnit = new List<string>();
            List<LkUpLeanTime> oLkUpLeanTimes = oLkUpLeanTimeHelper.lstGetLkUpLeanTime();
            foreach (LkUpLeanTime oLkUpLeanTime in oLkUpLeanTimes)
            {
                sLeanTimeUnit.Add(oLkUpLeanTime.sUnit);
            }

            //Get the list of Waste Categories.
            List<string> sLkUpWasteCategories = new List<string>();
            List<LkUpWasteCategory> oLkUpWasteCategories = oLkUpWasteCategoryHelper.lstGetWasteCategory();
            foreach (LkUpWasteCategory oLkUpWasteCategory in oLkUpWasteCategories)
            {
                sLkUpWasteCategories.Add(oLkUpWasteCategory.sWaste);
            }

            //Get the list of Functions.
            List<string> sFunctions = new List<string>();
            List<Functions> oFunctions = oFunctionMgt.lstGetFunctions();
            foreach (Functions oFunction in oFunctions)
            {
                sFunctions.Add(oFunction.m_sFunction);
            }

            for (int xRow = 2; xRow <= oWs.Dimension.End.Row; xRow++)
            {
                iRet = iRet + 1;
                try
                {
                    oError.Clear();

                    //Project Name
                    if (oDataManager.dataIsInvalid(oWs.Cells[xRow, 1].Value))
                    {
                        oError.Add("Project Name is Blank");
                    }
                    else
                    {
                        if (oDataManager.isNotDbMasterData(sProjects, oWs.Cells[xRow, 1].Value.ToString()))
                        {
                            oError.Add("Project Name '" + oWs.Cells[xRow, 1].Value.ToString() + "' does NOT exist in Database");
                        }
                    }

                    //Function
                    if (oDataManager.dataIsInvalid(oWs.Cells[xRow, 2].Value))
                    {
                        oError.Add("Function is Blank");
                    }
                    else
                    {
                        if (oDataManager.isNotDbMasterData(sFunctions, oWs.Cells[xRow, 2].Value.ToString()))
                        {
                            oError.Add("Function '" + oWs.Cells[xRow, 2].Value.ToString() + "' does NOT exist in Database");
                        }
                    }

                    if (oDataManager.dataIsInvalid(oWs.Cells[xRow, 3].Value)) { oError.Add("Activity Decsription is Blank"); }
                    if (oDataManager.dataIsInvalid(oWs.Cells[xRow, 4].Value)) { oError.Add("Process LT is Blank"); }

                    //Process LT Unit
                    if (oDataManager.dataIsInvalid(oWs.Cells[xRow, 5].Value))
                    {
                        oError.Add("Process LT Unit is Blank");
                    }
                    else
                    {
                        if (oDataManager.isNotDbMasterData(sLeanTimeUnit, oWs.Cells[xRow, 5].Value.ToString()))
                        {
                            oError.Add("Process LT Unit '" + oWs.Cells[xRow, 5].Value.ToString() + "' does NOT exist in Database");
                        }
                    }

                    if (oDataManager.dataIsInvalid(oWs.Cells[xRow, 6].Value)) { oError.Add("Process VAT is Blank"); }

                    //Process VAT Unit
                    if (oDataManager.dataIsInvalid(oWs.Cells[xRow, 7].Value))
                    {
                        oError.Add("Process VAT Unit is Blank");
                    }
                    else
                    {
                        if (oDataManager.isNotDbMasterData(sLeanTimeUnit, oWs.Cells[xRow, 7].Value.ToString()))
                        {
                            oError.Add("Process VAT Unit '" + oWs.Cells[xRow, 7].Value.ToString() + "' does NOT exist in Database");
                        }
                    }

                    //if (oDataManager.dataIsInvalid(oWs.Cells[xRow, 8].Value)) { oError.Add("Process LT Minutes is Blank"); }
                    //if (oDataManager.dataIsInvalid(oWs.Cells[xRow, 9].Value)) { oError.Add("Process VAT Minutes is Blank"); }

                    //Others									
                    //if (dataIsInvalid(oWs.Cells[xRow, 10].Value)) { oError.Add("Supplier is Blank"); }
                    //if (dataIsInvalid(oWs.Cells[xRow, 11].Value)) { oError.Add("Input is Blank"); }
                    //if (dataIsInvalid(oWs.Cells[xRow, 12].Value)) { oError.Add("Customer is Blank"); }                    
                    //if (dataIsInvalid(oWs.Cells[xRow, 13].Value)) { oError.Add("Output is Blank"); }
                    //if (dataIsInvalid(oWs.Cells[xRow, 14].Value)) { oError.Add("Lean Tool is Blank"); }
                    
                    //Waste Category
                    if (oDataManager.dataIsInvalid(oWs.Cells[xRow, 15].Value))
                    {
                        oError.Add("Waste Category is Blank");
                    }
                    else
                    {
                        if (oDataManager.isNotDbMasterData(sLkUpWasteCategories, oWs.Cells[xRow, 15].Value.ToString()))
                        {
                            oError.Add("Waste Category '" + oWs.Cells[xRow, 15].Value.ToString() + "' does NOT exist in Database");
                        }
                    }
                    //if (dataIsInvalid(oWs.Cells[xRow, 16].Value)) { oError.Add("WasteCodes is Blank"); }

                    //Check if the data in each of the Cells are Numeric
                    if (oDataManager.testXlsNumberForNumeric(oWs.Cells[xRow, 4].Value) != true) { oError.Add("Process LT value is Invalid!!!"); }
                    if (oDataManager.testXlsNumberForNumeric(oWs.Cells[xRow, 6].Value) != true) { oError.Add("Process VAT value is Invalid!!!"); }
                    //if (oDataManager.testXlsNumberForNumeric(oWs.Cells[xRow, 8].Value) != true) { oError.Add("Process LT Minutes value is Invalid!!!"); }
                    //if (oDataManager.testXlsNumberForNumeric(oWs.Cells[xRow, 9].Value) != true) { oError.Add("Process VAT Minutes value is Invalid!!!"); }

                    if (oError.Count > 0)
                    {
                        sErrorList = sErrorList + xRow.ToString() + "_";
                        oSw.WriteLine("Error in Line " + xRow.ToString());

                        foreach (string sItem in oError)
                        {
                            oSw.WriteLine("# :" + sItem);
                        }

                        oSw.WriteLine("**************Abort Error Line " + (xRow + 1));
                        oSw.WriteLine("");
                    }
                }
                catch (Exception ex)
                {
                    appMonitor.logAppExceptions(ex);
                    System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
                }
            }

            if (sErrorList == "!") sErrorList = "";

            myErrors.iItems = iRet;
            myErrors.sErrorList = sErrorList;

            oSw.Flush();
            oSw.Close();
        }
        catch (Exception ex)
        {
            appMonitor.logAppExceptions(ex);
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }
        return myErrors;
    }
    public dataManager.dbItemErrorList verifyImprovementRecommendationBulkLoad(string sFilePath, string sErrFile, string sErrorList, int iYear)
    {
        dataManager.dbItemErrorList myErrors = new dataManager.dbItemErrorList();
        int iRet = 0;
        try
        {
            System.IO.FileInfo oExcelFile = new System.IO.FileInfo(sFilePath);
            System.IO.StreamWriter oSw;
            oSw = System.IO.File.AppendText(sErrFile);

            ExcelPackage oPackage = new ExcelPackage(oExcelFile);
            ExcelWorksheet oWs = oPackage.Workbook.Worksheets[1];
            List<string> oError = new List<String>();

            //ProjectName	Recommendation	Function	ActionFunction	ActionParty	TargetDate	CycleTime	CostReduction	Barrels	Numbers	SponsorComments	ChampionComments    ImplementationStatus	GeneralComments

            //Get the list of projects in the database for the year specified.
            List<string> sProjects = new List<string>();
            List<MainProjects> oMainProjects = oMainProjectHelper.lstGetLeanProjectsByYear(iYear);
            foreach (MainProjects oMainProject in oMainProjects)
            {
                sProjects.Add(oMainProject.sTitle);
            }

            //Get the list of Functions.
            List<string> sFunctions = new List<string>();
            List<Functions> oFunctions = oFunctionMgt.lstGetFunctions();
            foreach (Functions oFunction in oFunctions)
            {
                sFunctions.Add(oFunction.m_sFunction);
            }

            for (int xRow = 2; xRow <= oWs.Dimension.End.Row; xRow++)
            {
                iRet = iRet + 1;
                try
                {
                    oError.Clear();

                    //Project Name
                    if (oDataManager.dataIsInvalid(oWs.Cells[xRow, 1].Value))
                    {
                        oError.Add("Project Name is Blank");
                    }
                    else
                    {
                        if (oDataManager.isNotDbMasterData(sProjects, oWs.Cells[xRow, 1].Value.ToString()))
                        {
                            oError.Add("Project Name '" + oWs.Cells[xRow, 1].Value.ToString() + "' does NOT exist in Database");
                        }
                    }

                    if (oDataManager.dataIsInvalid(oWs.Cells[xRow, 2].Value)) { oError.Add("Recommendation is Blank"); }

                    //Function
                    if (oDataManager.dataIsInvalid(oWs.Cells[xRow, 3].Value))
                    {
                        oError.Add("Function is Blank");
                    }
                    else
                    {
                        if (oDataManager.isNotDbMasterData(sFunctions, oWs.Cells[xRow, 3].Value.ToString()))
                        {
                            oError.Add("Function '" + oWs.Cells[xRow, 3].Value.ToString() + "' does NOT exist in Database");
                        }
                    }

                    //Action Function
                    if (oDataManager.dataIsInvalid(oWs.Cells[xRow, 4].Value))
                    {
                        oError.Add("Action Function is Blank");
                    }
                    else
                    {
                        if (oDataManager.isNotDbMasterData(sFunctions, oWs.Cells[xRow, 4].Value.ToString()))
                        {
                            oError.Add("Function '" + oWs.Cells[xRow, 4].Value.ToString() + "' does NOT exist in Database");
                        }
                    }

                    //Action Party
                    if (oDataManager.dataIsInvalid(oWs.Cells[xRow, 5].Value))
                    {
                        oError.Add("Action Party is Blank");
                    }
                    else
                    {
                        if (oDataManager.isNotDbMasterData(sFunctions, oWs.Cells[xRow, 5].Value.ToString()))
                        {
                            oError.Add("Function '" + oWs.Cells[xRow, 5].Value.ToString() + "' does NOT exist in Database");
                        }
                    }

                    //Target Date
                    if (oWs.Cells[xRow, 6].Text != "")
                    { 
                        if (oDataManager.testXlsDateForValidity(oWs.Cells[xRow, 6].Value)) { oError.Add("Target Date is Invalid!!!"); } 
                    }
                    
                    //if (dataIsInvalid(oWs.Cells[xRow, 7].Value)) { oError.Add("Cycle Time is Blank"); } //CycleTime	
                    //if (dataIsInvalid(oWs.Cells[xRow, 8].Value)) { oError.Add("Cost Reduction is Blank"); }
                    //if (dataIsInvalid(oWs.Cells[xRow, 9].Value)) { oError.Add("Barrels is Blank"); }
                    //if (dataIsInvalid(oWs.Cells[xRow, 10].Value)) { oError.Add("Numbers is Blank"); }
                    //if (oDataManager.dataIsInvalid(oWs.Cells[xRow, 11].Value)) { oError.Add("Sponsor Comments is Blank"); }
                    //if (oDataManager.dataIsInvalid(oWs.Cells[xRow, 12].Value)) { oError.Add("Champion Comments is Blank"); }
                    //if (oDataManager.dataIsInvalid(oWs.Cells[xRow, 13].Value)) { oError.Add("Implementation Status is Blank"); }
                    //if (oDataManager.dataIsInvalid(oWs.Cells[xRow, 14].Value)) { oError.Add("General Comments is Blank"); }
                    //if (oDataManager.dataIsInvalid(oWs.Cells[xRow, 15].Value)) { oError.Add("Benefit is Blank"); }

                    //Check if the data in each of the Cells are Numeric
                    if (oWs.Cells[xRow, 7].Text != "")
                    { if (oDataManager.testXlsNumberForNumeric(oWs.Cells[xRow, 7].Value) != true) { oError.Add("Cycle Time is Invalid!!!"); } }
                    if (oWs.Cells[xRow, 8].Text != "")
                    { if (oDataManager.testXlsNumberForNumeric(oWs.Cells[xRow, 8].Value) != true) { oError.Add("Cost Reduction is Invalid!!!"); } }
                    if (oWs.Cells[xRow, 9].Text != "")
                    { if (oDataManager.testXlsNumberForNumeric(oWs.Cells[xRow, 9].Value) != true) { oError.Add("Barrels is Invalid!!!"); } }
                    if (oWs.Cells[xRow, 10].Text != "")
                    { if (oDataManager.testXlsNumberForNumeric(oWs.Cells[xRow, 10].Value) != true) { oError.Add("Numbers is Invalid!!!"); } }

                    if (oError.Count > 0)
                    {
                        sErrorList = sErrorList + xRow.ToString() + "_";
                        oSw.WriteLine("Error in Line " + xRow.ToString());

                        foreach (string sItem in oError)
                        {
                            oSw.WriteLine("# :" + sItem);
                        }

                        oSw.WriteLine("**************Abort Error Line " + (xRow + 1));
                        oSw.WriteLine("");
                    }
                }
                catch (Exception ex)
                {
                    appMonitor.logAppExceptions(ex);
                    System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
                }
            }

            if (sErrorList == "!") sErrorList = "";

            myErrors.iItems = iRet;
            myErrors.sErrorList = sErrorList;

            oSw.Flush();
            oSw.Close();
        }
        catch (Exception ex)
        {
            appMonitor.logAppExceptions(ex);
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }
        return myErrors;
    }
    public int saveVSMAsIsBulkLoad(string sFilePath, int iYear)
    {
        int iRet = 0; string sProjectId; string sLTUnitId; string sLTVatUnitId; string sWasteCategoriesId; string sFunctionId;

        try
        {
            FileInfo oExcelFile = new FileInfo(sFilePath);
            ExcelPackage oPackage = new ExcelPackage(oExcelFile);
            ExcelWorksheet oWs = oPackage.Workbook.Worksheets[1];

            //List<dbReMapItem> oRet = new List<dbReMapItem>();

            List<dataManager.dbReMapItem> oProjectId = new List<dataManager.dbReMapItem>();
            List<MainProjects> oMainProjects = oMainProjectHelper.lstGetLeanProjectsByYear(iYear);
            foreach (MainProjects oMainProject in oMainProjects)
            {
                dataManager.dbReMapItem eProjectId = new dataManager.dbReMapItem();
                eProjectId.lItem = oMainProject.lProjectId;
                eProjectId.sItem = oMainProject.sTitle;
                oProjectId.Add(eProjectId);
            }

            List<dataManager.dbReMapItem> oLeanTimeUnitId = new List<dataManager.dbReMapItem>();
            List<LkUpLeanTime> oLkUpLeanTimes = oLkUpLeanTimeHelper.lstGetLkUpLeanTime();
            foreach (LkUpLeanTime oLkUpLeanTime in oLkUpLeanTimes)
            {
                dataManager.dbReMapItem eLeanTimeUnitId = new dataManager.dbReMapItem();
                eLeanTimeUnitId.iItem = oLkUpLeanTime.iTimeId;
                eLeanTimeUnitId.sItem = oLkUpLeanTime.sUnit;
                oLeanTimeUnitId.Add(eLeanTimeUnitId);
            }

            List<dataManager.dbReMapItem> oWasteCategoriesId = new List<dataManager.dbReMapItem>();
            List<LkUpWasteCategory> oLkUpWasteCategories = oLkUpWasteCategoryHelper.lstGetWasteCategory();
            foreach (LkUpWasteCategory oLkUpWasteCategory in oLkUpWasteCategories)
            {
                dataManager.dbReMapItem eWasteCategoriesId = new dataManager.dbReMapItem();
                eWasteCategoriesId.iItem = oLkUpWasteCategory.iWasteId;
                eWasteCategoriesId.sItem = oLkUpWasteCategory.sWaste;
                oWasteCategoriesId.Add(eWasteCategoriesId);
            }

            List<dataManager.dbReMapItem> oFunctionId = new List<dataManager.dbReMapItem>();
            List<Functions> oFunctions = oFunctionMgt.lstGetFunctions();
            foreach (Functions oFunction in oFunctions)
            {
                dataManager.dbReMapItem eFunctionId = new dataManager.dbReMapItem();
                eFunctionId.iItem = oFunction.m_iFunctionId;
                eFunctionId.sItem = oFunction.m_sFunction;
                oFunctionId.Add(eFunctionId);
            }

            //DataTable dt = new DataTable();
            //dt = corporatePriorityAccess.dtGetCorporatePriorities();
            //dt = okpiHeaderAccess.dtGetKpiHeaders();
            for (int xRow = 2; xRow <= oWs.Dimension.End.Row + 1; xRow++)
            {
                sProjectId = dataManager.modifyDbStringEx(oWs.Cells[xRow, 1].Value, "");
                sFunctionId = dataManager.modifyDbStringEx(oWs.Cells[xRow, 2].Value, "");
                sLTUnitId = dataManager.modifyDbStringEx(oWs.Cells[xRow, 5].Value, "");
                sLTVatUnitId = dataManager.modifyDbStringEx(oWs.Cells[xRow, 7].Value, "");
                sWasteCategoriesId = dataManager.modifyDbStringEx(oWs.Cells[xRow, 15].Value, "");


                //sKpiHeaderId = modifyDbStringEx(oWs.Cells[xRow, 2].Value, "");
                if ((sProjectId.Length > 0) && (sLTUnitId.Length > 0) && (sLTVatUnitId.Length > 0) && (sWasteCategoriesId.Length > 0) && (sFunctionId.Length > 0))
                {
                    //DataRow[] oRow = null;
                    oVSMASIS.iSeqId = xRow;
                    oVSMASIS.lProjectId = oDataManager.getDbMasterId(oProjectId, sProjectId);
                    oVSMASIS.iFunctionId = oDataManager.getDbId(oFunctionId, sFunctionId);
                    oVSMASIS.sActivityDesc = (oWs.Cells[xRow, 3].Value.ToString() == null) ? "" : dataManager.modifyDbStringEx(oWs.Cells[xRow, 3].Value.ToString());
                    oVSMASIS.dProcessLt = Convert.ToDecimal(oDataManager.modifyXlsNumber(oWs.Cells[xRow, 4].Value));
                    oVSMASIS.iProcessLtUnit = oDataManager.getDbId(oLeanTimeUnitId, sLTUnitId);
                    oVSMASIS.dProcessVat = Convert.ToDecimal(oDataManager.modifyXlsNumber(oWs.Cells[xRow, 6].Value));
                    oVSMASIS.iProcessVatUnit = oDataManager.getDbId(oLeanTimeUnitId, sLTVatUnitId);
                    //oVSMASIS.dProcessLtMin = Convert.ToDecimal(oDataManager.modifyXlsNumber(oWs.Cells[xRow, 8].Value));
                    //oVSMASIS.dProcessVatMin = Convert.ToDecimal(oDataManager.modifyXlsNumber(oWs.Cells[xRow, 9].Value));
                    oVSMASIS.sSupplier = (oWs.Cells[xRow, 10].Text == "") ? "" : dataManager.modifyDbStringEx(oWs.Cells[xRow, 10].Value.ToString());
                    oVSMASIS.sInput = (oWs.Cells[xRow, 11].Text == "") ? "" : dataManager.modifyDbStringEx(oWs.Cells[xRow, 11].Value.ToString());
                    oVSMASIS.sCustomer = (oWs.Cells[xRow, 12].Text == "") ? "" : dataManager.modifyDbStringEx(oWs.Cells[xRow, 12].Value.ToString());
                    oVSMASIS.sOutPut = (oWs.Cells[xRow, 13].Text == "") ? "" : dataManager.modifyDbStringEx(oWs.Cells[xRow, 13].Value.ToString());
                    oVSMASIS.sImprovement = (oWs.Cells[xRow, 14].Text == "") ? "" : dataManager.modifyDbStringEx(oWs.Cells[xRow, 14].Value.ToString());
                    oVSMASIS.iWasteCat = oDataManager.getDbId(oWasteCategoriesId, sWasteCategoriesId);
                    oVSMASIS.sWasteCode = (oWs.Cells[xRow, 16].Text == "") ? "" : dataManager.modifyDbStringEx(oWs.Cells[xRow, 16].Value.ToString());

                    if (oVSMASISHelper.InsertVsmAsIs(oVSMASIS))
                    {
                        iRet = iRet + 1;
                    }
                }
            }
        }
        catch (Exception ex)
        {
            appMonitor.logAppExceptions(ex);
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }
        return iRet;
    }
    public int saveImprovementRecommendationBulkLoad(string sFilePath, int iYear)
    {
        int iRet = 0; string sProjectId; string sFunctionId; string sActionFunction = ""; string sActionParty = ""; string sStatusId = "";

        try
        {
            FileInfo oExcelFile = new FileInfo(sFilePath);
            ExcelPackage oPackage = new ExcelPackage(oExcelFile);
            ExcelWorksheet oWs = oPackage.Workbook.Worksheets[1];

            List<dataManager.dbReMapItem> oProjectId = new List<dataManager.dbReMapItem>();
            List<MainProjects> oMainProjects = oMainProjectHelper.lstGetLeanProjectsByYear(iYear);
            foreach (MainProjects oMainProject in oMainProjects)
            {
                dataManager.dbReMapItem eProjectId = new dataManager.dbReMapItem();
                eProjectId.lItem = oMainProject.lProjectId;
                eProjectId.sItem = oMainProject.sTitle;
                oProjectId.Add(eProjectId);
            }

            List<dataManager.dbReMapItem> oFunctionId = new List<dataManager.dbReMapItem>();
            List<Functions> oFunctions = oFunctionMgt.lstGetFunctions();
            foreach (Functions oFunction in oFunctions)
            {
                dataManager.dbReMapItem eFunctionId = new dataManager.dbReMapItem();
                eFunctionId.iItem = oFunction.m_iFunctionId;
                eFunctionId.sItem = oFunction.m_sFunction;
                oFunctionId.Add(eFunctionId);
            }

            List<dataManager.dbReMapItem> oStatusId = new List<dataManager.dbReMapItem>();

            dataManager.dbReMapItem eStatusId = new dataManager.dbReMapItem();
            eStatusId.iItem = (int)ProjectStatus.ProjStatus.NotStarted;
            eStatusId.sItem = ProjectStatus.status(ProjectStatus.ProjStatus.NotStarted);
            eStatusId.iItem = (int)ProjectStatus.ProjStatus.Ongoing10;
            eStatusId.sItem = ProjectStatus.status(ProjectStatus.ProjStatus.Ongoing10);
            eStatusId.iItem = (int)ProjectStatus.ProjStatus.Yes20;
            eStatusId.sItem = ProjectStatus.status(ProjectStatus.ProjStatus.Yes20 - 1);
            oStatusId.Add(eStatusId);

            for (int xRow = 2; xRow <= oWs.Dimension.End.Row + 1; xRow++)
            {
                sProjectId = dataManager.modifyDbStringEx(oWs.Cells[xRow, 1].Value, "");
                sFunctionId = dataManager.modifyDbStringEx(oWs.Cells[xRow, 3].Value, "");
                sActionFunction = dataManager.modifyDbStringEx(oWs.Cells[xRow, 4].Value, "");
                sActionParty = dataManager.modifyDbStringEx(oWs.Cells[xRow, 5].Value, "");
                sStatusId = dataManager.modifyDbStringEx(oWs.Cells[xRow, 13].Value, "");
                oRecommendations.iSeqId = xRow;

                if ((sProjectId.Length > 0) && (sFunctionId.Length > 0) && (sActionFunction.Length > 0) && (sActionParty.Length > 0))
                {
                    oRecommendations.lProjectId = oDataManager.getDbMasterId(oProjectId, sProjectId);
                    oRecommendations.iFunctionId = oDataManager.getDbId(oFunctionId, sFunctionId);
                    oRecommendations.iActionFunction = oDataManager.getDbId(oFunctionId, sActionFunction);
                    oRecommendations.iActionParty = oDataManager.getDbId(oFunctionId, sActionParty);

                    oRecommendations.sRecommendations = (oWs.Cells[xRow, 2].Text == "") ? "" : dataManager.modifyDbStringEx(oWs.Cells[xRow, 2].Value.ToString());
                    string datess = oWs.Cells[xRow, 6].Text;
                    oRecommendations.dtTargetDate = dataManager.modifyDbDate(datess);
                    oRecommendations.dCTReduction = Convert.ToSingle(oDataManager.modifyXlsNumber(oWs.Cells[xRow, 7].Value));
                    oRecommendations.dCostReduction = Convert.ToSingle(oDataManager.modifyXlsNumber(oWs.Cells[xRow, 8].Value));
                    oRecommendations.dProductionBarrel = Convert.ToSingle(oDataManager.modifyXlsNumber(oWs.Cells[xRow, 9].Value));
                    oRecommendations.dNumber = Convert.ToSingle(oDataManager.modifyXlsNumber(oWs.Cells[xRow, 10].Value));
                    oRecommendations.sSponsorComment = (oWs.Cells[xRow, 11].Text == "") ? "" : dataManager.modifyDbStringEx(oWs.Cells[xRow, 11].Value.ToString());
                    oRecommendations.sChampionComment = (oWs.Cells[xRow, 12].Text == "") ? "" : dataManager.modifyDbStringEx(oWs.Cells[xRow, 12].Value.ToString());
                    oRecommendations.iStatus = oDataManager.getDbId(oStatusId, sStatusId);
                    oRecommendations.sComments = (oWs.Cells[xRow, 14].Text == "") ? "" : dataManager.modifyDbStringEx(oWs.Cells[xRow, 14].Value.ToString());
                    oRecommendations.sOtherBenefits = "";
                    //oRecommendations.sOtherBenefits = (oWs.Cells[xRow, 15] == null) ? "" : dataManager.modifyDbStringEx(oWs.Cells[xRow, 15].Value.ToString());

                    if (oRecommendationsHelper.InsertRecommendation(oRecommendations))
                    {
                        iRet = iRet + 1;
                    }
                }
            }
        }
        catch (Exception ex)
        {
            appMonitor.logAppExceptions(ex);
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }
        return iRet;
    }
    public bool downLoadFunctions(ExcelPackage oPck)
    {
        try
        {
            ExcelWorksheet oWs = oPck.Workbook.Worksheets.Add("Functions");
            oWs.View.ShowGridLines = true;
            oWs.Cells[1, 1].Value = "Functions";

            oWs.Column(1).Width = 50;

            int iRet = 2;
            List<Functions> lstFunctions = oFunctionMgt.lstGetFunctions();
            foreach (Functions oFunction in lstFunctions)
            {
                oWs.Cells[iRet, 1].Value = oFunction.m_sFunction;
                iRet += 1;
            }

            oWs.Cells[1, 1, 1, 1].Style.Fill.PatternType = ExcelFillStyle.Solid; //must set this for bgcolor
            oWs.Cells[1, 1, 1, 1].Style.Fill.BackgroundColor.SetColor(Color.PaleGreen);
            oWs.Cells[1, 1, 1, 1].Style.Font.Color.SetColor(Color.Blue);
            oWs.Cells[1, 1, 1, 1].Style.Font.Bold = true;
        }
        catch (Exception ex)
        {
            appMonitor.logAppExceptions(ex);
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }

        return true;
    }
    public bool downLoadProcessLTVatUnits(ExcelPackage oPck)
    {
        try
        {
            ExcelWorksheet oWs = oPck.Workbook.Worksheets.Add("Process LT/Vat Units");
            oWs.View.ShowGridLines = true;
            oWs.Cells[1, 1].Value = "Process LT/Vat Units";
            oWs.Cells[1, 2].Value = "Description";
            oWs.Cells[1, 3].Value = "Conversion";

            oWs.Column(1).Width = 15;
            oWs.Column(2).Width = 50;
            oWs.Column(3).Width = 20;

            int iRet = 2;
            List<LkUpLeanTime> oLkUpLeanTimes = oLkUpLeanTimeHelper.lstGetLkUpLeanTime();
            foreach (LkUpLeanTime oLkUpLeanTime in oLkUpLeanTimes)
            {
                oWs.Cells[iRet, 1].Value = oLkUpLeanTime.sUnit;
                oWs.Cells[iRet, 2].Value = oLkUpLeanTime.sDescription;
                oWs.Cells[iRet, 3].Value = oLkUpLeanTime.sMinConvertion;
                iRet += 1;
            }

            oWs.Cells[1, 1, 1, 3].Style.Fill.PatternType = ExcelFillStyle.Solid; //must set this for bgcolor
            oWs.Cells[1, 1, 1, 3].Style.Fill.BackgroundColor.SetColor(Color.PaleGreen);
            oWs.Cells[1, 1, 1, 3].Style.Font.Color.SetColor(Color.Blue);
            oWs.Cells[1, 1, 1, 3].Style.Font.Bold = true;
        }
        catch (Exception ex)
        {
            appMonitor.logAppExceptions(ex);
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }

        return true;
    }
    public bool downLoadWasteCategory(ExcelPackage oPck)
    {
        try
        {
            ExcelWorksheet oWs = oPck.Workbook.Worksheets.Add("Waste Category");
            oWs.View.ShowGridLines = true;
            oWs.Cells[1, 1].Value = "Waste Category";
            oWs.Cells[1, 2].Value = "Code";

            oWs.Column(1).Width = 25;
            oWs.Column(2).Width = 10;

            int iRet = 2;
            List<LkUpWasteCategory> oLkUpWasteCategories = oLkUpWasteCategoryHelper.lstGetWasteCategory();
            foreach (LkUpWasteCategory oLkUpWasteCategory in oLkUpWasteCategories)
            {
                oWs.Cells[iRet, 1].Value = oLkUpWasteCategory.sWaste;
                oWs.Cells[iRet, 2].Value = oLkUpWasteCategory.sCode;
                iRet += 1;
            }

            oWs.Cells[1, 1, 1, 2].Style.Fill.PatternType = ExcelFillStyle.Solid; //must set this for bgcolor
            oWs.Cells[1, 1, 1, 2].Style.Fill.BackgroundColor.SetColor(Color.PaleGreen);
            oWs.Cells[1, 1, 1, 2].Style.Font.Color.SetColor(Color.Blue);
            oWs.Cells[1, 1, 1, 2].Style.Font.Bold = true;
        }
        catch (Exception ex)
        {
            appMonitor.logAppExceptions(ex);
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }

        return true;
    }
}