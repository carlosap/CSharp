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
                return (
                    <li key={menuItem.Id}>
                        <Link to={menuItem.LinkTo}>
                            {menuItem.Text}
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