using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using Oracle.ManagedDataAccess.Client;
using System.Reflection;

/// <summary>
/// Summary description for Commitments
/// </summary>

public class Commitments
{
    //public long lCommitmentId { get; set; }

    //public int iOuId { get; set; }
    //public int iAssetId { get; set; }
    //public int iFacilityId { get; set; }
    //public int iTeamId { get; set; }
    //public string sTeamIndicator { get; set; }

    //public string sCostObject { get; set; }
    //public string sCostObjectDesc { get; set; }
    //public int iCapexOpex { get; set; }

    //public string sPRNumber { get; set; }
    //public decimal dPRValue { get; set; }
    //public string sPONumber { get; set; }
    //public decimal dPOValue { get; set; }
    //public string sCommitmentNumber { get; set; }
    //public decimal dCommitment { get; set; }

    //public string sTitle { get; set; }
    //public string sJustification { get; set; }
    //public string sThreat { get; set; }

    //public string sContractNumberVendor { get; set; }
    //public int iGroupId { get; set; }
    //public int iTypeId { get; set; }
    //public int iStatusId { get; set; }
    //public int iVehicleId { get; set; }
    //public DateTime? tPeriodFrom { get; set; }
    //public DateTime? tPeriodTo { get; set; }
    //public DateTime? tPrevious { get; set; }
    //public DateTime? tDateSubmitted { get; set; }

    //public decimal dNappimsNaira { get; set; }
    //public decimal dNappimsDollar { get; set; }
    //public decimal dNappimsFuncDollar { get; set; }
    //public decimal dRequestNaira { get; set; }
    //public decimal dRequestDollar { get; set; }
    //public decimal dRequestFuncDollar { get; set; }

    //public int iSponsorId { get; set; }
    //public int iCheckedById { get; set; }
    //public int iApproverId { get; set; }
    //public int iInitiatorId { get; set; }

    ////Approval Process
    //public int iApprovalId { get; set; }
    //public string sApprovalComments { get; set; }
    //public decimal dSavings { get; set; }
    //public string dVariance { get; set; }


    public long COMMITMENTID { get; set; }

    public int IDOU { get; set; }
    public int ASSETID { get; set; }
    public int FACILITYID { get; set; }
    public int IDDEPARTMENT { get; set; }
    public string TEAMINDICATOR { get; set; }

    public string COSTOBJECT { get; set; }
    public string COSTOBJECTDESC { get; set; }
    public int CAPEXOPEX { get; set; }

    public string PRNUMBER { get; set; }
    public decimal PRVALUE { get; set; }
    public string PONUMBER { get; set; }
    public decimal POVALUE { get; set; }
    public string COMITMNTNO { get; set; }
    public decimal COMMITMENT { get; set; }

    public string TITLE { get; set; }
    public string JUSTIFICATION { get; set; }
    public string THREAT { get; set; }

    public string CONTRACTNOVENDOR { get; set; }
    public int GROUPID { get; set; }
    public int TYPEID { get; set; }
    public int STATUSID { get; set; }
    public int VEHICLEID { get; set; }
    public DateTime? PERIODFROM { get; set; }
    public DateTime? PERIODTO { get; set; }
    public DateTime? PREVIOUS { get; set; }
    public DateTime? DATE_SUBMITTED { get; set; }

    public decimal NAPPIMSNAIRA { get; set; }
    public decimal NAPPIMSDOLLAR { get; set; }
    public decimal NAPPIMSFUNCDOLLAR { get; set; }
    public decimal REQUESTNAIRA { get; set; }
    public decimal REQUESTDOLLAR { get; set; }
    public decimal REQUESTFUNCDOLLAR { get; set; }

    public int SPONSORID { get; set; }
    public int CHECKEDBYID { get; set; }
    public int APPROVERID { get; set; }
    public int INITIATORID { get; set; }
    public int FOCALPOINTID { get; set; }

    //Approval Process
    public int APPROVALID { get; set; }
    public string APPROVALCOMMENT { get; set; }
    public decimal SAVINGS { get; set; }
    public string dVariance { get; set; }

    public ApprovalDecision eDecision { get; set; }
    public ContractProcurementVehicle eVehicle { get; set; }
    public PlannedEmmergency eEmmergency { get; set; }
    public PurchasingGroup eGroup { get; set; }
    public RequestStatus eStatus { get; set; }
    public Team eTeam { get; set; }

    public Facility eFacility { get; set; }
    public Assets eAsset { get; set; }

    public Department eDepartment { get; set; }
    public appUsers eSponsor { get; set; }
    public appUsers eFocalPoint { get; set; }
    public appUsers eCheckedBy { get; set; }
    public appUsers eRequestor { get; set; }
    public appUsers eApprover { get; set; }
    public appUsers eInitiator { get; set; }

    public string GROUPNAME { get; set; }
    public string TEAMNAME { get; set; }
    public string INITIATORFULLNAME { get; set; }
    public string DECISION { get; set; }
    public string STATUS { get; set; }

    //ddlHotDeskSupport
    //ddlGMApproval

