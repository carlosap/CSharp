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
                name: "optlanguage",
                isInline: false,
                Items: ['eng', 'es', 'rus']
            }
        };
        return {
            settings: options,
            errors: {},
        };
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
                />
        );
    }
});

module.exports = SettingsPage;