"use strict";
var React = require('react');
var Router = require('react-router');
var Link = Router.Link;
var SubMenu = require('./submenu');
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
            inlineStyle = { display: 'block' };
        if (_this.props.Items) {
            var menuItems = _this.props.Items.map(function (menuItem, index) {
                var listItem = null;
                var styleCss = ((_this.state.focused == index)) ? styleCss = 'active' : '';
                if (menuItem.Items.length > 0) {
                    listItem = (
                        <li key={menuItem.Id}
                            className="dropdown"
                            onClick={_this.clicked.bind(self, index) }>
                            <Link   className="dropdown-toggle"
                                data-toggle="dropdown"
                                to={menuItem.LinkTo}>
                                {menuItem.Text}
                                <span className="caret"></span>
                            </Link>
                            <SubMenu Items={menuItem.Items} />
                        </li>
                    )
                } else {
                    listItem = (
                        <li key={menuItem.Id}
                            className={styleCss}
                            onClick={_this.clicked.bind(self, index) }>
                            <Link to={menuItem.LinkTo}>{menuItem.Text}</Link>
                        </li>
                    )
                }
                return ({ listItem });
            });
        }
        return (       
            <ul className="nav navbar-nav">
                { menuItems }
            </ul>            
        );
    }
});
module.exports = Menu;