    public Commitments()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public Commitments(DataRow dr)
    {
        COMMITMENTID = long.Parse(dr["COMMITMENTID"].ToString());

        IDOU = int.Parse(dr["IDOU"].ToString());
        ASSETID = string.IsNullOrEmpty(dr["ASSETID"].ToString()) ? 0 : int.Parse(dr["ASSETID"].ToString());
        FACILITYID = string.IsNullOrEmpty(dr["FACILITYID"].ToString()) ? 0 : int.Parse(dr["FACILITYID"].ToString());
        IDDEPARTMENT = int.Parse(dr["IDDEPARTMENT"].ToString());
        TEAMINDICATOR = dr["TEAMINDICATOR"].ToString();

        COSTOBJECT = dr["COSTOBJECT"].ToString();
        COSTOBJECTDESC = dr["COSTOBJECTDESC"].ToString();
        CAPEXOPEX = string.IsNullOrEmpty(dr["CAPEXOPEX"].ToString()) ? 0 : int.Parse(dr["CAPEXOPEX"].ToString());

        PRNUMBER = dr["PRNUMBER"].ToString();
        PRVALUE = string.IsNullOrEmpty(dr["PRVALUE"].ToString()) ? 0 : decimal.Parse(dr["PRVALUE"].ToString());
        PONUMBER = dr["PONUMBER"].ToString();
        POVALUE = string.IsNullOrEmpty(dr["POVALUE"].ToString()) ? 0 : decimal.Parse(dr["POVALUE"].ToString());
        dVariance = (POVALUE == 0) ? 0.ToString() + " %" : (Math.Round(((PRVALUE / POVALUE) * 100), 2)).ToString() + " %";
        COMITMNTNO = dr["COMITMNTNO"].ToString();
        COMMITMENT = string.IsNullOrEmpty(dr["COMMITMENT"].ToString()) ? 0 : decimal.Parse(dr["COMMITMENT"].ToString());

        TITLE = dr["TITLE"].ToString();
        JUSTIFICATION = dr["JUSTIFICATION"].ToString();
        THREAT = dr["THREAT"].ToString();

        CONTRACTNOVENDOR = dr["CONTRACTNOVENDOR"].ToString();
        GROUPID = int.Parse(dr["GROUPID"].ToString());
        TYPEID = int.Parse(dr["TYPEID"].ToString());
        STATUSID = int.Parse(dr["STATUSID"].ToString());
        VEHICLEID = int.Parse(dr["VEHICLEID"].ToString());

        PERIODFROM = !string.IsNullOrEmpty(dr["PERIODFROM"].ToString()) ? DateTime.Parse(dr["PERIODFROM"].ToString()) : (DateTime?)null;
        PERIODTO = !string.IsNullOrEmpty(dr["PERIODTO"].ToString()) ? DateTime.Parse(dr["PERIODTO"].ToString()) : (DateTime?)null;
        PREVIOUS = !string.IsNullOrEmpty(dr["PREVIOUS"].ToString()) ? DateTime.Parse(dr["PREVIOUS"].ToString()) : (DateTime?)null;
        DATE_SUBMITTED = !string.IsNullOrEmpty(dr["DATE_SUBMITTED"].ToString()) ? DateTime.Parse(dr["DATE_SUBMITTED"].ToString()) : (DateTime?)null;

        NAPPIMSNAIRA = string.IsNullOrEmpty(dr["NAPPIMSNAIRA"].ToString()) ? 0 : decimal.Parse(dr["NAPPIMSNAIRA"].ToString());
        NAPPIMSDOLLAR = string.IsNullOrEmpty(dr["NAPPIMSDOLLAR"].ToString()) ? 0 : decimal.Parse(dr["NAPPIMSDOLLAR"].ToString());
        NAPPIMSFUNCDOLLAR = string.IsNullOrEmpty(dr["NAPPIMSFUNCDOLLAR"].ToString()) ? 0 : decimal.Parse(dr["NAPPIMSFUNCDOLLAR"].ToString());
        REQUESTNAIRA = string.IsNullOrEmpty(dr["REQUESTNAIRA"].ToString()) ? 0 : decimal.Parse(dr["REQUESTNAIRA"].ToString());
        REQUESTDOLLAR = string.IsNullOrEmpty(dr["REQUESTDOLLAR"].ToString()) ? 0 : decimal.Parse(dr["REQUESTDOLLAR"].ToString());
        REQUESTFUNCDOLLAR = string.IsNullOrEmpty(dr["REQUESTFUNCDOLLAR"].ToString()) ? 0 : decimal.Parse(dr["REQUESTFUNCDOLLAR"].ToString());

        SPONSORID = string.IsNullOrEmpty(dr["SPONSORID"].ToString()) ? 0 : int.Parse(dr["SPONSORID"].ToString());
        CHECKEDBYID = string.IsNullOrEmpty(dr["CHECKEDBYID"].ToString()) ? 0 : int.Parse(dr["CHECKEDBYID"].ToString());
        APPROVERID = string.IsNullOrEmpty(dr["APPROVERID"].ToString()) ? 0 : int.Parse(dr["APPROVERID"].ToString());
        INITIATORID = string.IsNullOrEmpty(dr["INITIATORID"].ToString()) ? 0 : int.Parse(dr["INITIATORID"].ToString());
        FOCALPOINTID = string.IsNullOrEmpty(dr["FOCALPOINTID"].ToString()) ? 0 : int.Parse(dr["FOCALPOINTID"].ToString());

        APPROVALID = string.IsNullOrEmpty(dr["APPROVALID"].ToString()) ? 0 : int.Parse(dr["APPROVALID"].ToString());
        APPROVALCOMMENT = dr["APPROVALCOMMENT"].ToString();
        SAVINGS = string.IsNullOrEmpty(dr["SAVINGS"].ToString()) ? 0 : decimal.Parse(dr["SAVINGS"].ToString());

        var oHlp = new appUsersHelper();
        eSponsor = oHlp.objGetUserByUserID(SPONSORID);
        eCheckedBy = oHlp.objGetUserByUserID(CHECKEDBYID);
        eApprover = oHlp.objGetUserByUserID(APPROVERID);
        eInitiator = oHlp.objGetUserByUserID(INITIATORID);
        eFocalPoint = oHlp.objGetUserByUserID(FOCALPOINTID);

        var t = new TeamMgt();
        eTeam = t.objGetTeamById(IDDEPARTMENT);

        var d = new Department();
        eDepartment = d.objGetDeparmentById(IDDEPARTMENT);

        var g = new PurchasingGroupMgt();
        eGroup = g.objGetPurchasingGroupById(GROUPID);

        var a = new ApprovalDecisionMgt();
        eDecision = a.objGetApprovalDecisionById(APPROVALID);

        var c = new ContractProcurementVehicleMgt();
        eVehicle = c.objGetContractProcurementVehicleById(VEHICLEID);

        var s = new RequestStatusMgt();
        eStatus = s.objGetRequestStatusById(STATUSID);

        var p = new PlannedEmmergencyMgt();
        eEmmergency = p.objGetPlannedEmmergencyById(TYPEID);

        eAsset = Assets.objGetAssetById(ASSETID);
        eFacility = Facility.objGetFacilityById(FACILITYID);


        GROUPNAME = eGroup.m_sName;
        TEAMNAME = eDepartment.m_sDepartment;
        INITIATORFULLNAME = eInitiator.m_sFullName;
        DECISION = eDecision.m_sDecision;
        STATUS = eStatus.m_sStatus;
    }

    //    iOuId
    //    iAssetId
    //    iFacilityId
    //    iTeamId
    //    sTeamIndicator

    //    sCostObject
    //    sCostObjectDesc
    //    iCapexOpex

    //    sPRNumber
    //    dPRValue
    //    sPONumber
    //    dPOValue
    //    sCommitmentNumber
    //    dCommitment


    //    sTitle
    //    sJustification
    //    sThreat

    //    sContractNumberVendor
    //    iGroupId
    //    iTypeId
    //    iStatusId
    //    iVehicleId
    //    tPeriodFrom
    //    tPeriodTo
    //    tPrevious
    //    tDateSubmitted

    //    dNappimsNaira
    //    dNappimsDollar
    //    dNappimsFuncDollar
    //    dRequestNaira
    //    dRequestDollar
    //    dRequestFuncDollar

    //    iSponsorId
    //    iCheckedById
    //    iApproverId
    //    iInitiatorId

    //    sApprovalComments
    //    dSavings

}

public class CommitmentsMgt
{
    readonly ActivityDetailsMgt oMgt = new ActivityDetailsMgt();

