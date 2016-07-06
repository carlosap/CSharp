"use strict";
var React = require('react');
var Router = require('react-router');
var Link = Router.Link;
var SubMenu = React.createClass({
    propTypes: {
        Items: React.PropTypes.array.isRequired
    },
    render: function () {
        var _this = this;
        if (_this.props.Items) {
            var subItems = _this.props.Items.map(function (menuItem) {
                var menuText = (app.label.get(menuItem.Label) || menuItem.Text || '');
                return (
                    <li key={menuItem.Id}>
                        <Link to={menuItem.LinkTo}>
                            {menuText}
                        </Link>
                        <SubMenu Items={menuItem.Items} />
                    </li>
                );
            });
        }
        return (
            <ul className="dropdown-menu">
                { subItems }
            </ul>

        );
    }

});
module.exports = SubMenu;