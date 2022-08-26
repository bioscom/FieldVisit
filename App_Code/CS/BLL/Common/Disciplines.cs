using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Common; using Oracle.ManagedDataAccess.Client;


/// <summary>
/// Summary description for Disciplines
/// </summary>
public class Disciplines
{
    public int m_iDisciplineId { get; set; }
    public string m_sDiscipline { get; set; }
    public string m_sDescription { get; set; }
    //public int m_iNoofStaff { get; set; }
    //public int m_iMaxWkHr { get; set; }

	public Disciplines()
	{
		//
		// 
		//
	}

    public Disciplines(DataRow dr)
    {
        m_iDisciplineId = int.Parse(dr["IDDISCIPLINE"].ToString());
        m_sDiscipline = dr["DISCIPLINE"].ToString();
        m_sDescription = dr["DESCRIPTION"].ToString();
        //m_iNoofStaff = (dr["NOOFSTAFF"].ToString() != "" ? int.Parse(dr["NOOFSTAFF"].ToString()) : 0);
        //m_iMaxWkHr = (dr["MAXWRHR"].ToString() != "" ? int.Parse(dr["MAXWRHR"].ToString()) : 0);
    }

    public DataTable dtGetDisciplines()
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureManHour.getDisciplines();

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public DataTable dtGetDisciplineById(int iDisciplineId)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedureManHour.getDisciplineById();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":IDDISCIPLINE";
        param.Value = iDisciplineId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public Disciplines objGetDisciplineById(int iDisciplineId)
    {
        DataTable dt = dtGetDisciplineById(iDisciplineId);

        Disciplines discipln = new Disciplines();
        foreach (DataRow dr in dt.Rows)
        {
            discipln = new Disciplines(dr);
        }
        return discipln;
    }

    public List<Disciplines> lstGetDisciplines()
    {
        DataTable dt = dtGetDisciplines();

        List<Disciplines> xRows = new List<Disciplines>(dt.Rows.Count);
        foreach (DataRow dr in dt.Rows)
        {
            xRows.Add(new Disciplines(dr));
        }
        return xRows;
    }
}