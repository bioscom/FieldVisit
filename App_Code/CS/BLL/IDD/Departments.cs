using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Common; using Oracle.ManagedDataAccess.Client;

namespace EIdd
{
    /// <summary>
    /// Summary description for Departments
    /// </summary>

    public class DepartmentsMgt
    {
        public DepartmentsMgt()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public DataTable GetDepartments()
        {
            OracleCommand comm = GenericDataAccess.CreateCommand();
            comm.CommandText = StoredProcedureIDD.getDepartments();

            return GenericDataAccess.ExecuteSelectCommand(comm);
        }

        public List<EIdd.Deparment> LstGetDepartments()
        {
            DataTable dt = GetDepartments();

            var o = new List<EIdd.Deparment>(dt.Rows.Count);
            foreach (DataRow dr in dt.Rows)
            {
                o.Add(new EIdd.Deparment(dr));
            }
            return o;
        }
    }
}