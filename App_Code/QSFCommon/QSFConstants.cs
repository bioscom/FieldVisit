using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// This Class contains all constants used across the QSF.
/// </summary>
namespace Telerik.QuickStart
{
    public static class QSFConstants
    {
        public const string SearchableExamples = "SearchableExamples";
        public const string Categories = "Categories";
        public const string MobileExamples = "MobileExamples";
        public const string NavigationLanguageLiteral = "navigationLanguage";
        public const string DemoPathLiteral = "demoPath";
        public const string ControlNameLiteral = "controlName";
        public const string DemoNodeLiteral = "demoNode";
        public const string ControlNodeLiteral = "controlNode";
        public const string SelectedSkinLiteral = "selectedSkin";
        public const string LoggedEventsLiteral = "LoggedEvents";
        public const string Header = "UI for ASP.NET AJAX";
        public const string HeaderLiteral = "Header";

        public static class ClassNames
        {
            public const string IsNew = "new";
            public const string isUpdated = "updated";
            public const string DemoCategory = "rtCategory";
            public const string ControlsCategory = "rtRootNode";
        }

        public static class Configurator
        {
            public const string DefaultTitle = "Demo Configurator";
            public const string ClassName = "configurator";
            public const string WrapperClassName = "panel";
            public const string HeadingClassName = "panel-heading";
            public const string BodyClassName = "panel-body";
            public const string ColumnsClassName = "columns";
        }

        public static class ConfiguratorColumn
        {
            public const string WrapperClassName = "col";
            public const string ThinClassName = "col-thin";
            public const string NarrowClassName = "col-narrow";
            public const string MediumClassName = "col-medium";
            public const string WideClassName = "col-wide";
        }

        public static class MessageBox
        {
            public const string WrapperClassName = "message-box";
            public const string TypeGeneralClassName = "message-general";
            public const string TypeInfoClassName = "message-info";
            public const string TypeWarningClassName = "message-warning";
            public const string TypeMuteClassName = "message-mute";
            public const string IconInfoClassName = "icon-info";
            public const string IconAccessibilityClassName = "icon-accessibility";
            public const string IconWarningClassName = "icon-warning";
            public const string IconDbResetClassName = "icon-db-reset";
            public const string IconFolderClassName = "icon-folder";
        }

        public static class EventLog
        {
            public const string Title = "Event log";
            public const string ClearButtonTitle = "Clear log";
            public const string WrapperClassName = "panel event-log";
            public const string HeadingClassName = "panel-heading";
            public const string ListGroup = "list-group";
            public const string ClearLogClassName = "console-button";
            public const string DeleteIconClassName = "icon icon-delete";
        }
    }
}