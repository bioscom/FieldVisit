using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Common; using Oracle.ManagedDataAccess.Client;


/// <summary>
/// Summary description for Basedata
/// </summary>
public class Basedata
{
    public int m_iBaseId { get; set; }
    public int m_iDisciplineId { get; set; }
    public int m_iNoOfPersonnel { get; set; }
    public int m_iBaseLoadPerMonth { get; set; }
    
	public Basedata()
	{
		//
		// 
		//
	}

    public Basedata(DataRow dr)
    {
        m_iBaseId = int.Parse(dr["IDBASE"].ToString());
        m_iDisciplineId = int.Parse(dr["IDDISCIPLINE"].ToString());
        m_iNoOfPersonnel = int.Parse(dr["NOOFPERSONNEL"].ToString());
        m_iBaseLoadPerMonth = int.Parse(dr["BASELOADMNT"].ToString());
    }
}

public class BasedataHelper
{
    public BasedataHelper()
    {

    }

    public static DataTable dtGetBaseData()
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureManHour.getBaseData();

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public static bool InsertIntoBaseData(int iDisciplineId, int iNoOfPersonel, int iBaseLoadMnt)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureManHour.InsertBaseData();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":IDDISCIPLINE";
        param.Value = iDisciplineId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":NOOFPERSONNEL";
        param.Value = iNoOfPersonel;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":BASELOADMNT";
        param.Value = iBaseLoadMnt;
        param.DbType = DbType.Int32;
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

    public static bool UpdateBaseData(int iBaseId, int iDisciplineId, int iNoOfPersonel, int iBaseLoadMnt)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureManHour.UpdateBaseData();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":IDBASE";
        param.Value = iBaseId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":IDDISCIPLINE";
        param.Value = iDisciplineId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":NOOFPERSONNEL";
        param.Value = iNoOfPersonel;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = ":BASELOADMNT";
        param.Value = iBaseLoadMnt;
        param.DbType = DbType.Int32;
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


    //public DataTable dtGetDisciplineById(int iDisciplineId)
    //{
    //    OracleCommand comm = GenericDataAccess.CreateCommand();
    //    comm.CommandText = StoredProcedure.getDisciplineById();

    //    OracleParameter param = comm.CreateParameter();
    //    param.ParameterName = ":IDDISCIPLINE";
    //    param.Value = iDisciplineId;
    //    param.DbType = DbType.Int32;
    //    comm.Parameters.Add(param);

    //    return GenericDataAccess.ExecuteSelectCommand(comm);
    //}

    //public Disciplines objGetDisciplineById(int iDisciplineId)
    //{
    //    DataTable dt = dtGetDisciplineById(iDisciplineId);

    //    Disciplines discipln = new Disciplines();
    //    foreach (DataRow dr in dt.Rows)
    //    {
    //        discipln = new Disciplines(dr);
    //    }
    //    return discipln;
    //}

    //public List<Disciplines> lstGetDisciplines()
    //{
    //    DataTable dt = dtGetDisciplines();

    //    List<Disciplines> xRows = new List<Disciplines>(dt.Rows.Count);
    //    foreach (DataRow dr in dt.Rows)
    //    {
    //        xRows.Add(new Disciplines(dr));
    //    }
    //    return xRows;
    //}

}