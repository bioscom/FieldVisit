using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Common; using Oracle.ManagedDataAccess.Client;


namespace EIdd
{
    /// <summary>
    /// Summary description for Locations
    /// </summary>
    public class Locations
    {
        public Locations()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public DataTable GetLocations()
        {
            OracleCommand comm = GenericDataAccess.CreateCommand();
            comm.CommandText = StoredProcedureIDD.getLocations();

            return GenericDataAccess.ExecuteSelectCommand(comm);
        }

        public List<Location> LstGetLocations()
        {
            DataTable dt = GetLocations();

            var o = new List<Location>(dt.Rows.Count);
            foreach (DataRow dr in dt.Rows)
            {
                o.Add(new Location(dr));
            }
            return o;
        }
    }
}