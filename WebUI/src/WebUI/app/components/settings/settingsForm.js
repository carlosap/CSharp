"use strict";
var React = require('react');
var RadioButtons = require('../common/radiobuttons');
var SettingsForm = React.createClass({
    propTypes: {
        settings: React.PropTypes.object.isRequired,
        errors: React.PropTypes.object,
        onSave:	React.PropTypes.func.isRequired,
    },

    render: function () {
        return (
            <form>
                <h1>Application Settings</h1>
                <RadioButtons 
                    name={this.props.settings.lang.name} 
                    isInline={this.props.settings.lang.isInline}
                    Items={this.props.settings.lang.Items}/>

                <input type="submit" value="Save" className="btn btn-default" onClick={this.props.onSave} />
            </form>
        );
    }
});
module.exports = SettingsForm;