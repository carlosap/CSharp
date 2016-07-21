import React from "react";
import Router from "react";
import { Link } from 'react-router';
import SettingsForm from './settingsForm';
import autoBind from 'react-autobind';
import PureRenderMixin from 'react-addons-pure-render-mixin';

class SettingsPage extends Component() {
    constructor(props) {
        super(props);
        autoBind(this);
        this.shouldComponentUpdate = PureRenderMixin.shouldComponentUpdate.bind(this);

        settings = {
            lang: {
                value: 'eng',
                groupname: "optlang",
                isInline: false,
                Items: ['eng', 'es', 'rus']
            }
        };
        errors = {};
        dirty = false;
    }

    componentDidMount() {
        var cachedLanguage = app.cache.localGet('language');
        var options = this.state.settings;
        options.lang.value = (app.utils.isNullUndefOrEmpty(cachedLanguage)) ? app.localization.language : cachedLanguage;
        this.setState({ settings: options });
    }

    setSettingsState(event) {
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
    }
    saveSettings(event) {
        event.preventDefault();
        if (!this.settingsFormIsValid()) {
            return;
        }

    }
    settingsFormIsValid() {
        var formIsValid = true;
        this.state.errors = {};
        return formIsValid;
    }
    render() {
        return (
            <SettingsForm
                settings={this.state.settings}
                errors={this.state.errors}
                onSave={this.saveSettings}
                onChange={this.setSettingsState}
                />
        );
    }
}
export default SettingsPage;


