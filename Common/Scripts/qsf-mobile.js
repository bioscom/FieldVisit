;(function($, mt) {

    var $demoContainer;
    var firstChild;
    var repaintFlag;

    $(function() {
        var skin = $("#skin").val();
        var $content = $(".tm-view");
        var $overlay = $(".tm-click-overlay");
        var $fontSizeSlider = $(".tm-font-size-slider");

        $("#skin-chooser")
            .find("li.selected")
            .removeClass("selected")
            .end()
            .find("li > a.skin-" + skin)
            .parent()
            .addClass("selected");

        $("#header .tm-button-skinchooser").on("click", function (e) {
            $content.toggleClass("tm-right-drawer-active");
            $overlay.css("left", "0");
        });

        $("#header .tm-button-font-size").on("click", function (e) {
            $(this).toggleClass("tm-button-active");
            $fontSizeSlider.toggleClass("tm-closed");
        });

        $overlay.on("click", function() {
            $content.removeClass("tm-right-drawer-active");
            $overlay.css("left", "-100%");
        });

    });

    mt.onClientLoad = function (sender, args) {
        $demoContainer = $(".demo-container");
        firstChild = $demoContainer.children().get(0);
        repaintFlag = $demoContainer.hasClass( "repaint" ) && firstChild && firstChild.control && "repaint" in firstChild.control;

        $(".tm-font-size-indicator").html(sender.get_value() + " px");
        $demoContainer.css("fontSize", sender.get_value());
    }

    mt.onClientValueChanged = function (sender, args) {
        $(".tm-font-size-indicator").html(args.get_newValue() + " px");
        $demoContainer.css("fontSize", args.get_newValue());

        if ( repaintFlag ) {
            firstChild.control.repaint();
        }
    }

})($telerik.$, window.mt = window.mt || {});