    public CommitmentsMgt()
    {

    }

    private static DataTable dtGetCommitmentId()
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureBongaCC.getBongaAutoNumber();

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    private struct CommitmentIdentity
    {
        public long lCommitmentID;
        public string sCommitmentNumber;
    }

    private CommitmentIdentity CommitmentIdentifier(int iOu)
    {
        CommitmentIdentity e = new CommitmentIdentity();
        try
        {
            string sNo = "";
            DataTable dt = dtGetCommitmentId();
            e.lCommitmentID = long.Parse(dt.Rows[0]["AUTO"].ToString()) + 1;

            if (e.lCommitmentID.ToString().Length == 1) sNo = "000" + e.lCommitmentID.ToString();
            else if (e.lCommitmentID.ToString().Length == 2) sNo = "00" + e.lCommitmentID.ToString();
            else if (e.lCommitmentID.ToString().Length == 3) sNo = "0" + e.lCommitmentID.ToString();
            else if (e.lCommitmentID.ToString().Length >= 4) sNo = e.lCommitmentID.ToString();

            if (iOu == (int)commonEnums.OU.SNEPCO)
                e.sCommitmentNumber = "SNEP" + DateTime.Now.Year.ToString().Remove(0, 2) + sNo;
            else if (iOu == (int)commonEnums.OU.SPDC)
                e.sCommitmentNumber = "SPDC" + DateTime.Now.Year.ToString().Remove(0, 2) + sNo;
        }
        catch (Exception ex)
        {
            appMonitor.logAppExceptions(ex);
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }

        return e;
    }

    public bool UpdateBongaAutoNumberGenerator(long lCommitmentId)
    {
        //Update Bonga_Auto table to the latest value
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureBongaCC.UpdateBongaAuto();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":lCommitmentId";
        param.Value = lCommitmentId;
        param.DbType = DbType.Int64;
        comm.Parameters.Add(param);

        // result will represent the number of changed rows
        int result = -1;
        try
        {
            // execute the stored procedure
            result = GenericDataAccess.ExecuteNonQuery(comm);
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }
        // result will be 1 in case of success
        return (result != -1);
    }

   
    #region ================== SNEPCO =============================

    public bool InsertSnepco(Commitments o, ref long lCommitmentId, ref string sCommitmentNumber)
    {
        CommitmentIdentity c = CommitmentIdentifier(o.IDOU);
        lCommitmentId = c.lCommitmentID;
        o.COMMITMENTID = c.lCommitmentID;
        o.COMITMNTNO = c.sCommitmentNumber;
        sCommitmentNumber = c.sCommitmentNumber;

        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureBongaCC.InsertCommitmentSnepco();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":lCommitmentId";
        param.Value = o.COMMITMENTID;
        param.DbType = DbType.Int64;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iOuId";
        param.Value = o.IDOU;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":sCommitmentNumber";
        param.Value = o.COMITMNTNO;
        param.DbType = DbType.String;
        param.Size = 2000;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":sTitle";
        param.Value = o.TITLE;
        param.DbType = DbType.String;
        param.Size = 2000;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":sCostObject";
        param.Value = o.COSTOBJECT;
        param.DbType = DbType.String;
        param.Size = 2000;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iGroupId";
        param.Value = o.GROUPID;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iTeamId";
        param.Value = o.IDDEPARTMENT;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iSponsorId";
        param.Value = o.SPONSORID;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iCheckedById";
        param.Value = o.CHECKEDBYID;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iFocalPointId";
        param.Value = o.FOCALPOINTID;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iInitiatorId";
        param.Value = o.INITIATORID;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iTypeId";
        param.Value = o.TYPEID;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iStatusId";
        param.Value = o.STATUSID;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":tPeriodFrom";
        param.Value = o.PERIODFROM;
        param.DbType = DbType.Date;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":tPeriodTo";
        param.Value = o.PERIODTO;
        param.DbType = DbType.Date;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":sJustification";
        param.Value = o.JUSTIFICATION;
        param.DbType = DbType.String;
        param.Size = 2000;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":sThreat";
        param.Value = o.THREAT;
        param.DbType = DbType.String;
        param.Size = 2000;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iVehicleId";
        param.Value = o.VEHICLEID;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":sContractNumberVendor";
        param.Value = o.CONTRACTNOVENDOR;
        param.DbType = DbType.String;
        param.Size = 200;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":sPRNumber";
        param.Value = o.PRNUMBER;
        param.DbType = DbType.String;
        param.Size = 200;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":dPRValue";
        param.Value = o.PRVALUE;
        param.DbType = DbType.Decimal;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":sPONumber";
        param.Value = o.PONUMBER;
        param.DbType = DbType.String;
        param.Size = 200;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":dPOValue";
        param.Value = o.POVALUE;
        param.DbType = DbType.Decimal;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":dCommitment";
        param.Value = o.COMMITMENT;
        param.DbType = DbType.Decimal;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":tDateSubmitted";
        param.Value = DateTime.Today.Date;
        param.DbType = DbType.Date;
        comm.Parameters.Add(param);

        //param = comm.CreateParameter();
        //param.ParameterName = ":sCommitmentNumber";
        //param.Value = o.COMITMNTNO;
        //param.DbType = DbType.String;
        //param.Size = 2000;
        //comm.Parameters.Add(param);

        //param = comm.CreateParameter();
        //param.ParameterName = ":iFacilityId";
        //param.Value = o.FACILITYID;
        //param.DbType = DbType.Int32;
        //comm.Parameters.Add(param);

        //param = comm.CreateParameter();
        //param.ParameterName = ":iAssetId";
        //param.Value = o.ASSETID;
        //param.DbType = DbType.Int32;
        //comm.Parameters.Add(param);

        //param = comm.CreateParameter();
        //param.ParameterName = ":sTeamIndicator";
        //param.Value = o.TEAMINDICATOR;
        //param.DbType = DbType.String;
        //param.Size = 200;
        //comm.Parameters.Add(param);

        //param = comm.CreateParameter();
        //param.ParameterName = ":sCostObjectDesc";
        //param.Value = o.COSTOBJECTDESC;
        //param.DbType = DbType.String;
        //param.Size = 2000;
        //comm.Parameters.Add(param);

        ////param = comm.CreateParameter();
        ////param.ParameterName = ":iCapexOpex";
        ////param.Value = o.CAPEXOPEX;
        ////param.DbType = DbType.Int32;
        ////comm.Parameters.Add(param);

        //param = comm.CreateParameter();
        //param.ParameterName = ":tPrevious";
        //param.Value = o.PREVIOUS;
        //param.DbType = DbType.Date;
        //comm.Parameters.Add(param);

        //param = comm.CreateParameter();
        //param.ParameterName = ":dNappimsNaira";
        //param.Value = o.NAPPIMSNAIRA;
        //param.DbType = DbType.Decimal;
        //comm.Parameters.Add(param);

        //param = comm.CreateParameter();
        //param.ParameterName = ":dNappimsDollar";
        //param.Value = o.NAPPIMSDOLLAR;
        //param.DbType = DbType.Decimal;
        //comm.Parameters.Add(param);

        //param = comm.CreateParameter();
        //param.ParameterName = ":dNappimsFuncDollar";
        //param.Value = o.NAPPIMSFUNCDOLLAR;
        //param.DbType = DbType.Decimal;
        //comm.Parameters.Add(param);

        //param = comm.CreateParameter();
        //param.ParameterName = ":dRequestNaira";
        //param.Value = o.REQUESTNAIRA;
        //param.DbType = DbType.Decimal;
        //comm.Parameters.Add(param);

        //param = comm.CreateParameter();
        //param.ParameterName = ":dRequestDollar";
        //param.Value = o.REQUESTDOLLAR;
        //param.DbType = DbType.Decimal;
        //comm.Parameters.Add(param);

        //param = comm.CreateParameter();
        //param.ParameterName = ":dRequestFuncDollar";
        //param.Value = o.REQUESTFUNCDOLLAR;
        //param.DbType = DbType.Decimal;
        //comm.Parameters.Add(param);

        // result will represent the number of changed rows
        int result = -1;
        try
        {
            // execute the stored procedure
            result = GenericDataAccess.ExecuteNonQuery(comm);
        }
        catch (Exception ex)
        {
            appMonitor.logAppExceptions(ex);
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }
        // result will be 1 in case of success
        return (result != -1);
    }

