using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data.Common; using Oracle.ManagedDataAccess.Client;
using System.Configuration;
using System.Data;
using System.Text;
using System.Web.Script.Serialization;
using System.Web.Script.Services;


[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[System.ComponentModel.ToolboxItem(false)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
[System.Web.Script.Services.ScriptService]

public class wsJQueryDBCall : System.Web.Services.WebService
{
    [WebMethod]
    //[ScriptMethod(ResponseFormat = ResponseFormat.Json, UseHttpGet = false)]
    public List<appUsers> GetUsersByFirstLastName(string UserName)
    {
        StringBuilder sb = new StringBuilder();
        appUsersHelper oAppUsersHelper = new appUsersHelper();
        List<appUsers> lstStaffs = appUsersHelper.lstGetUsersByName(UserName.ToUpper());
        
        return lstStaffs;
    }
}
