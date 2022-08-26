using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Linq;
using System.Web;
using Telerik.QuickStart;
using Telerik.Web.UI;

namespace Telerik.QuickStart
{
    /// <summary>
    /// Summary description for SkinChooser
    /// </summary>
    public partial class SkinChooser : System.Web.UI.UserControl
    {
        public static string[] Skins
        {
            get
            {
                return new string[] { 
                    "Black",
                    "BlackMetroTouch",
                    "Bootstrap",
                    "Default",
                    "Glow",
                    "Material",
                    "Metro",
                    "MetroTouch",
                    "Office2007",
                    "Office2010Black",
                    "Office2010Blue",
                    "Office2010Silver",
                    "Outlook",
                    "Silk",
                    "Simple",
                    "Sunset",
                    "Telerik",
                    "Vista",
                    "Web20",
                    "WebBlue",
                    "Windows7"
                };
            }
        }

        public string Url
        {
            get
            {
                string url = Request.RawUrl;

                if (Request.QueryString.Count == 0)
                {
                    url += "?skin=";
                }
                else if (Request.QueryString["skin"] == null)
                {
                    url += "&skin=";
                }
                else
                {
                    string[] urlParams = url.Split('?');
                    NameValueCollection queryString = HttpUtility.ParseQueryString(urlParams[1]);
                    queryString.Remove("skin");
                    queryString["skin"] = string.Empty;

                    url = string.Format("{0}?{1}", urlParams[0], queryString.ToString());
                }

                return url;
            }
        }

        public string SelectedSkin
        {
            get
            {
                return (string)Session[QSFConstants.SelectedSkinLiteral] ?? ConfigurationManager.AppSettings["Telerik.Skin"];
            }
            set
            {
                Session[QSFConstants.SelectedSkinLiteral] = value;
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            if (!Page.IsPostBack)
            {
                NameValueCollection queryParameters = HttpUtility.ParseQueryString(Request.QueryString.ToString());

                if (queryParameters["skin"] != null)
                {
                    try
                    {
                        SelectedSkin = Skins.Single<string>(skin => skin.IsEqualTo(queryParameters["skin"]));
                        Tracker.TrackData(this, FeaturesKeys.FormatFeature(FeaturesKeys.Context.Skins, SelectedSkin));
                    }
                    catch (InvalidOperationException)
                    { }
                }

                (FindControl("QsfSkinManager") as RadSkinManager).Skin = SelectedSkin;
            }
        }
    }
}