    public bool UpdateSnepco(Commitments o)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureBongaCC.UpdateCommitmentSnepco();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":lCommitmentId";
        param.Value = o.COMMITMENTID;
        param.DbType = DbType.Int64;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iOuId";
        param.Value = o.IDOU;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":sCostObject";
        param.Value = o.COSTOBJECT;
        param.DbType = DbType.String;
        param.Size = 2000;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":sTitle";
        param.Value = o.TITLE;
        param.DbType = DbType.String;
        param.Size = 2000;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iGroupId";
        param.Value = o.GROUPID;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iTeamId";
        param.Value = o.IDDEPARTMENT;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iSponsorId";
        param.Value = o.SPONSORID;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iCheckedById";
        param.Value = o.CHECKEDBYID;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iFocalPointId";
        param.Value = o.FOCALPOINTID;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iInitiatorId";
        param.Value = o.INITIATORID;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iTypeId";
        param.Value = o.TYPEID;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iStatusId";
        param.Value = o.STATUSID;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":tPeriodFrom";
        param.Value = o.PERIODFROM;
        param.DbType = DbType.Date;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":tPeriodTo";
        param.Value = o.PERIODTO;
        param.DbType = DbType.Date;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":sJustification";
        param.Value = o.JUSTIFICATION;
        param.DbType = DbType.String;
        param.Size = 2000;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":sThreat";
        param.Value = o.THREAT;
        param.DbType = DbType.String;
        param.Size = 2000;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iVehicleId";
        param.Value = o.VEHICLEID;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":sContractNumberVendor";
        param.Value = o.CONTRACTNOVENDOR;
        param.DbType = DbType.String;
        param.Size = 200;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":sPRNumber";
        param.Value = o.PRNUMBER;
        param.DbType = DbType.String;
        param.Size = 200;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":dPRValue";
        param.Value = o.PRVALUE;
        param.DbType = DbType.Decimal;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":sPONumber";
        param.Value = o.PONUMBER;
        param.DbType = DbType.String;
        param.Size = 200;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":dPOValue";
        param.Value = o.POVALUE;
        param.DbType = DbType.Decimal;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":dCommitment";
        param.Value = o.COMMITMENT;
        param.DbType = DbType.Decimal;
        comm.Parameters.Add(param);

