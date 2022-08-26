using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Common; using Oracle.ManagedDataAccess.Client;


namespace EIdd
{
    /// <summary>
    /// Summary description for eIDD
    /// </summary>
    public class eIDD
    {
        public eIDD()
        {
            //
            // TODO: Add constructor logic here
            //
        }
    }

    /// <summary>
    /// Summary description for Location
    /// </summary>
    public class Location
    {
        public int m_iLocationId { get; set; }
        public string m_sLocation { get; set; }

        public Location()
        {
            //
            //
            //
        }

        public Location(DataRow dr)
        {
            m_iLocationId = int.Parse(dr["LOCATIONID"].ToString());
            m_sLocation = dr["LOCATION"].ToString();
        }
    }

    public class LocationServices
    {
        public int m_iLocationId { get; set; }
        public int m_iCategoryId { get; set; }
      

        public LocationServices()
        {
            //
            //
            //
        }

        public LocationServices(DataRow dr)
        {
            m_iLocationId = int.Parse(dr["LOCATIONID"].ToString());
            m_iCategoryId = int.Parse(dr["CATEGORYID"].ToString());
        }
    }

    public class Category
    {
        public int m_iCategoryId { get; set; }
        public string m_sCategory { get; set; }
        public int m_iDepartmentId { get; set; }
        public int m_iUserId { get; set; }

        public Category()
        {
            //
            //
            //
        }

        public Category(DataRow dr)
        {
            m_iCategoryId = int.Parse(dr["CATEGORYID"].ToString());
            m_sCategory = dr["CATEGORY"].ToString();
            m_iDepartmentId = int.Parse(dr["DEPTID"].ToString());
            m_iUserId = !string.IsNullOrEmpty(dr["USERID"].ToString()) ? int.Parse(dr["USERID"].ToString()) : 0;
        }
    }

    public class Deparment
    {
        public int m_iDepartmentId { get; set; }
        public string m_sDeparment { get; set; }

        public Deparment()
        {
            //
            //
            //
        }

        public Deparment(DataRow dr)
        {
            m_iDepartmentId = int.Parse(dr["DEPTID"].ToString());
            m_sDeparment = dr["DEPARTMENT"].ToString();
        }
    }

    public class ContractHolders
    {
        public int m_iContractHolderId { get; set; }
        public int m_iUserId { get; set; }
        public int m_iCategoryId { get; set; }

        public ContractHolders()
        {
            //
            //
            //
        }

        public ContractHolders(DataRow dr)
        {
            m_iContractHolderId = int.Parse(dr["CONTRACTHOLDERID"].ToString());
            m_iUserId = int.Parse(dr["USERID"].ToString());
            m_iCategoryId = int.Parse(dr["CATEGORYID"].ToString());
        }
    }

    public class RequestDocs
    {
        public long m_lDocsId { get; set; }
        public long m_iRequestId { get; set; }
        public byte[] m_bDocs { get; set; }
        public string m_sFileName { get; set; }
        public string m_sFileType { get; set; }

        public RequestDocs()
        {
            //
            //
            //
        }

        public RequestDocs(DataRow dr)
        {
            m_lDocsId = long.Parse(dr["DOCSID"].ToString());
            m_iRequestId = long.Parse(dr["REQUESTID"].ToString());
            m_bDocs = (dr["DOCS"] == DBNull.Value) ? null : (byte[]) dr["DOCS"];
            m_sFileName = dr["SFILENAME"].ToString();
            m_sFileType = dr["SFILETYPE"].ToString();
        }
    }

    public class RequestProgressReport
    {
        public long m_lReportId { get; set; }
        public long m_iRequestId { get; set; }
        public int m_iStatus { get; set; }
        public string m_sComments { get; set; }
        public DateTime m_dDateComment { get; set; }
        public int m_iAnalystId { get; set; }

        public RequestProgressReport()
        {
            //
            //
            //
        }

        public RequestProgressReport(DataRow dr)
        {
            m_lReportId = long.Parse(dr["REPORTID"].ToString());
            m_iRequestId = long.Parse(dr["REQUESTID"].ToString());
            m_iStatus = int.Parse(dr["STATUS"].ToString());
            m_sComments = dr["COMMENTS"].ToString();
            m_dDateComment = DateTime.Parse(dr["DATE_COMMENT"].ToString());
            m_iAnalystId = int.Parse(dr["ANALYSTID"].ToString());
        }
    }


    public class Vendors
    {
        public long m_lVendorId { get; set; }
        public string m_sCodes { get; set; }
        public string m_sVendorName { get; set; }
        public DateTime m_dValitiyPeriod { get; set; }
        public string m_sComments { get; set; }
        public int m_iStatus { get; set; }

        public Vendors()
        {
            //
            //
        }

