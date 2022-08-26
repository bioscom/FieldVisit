using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Caching;
using System.Xml;

/// <summary>
/// This class initialize the runtime cache with the data from Examples.xml. It is used in the Global.asax
/// </summary>
namespace Telerik.QuickStart
{
    public sealed class ExamplesProvider
    {
        #region Fields

        private static readonly ExamplesProvider _instance = new ExamplesProvider();

        #endregion

        #region Constructors

        static ExamplesProvider()
        {
        }

        private ExamplesProvider()
        {
        }

        #endregion

        #region Properties

        public static ExamplesProvider Instance
        {
            get
            {
                return _instance;
            }
        }

        public List<XmlNode> SearchableExamples
        {
            get
            {
                List<XmlNode> exampleList = (List<XmlNode>)HttpRuntime.Cache[QSFConstants.SearchableExamples];

                if (exampleList == null)
                {
                    exampleList = InitializeCache(QSFConstants.SearchableExamples);
                }

                return exampleList;
            }
        }

        public List<XmlNode> CategoryList
        {
            get
            {
                List<XmlNode> categoryList = (List<XmlNode>)HttpRuntime.Cache[QSFConstants.Categories];

                if (categoryList == null)
                {
                    categoryList = InitializeCache(QSFConstants.Categories);
                }

                return categoryList;
            }
        }

        public List<XmlNode> MobileExamples
        {
            get
            {
                List<XmlNode> categoryList = (List<XmlNode>)HttpRuntime.Cache[QSFConstants.MobileExamples];

                if (categoryList == null)
                {
                    categoryList = InitializeCache(QSFConstants.MobileExamples);
                }

                return categoryList;
            }
        }

        #endregion

        #region Methods

        public void InitializeRuntimeCache()
        {
            XmlDocument examples = new XmlDocument();
            examples.Load(HttpContext.Current.Server.MapPath("~/Common/Examples.xml"));

            foreach (XmlNode category in examples.SelectNodes("/examples/category[not(@private)]"))
            {
                CategoryList.Add(category);

                foreach (XmlNode example in category.SelectNodes(".//example[not(@private)]"))
                {
                    SearchableExamples.Add(example);
                }
            }

            examples.Load(HttpContext.Current.Server.MapPath("~/Common/MobileExamples.xml"));

            foreach (XmlNode mobileExample in examples.SelectNodes("/examples/category"))
            {
                MobileExamples.Add(mobileExample);
            }
        }

        private List<XmlNode> InitializeCache(string cacheKey)
        {
            DateTime absoluteExpiration = DateTime.Now.AddYears(1);
            List<XmlNode> list = new List<XmlNode>();
            HttpRuntime.Cache.Add(
            cacheKey,
            list,
            null,
            absoluteExpiration,
            Cache.NoSlidingExpiration,
            CacheItemPriority.NotRemovable,
            null);

            return list;
        }

        #endregion
    }
}