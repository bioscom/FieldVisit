using System;
using System.Globalization;
using System.Linq;
using System.Collections.Generic;
using System.Web;
using System.Xml;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using Telerik.Web.UI;

namespace Telerik.QuickStart
{
    public class QSFMasterPage : System.Web.UI.MasterPage
    {
        #region Properties

        public RadScriptManager ScriptManager
        {
            get
            {
                return FindControl("QsfScriptManager") as RadScriptManager;
            }
        }

        public Control SkinChooser
        {
            get
            {
                return FindControl("QSFSkinChooser");
            }
        }

        public Control DBResetTimer
        {
            get
            {
                return FindControl("DbResetPanel");
            }
        }

        public HtmlGenericControl DBResetTimeout
        {
            get
            {
                return (HtmlGenericControl)FindControl("qsfResetTimeout");
            }
        }

        public QrCode QrCode
        {
            get
            {
                return (QrCode)FindControl("QrPlaceholder").FindControl("QrCode");
            }
        }

        public string DemoPath
        {
            get
            {
                return (string)(ViewState[QSFConstants.DemoPathLiteral] ?? string.Empty);
            }
            set
            {
                ViewState[QSFConstants.DemoPathLiteral] = value;
            }
        }

        public XmlNode DemoNode
        {
            get
            {
                if (Session[QSFConstants.DemoNodeLiteral] == null)
                {
                    InitializeProperties();
                }

                return (XmlNode)Session[QSFConstants.DemoNodeLiteral];
            }
            set
            {
                Session[QSFConstants.DemoNodeLiteral] = value;
            }
        }

        public XmlNode ControlNode
        {
            get
            {
                if (Session[QSFConstants.ControlNodeLiteral] == null)
                {
                    InitializeProperties();
                }

                return (XmlNode)Session[QSFConstants.ControlNodeLiteral];
            }
            set
            {
                Session[QSFConstants.ControlNodeLiteral] = value;
            }
        }

        public string ControlName
        {
            get
            {
                return (string)(ViewState[QSFConstants.ControlNameLiteral] ?? string.Empty);
            }
            set
            {
                ViewState[QSFConstants.ControlNameLiteral] = value;
            }
        }

        public string CurrentLanguage
        {
            get
            {
                return (string)(Session[QSFConstants.NavigationLanguageLiteral] ?? "CS");
            }

            set
            {
                Session[QSFConstants.NavigationLanguageLiteral] = value;
            }
        }

        public string DemoTitle
        {
            get
            {
                return string.IsNullOrEmpty(DemoNode.Attributes["title"].Value) ? string.Format("ASP.NET {0} Demo - {1}", OriginalControlName, DemoName) :
                    DemoNode.Attributes["title"].Value;
            }
        }

        public string DemoName
        {
            get
            {
                return DemoNode != null ? DemoNode.Attributes["name"].Value : string.Empty;
            }
        }

        public string DemoHeader
        {
            get
            {
                if (DemoNode != null && DemoNode.Attributes["header"] != null)
                {
                    return DemoNode.Attributes["header"].Value;
                }
                else
                {
                    return DemoNode.Attributes["default"] == null ? string.Format("{0} - {1}", OriginalControlName, DemoName) :
                         string.Format("Rad{0} - Telerik ASP.NET {0}", OriginalControlName);
                }
            }
        }

        public string OriginalControlName
        {
            get
            {
                return ControlNode != null ? ControlNode.Attributes["text"].Value : string.Empty;
            }
        }

        public string DemoDescription
        {
            get
            {
                return string.IsNullOrEmpty(DemoNode.Attributes["description"].Value) ? ControlNode.Attributes["description"].Value :
                    DemoNode.Attributes["description"].Value;
            }
        }

        public bool ShowSkinChooserSection
        {
            get
            {
                return DemoNode.Attributes["hideSkinChooser"] == null;
            }
        }

        public bool ShowDBResetTimer
        {
            get
            {
                return DemoNode.Attributes["showDBReset"] != null;
            }
        }

        public bool IsLocal
        {
            get
            {
                return Request.IsLocal;
            }
        }

        public bool IsTracking
        {
            get
            {
#if Tracking
                return true;
#else
                return false;
#endif
            }
        }

        public bool IsNotLocal
        {
            get
            {
                return !Request.IsLocal;
            }
        }

        public bool IsLive
        {
            get
            {
                return Request.Url.OriginalString.StartsWith("http://demos.telerik.com");
            }
        }

        #endregion

