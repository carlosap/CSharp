var app = app || {};
(function () {
	app.cache = {
		data: {},
		memGet: function (key) {
			return this.data[key];
		},
		memSet: function (key, value) {
			this.data[key] = value;
		},
		memDelete: function (key) {
			delete this.data[key];
		},
		sessionGet: function (key) {
			var data = sessionStorage.getItem(key);
			return data ? JSON.parse(data) : data;
		},
		sessionSet: function (key, value) {
			sessionStorage.setItem(key, JSON.stringify(value));
		},
		sessionDelete: function (key) {
			sessionStorage.removeItem(key);
		},
		localGet: function (key) {
			var data = localStorage.getItem(key);
			return data ? JSON.parse(data) : data;
		},
		localSet: function (key, value) {
			localStorage.setItem(key, JSON.stringify(value));
		},
		localDelete: function (key) {
			localStorage.removeItem(key);
		},
		getCookie: function (name) {
			var cookies = this.getCookies() || {};
			return cookies[name];
		},
		getCookies: function () {
			if (this.app.isNode) {
				return this.app.server.request.cookies;
			} else {
				var cookies = {};
				_.each(document.cookie.split('; ') || [], function (cookie) {
					var split = cookie.split('=');
					cookies[split[0]] = split[1];
				});
				return cookies;
			}
		},
		setCookie: function (name, value, options) {
			options = _.extend({
				path: '/'
			}, options);

			var sendCookie = [name + '=' + value];
			if (_.isNumber(options.maxAge)) {
				sendCookie.push('Max-Age=' + options.maxAge);
				var date = new Date();
				date.setTime(date.getTime() + (options.maxAge * 1000));
				sendCookie.push('Expires=' + date.toUTCString());
			}
			if (options.domain) { sendCookie.push('Domain=' + options.domain); }
			sendCookie.push('Path=' + options.path);
			document.cookie = sendCookie.join('; ');


		},
		removeCookie: function (name, options) {
			options = _.extend({
				maxAge: 0
			}, options);
			this.setCookie(name, null, options);
		}
	};
})();
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


var app = app || {};
(function () {
    "use strict";
	app.localization = {
        language: '',
		init: function(){
			this.setLanguage();
		},
        getDomainPrefix: function () {
            return window.location.host.split(".").splice(-1)[0];
        },
        setLanguage: function (domainPrefix) {
            var prefix = this.getDomainPrefix() || '';
            switch (prefix) {
                case 'com':
                    this.language = 'eng'; 	//  US
                    break;
                case 'es':
                    this.language = 'es'; 	//  ES
                    break;
                case 'rus':
                    this.language = 'rus'; 	//  Rus
                    break;
                case 'au':
                    this.language = 'au'; 	// AU
                    break;
                case 'de':
                    this.language = 'de'; 	//DE
                    break;
                case 'ca':
                    this.language = 'ca'; 	// CA
                    break;
                case 'fr':
                    this.language = 'fr'; 	// FR
                    break;
                case 'uk':
                    this.language = 'uk'; 	// UK
                    break;
                case 'jp':
                    this.language = 'jp'; 	// JP
                    break;
                default:
                    this.language = 'eng'; //  US
                    break;
            }
		}
	}
	app.localization.init();
})();


var app = app || {};
(function () {
    "use strict";
    app.service = new Queue();
    app.service.baseURL = "http://pmtwebapi.azurewebsites.net/api";
    app.service.connection.check = false;
    app.service.dataType = "json";
    app.service.type = "POST";
})();

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


var app = app || {};
(function () {
    "use strict";
	app.utils = {

		guid: function () {
			var i, random;
			var uuid = '';
			for (i = 0; i < 32; i++) {
				random = Math.random() * 16 | 0;
				if (i === 8 || i === 12 || i === 16 || i === 20) {
					uuid += '-';
				}
				uuid += (i === 12 ? 4 : (i === 16 ? (random & 3 | 8) : random))
					.toString(16);
			}

			return uuid;
		},
		pluralize: function (count, word) {
			return count === 1 ? word : word + 's';
		},
		store: function (namespace, data) {
			if (data) {
				return localStorage.setItem(namespace, JSON.stringify(data));
			}

			var store = localStorage.getItem(namespace);
			return (store && JSON.parse(store)) || [];
		},
		extend: function () {
			var newObj = {};
			for (var i = 0; i < arguments.length; i++) {
				var obj = arguments[i];
				for (var key in obj) {
					if (obj.hasOwnProperty(key)) {
						newObj[key] = obj[key];
					}
				}
			}
			return newObj;
		},
		getParameter: function (name) {
			name = name.replace(/[\[]/, "\\\[").replace(/[\]]/, "\\\]");
			var regexS = "[\\?&]" + name + "=([^&#]*)";
			var regex = new RegExp(regexS);
			var results = regex.exec(window.location.href);
			if (results == null)
				return "";
			else
				return results[1];
		},
		isNullUndefOrEmpty: function (variable) {
			var results = true;
			var varType = typeof (variable);
			switch (varType) {
				case "string":
					results = !(variable.length > 0);
					break;
				case "number":
					results = !(variable > 0);
					break;
				case "boolean":
					results = (variable) ? false : true;
					break;
				case "null":
				case "undefined":
					results = true;
					break;
				case "object":
					{
						var size = 0, key;
						for (key in variable) { if (variable.hasOwnProperty(key)) size++; }
						results = !(size > 0);
					}
					break;
				default:
					results = true;
			}
			return results;
		}
	}
})();