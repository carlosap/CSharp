"use strict";
var React = require('react');
var RadioButtons = React.createClass({
    propTypes: {
        name: React.PropTypes.string.isRequired,
        isInline: React.PropTypes.bool.isRequired,
        Items: React.PropTypes.array.isRequired
    },
    render: function () {
        var _this = this;
        if (_this.props.Items) {
            var styleCss = ((_this.props.isInline)) ? styleCss = 'radio-inline' : 'radio';
            var radioGroup = _this.props.Items.map(function (radioItem,index) {
                return (
                    <div key={index} className={styleCss}>
                        <label>
                            <input
                                type="radio"
                                name={_this.props.name}/>
                                {radioItem}
                        </label>
                    </div>
                );
            });
        }
        return ({ radioGroup });
    }
});
module.exports = RadioButtons;
