/***************************************************************************
aman:service
-developer: Carlos A. Perez
-Date: 9/21/2016
-usage: Use this class for any remote server communications.
        -Add an Observable obj and call by trigger
        -user.trigger("addUser", { data: "data" });
        -app.service.user.trigger("addUser",{data:"hello"});

-todo: add dynamic env check
       prod- baseURL = "http://pmtwebapi.azurewebsites.net/api";
****************************************************************************/
var app = app || {};
(function () {
    "use strict";
    app.service = {
        dbBaseUrl: 'http://pmtdb.azurewebsites.net/api',
        failures: [],
        q: new kendo.Observable(),
        user: new kendo.Observable(),
        Limits: new kendo.Observable()
    }
    //--------------User Create-------------------------------------------->
    app.service.user.bind("create", function (e) {
        try {
            var user = e.data;
            var url = app.service.dbBaseUrl + '/adduserclient?firstname=' + user.firstname +
                '&lastname=' + user.lastname +
                '&email=' + user.email +
                '&tel=' + user.phone +
                '&emailenable=' + user.enableSendEmail +
                '&textenable=' + user.enableSendText
            $.get(url);
        } catch (error) { }
    });
    app.service.user.bind("read", function (e) {
        try {
            var users = [];
            var url = app.service.dbBaseUrl + '/getuserclients?take=20';
            app.progress.show();
            $.get(url, function (data) {
                if (data.length) {
                    data.forEach(function (item) {
                        var user = {
                            firstname: item.firstName,
                            lastname: item.lastName,
                            email: item.email,
                            phone: item.phone,
                            enableSendEmail: item.emailEnable,
                            enableSendText: item.textEnable
                        }
                        users.push(user);
                    });
                    app.cache.localSet("users", users);
                } else {
                    app.cache.localSet("users", []);
                }
            }).fail(function () {
                var failure = {
                    name: 'user:read',
                    type: 'ajax',
                    msg: '',
                    url: this.url
                }
                app.service.failures.push(failure);
                app.cache.localSet("users", []);
            }).always(function () {
                app.progress.hide();
            });

        } catch (error) { }
    });

    app.service.user.bind("update", function (e) {
        try {
            var user = e.data;
            var url = app.service.dbBaseUrl + '/updateuserclient?firstname=' + user.firstname +
                '&lastname=' + user.lastname +
                '&email=' + user.email +
                '&tel=' + user.phone +
                '&emailenable=' + user.enableSendEmail +
                '&textenable=' + user.enableSendText

            $.get(url);
        } catch (error) { }
    });

    app.service.user.bind("delete", function (e) {
        try {
            var user = e.data;
            var url = app.service.dbBaseUrl + '/deleteuserclient?email=' + user.email;
            $.get(url);
        } catch (error) { }
    });

    //--------------Limits Create-------------------------------------------->

    app.service.Limits.bind("humidity", function (e) {
        try {
            var limit = e.data;
            var url = app.service.dbBaseUrl + '/updatehumidity?name=TESTBETA123' +
                '&max=' + limit.max +
                '&min=' + limit.min +
                '&msg=' + limit.msg
            $.get(url);
        } catch (error) { }
    });
    app.service.Limits.bind("get:humidity", function (e) {
        try {
            var limit = {};
            var url = app.service.dbBaseUrl + '/gethumidity?name=TESTBETA123';
            $.get(url, function (data) {
                if (!app.utils.isNullUndefOrEmpty(data)) {
                    var humidity = {
                        min: data.low,
                        max: data.max,
                        msg: data.msg,
                    }
                    app.cache.localSet("humidity", humidity);
                } else {
                    app.cache.localSet("humidity", {});
                }
            }).fail(function () {
                var failure = {
                    name: 'get:humidity',
                    type: 'ajax',
                    msg: '',
                    url: this.url
                }
                app.service.failures.push(failure);
                app.cache.localSet("humidity", {});
            }).always(function () {
                app.progress.hide();
            });

        } catch (error) { }
    });

    app.service.Limits.bind("voc", function (e) {
        try {
            var limit = e.data;
            var url = app.service.dbBaseUrl + '/updateppm?name=TESTBETA123' +
                '&max=' + limit.max +
                '&min=' + limit.min +
                '&msg=' + limit.msg
            $.get(url);
        } catch (error) { }
    });

    app.service.Limits.bind("get:voc", function (e) {
        try {
            var limit = {};
            var url = app.service.dbBaseUrl + '/getppm?name=TESTBETA123';
            $.get(url, function (data) {
                if (!app.utils.isNullUndefOrEmpty(data)) {
                    var voc = {
                        min: data.low,
                        max: data.max,
                        msg: data.msg,
                    }
                    app.cache.localSet("voc", voc);
                } else {
                    app.cache.localSet("voc", {});
                }
            }).fail(function () {
                var failure = {
                    name: 'get:temp',
                    type: 'ajax',
                    msg: '',
                    url: this.url
                }
                app.service.failures.push(failure);
                app.cache.localSet("temp", {});
            }).always(function () {
                app.progress.hide();
            });

        } catch (error) { }
    });
    app.service.Limits.bind("temperature", function (e) {
        try {
            var limit = e.data;
            var url = app.service.dbBaseUrl + '/updatetemperature?name=TESTBETA123' +
                '&max=' + limit.max +
                '&min=' + limit.min +
                '&msg=' + limit.msg
            $.get(url);
        } catch (error) { }
    });
    app.service.Limits.bind("get:temp", function (e) {
        try {
            var limit = {};
            var url = app.service.dbBaseUrl + '/gettemperature?name=TESTBETA123';
            $.get(url, function (data) {
                if (!app.utils.isNullUndefOrEmpty(data)) {
                    var temp = {
                        min: data.low,
                        max: data.max,
                        msg: data.msg,
                    }
                    app.cache.localSet("temp", temp);
                } else {
                    app.cache.localSet("temp", {});
                }
            }).fail(function () {
                var failure = {
                    name: 'get:temp',
                    type: 'ajax',
                    msg: '',
                    url: this.url
                }
                app.service.failures.push(failure);
                app.cache.localSet("temp", {});
            }).always(function () {
                app.progress.hide();
            });

        } catch (error) { }
    });
    //--------------Q Model-------------------------------------------------->
    app.service.q.bind("savefailure", function (e) {
        try {
            var failure = e.data;
            var url = app.service.dbBaseUrl + '/deleteuserclient?email=' + user.email;
            $.get(url);
        } catch (error) { }
    });

})();
