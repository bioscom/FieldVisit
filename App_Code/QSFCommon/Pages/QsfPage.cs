using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using Telerik.Web;
using Telerik.Web.UI;

namespace Telerik.QuickStart
{
    public class QsfPage : Page
    {
        public QsfPage()
        {
            PreRenderComplete += QsfPage_PreRenderComplete;
            Unload += QsfPage_Unload;
        }

        void QsfPage_Unload(object sender, EventArgs e)
        {
            PreRenderComplete -= QsfPage_PreRenderComplete;
            Unload -= QsfPage_Unload;
        }

        void QsfPage_PreRenderComplete(object sender, EventArgs e)
        {
            ResolveDuplicates();
        }

        public void ResolveDuplicates()
        {
            EmbeddedSkinAttribute[] attrs = GetControlsList();

            var manager = RadStyleSheetManager.GetCurrent(Page);
            var sheets = new List<StyleSheetReference>();

            foreach (var attr in attrs)
            {
                foreach (var styleSheet in manager.StyleSheets)
                {
                    if (Page.ClientScript.IsClientScriptBlockRegistered(attr.Type, styleSheet.Name))
                    {
                        sheets.Add(styleSheet);
                    }
                }
            }

            foreach (var styleSheet in sheets)
            {
                manager.StyleSheets.Remove(styleSheet);
            }
        }

        public EmbeddedSkinAttribute[] GetControlsList()
        {
            return new EmbeddedSkinAttribute[] 
            {
                new Telerik.Web.EmbeddedSkinAttribute("TreeView", typeof(RadTreeView)),
                new Telerik.Web.EmbeddedSkinAttribute("MultiPage", typeof(RadMultiPage)),
                new Telerik.Web.EmbeddedSkinAttribute("ToolBar", typeof(RadToolBar)),
                new Telerik.Web.EmbeddedSkinAttribute("SearchBox", typeof(RadSearchBox)),
            };
        }
    }
}