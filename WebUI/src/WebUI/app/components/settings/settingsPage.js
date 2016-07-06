"use strict";
var React = require('react');
var Router = require('react-router');
var SettingsForm = require('./settingsForm');
var toastr = require('toastr');
var SettingsPage = React.createClass({
    mixins: [
        Router.Navigation
    ],
    getInitialState: function () {
        var options = {
            lang: {
                value: 'eng',
                groupname: "optlang",
                isInline: false,
                Items: ['eng', 'es', 'rus']
            }
        };
        return {
            settings: options,
            errors: {},
            dirty: false
        };
    },
    componentDidMount: function () {
        var cachedLanguage = app.cache.localGet('language');
        var options = this.state.settings;
        options.lang.value = (app.utils.isNullUndefOrEmpty(cachedLanguage)) ? app.localization.language:cachedLanguage;
        this.setState({ settings: options });
    },
    setSettingsState: function (event) {
        this.setState({ dirty: true });
        switch (event.target.name) {
            case "optlang":
                var options = this.state.settings;
                options.lang.value = event.target.value;            
                app.localization.language = event.target.value;
                app.cache.localSet('language', event.target.value);
                toastr.success(event.target.value);
                this.setState({ settings: options });
                app.service.start();
                break;
            default:
                break;
        }
    },
    saveSettings: function (event) {
        event.preventDefault();
        if (!this.settingsFormIsValid()) {
            return;
        }
        toastr.success('Author saved.');
        //this.transitionTo('authors');
    },
    settingsFormIsValid: function () {
        var formIsValid = true;
        this.state.errors = {}; //clear any previous errors.
        return formIsValid;
    },
    render: function () {
        return (
            <SettingsForm
                settings={this.state.settings}
                errors={this.state.errors}
                onSave={this.saveSettings}
                onChange={this.setSettingsState}
                />
        );
    }
});

module.exports = SettingsPage;