        public Vendors(DataRow dr)
        {
            m_lVendorId = long.Parse(dr["IDVENDOR"].ToString());
            m_sCodes = dr["CODES"].ToString();
            m_sVendorName = dr["VENDORNAME"].ToString();
            m_dValitiyPeriod = DateTime.Parse(dr["VALIDITYPERIOD"].ToString());
            m_sComments = dr["COMMENTS"].ToString();
            m_iStatus = int.Parse(dr["STATUS"].ToString());
        }
    }

    public class AnalystAuditTrail
    {
        public long m_lAuditId { get; set; }
        public long m_lRequestId { get; set; }
        public int m_iAnalystId { get; set; }
        public int m_iStage { get; set; }
        public int m_iStatus { get; set; }
        public string m_sComments { get; set; }
        public DateTime m_dDateComment { get; set; }
        public DateTime m_dDateApproved { get; set; }
        public string m_sApproverComments { get; set; }
        public int m_iApprovalStatus { get; set; }
        public int m_iApproverId { get; set; }

        public AnalystAuditTrail()
        {
            //
            //
        }

        public AnalystAuditTrail(DataRow dr)
        {
            m_lAuditId = long.Parse(dr["AUDITID"].ToString());
            m_lRequestId = long.Parse(dr["REQUESTID"].ToString());
            m_iAnalystId = int.Parse(dr["USERID"].ToString());
            m_iStage = int.Parse(dr["STAGE"].ToString());
            m_iStatus = int.Parse(dr["STATUS"].ToString());
            m_sComments = dr["COMMENTS"].ToString();
            m_dDateComment = (!string.IsNullOrEmpty(dr["DATECOMMENT"].ToString())) ? DateTime.Parse(dr["DATECOMMENT"].ToString()) : DateTime.Today.Date;
            m_dDateApproved = (!string.IsNullOrEmpty(dr["DATEAPPROVED"].ToString())) ? DateTime.Parse(dr["DATEAPPROVED"].ToString()) : DateTime.Today.Date;
            m_sApproverComments = dr["APPROVERCOMMENT"].ToString();
            m_iApprovalStatus = (!string.IsNullOrEmpty(dr["APPROVALSTATUS"].ToString())) ? int.Parse(dr["APPROVALSTATUS"].ToString()) : 0;
            m_iApproverId = (!string.IsNullOrEmpty(dr["APPROVEDBY"].ToString())) ? int.Parse(dr["APPROVEDBY"].ToString()) : 0;
        }
    }




    ///New update to the application Begins here


    public class RequestForIDD
    {
        public long m_lRequestId { get; set; }
        public long m_lVendorId { get; set; }
        public string m_sIDDNo { get; set; }
        public int m_iUserId { get; set; }
        public int m_iCategoryId { get; set; }
        public string m_sVendourCode { get; set; }
        public string m_sRegisteredName { get; set; }
        public string m_sComments { get; set; }
        public int m_iStatus { get; set; }
        public int m_iStage { get; set; }
        public DateTime? m_dDateSubmitted { get; set; }
        public DateTime? m_dValidityPeriod { get; set; }
        public DateTime? m_dDateAssignedToAnalyst { get; set; }
        public int m_iNoR { get; set; }
        public string m_sContractHolder { get; set; }
        public int m_iFocalPointId { get; set; }
        public string m_sFocalPoint { get; set; }
        public int m_iAnalystId { get; set; }
        public string m_sAnalyst { get; set; }
        public string m_sApproverComment { get; set; }

        public string m_sAddress { get; set; }
        public string m_sRepresentative { get; set; }
        public string m_sEmailAddress { get; set; }
        public string m_sTelephoneNumber { get; set; }
        public decimal m_dAmount { get; set; }
        public int m_iGO { get; set; }
        public int m_iGI { get; set; }
        public int m_iVSR { get; set; }

        public RequestForIDD()
        {
            //
            //
            //
        }

