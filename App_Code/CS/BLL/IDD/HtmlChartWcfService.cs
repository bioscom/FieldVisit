using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Web.Script.Serialization;

/// <summary>
/// Summary description for HtmlChartWcfService
/// </summary>
/// 
namespace EIdd
{
    [ServiceContract]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]

    public class HtmlChartWcfService
    {
        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]

        public string getJsonData()
        {
            List<HtmlChartFields> dataSourceJson = new List<HtmlChartFields>();
            dataSourceJson.Add(new HtmlChartFields { Color = "Green", Barrels = 36808, IsExploded = true, Country = "Nigeria" });
            dataSourceJson.Add(new HtmlChartFields { Color = "Gray", Barrels = 16731, IsExploded = false, Country = "Iraq" });
            dataSourceJson.Add(new HtmlChartFields { Color = "Gold", Barrels = 19659, IsExploded = false, Country = "Algeria" });
            dataSourceJson.Add(new HtmlChartFields { Color = "Purple", Barrels = 17986, IsExploded = false, Country = "Angola" });
            dataSourceJson.Add(new HtmlChartFields { Color = "Red", Barrels = 12130, IsExploded = false, Country = "Russia" });

            JavaScriptSerializer oSerializer = new JavaScriptSerializer();
            string sJson = oSerializer.Serialize(dataSourceJson);

            return sJson;

        }

        [DataContract]

        public class HtmlChartFields
        {
            [DataMember]
            public string Color { get; set; }

            [DataMember]
            public int Barrels { get; set; }

            [DataMember]
            public bool IsExploded { get; set; }

            [DataMember]
            public string Country { get; set; }
        }
    }
}