        // result will represent the number of changed rows
        int result = -1;
        try
        {
            // execute the stored procedure
            result = GenericDataAccess.ExecuteNonQuery(comm);
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }
        // result will be 1 in case of success
        return (result != -1);
    }

    #endregion


    #region ================== SPDC =============================

    public bool Insert(Commitments o, ref long lCommitmentId, ref string sCommitmentNumber)
    {
        CommitmentIdentity c = CommitmentIdentifier(o.IDOU);
        lCommitmentId = c.lCommitmentID;
        o.COMMITMENTID = c.lCommitmentID;
        o.COMITMNTNO = c.sCommitmentNumber;
        sCommitmentNumber = c.sCommitmentNumber;

        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureBongaCC.InsertCommitment();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":lCommitmentId";
        param.Value = o.COMMITMENTID;
        param.DbType = DbType.Int64;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iOuId";
        param.Value = o.IDOU;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":sCommitmentNumber";
        param.Value = o.COMITMNTNO;
        param.DbType = DbType.String;
        param.Size = 2000;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":sTitle";
        param.Value = o.TITLE;
        param.DbType = DbType.String;
        param.Size = 2000;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":sCostObject";
        param.Value = o.COSTOBJECT;
        param.DbType = DbType.String;
        param.Size = 2000;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iGroupId";
        param.Value = o.GROUPID;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iTeamId";
        param.Value = o.IDDEPARTMENT;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iSponsorId";
        param.Value = o.SPONSORID;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iCheckedById";
        param.Value = o.CHECKEDBYID;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iInitiatorId";
        param.Value = o.INITIATORID;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iTypeId";
        param.Value = o.TYPEID;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iStatusId";
        param.Value = o.STATUSID;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":tPeriodFrom";
        param.Value = o.PERIODFROM;
        param.DbType = DbType.Date;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":tPeriodTo";
        param.Value = o.PERIODTO;
        param.DbType = DbType.Date;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":sJustification";
        param.Value = o.JUSTIFICATION;
        param.DbType = DbType.String;
        param.Size = 2000;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":sThreat";
        param.Value = o.THREAT;
        param.DbType = DbType.String;
        param.Size = 2000;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iVehicleId";
        param.Value = o.VEHICLEID;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":sContractNumberVendor";
        param.Value = o.CONTRACTNOVENDOR;
        param.DbType = DbType.String;
        param.Size = 200;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":sPRNumber";
        param.Value = o.PRNUMBER;
        param.DbType = DbType.String;
        param.Size = 200;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":dPRValue";
        param.Value = o.PRVALUE;
        param.DbType = DbType.Decimal;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":sPONumber";
        param.Value = o.PONUMBER;
        param.DbType = DbType.String;
        param.Size = 200;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":dPOValue";
        param.Value = o.POVALUE;
        param.DbType = DbType.Decimal;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":dCommitment";
        param.Value = o.COMMITMENT;
        param.DbType = DbType.Decimal;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iFacilityId";
        param.Value = o.FACILITYID;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iAssetId";
        param.Value = o.ASSETID;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":sTeamIndicator";
        param.Value = o.TEAMINDICATOR;
        param.DbType = DbType.String;
        param.Size = 200;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":sCostObjectDesc";
        param.Value = o.COSTOBJECTDESC;
        param.DbType = DbType.String;
        param.Size = 2000;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iCapexOpex";
        param.Value = o.CAPEXOPEX;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":tPrevious";
        param.Value = o.PREVIOUS;
        param.DbType = DbType.Date;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":dNappimsNaira";
        param.Value = o.NAPPIMSNAIRA;
        param.DbType = DbType.Decimal;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":dNappimsDollar";
        param.Value = o.NAPPIMSDOLLAR;
        param.DbType = DbType.Decimal;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":dNappimsFuncDollar";
        param.Value = o.NAPPIMSFUNCDOLLAR;
        param.DbType = DbType.Decimal;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":dRequestNaira";
        param.Value = o.REQUESTNAIRA;
        param.DbType = DbType.Decimal;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":dRequestDollar";
        param.Value = o.REQUESTDOLLAR;
        param.DbType = DbType.Decimal;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":dRequestFuncDollar";
        param.Value = o.REQUESTFUNCDOLLAR;
        param.DbType = DbType.Decimal;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":tDateSubmitted";
        param.Value = DateTime.Today.Date;
        param.DbType = DbType.Date;
        comm.Parameters.Add(param);

        // result will represent the number of changed rows
        int result = -1;
        try
        {
            // execute the stored procedure
            result = GenericDataAccess.ExecuteNonQuery(comm);
        }
        catch (Exception ex)
        {
            appMonitor.logAppExceptions(ex);
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }
        // result will be 1 in case of success
        return (result != -1);
    }

    public bool Update(Commitments o)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureBongaCC.UpdateCommitment();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":lCommitmentId";
        param.Value = o.COMMITMENTID;
        param.DbType = DbType.Int64;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iOuId";
        param.Value = o.IDOU;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":sCostObject";
        param.Value = o.COSTOBJECT;
        param.DbType = DbType.String;
        param.Size = 2000;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":sTitle";
        param.Value = o.TITLE;
        param.DbType = DbType.String;
        param.Size = 2000;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iGroupId";
        param.Value = o.GROUPID;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iTeamId";
        param.Value = o.IDDEPARTMENT;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iSponsorId";
        param.Value = o.SPONSORID;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iCheckedById";
        param.Value = o.CHECKEDBYID;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iInitiatorId";
        param.Value = o.INITIATORID;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iTypeId";
        param.Value = o.TYPEID;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iStatusId";
        param.Value = o.STATUSID;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":tPeriodFrom";
        param.Value = o.PERIODFROM;
        param.DbType = DbType.Date;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":tPeriodTo";
        param.Value = o.PERIODTO;
        param.DbType = DbType.Date;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":sJustification";
        param.Value = o.JUSTIFICATION;
        param.DbType = DbType.String;
        param.Size = 2000;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":sThreat";
        param.Value = o.THREAT;
        param.DbType = DbType.String;
        param.Size = 2000;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iVehicleId";
        param.Value = o.VEHICLEID;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":sContractNumberVendor";
        param.Value = o.CONTRACTNOVENDOR;
        param.DbType = DbType.String;
        param.Size = 200;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":sPRNumber";
        param.Value = o.PRNUMBER;
        param.DbType = DbType.String;
        param.Size = 200;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":dPRValue";
        param.Value = o.PRVALUE;
        param.DbType = DbType.Decimal;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":sPONumber";
        param.Value = o.PONUMBER;
        param.DbType = DbType.String;
        param.Size = 200;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":dPOValue";
        param.Value = o.POVALUE;
        param.DbType = DbType.Decimal;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":dCommitment";
        param.Value = o.COMMITMENT;
        param.DbType = DbType.Decimal;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iFacilityId";
        param.Value = o.FACILITYID;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iAssetId";
        param.Value = o.ASSETID;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":sTeamIndicator";
        param.Value = o.TEAMINDICATOR;
        param.DbType = DbType.String;
        param.Size = 200;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":sCostObjectDesc";
        param.Value = o.COSTOBJECTDESC;
        param.DbType = DbType.String;
        param.Size = 2000;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iCapexOpex";
        param.Value = o.CAPEXOPEX;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":tPrevious";
        param.Value = o.PREVIOUS;
        param.DbType = DbType.Date;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":dNappimsNaira";
        param.Value = o.NAPPIMSNAIRA;
        param.DbType = DbType.Decimal;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":dNappimsDollar";
        param.Value = o.NAPPIMSDOLLAR;
        param.DbType = DbType.Decimal;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":dNappimsFuncDollar";
        param.Value = o.NAPPIMSFUNCDOLLAR;
        param.DbType = DbType.Decimal;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":dRequestNaira";
        param.Value = o.REQUESTNAIRA;
        param.DbType = DbType.Decimal;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":dRequestDollar";
        param.Value = o.REQUESTDOLLAR;
        param.DbType = DbType.Decimal;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":dRequestFuncDollar";
        param.Value = o.REQUESTFUNCDOLLAR;
        param.DbType = DbType.Decimal;
        comm.Parameters.Add(param);

        // result will represent the number of changed rows
        int result = -1;
        try
        {
            // execute the stored procedure
            result = GenericDataAccess.ExecuteNonQuery(comm);
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }
        // result will be 1 in case of success
        return (result != -1);
    }

    #endregion

    public bool Update2(Commitments o)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureBongaCC.UpdateCommitment2();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":iApprovalId";
        param.Value = o.APPROVALID;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":iApproverId";
        param.Value = o.APPROVERID;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":sApprovalComments";
        param.Value = o.APPROVALCOMMENT;
        param.DbType = DbType.String;
        param.Size = 2000;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":dSavings";
        param.Value = o.SAVINGS;
        param.DbType = DbType.Decimal;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":lCommitmentId";
        param.Value = o.COMMITMENTID;
        param.DbType = DbType.Int64;
        comm.Parameters.Add(param);

        // result will represent the number of changed rows
        int result = -1;
        try
        {
            // execute the stored procedure
            result = GenericDataAccess.ExecuteNonQuery(comm);
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }
        // result will be 1 in case of success
        return (result != -1);
    }

    public bool RepresentForReview(long lCommitmentId, int iApprovalId)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureBongaCC.RepresentForReview();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":iApprovalId";
        param.Value = iApprovalId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":lCommitmentId";
        param.Value = lCommitmentId;
        param.DbType = DbType.Int64;
        comm.Parameters.Add(param);

        // result will represent the number of changed rows
        int result = -1;
        try
        {
            // execute the stored procedure
            result = GenericDataAccess.ExecuteNonQuery(comm);
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }
        // result will be 1 in case of success
        return (result != -1);
    }


    public DataTable dtGetCommitments()
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureBongaCC.getCommitmentMaster();

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public Commitments objGetCommitmentById(long lCommitmentId)
    {
        DataTable dt = dtGetCommitments().AsEnumerable().Where(t => t.Field<decimal>("COMMITMENTID") == lCommitmentId).CopyToDataTable();

        Commitments o = new Commitments();
        foreach (DataRow dr in dt.Rows)
        {
            o = new Commitments(dr);
        }
        return o;
    }

    public List<Commitments> lstCommitments()
    {
        DataTable dt = dtGetCommitments();

        List<Commitments> o = new List<Commitments>(dt.Rows.Count);
        foreach (DataRow dr in dt.Rows)
        {
            o.Add(new Commitments(dr));
        }
        return o;
    }

    public List<Commitments> lstCommitments(string iOu, DateTime? from, DateTime? to, string iAsset, string iFacility, string iTeam, string iCapexOpex)
    {
        List<Commitments> o = lstCommitments().Where(t => t.IDOU == (!string.IsNullOrEmpty(iOu) ? Convert.ToDecimal(iOu) : 0)
        || t.PERIODFROM == from
        || t.PERIODTO == to
        || t.ASSETID == (!string.IsNullOrEmpty(iAsset) ? Convert.ToDecimal(iAsset) : 0)
        || t.FACILITYID == (!string.IsNullOrEmpty(iFacility) ? Convert.ToDecimal(iFacility) : 0)
        || t.IDDEPARTMENT == (!string.IsNullOrEmpty(iTeam) ? Convert.ToDecimal(iTeam) : 0)
        || t.CAPEXOPEX == (!string.IsNullOrEmpty(iCapexOpex) ? Convert.ToDecimal(iCapexOpex) : 0)).ToList();

        return o;
    }

    public DataTable ToDataTable<T>(IEnumerable<T> items)
    {
        DataTable dataTable = new DataTable(typeof(T).Name);

        //Get all the properties
        PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
        foreach (PropertyInfo prop in Props)
        {
            //Defining type of data column gives proper data table 
            var type = (prop.PropertyType.IsGenericType && prop.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>) ? Nullable.GetUnderlyingType(prop.PropertyType) : prop.PropertyType);
            //Setting column names as Property names
            dataTable.Columns.Add(prop.Name, type);
        }
        foreach (T item in items)
        {
            var values = new object[Props.Length];
            for (int i = 0; i < Props.Length; i++)
            {
                //inserting property values to datatable rows
                values[i] = Props[i].GetValue(item, null);
            }
            dataTable.Rows.Add(values);
        }
        //put a breakpoint here and check datatable
        return dataTable;
    }

    public void ExporttoExcel(List<Commitments> o)
    {
        HttpContext.Current.Response.Clear();
        HttpContext.Current.Response.ClearContent();
        HttpContext.Current.Response.ClearHeaders();
        HttpContext.Current.Response.Buffer = true;
        HttpContext.Current.Response.ContentType = "application/ms-excel";
        HttpContext.Current.Response.Write(@"<!DOCTYPE HTML PUBLIC ""-//W3C//DTD HTML 4.0 Transitional//EN"">");
        HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment;filename=Commitment"+ DateTime.Today.ToShortDateString() + DateTime.Today.ToLongTimeString() + ".xls");

        HttpContext.Current.Response.Charset = "utf-8";
        HttpContext.Current.Response.ContentEncoding = System.Text.Encoding.GetEncoding("windows-1250");
        //sets font
        HttpContext.Current.Response.Write("<font style='font-size:12.0pt; font-family:Calibri;'>");
        HttpContext.Current.Response.Write("<BR><BR><BR>");
        //sets the table border, cell spacing, border color, font of the text, background, foreground, font height
        HttpContext.Current.Response.Write("<table border='1' bgColor='#ffffff' " +
          "borderColor='#000000' cellSpacing='0' cellPadding='0' " +
          "style='font-size:10.0pt; font-family:Calibri; background:white;'>");

        HttpContext.Current.Response.Write("<tr>");
        HttpContext.Current.Response.Write("<td><b>S/No</b></td>");
        HttpContext.Current.Response.Write("<td><b>BCC No</b></td>");
        HttpContext.Current.Response.Write("<td><b>Activity Description</b></td>");
        HttpContext.Current.Response.Write("<td><b>Cost Object</b></td>");
        HttpContext.Current.Response.Write("<td><b>Cost Object Description</b></td>");
        HttpContext.Current.Response.Write("<td><b>Capex/Opex</b></td>");
        HttpContext.Current.Response.Write("<td><b>Facility</b></td>");
        HttpContext.Current.Response.Write("<td><b>Asset</b></td>");
        HttpContext.Current.Response.Write("<td><b>Purchasing Group</b></td>");
        HttpContext.Current.Response.Write("<td><b>Team</b></td>");
        HttpContext.Current.Response.Write("<td><b>Team Indicator</b></td>");
        HttpContext.Current.Response.Write("<td><b>Initiator</b></td>");
        HttpContext.Current.Response.Write("<td><b>Focal Point</b></td>");
        HttpContext.Current.Response.Write("<td><b>Sponsor</b></td>");
        HttpContext.Current.Response.Write("<td><b>Cost Break Down</b></td>");
        HttpContext.Current.Response.Write("<td><b>Checked By</b></td>");
        //HttpContext.Current.Response.Write("<td><b>PR Requestor</b></td>");
        HttpContext.Current.Response.Write("<td><b>PR Approver</b></td>");
        HttpContext.Current.Response.Write("<td><b>Planned/Emmergency</b></td>");
        HttpContext.Current.Response.Write("<td><b>New or Represented</b></td>");
        HttpContext.Current.Response.Write("<td><b>Activity Period(From)</b></td>");
        HttpContext.Current.Response.Write("<td><b>Activity Period(To)</b></td>");
        HttpContext.Current.Response.Write("<td><b>Business Justification</b></td>");
        HttpContext.Current.Response.Write("<td><b>Regrets/Implacation of Non Approval</b></td>");
        HttpContext.Current.Response.Write("<td><b>Contract/Procurement Vehicle</b></td>");
        HttpContext.Current.Response.Write("<td><b>Contract No & Vendor</b></td>");
        HttpContext.Current.Response.Write("<td><b>PR Number</b></td>");
        HttpContext.Current.Response.Write("<td><b>PR Value(F$)</b></td>");
        HttpContext.Current.Response.Write("<td><b>PO Number</b></td>");
        HttpContext.Current.Response.Write("<td><b>PO Value(F$)</b></td>");
        HttpContext.Current.Response.Write("<td><b>Actual + Commitment YTD F$'000</b></td>");
        HttpContext.Current.Response.Write("<td><b>PO/PR Variance(%)</b></td>");
        HttpContext.Current.Response.Write("<td><b>OP16/NAPPIMS SUPPORTED SN'000</b></td>");
        HttpContext.Current.Response.Write("<td><b>OP16/NAPPIMS SUPPORTED S$'000</b></td>");
        HttpContext.Current.Response.Write("<td><b>OP16/NAPPIMS SUPPORTED F$'000</b></td>");
        HttpContext.Current.Response.Write("<td><b>Week's Commitment Request SN'000</b></td>");
        HttpContext.Current.Response.Write("<td><b>Week's Commitment Request S$'000</b></td>");
        HttpContext.Current.Response.Write("<td><b>Week's Commitment Request F$'000</b></td>");
        HttpContext.Current.Response.Write("<td><b>Approval Decision</b></td>");
        HttpContext.Current.Response.Write("<td><b>Approval Decision Comments</b></td>");
        HttpContext.Current.Response.Write("<td><b>Savings($)</b></td>");
        HttpContext.Current.Response.Write("</tr>");

        int i = 1;

        foreach (Commitments oT in o)
        {
            HttpContext.Current.Response.Write("<tr>");

            HttpContext.Current.Response.Write("<td>" + i++ + "</td>");
            HttpContext.Current.Response.Write("<td>" + oT.COMITMNTNO + "</td>");
            HttpContext.Current.Response.Write("<td>" + oT.TITLE + "</td>");

            HttpContext.Current.Response.Write("<td>" + oT.COSTOBJECT + "</td>");

            HttpContext.Current.Response.Write("<td>" + oT.COSTOBJECTDESC + "</td>");
            HttpContext.Current.Response.Write("<td>" + commonEnums.CapexOpexDesc((commonEnums.CapexOpex)oT.CAPEXOPEX) + "</td>");
            HttpContext.Current.Response.Write("<td>" + oT.eFacility.m_sFacility + "</td>");
            HttpContext.Current.Response.Write("<td>" + oT.eAsset.sAsset + "</td>");

            HttpContext.Current.Response.Write("<td>" + oT.eGroup.m_sName + "</td>");

            HttpContext.Current.Response.Write("<td>" + oT.eTeam.m_sTeam + "</td>");
            HttpContext.Current.Response.Write("<td>" + oT.TEAMINDICATOR + "</td>");
            HttpContext.Current.Response.Write("<td>" + oT.eInitiator.m_sFullName + "</td>");
            HttpContext.Current.Response.Write("<td>" + oT.eFocalPoint.m_sFullName + "</td>");
            HttpContext.Current.Response.Write("<td>" + oT.eSponsor.m_sFullName + "</td>");

            HttpContext.Current.Response.Write("<td>");
            List<ActivityDetails> Dtls = oMgt.lstGetActivityDetailsById(oT.COMMITMENTID);

            if (Dtls.Count > 0)
            {
                HttpContext.Current.Response.Write("<Table border='1' bgColor='#ffffff' " +
                  "borderColor='#000000' cellSpacing='0' cellPadding='0' " +
                  "style='font-size:10.0pt; font-family:Calibri; background:white;'>");

                HttpContext.Current.Response.Write("<tr>");
                HttpContext.Current.Response.Write("<td>S/No</td>");
                HttpContext.Current.Response.Write("<td>Description</td>");
                HttpContext.Current.Response.Write("<td>Quantity</td>");
                HttpContext.Current.Response.Write("<td>Rate ($)</td>");
                HttpContext.Current.Response.Write("<td>Amount ($)</td>");
                HttpContext.Current.Response.Write("</tr>");


                int j = 1; decimal dAmount = 0; decimal dTotalAmount = 0;
                foreach (ActivityDetails oD in Dtls)
                {
                    HttpContext.Current.Response.Write("<tr>");
                    HttpContext.Current.Response.Write("<td>" + j++ + "</td>");
                    HttpContext.Current.Response.Write("<td>" + oD.m_sDescription + "</td>");
                    HttpContext.Current.Response.Write("<td>" + stringRoutine.formatAsBankMoney(oD.m_dQuantity) + "</td>");
                    HttpContext.Current.Response.Write("<td>" + stringRoutine.formatAsBankMoney(oD.m_dRate) + "</td>");

                    dAmount = (oD.m_dQuantity * oD.m_dRate);
                    dTotalAmount += dAmount;

                    HttpContext.Current.Response.Write("<td>" + stringRoutine.formatAsBankMoney(dAmount) + "</td>");
                    HttpContext.Current.Response.Write("</tr>");
                }

                HttpContext.Current.Response.Write("<tr>");
                HttpContext.Current.Response.Write("<td></td>");
                HttpContext.Current.Response.Write("<td>Total</td>");
                HttpContext.Current.Response.Write("<td colspan='2'></td>");
                HttpContext.Current.Response.Write("<td>" + stringRoutine.formatAsBankMoney(dTotalAmount) + "</td>");
                HttpContext.Current.Response.Write("</tr>");
                HttpContext.Current.Response.Write("</Table>");
            }

            HttpContext.Current.Response.Write("</td>");

            HttpContext.Current.Response.Write("<td>" + oT.eCheckedBy.m_sFullName + "</td>");
            //HttpContext.Current.Response.Write(oT.eRequestor.m_sFullName);
            HttpContext.Current.Response.Write("<td>" + oT.eApprover.m_sFullName + "</td>");
            HttpContext.Current.Response.Write("<td>" + oT.eEmmergency.m_sType + "</td>");
            HttpContext.Current.Response.Write("<td>" + oT.eStatus.m_sStatus + "</td>");
            HttpContext.Current.Response.Write("<td>" + string.Format("0:dd-MMM-yyyy", oT.PERIODFROM) + "</td>");
            HttpContext.Current.Response.Write("<td>" + string.Format("0:dd-MMM-yyyy", oT.PERIODTO) + "</td>");
            HttpContext.Current.Response.Write("<td>" + oT.JUSTIFICATION + "</td>");
            HttpContext.Current.Response.Write("<td>" + oT.THREAT + "</td>");
            HttpContext.Current.Response.Write("<td>" + oT.eVehicle.m_sName + "</td>");
            HttpContext.Current.Response.Write("<td>" + oT.CONTRACTNOVENDOR + "</td>");
            HttpContext.Current.Response.Write("<td>" + oT.PRNUMBER + "</td>");
            HttpContext.Current.Response.Write("<td>" + stringRoutine.formatAsBankMoney(oT.PRVALUE) + "</td>");
            HttpContext.Current.Response.Write("<td>" + oT.PONUMBER + "</td>");
            HttpContext.Current.Response.Write("<td>" + stringRoutine.formatAsBankMoney(oT.POVALUE) + "</td>");
            HttpContext.Current.Response.Write("<td>" + stringRoutine.formatAsBankMoney(oT.COMMITMENT) + "</td>");
            HttpContext.Current.Response.Write("<td>" + oT.dVariance + "</td>");
            HttpContext.Current.Response.Write("<td>"+ oT.NAPPIMSNAIRA +"</td>");
            HttpContext.Current.Response.Write("<td>" + oT.NAPPIMSDOLLAR + "</td>");
            HttpContext.Current.Response.Write("<td>" + oT.NAPPIMSFUNCDOLLAR + "</td>");
            HttpContext.Current.Response.Write("<td>" + oT.REQUESTNAIRA + "</td>");
            HttpContext.Current.Response.Write("<td>" + oT.REQUESTDOLLAR + "</td>");
            HttpContext.Current.Response.Write("<td>" + oT.REQUESTFUNCDOLLAR + "</td>");
            HttpContext.Current.Response.Write("<td>" + oT.eDecision.m_sDecision + "</td>");
            HttpContext.Current.Response.Write("<td>" + oT.APPROVALCOMMENT + "</td>");
            HttpContext.Current.Response.Write("<td>" + stringRoutine.formatAsBankMoney(oT.SAVINGS) + "</td>");
            HttpContext.Current.Response.Write("</tr>");
        }

        HttpContext.Current.Response.Write("<tr>");
        HttpContext.Current.Response.Write("<td colspan='39'>");
        HttpContext.Current.Response.Write("</td>");
        HttpContext.Current.Response.Write("</tr>");
        HttpContext.Current.Response.Write("</Table>");
        HttpContext.Current.Response.Write("</font>");
        HttpContext.Current.Response.Flush();
        HttpContext.Current.Response.End();
    }

    public List<structUserMailIdx> CommitmentReviewers(Commitments o)
    {
        var receivers = new List<structUserMailIdx>();
        try
        {
            receivers.Add(o.eApprover.structUserIdx);
            receivers.Add(o.eCheckedBy.structUserIdx);
            receivers.Add(o.eFocalPoint.structUserIdx);
            receivers.Add(o.eRequestor.structUserIdx);
            receivers.Add(o.eSponsor.structUserIdx);
            receivers.Add(o.eInitiator.structUserIdx);
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }

        return receivers;
    }

    public List<Commitments> lstCommitmentsByOuId(int iOuId)
    {
        DataTable dt = dtGetCommitments().AsEnumerable().Where(t => t.Field<decimal>("IDOU") == iOuId).CopyToDataTable();

        List<Commitments> o = new List<Commitments>(dt.Rows.Count);
        foreach (DataRow dr in dt.Rows)
        {
            o.Add(new Commitments(dr));
        }
        return o;
    }
}

