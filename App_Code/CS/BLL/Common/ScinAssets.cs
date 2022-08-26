using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Common; using Oracle.ManagedDataAccess.Client;

/// <summary>
/// Summary description for AllAssets
/// </summary>
/// 

namespace Common
{
    public class ScinAssets
    {
        public int m_iAsset { get; set; }
        public string m_sAsset { get; set; }

        public ScinAssets()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public ScinAssets(DataRow dr)
        {
            m_iAsset = int.Parse(dr["ASSETID"].ToString());
            m_sAsset = dr["ASSET"].ToString();
        }

        public ScinAssets(int m_iAsset, string m_sAsset)
        {
            this.m_iAsset = m_iAsset;
            this.m_sAsset = m_sAsset;
        }
    }

    public class AssetFacilities
    {
        public int m_iAsset { get; set; }
        public int m_iFacility { get; set; }
        public string m_sFacility { get; set; }
        public string m_sLocation { get; set; }

        public AssetFacilities()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public AssetFacilities(DataRow dr)
        {
            m_iAsset = int.Parse(dr["ASSETID"].ToString());
            m_iFacility = int.Parse(dr["FACILITYID"].ToString());
            m_sFacility = dr["FACILITY"].ToString();
            m_sLocation = dr["LOCATION"].ToString();
        }

        public AssetFacilities(int m_iAsset, int m_iFacility, string m_sFacility, string m_sLocation)
        {
            this.m_iAsset = m_iAsset;
            this.m_iFacility = m_iFacility;
            this.m_sFacility = m_sFacility;
            this.m_sLocation = m_sLocation;
        }
    }
}