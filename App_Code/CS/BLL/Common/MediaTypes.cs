using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Common; using Oracle.ManagedDataAccess.Client;

/// <summary>
/// Summary description for MediaTypes
/// </summary>
public class MediaTypes
{
    public int m_iMediaId { get; set; }
    public string m_sMedia { get; set; }
    public string m_sMediaExt { get; set; }


    public MediaTypes()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public MediaTypes(DataRow dr)
    {
        m_iMediaId = int.Parse(dr["MEDIAID"].ToString());
        m_sMedia = dr["MEDIA"].ToString();
        m_sMediaExt = dr["EXTENSION"].ToString();
    }

}

public class MediaTypesMgt
{
    public MediaTypesMgt()
    {

    }

    public DataTable dtGetMediaTypes()
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedure.getMediaTypes();

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public DataTable dtGetMediaTypeByMedia(string sMedia)
    {
        OracleCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = StoredProcedure.getMediaTypeByMedia();

        OracleParameter param = comm.CreateParameter();
        param.ParameterName = ":sMedia";
        param.Value = sMedia;
        param.DbType = DbType.String;
        param.Size = 1000;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public MediaTypes objGetMediaType(string sMedia)
    {
        DataTable dt = dtGetMediaTypeByMedia(sMedia);

        var media = new MediaTypes();
        foreach (DataRow dr in dt.Rows)
        {
            media = new MediaTypes(dr);
        }
        return media;
    }

}