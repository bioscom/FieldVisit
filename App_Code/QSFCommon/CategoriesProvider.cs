using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;

/// <summary>
/// This class contains a list of categories and the controls in each category
/// </summary>
namespace Telerik.QuickStart
{
    public class CategoriesProvider
    {
        #region Fields

        private static readonly CategoriesProvider _instance = new CategoriesProvider();
        private Dictionary<string, List<string>> _categories;
        private static readonly object _lock = new object();

        #endregion

        #region Constructors

        private CategoriesProvider()
        {

        }

        static CategoriesProvider()
        {

        }

        #endregion

        #region Properties

        public static CategoriesProvider Instance
        {
            get
            {
                return _instance;
            }
        }

        public Dictionary<string, List<string>> Categories
        {
            get
            {
                lock (_lock)
                {
                    if (_categories == null)
                    {
                        _categories = PopulateCategories();
                    }

                    return _categories;
                }
            }
        }

        #endregion

        #region Methods

        private Dictionary<string, List<string>> PopulateCategories()
        {
            XmlDocument categories = new XmlDocument();
            //categories.Load(HttpContext.Current.Server.MapPath("~/Common/Categories.xml"));
            categories.Load(HttpContext.Current.Server.MapPath("~/Common/BongaMR2.xml"));
            Dictionary<string, List<string>> dictionary = new Dictionary<string, List<string>>();

            foreach (XmlNode category in categories.SelectNodes(".//category"))
            {
                string categoryName = category.Attributes["name"].Value;

                dictionary.Add(categoryName, new List<string>());

                foreach (XmlNode example in category.SelectNodes("./control"))
                {
                    dictionary[categoryName].Add(example.Attributes["name"].Value);
                }

                //dictionary[categoryName].Sort();
            }

            return dictionary;
        }

        #endregion
    }
}