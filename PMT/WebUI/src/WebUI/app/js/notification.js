/***************************************************************************
aman:notify
-developer: Carlos A. Perez
-Date: 8/30/2016
-usage: 
        show: app.notify.show("hello","warning");
        show: app.notify("hello");
        hide: app.notify.hide();

-Note: 
        Make sure the 'popupNotification' element ID lives in the DOM
****************************************************************************/
var app = app || {};
(function () {
    "use strict";
    app.notify = {
        popupNotification: null,
        elementId: 'popupNotification',
        show: function (msg, style) {
            try {
                var styleType = style || '';
                if ($("#" + this.elementId).length > 0) {
                    this.popupNotification = $("#" + this.elementId).kendoNotification({
                        autoHideAfter: 5000,
                        //height: 60,
                        //width: 120,
                        stacking: "down",
                        hideOnClick: true,
                        position: {
                            pinned: false,
                            top: 55,
                            left: null,
                            bottom: null,
                            right: 0
                        }
                    }).data("kendoNotification");

                    switch (styleType) {
                        case "success":
                            this.popupNotification.success(msg);
                            break;
                        case "warning":
                            this.popupNotification.warning(msg);
                            break;
                        case "info":
                            this.popupNotification.info(msg);
                            break;
                        default:
                            this.popupNotification.show(msg);
                            break;
                    }

                }
            } catch (err) { }
        },
        hide: function () {
            try {
                if (this.popupNotification) {
                    this.popupNotification.hide();
                }
            } catch (err) { }

        },
    }
})();

