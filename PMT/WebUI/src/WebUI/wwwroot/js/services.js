var app = app || {};
(function () {
    "use strict";
    app.service = new Queue();
    app.service.baseURL = "http://pmt.me/api";
    app.service.connection.check = false;
    app.service.dataType = "json";
    app.service.type = "POST";
})();
