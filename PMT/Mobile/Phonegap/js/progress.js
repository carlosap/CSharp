/***************************************************************************
aman:progress
-developer: Carlos A. Perez
-Date: 8/31/2016
-usage: 
        show: app.progress.show(2); - shows loader for 2 secs
        show: app.progress.show();  - shows loader until hide() fuction
        hide: app.progress.hide();  - hides and releases the UI

-Note: 
        Make sure the 'document.body' centers to the body
****************************************************************************/
var app = app || {};
(function () {
    "use strict";
    app.progress = {
        target: '',
        show: function (seconds) {
            try {
                var milliSeconds = seconds || 0;
                var element = $(document.body);
                kendo.ui.progress(element, true);
                if(milliSeconds > 0){
                    milliSeconds = seconds * 1000;
                    setTimeout(function () {
                        kendo.ui.progress(element, false);
                    }, milliSeconds);
                }

            } catch (err) { }
        },
        hide: function () {
            try {
                 var element = $(document.body);
                 kendo.ui.progress(element, false);
            } catch (err) { }
        },
    }
})();