        public RequestForIDD(DataRow dr)
        {
            m_lRequestId = long.Parse(dr["REQUESTID"].ToString());
            m_lVendorId = (!string.IsNullOrEmpty(dr["VENDORID"].ToString())) ? long.Parse(dr["VENDORID"].ToString()) : 0;
            m_sIDDNo = dr["IDDNO"].ToString();
            m_sRegisteredName = dr["REGISTEREDNAME"].ToString();
            m_iUserId = int.Parse(dr["USERID"].ToString());
            m_iCategoryId = int.Parse(dr["CATEGORYID"].ToString());
            m_sVendourCode = dr["CODE"].ToString();
            m_sComments = dr["COMMENTS"].ToString();
            m_iStatus = int.Parse(dr["STATUS"].ToString());
            m_iStage = int.Parse(dr["STAGE"].ToString());

            m_dDateSubmitted = (!string.IsNullOrEmpty(dr["DATE_SUBMITTED"].ToString())) ? DateTime.Parse(dr["DATE_SUBMITTED"].ToString()) : (DateTime?)null;
            m_dValidityPeriod = (!string.IsNullOrEmpty(dr["DATESCREENED"].ToString())) ? DateTime.Parse(dr["DATESCREENED"].ToString()) : (DateTime?)null;
            m_dDateAssignedToAnalyst = (!string.IsNullOrEmpty(dr["DATE_ASSIGNED"].ToString())) ? DateTime.Parse(dr["DATE_ASSIGNED"].ToString()) : (DateTime?) null;

            m_iNoR = (!string.IsNullOrEmpty(dr["NOR"].ToString())) ? int.Parse(dr["NOR"].ToString()) : 0;
            m_dAmount = (!string.IsNullOrEmpty(dr["AMOUNT"].ToString())) ? decimal.Parse(dr["AMOUNT"].ToString()) : 0;
            m_iFocalPointId = (!string.IsNullOrEmpty(dr["FOCALPOINTID"].ToString())) ? int.Parse(dr["FOCALPOINTID"].ToString()) : 0;
            m_iAnalystId = (!string.IsNullOrEmpty(dr["ANALYSTID"].ToString())) ? int.Parse(dr["ANALYSTID"].ToString()) : 0;
            m_sApproverComment = dr["APPROVERCOMMENT"].ToString();

            m_sContractHolder = dr["CONTRACTHOLDERFULLNAME"].ToString();
            m_sFocalPoint = dr["FOCALPOINTFULLNAME"].ToString();
            m_sAnalyst = dr["ANALYSTFULLNAME"].ToString();

            m_sAddress = dr["ADDRESS"].ToString();
            m_sRepresentative = dr["REPRESENTATIVE"].ToString();
            m_sEmailAddress = dr["EMAILADDRESS"].ToString();
            m_sTelephoneNumber = dr["TELEPHONENO"].ToString();
            m_iGO = (!string.IsNullOrEmpty(dr["GOE"].ToString())) ? int.Parse(dr["GOE"].ToString()) : 0;
            m_iGI = (!string.IsNullOrEmpty(dr["GI"].ToString())) ? int.Parse(dr["GI"].ToString()) : 0;

            m_iVSR = int.Parse(dr["VSR"].ToString());
        }
    }

    public class ExpiredIdds
    {
        public long m_lRequestId { get; set; }
        public long m_lVendorId { get; set; }

        public ExpiredIdds()
        {
            //
            //
            //
        }

        public ExpiredIdds(DataRow dr)
        {
            m_lRequestId = long.Parse(dr["REQUESTID"].ToString());
            m_lVendorId = (!string.IsNullOrEmpty(dr["VENDORID"].ToString())) ? long.Parse(dr["VENDORID"].ToString()) : 0;
        }
    }

    public class Vendours
    {
        public long m_lVendorId { get; set; }
        public string m_sCodes { get; set; }
        public int m_iCategoryId { get; set; }
        public string m_sRegisteredName { get; set; }
        public string m_sAddress { get; set; }
        public string m_sRepresentative { get; set; }
        public string m_sEmailAddress { get; set; }
        public string m_sTelephoneNumber { get; set; }
        public string m_sIDDNo { get; set; }
        public decimal m_dAmount { get; set; }
        public int m_iGO { get; set; }
        public int m_iGI { get; set; }

        public Vendours()
        {
            //
            //
        }

        public Vendours(DataRow dr)
        {
            m_lVendorId = long.Parse(dr["VENDORID"].ToString());
            m_sCodes = dr["CODE"].ToString();
            m_iCategoryId = int.Parse(dr["CATEGORYID"].ToString());
            m_sRegisteredName = dr["REGISTEREDNAME"].ToString();
            m_sAddress = dr["ADDRESS"].ToString();
            m_sRepresentative = dr["REPRESENTATIVE"].ToString();
            m_sEmailAddress = dr["EMAILADDRESS"].ToString();
            m_sTelephoneNumber = dr["TELEPHONENO"].ToString();
            m_sIDDNo = dr["IDDNO"].ToString();
            m_dAmount = !string.IsNullOrEmpty(dr["AMOUNT"].ToString()) ? decimal.Parse(dr["AMOUNT"].ToString()) : 0;
            m_iGO = (!string.IsNullOrEmpty(dr["GOE"].ToString())) ? int.Parse(dr["GOE"].ToString()) : 0;
            m_iGI = (!string.IsNullOrEmpty(dr["GI"].ToString())) ? int.Parse(dr["GI"].ToString()) : 0;
        }
    }
}