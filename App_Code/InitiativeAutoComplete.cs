using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Script.Services;
using System.Web.Services.Protocols;

/// <summary>
/// Summary description for InitiativeAutoComplete
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
[ScriptService]

public class InitiativeAutoComplete : System.Web.Services.WebService {

    public InitiativeAutoComplete () {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod]
    public string HelloWorld() {
        return "Hello World";
    }


    [WebMethodAttribute()]
    public string[] GetCompletionList(string prefixText, int count, string contextKey)
    {
        List<string> MyItems = new List<string>();

        Initiative oInitiative = new Initiative();
        List<Initiative> Initiatives = oInitiative.lstGetBusinessInitiativeByPrefixText(contextKey);
        foreach (Initiative initiative in Initiatives)
        {
            MyItems.Add(initiative.m_sTitle);
            //MyItems.Add(new ListItem(initiative.m_sTitle, initiative.m_lInitiativeId.ToString()));
        }

        return MyItems.ToArray();
    }
}