import React from "react";
import RadioButtons from '../common/radiobuttons';
const SettingsForm = props => {
    return (
        <form>
            <h1>Application Settings</h1>
            <RadioButtons
                groupname= {this.props.settings.lang.groupname}
                value= {this.props.settings.lang.value}
                isInline={this.props.settings.lang.isInline}
                Items={this.props.settings.lang.Items}
                onChange={this.props.onChange}
                />

            <input type="submit" value="Save" className="btn btn-default" onClick={this.props.onSave} />
        </form>
    );
};

SettingsForm.propTypes = {
    settings: React.PropTypes.object.isRequired,
    errors: React.PropTypes.object,
    onSave: React.PropTypes.func.isRequired,
    onChange: React.PropTypes.func.isRequired
};

export default SettingsForm;
