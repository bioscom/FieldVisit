using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using Configurator = Telerik.QuickStart.QSFConstants.Configurator;

namespace Telerik.QuickStart
{
    [ParseChildren(true)]
    public class ConfiguratorPanel : CompositeControl, INamingContainer
    {
        #region Fields

        private RadTabStrip _tabStrip;
        private RadMultiPage _multiPage;
        private ViewsCollection _views;
        private string _title = Configurator.DefaultTitle;

        #endregion

        #region Properties

        internal RadTabCollection Tabs
        {
            get
            {
                EnsureChildControls();
                return _tabStrip.Tabs;
            }
        }

        internal RadPageViewCollection PageViews
        {
            get
            {
                EnsureChildControls();
                return _multiPage.PageViews;
            }
        }

        [PersistenceMode(PersistenceMode.InnerProperty)]
        public ViewsCollection Views 
        {
            get 
            {
                if (_views == null)
                {
                    _views = new ViewsCollection(this);
                }

                return _views;
            }
        }

        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }

        #endregion

        protected override void CreateChildControls()
        {
            Controls.Clear();

            _multiPage = new RadMultiPage() 
            {
                ID = string.Format("multiPage", ID),
                SelectedIndex = 0,
                EnableEmbeddedSkins = false,
                EnableEmbeddedBaseStylesheet = true
            };

            _tabStrip = new RadTabStrip()
            {
                ID = string.Format("tabStrip", ID),
                MultiPageID = _multiPage.ID,
                SelectedIndex = 0,
                Skin = String.Empty,
                CssClass = "nav nav-simple",
                EnableEmbeddedSkins = false,
                EnableEmbeddedBaseStylesheet = true
            };

            Controls.Add(_tabStrip);
            Controls.Add(_multiPage);
        }

        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);

            _tabStrip.Visible = _tabStrip.Tabs.Count > 0;
        }

        #region Rendering

        protected override HtmlTextWriterTag TagKey
        {
            get { return HtmlTextWriterTag.Div; }
        }

        protected override void AddAttributesToRender(HtmlTextWriter writer)
        {
            base.AddAttributesToRender(writer);

            writer.AddAttribute(HtmlTextWriterAttribute.Class, string.Format("{0} {1}", Configurator.WrapperClassName, Configurator.ClassName));
        }

        protected override void RenderContents(HtmlTextWriter writer)
        {
            writer.AddAttribute(HtmlTextWriterAttribute.Class, Configurator.HeadingClassName);
            writer.RenderBeginTag(HtmlTextWriterTag.Div);
            {
                writer.WriteLine(String.Format("<h4>{0}</h4>", Title));
                _tabStrip.RenderControl(writer);
            };
            writer.RenderEndTag();

            writer.AddAttribute(HtmlTextWriterAttribute.Class, string.Format("{0} {1}", Configurator.BodyClassName, Configurator.ColumnsClassName));
            writer.RenderBeginTag(HtmlTextWriterTag.Div);
            {
                _multiPage.RenderControl(writer);
            };
            writer.RenderEndTag();
        }

        #endregion
    }

    public class ViewsCollection : ControlCollection
    {
        private ConfiguratorPanel _panel;

        public ViewsCollection(ConfiguratorPanel panel)
            : base(panel)
        {
            _panel = panel;
        }

        public void Add(View view)
        {
            base.Add(view);

            if (!string.IsNullOrEmpty(view.Title))
            {
                _panel.Tabs.Add(new RadTab(view.Title));
            }

            _panel.PageViews.Add(view);
        }

        public new View this[int index]
        {
            get { return base[index] as View; }
        }
    }

    [ToolboxItem(false)]
    public class View : RadPageView
    {
        public string Title
        {
            get;
            set;
        }
    }
}