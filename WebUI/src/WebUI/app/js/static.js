var app = app || {};
(function () {
    "use strict";
    app.staticPages = {
        items: {},
        get: function (partialName) {
            return this.items[partialName] || '';
        },
        set: function (partialName,value) {
            this.items[partialName] = value;
        },
        setItems: function (partials) {
            var _this = this;
            if(partials && _this.items){
                _this.items = {};
            }
            partials.forEach(function (partialPage) {
                _this.items[partialPage.Name] = partialPage.Value;
            });
        }
    }
})();

