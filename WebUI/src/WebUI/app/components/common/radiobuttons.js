"use strict";
var React = require('react');
var RadioButtons = React.createClass({
    propTypes: {
        groupname: React.PropTypes.string.isRequired,
        value: React.PropTypes.string.isRequired,
        isInline: React.PropTypes.bool.isRequired,
        Items: React.PropTypes.array.isRequired,
        onChange: React.PropTypes.func.isRequired
    },
    render: function () {
        var _this = this;
        if (_this.props.Items) {
            var styleCss = ((_this.props.isInline)) ? styleCss = 'radio-inline' : 'radio';
            var radioGroup = _this.props.Items.map(function (radioItem, index) {
                return (
                    <div key={index} className={styleCss}>
                        <label>
                            <input
                                type="radio"
                                name={_this.props.groupname}
                                value={radioItem}
                                onChange={_this.props.onChange}
                                checked = {_this.props.value === radioItem}
                                />
                            {radioItem}
                        </label>
                    </div>
                );
            });
        }
        return (
            <div>
                {radioGroup}
            </div>
        );
    }
});
module.exports = RadioButtons;
