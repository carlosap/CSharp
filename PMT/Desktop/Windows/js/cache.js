/***************************************************************************
aman:cache
-developer: Carlos A. Perez
-Date: 9/01/2016
-usage: (see also getters)
        local: app.cache.localSet(key,value);
        cookie: app.cache.setCookie(key,value);
        session: app.cache.sessionSet(key,value);
****************************************************************************/
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
		    var cookies = {};
		    _.each(document.cookie.split('; ') || [], function (cookie) {
		        var split = cookie.split('=');
		        cookies[split[0]] = split[1];
		    });
		    return cookies;
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