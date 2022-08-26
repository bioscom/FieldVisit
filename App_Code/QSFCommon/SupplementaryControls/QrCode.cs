using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;


namespace Telerik.QuickStart
{

    /// <summary>
    /// Summary description for QrCode
    /// </summary>
    public class QrCode : Panel
    {
        #region Fields

        private RadBarcode _barcode = new RadBarcode();

        #endregion

        #region Properties

        public string ImageUrl { get; set; }

        public string NavigateUrl { get; set; }

        #endregion

        public QrCode()
        {
            _barcode.Type = BarcodeType.QRCode;
            _barcode.OutputType = BarcodeOutputType.EmbeddedPNG;
            _barcode.QRCodeSettings.Version = 0;
            _barcode.QRCodeSettings.AutoIncreaseVersion = true;
            _barcode.QRCodeSettings.DotSize = 3;
            _barcode.Width = Unit.Empty;
            _barcode.Height = Unit.Empty;

            Controls.Add( _barcode );
        }

        #region Rendering

        protected override void Render(HtmlTextWriter writer)
        {
            if (Visible)
            {
                base.Render(writer);
            }
        }

        public override void RenderBeginTag(HtmlTextWriter writer)
        {
            _barcode.Text = NavigateUrl;

            writer.AddAttribute(HtmlTextWriterAttribute.Class, "demo-qr-code");
            base.RenderBeginTag(writer);
        }

        protected override void RenderContents(HtmlTextWriter writer)
        {
            writer.AddAttribute(HtmlTextWriterAttribute.Href, NavigateUrl);
            writer.AddAttribute(HtmlTextWriterAttribute.Class, "link");
            writer.RenderBeginTag(HtmlTextWriterTag.A);
            {
                base.RenderContents( writer );

                writer.AddAttribute(HtmlTextWriterAttribute.Class, "desc");
                writer.RenderBeginTag(HtmlTextWriterTag.Span);
                writer.Write( "Scan the QR code to test the behavior of our controls on mobile devices." );
                writer.RenderEndTag();
            };
            writer.RenderEndTag();
        }

        #endregion
    }

}