        #region Methods

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            if (!Page.IsPostBack)
            {
                Func<string, string> sanitize = (value) =>
                {
                    return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(value);
                };
                InitializeProperties();
                SkinChooser.Visible = ShowSkinChooserSection;
                InitializeResetTimer();
                RegisterScripts();
                Tracker.TrackData(this, FeaturesKeys.FormatFeature(FeaturesKeys.Context.Navigation, sanitize(ControlName)));
                Tracker.TrackData(this, FeaturesKeys.FormatFeature(FeaturesKeys.Context.Demos, sanitize(ControlName), sanitize(DemoName)));
            }
        }

        private void InitializeResetTimer()
        {
            if (ShowDBResetTimer && IsNotLocal)
            {
                DBResetTimer.Visible = true;
                Utility.Instance.InitDbReset(DBResetTimeout);
            }
        }

        private void RegisterScripts()
        {
            if (IsTracking)
            {
                ScriptManager.Scripts.Add(new ScriptReference() { Path = "~/Common/Scripts/qsf-monitor.js" });
            }

            if (DeviceInfoTracker.ShouldTrackDeviceInfo())
            {
                Page.ClientScript.RegisterClientScriptBlock(
                    this.GetType(),
                    "deviceInfoTracker", "var deviceInfoRecorderURL=\"" + ResolveUrl("~/Common/Handlers/DeviceInfoRecorder.ashx") + "\";",
                    true
                );
                ScriptManager.Scripts.Add(new ScriptReference() { Path = "~/Common/Scripts/qsf-device-info-tracker.js" });
            }
        }

        private void InitializeProperties()
        {
            string pathAndQuery = Request.Url.PathAndQuery.ToLower();
            string applicationPath = HttpUtility.UrlPathEncode(Request.ApplicationPath.ToLowerInvariant());
            string path = (applicationPath.IsEqualTo("/") ? pathAndQuery.Substring(1) : pathAndQuery.Replace(applicationPath.ToLower() + "/", string.Empty));

            Action setCurrentLanguage = () =>
            {
                var rawUrl = HttpUtility.UrlPathEncode(Request.RawUrl);
                var index = rawUrl.LastIndexOf(".aspx");

                CurrentLanguage = Request.Url.PathAndQuery.Substring((index - 2), 2).ToUpper();
            };

            Action setDemoPath = () =>
            {
                DemoPath = path.Substring(0, path.IndexOf(string.Format("/default{0}.aspx", CurrentLanguage.ToLower())));
            };

            Action setControlName = () =>
            {
                if (Request.QueryString["product"] != null)
                {
                    ControlName = Request.QueryString["product"].ToString();
                }
                else
                {
                    ControlName = path.Substring(0, path.IndexOf("/")).Replace("-", string.Empty);
                }
            };

            Action setDemoNode = () =>
            {
                XmlNode demoNode = null;

                try
                {
                    if (ControlName.IsEqualTo("controls"))
                    {
                        demoNode = ExamplesProvider.Instance.SearchableExamples
                            .Find(node=> node.Attributes["path"].Value.IsEqualTo(DemoPath));
                    }
                    else {

                        demoNode = ExamplesProvider.Instance.CategoryList
                            .FirstOrDefault(node => node.Attributes["text"].Value.IsEqualTo(ControlName))
                            .SelectSingleNode(string.Format(".//example[translate(@path, 'ABCDEFGHIJKLMNOPQRSTUVWXYZ', 'abcdefghijklmnopqrstuvwxyz')='{0}']", DemoPath.ToLower()));
                    }
                }
                catch (Exception)
                {
                    throw new Exception(string.Format("Control with name: {0} and demo path: {1} does not exists", ControlName, DemoPath));
                }
                finally
                {
                    if (demoNode == null)
                    {
                        throw new Exception(string.Format("Control with name: {0} and demo path: {1} does not exists", ControlName, DemoPath));
                    }
                }


                DemoNode = demoNode;
            };

            Action changeControlName = () =>
            {
                if (DemoNode.Attributes["product"] != null && ControlName.Equals("controls", StringComparison.InvariantCultureIgnoreCase))
                {
                    ControlName = DemoNode.Attributes["product"].Value;
                }
            };

            Action setControlNode = () =>
            {
                XmlNode controlNode = ExamplesProvider.Instance.CategoryList.Find(x => x.Attributes["text"].Value.ToString().IsEqualTo(ControlName));

                if (controlNode == null)
                {
                    throw new Exception(string.Format("Control with name:{0} does not exists", ControlName));
                }

                ControlNode = controlNode;
            };

            setCurrentLanguage();
            setDemoPath();
            setControlName();
            setDemoNode();
            changeControlName();
            setControlNode();
        }

        #endregion
    }
}