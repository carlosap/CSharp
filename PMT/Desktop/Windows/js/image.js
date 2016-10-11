var app = app || {};
(function () {
    "use strict";
    app.image = {
        items: {},
        get: function (imageName) {
            return this.items[imageName] || '';
        },
        set: function (imageName,value) {
            this.items[imageName] = value;
        },
        setItems: function (images) {
            var _this = this;
            if(images && _this.items){
                _this.items = {};
            }
            images.forEach(function (image) {
                _this.items[image.Name] = image.Value;
            });
        }
    }
})();

