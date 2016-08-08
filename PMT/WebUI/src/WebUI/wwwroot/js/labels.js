var app = app || {};
(function () {
    "use strict";
    app.label = {
        items: {},
        get: function (labelName) {
            return this.items[labelName] || '';
        },
        set: function (labelName,value) {
            this.items[labelName] = value;
        },
        setItems: function (labels) {
            var _this = this;
            labels.forEach(function (label) {
                _this.items[label.Name] = label.Value;
            });
        }
    }
})();

