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

