using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Common; using Oracle.ManagedDataAccess.Client;


namespace EIdd
{
    /// <summary>
    /// Summary description for ContractHolders
    /// </summary>
    public class ContractHoldersMgt
    {
        public ContractHoldersMgt()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public DataTable GetContractHolders()
        {
            OracleCommand comm = GenericDataAccess.CreateCommand();
            comm.CommandText = StoredProcedureIDD.getContractHolders();

            return GenericDataAccess.ExecuteSelectCommand(comm);
        }

        public bool CreateContractHolder(int iUserId, int iCategoryId)
        {
            OracleCommand comm = GenericDataAccess.CreateCommand();
            comm.CommandText = StoredProcedureIDD.CreateContractHolder();

            OracleParameter param = comm.CreateParameter();
            param.ParameterName = ":iUserId";
            param.Value = iUserId;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = ":iCategoryId";
            param.Value = iCategoryId;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);

            int result = -1;

            try
            {
                // execute the stored procedure
                result = GenericDataAccess.ExecuteNonQuery(comm);
            }
            catch (Exception ex)
            {
                // any errors are logged in GenericDataAccess, we ignore them here
                System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
            }
            // result will be 1 in case of success
            return (result != -1);
        }

        public bool RemoveContractHolder(int iUserId)
        {
            OracleCommand comm = GenericDataAccess.CreateCommand();
            comm.CommandText = StoredProcedureIDD.RemoveContractHolder();

            OracleParameter param = comm.CreateParameter();
            param.ParameterName = ":iUserId";
            param.Value = iUserId;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);

            int result = -1;

            try
            {
                // execute the stored procedure
                result = GenericDataAccess.ExecuteNonQuery(comm);
            }
            catch (Exception ex)
            {
                // any errors are logged in GenericDataAccess, we ignore them here
                System.Diagnostics.Debug.Fail(ex.TargetSite.Name + "\n \n" + ex.StackTrace + "\n \n" + ex.Message.ToString());
            }
            // result will be 1 in case of success
            return (result != -1);
        }


        public DataTable GetContractHoldersByLocationCategory(int iLocationId, int iCategoryId)
        {
            OracleCommand comm = GenericDataAccess.CreateCommand();
            comm.CommandText = StoredProcedureIDD.getContractHoldersByLocationCategory();

            OracleParameter param = comm.CreateParameter();
            param.ParameterName = ":iLocationId";
            param.Value = iLocationId;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = ":iCategoryId";
            param.Value = iCategoryId;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);

            return GenericDataAccess.ExecuteSelectCommand(comm);
        }

        public DataTable GetContractHoldersByLocation(int iLocationId)
        {
            OracleCommand comm = GenericDataAccess.CreateCommand();
            comm.CommandText = StoredProcedureIDD.getContractHoldersByLocation();

            OracleParameter param = comm.CreateParameter();
            param.ParameterName = ":iLocationId";
            param.Value = iLocationId;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);

            return GenericDataAccess.ExecuteSelectCommand(comm);
        }

        public List<EIdd.ContractHolders> LstGetContractHoldersByLocationCategory(int iLocationId, int iCategoryId)
        {
            DataTable dt = GetContractHoldersByLocationCategory(iLocationId, iCategoryId);

            var o = new List<EIdd.ContractHolders>(dt.Rows.Count);
            foreach (DataRow dr in dt.Rows)
            {
                o.Add(new EIdd.ContractHolders(dr));
            }
            return o;
        }

        public DataTable GetContractHoldersByUserId(int iUserId)
        {
            OracleCommand comm = GenericDataAccess.CreateCommand();
            comm.CommandText = StoredProcedureIDD.getContractHoldersByUserId();

            OracleParameter param = comm.CreateParameter();
            param.ParameterName = ":iUserId";
            param.Value = iUserId;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);

            return GenericDataAccess.ExecuteSelectCommand(comm);
        }

        public EIdd.ContractHolders objGetContractHoldersByUserId(int iUserId)
        {
            DataTable dt = GetContractHoldersByUserId(iUserId);

            var o = new EIdd.ContractHolders();
            foreach (DataRow dr in dt.Rows)
            {
                o = new EIdd.ContractHolders(dr);
            }

            return o;
        }
    }
}