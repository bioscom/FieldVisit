using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI.WebControls;
using System.Web.UI;
using MessageBoxConstants = Telerik.QuickStart.QSFConstants.MessageBox;

namespace Telerik.QuickStart
{

    /// <summary>
    /// This enumerator defines the message box type
    /// </summary>
    public enum MessageType
    {
        General = 0,
        Info = 1,
        Warning = 2,
        Mute = 3
    }

    /// <summary>
    /// This enumerator defines the icon type
    /// </summary>
    public enum IconType
    {
        None = 0,
        Info = 1,
        Accessibility = 2,
        Warning = 3,
        DBReset = 4,
        Folder = 5
    }

    /// <summary>
    /// Message class represents a simple panel with three types of images, one for general information, 
    /// one for accessibility info and one for db reset timer.
    /// </summary>
    public class MessageBox : Panel
    {

        #region Fields

        private readonly string[] WrapperClassNames = new string[] {
            MessageBoxConstants.TypeGeneralClassName,
            MessageBoxConstants.TypeInfoClassName,
            MessageBoxConstants.TypeWarningClassName,
            MessageBoxConstants.TypeMuteClassName
        };

        private readonly string[] IconClassNames = new string[] {
            String.Empty,
            MessageBoxConstants.IconInfoClassName,
            MessageBoxConstants.IconAccessibilityClassName,
            MessageBoxConstants.IconWarningClassName,
            MessageBoxConstants.IconDbResetClassName,
            MessageBoxConstants.IconFolderClassName
        };

        #endregion

        #region Properties

        public String Title { get; set; }

        public MessageType Type { get; set; }

        public IconType Icon { get; set; }

        #endregion

        #region Methods

        public override void RenderBeginTag(HtmlTextWriter writer)
        {
            var ClassNames = new string[] {
                MessageBoxConstants.WrapperClassName,
                WrapperClassNames[(int) Type]
            };
            writer.AddAttribute(HtmlTextWriterAttribute.Class, String.Join(" ", ClassNames ));
            base.RenderBeginTag(writer);
        }

        protected override void RenderContents(HtmlTextWriter writer)
        {

            if (Icon != IconType.None)
            {
                writer.AddAttribute(HtmlTextWriterAttribute.Class, "icon " + IconClassNames[(int) Icon]);
                writer.RenderBeginTag(HtmlTextWriterTag.Span);
                writer.RenderEndTag();
            }

            writer.AddAttribute(HtmlTextWriterAttribute.Class, "message");
            writer.RenderBeginTag(HtmlTextWriterTag.Div);
            {
                if (!String.IsNullOrWhiteSpace(Title))
                {
                    writer.RenderBeginTag(HtmlTextWriterTag.H4);
                    writer.Write(Title);
                    writer.RenderEndTag();
                }

                base.RenderContents(writer);
            };
            writer.RenderEndTag();
        }

        #endregion
    }
}