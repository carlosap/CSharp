"use strict";
var React = require('react');
var Router = require('react-router');
var Link = Router.Link;
var Menu = React.createClass({
    propTypes: {
        Items: React.PropTypes.array.isRequired
    },
    getInitialState: function () {
        return {
            focused: 0
        };
    },
    clicked: function (index) {
        this.setState({ focused: index });
    },

    render: function () {
        var _this = this,
            inlineStyle = { display: 'block' },
            submenu = null;
        if (_this.props.Items) {
            var menuItems = _this.props.Items.map(function (menuItem, index) {
                var styleCss = ((_this.state.focused == index)) ? styleCss = 'active' : '';
                return (
                    <li key={menuItem.Id}
                        className={styleCss}
                        onClick={_this.clicked.bind(self, index) }>
                        <Link to={menuItem.LinkTo}>
                            {menuItem.Text}
                        </Link>

                    </li>
                );
            });
        }
        return (
            <ul
                className="nav navbar-nav">
                {menuItems}
            </ul>
        );
    }
});
module.exports = Menu;