public class CommitmentDocs
{
    public long m_lDocsId { get; set; }
    public long m_iRequestId { get; set; }
    public byte[] m_bDocs { get; set; }
    public string m_sFileName { get; set; }
    public string m_sFileType { get; set; }

    public CommitmentDocs()
    {
        //
        //
        //
    }

    public CommitmentDocs(DataRow dr)
    {
        m_lDocsId = long.Parse(dr["DOCSID"].ToString());
        m_iRequestId = long.Parse(dr["COMMITMENTID"].ToString());
        m_bDocs = (dr["DOCS"] == DBNull.Value) ? null : (byte[])dr["DOCS"];
        m_sFileName = dr["SFILENAME"].ToString();
        m_sFileType = dr["SFILETYPE"].ToString();
    }
}

public class CommitmentsDocsMgt
{
    public CommitmentsDocsMgt()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public bool CreateCommitmentDocs(long lRequestId, byte[] bBlob, string sFileName, string sFileType)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureBongaCC.InsertRequestDocuments();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":lCommitmentId";
        param.Value = lRequestId;
        param.DbType = DbType.Int64;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":bBlobFile";
        param.Value = bBlob;
        param.OracleDbType = OracleDbType.Blob;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":sFileName";
        param.Value = sFileName;
        param.OracleDbType = OracleDbType.NVarchar2;
        param.Size = 2000;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":sFileType";
        param.Value = sFileType;
        param.OracleDbType = OracleDbType.NVarchar2;
        param.Size = 2000;
        comm.Parameters.Add(param);

