/***************************************************************************
aman:utils
-developer: Carlos A. Perez
-Date: 9/24/2016
-usage:
	- app.utils.isNullUndefOrEmpty(item);

****************************************************************************/
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
		},
		
		scrollPageTo: function (cssSelector, offset,speed) {
			//fast, slow
			var speedType = speed || 'fast';
			$('html,body').animate({ scrollTop: $(cssSelector).offset().top + offset }, speedType);
		},

		isEmail: function (strEmail) {
			var emailFilter = /^([a-zA-Z0-9_.-])+@(([a-zA-Z0-9-])+.)+([a-zA-Z0-9]{2,4})+$/;
			if (!emailFilter.test(strEmail)) {
				return false;
			}
			return true;

		},

		isNumber: function (value) {
			return isNaN(value);
		}
	}
})();
