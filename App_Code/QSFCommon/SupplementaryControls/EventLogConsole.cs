using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Web.UI;
using System.Web.UI.WebControls;
using EventLog = Telerik.QuickStart.QSFConstants.EventLog;

namespace Telerik.QuickStart
{
    public class EventLogConsole : WebControl, IPostBackDataHandler
    {
        #region Fields

        private string title = QSFConstants.EventLog.Title;
        private const string ClientScript =
            @";function clearLog() {{
                var log = $telerik.$('#{0}').find('ul.{1}');

                log.empty();

                $get('{2}').value = true;
            }};

            function logEvent(text) {{
                var log = $telerik.$('#{0} ul.{1}');

                $telerik.$('<li>'+text+'</li>').appendTo(log);
                log.scrollTop( 100000 );
            }};";

        private const string ScrollScript =
            @";$telerik.$(document).ready(function() {{
                    $telerik.$('#{0}').find('ul.{1}').scrollTop(100000);
                }}
            );";

        #endregion

        #region Properties

        public IList<string> LoggedEvents
        {
            get { return (IList<string>)(ViewState[QSFConstants.LoggedEventsLiteral] ?? (ViewState[QSFConstants.LoggedEventsLiteral] = new List<string>())); }
        }

        [DefaultValue(false)]
        public bool AllowClear
        {
            get { return (bool)(ViewState["AllowClear"] ?? false); }
            set { ViewState["AllowClear"] = value; }
        }

        [DefaultValue(EventLog.Title)]
        public string Title
        {
            get { return title; }
            set { title = value; }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string ClientStateFieldID
        {
            get
            {
                return ClientID + "_ClientState";
            }
        }

        #endregion

        #region IPostBackDataHandler

        bool IPostBackDataHandler.LoadPostData(string postDataKey, NameValueCollection postCollection)
        {
            var clientStateValue = postCollection[ClientStateFieldID];

            if (!clientStateValue.IsEmpty())
            {
                LoggedEvents.Clear();
            }

            return false;
        }

        void IPostBackDataHandler.RaisePostDataChangedEvent()
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Rendering

        protected override void AddAttributesToRender(HtmlTextWriter writer)
        {
            CssClass = string.Join(" ", new string[] { QSFConstants.EventLog.WrapperClassName, CssClass });

            base.AddAttributesToRender(writer);
        }

        protected override HtmlTextWriterTag TagKey
        {
            get { return HtmlTextWriterTag.Div; }
        }

        protected override void RenderContents(HtmlTextWriter writer)
        {
            writer.AddAttribute(HtmlTextWriterAttribute.Class, EventLog.HeadingClassName);
            writer.RenderBeginTag(HtmlTextWriterTag.Div);
            {
                writer.WriteLine(String.Format("<h4>{0}</h4>", Title));

                if (AllowClear)
                {
                    writer.AddAttribute(HtmlTextWriterAttribute.Class, EventLog.ClearLogClassName);
                    writer.AddAttribute(HtmlTextWriterAttribute.Title, EventLog.ClearButtonTitle);
                    writer.AddAttribute(HtmlTextWriterAttribute.Onclick, "javascript:clearLog();");
                    writer.RenderBeginTag(HtmlTextWriterTag.Span);
                    {
                        writer.AddAttribute(HtmlTextWriterAttribute.Class, EventLog.DeleteIconClassName);
                        writer.RenderBeginTag(HtmlTextWriterTag.Span);
                        writer.RenderEndTag();
                    };
                    writer.RenderEndTag();
                }

            };
            writer.RenderEndTag();

            writer.AddAttribute(HtmlTextWriterAttribute.Class, EventLog.ListGroup);
            writer.RenderBeginTag(HtmlTextWriterTag.Ul);
            {
                foreach (string loggedEvent in LoggedEvents)
                {
                    writer.RenderBeginTag(HtmlTextWriterTag.Li);
                    {
                        writer.WriteLine(loggedEvent);
                    }
                    writer.RenderEndTag();
                }
            };

            writer.RenderEndTag();

            RenderClientStateField(writer);
        }

        public virtual void RenderClientStateField(HtmlTextWriter writer)
        {
            writer.AddAttribute(HtmlTextWriterAttribute.Id, ClientStateFieldID);
            writer.AddAttribute(HtmlTextWriterAttribute.Name, ClientStateFieldID);
            writer.AddAttribute(HtmlTextWriterAttribute.Type, "hidden");
            writer.RenderBeginTag(HtmlTextWriterTag.Input);
            writer.RenderEndTag();
        }

        #endregion

        protected override void OnPreRender(System.EventArgs e)
        {
            base.OnPreRender(e);

            Page.RegisterRequiresPostBack(this);

            ScriptManager.RegisterClientScriptBlock(this, GetType(),
                "console-main-script",
                string.Format(ClientScript, ClientID, EventLog.ListGroup, ClientStateFieldID),
                true
                );
            ScriptManager.RegisterStartupScript(this, GetType(),
                "document-ready-script",
                string.Format(ScrollScript, ClientID, EventLog.ListGroup),
                true
                );
        }
    }
}