        // result will represent the number of changed rows
        int result = -1;
        try
        {
            // execute the stored procedure
            result = GenericDataAccess.ExecuteNonQuery(comm);
        }
        catch (Exception ex)
        {
            //appMonitor.logAppExceptions(ex);
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }
        // result will be 1 in case of success
        return (result != -1);
    }

    public bool UpdateCommitmentDocs(long lDocId, long lRequestId, byte[] bBlob, string sFileName)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureBongaCC.InsertRequestDocuments();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":lCommitmentId";
        param.Value = lRequestId;
        param.DbType = DbType.Int64;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":bBlobFile";
        param.Value = bBlob;
        param.OracleDbType = OracleDbType.Blob;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":sFileName";
        param.Value = sFileName;
        param.OracleDbType = OracleDbType.NVarchar2;
        param.Size = 2000;
        comm.Parameters.Add(param);

        // result will represent the number of changed rows
        int result = -1;
        try
        {
            // execute the stored procedure
            result = GenericDataAccess.ExecuteNonQuery(comm);
        }
        catch (Exception ex)
        {
            //appMonitor.logAppExceptions(ex);
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }
        // result will be 1 in case of success
        return (result != -1);
    }

    public bool deleteDocById(long lDocId)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureBongaCC.DeleteRequestDocuments();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":lDocId";
        param.Value = lDocId;
        param.DbType = DbType.Int64;
        comm.Parameters.Add(param);

        // result will represent the number of changed rows
        int result = -1;
        try
        {
            // execute the stored procedure
            result = GenericDataAccess.ExecuteNonQuery(comm);
        }
        catch (Exception ex)
        {
            //appMonitor.logAppExceptions(ex);
            System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
        }
        // result will be 1 in case of success
        return (result != -1);
    }

    public DataTable dtGetDocsByCommitmentId(long lCommitmentId)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureBongaCC.getRequestDocumentsByRequestId();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":lCommitmentId";
        param.Value = lCommitmentId;
        param.DbType = DbType.Int64;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);

    }

    public DataTable dtGetCommitmentDocByDocId(long lDocId)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureBongaCC.getRequestDocumentByDocId();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":lDocId";
        param.Value = lDocId;
        param.DbType = DbType.Int64;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public CommitmentDocs objGetCommitmentDocByDocId(long lDocsId)
    {
        DataTable dt = dtGetCommitmentDocByDocId(lDocsId);

        var o = new CommitmentDocs();
        foreach (DataRow dr in dt.Rows)
        {
            o = new CommitmentDocs(dr);
        }

        return o;
    }

    public List<CommitmentDocs> RetrieveCommitmentDocsById(long lCommitmentId)
    {
        var o = new List<CommitmentDocs>();

        return o;
    }
}