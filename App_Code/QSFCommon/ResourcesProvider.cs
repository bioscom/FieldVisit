using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;

/// <summary>
/// This class contains a list of resource (links to documentation, CL, KB, etc.) per control.
/// </summary>
namespace Telerik.QuickStart
{
    public class ResourcesProvider
    {
        #region Fields

        private static readonly ResourcesProvider _instance = new ResourcesProvider();
        private Dictionary<string, Dictionary<string, string>> _resources;
        private static readonly object _lock = new object();

        #endregion

        #region Constructors

        private ResourcesProvider()
        {
        }

        static ResourcesProvider()
        {

        }

        #endregion

        #region Properties

        public static ResourcesProvider Instance
        {
            get
            {
                return _instance;
            }
        }

        private Dictionary<string, Dictionary<string, string>> Resources
        {
            get
            {
                lock (_lock)
                {
                    if (_resources == null)
                    {
                        _resources = PopulateResources();
                    }

                    return _resources;
                }
            }
        }

        #endregion

        #region Methods

        public Dictionary<string, Dictionary<string, string>> PopulateResources()
        {
            XmlDocument categories = new XmlDocument();
            categories.Load(HttpContext.Current.Server.MapPath("~/Common/Resources.xml"));
            Dictionary<string, Dictionary<string, string>> dictionary = new Dictionary<string, Dictionary<string, string>>();

            foreach (XmlNode control in categories.SelectNodes(".//control"))
            {
                string categoryName = control.InnerText;

                dictionary.Add(categoryName, new Dictionary<string, string>());

                foreach (XmlAttribute attribute in control.Attributes)
                {
                    dictionary[categoryName].Add(attribute.Name, attribute.Value);
                }
            }

            return dictionary;
        }

        public Dictionary<string, string> ControlResources(string controlName)
        {
            return Resources.ContainsKey(controlName) ? Resources[controlName] : null;
        }

        #endregion
    }
}