import React, {Component, PropTypes} from 'react';
import Router from 'react-router';
import { Link } from 'react-router';
import autoBind from 'react-autobind';

var SubMenu = require('./submenu');
class Menu extends Component {
    constructor(props) {
        super(props);
        autoBind(this);
        focused = 0;

    }


    clicked(index) {
        this.setState({ focused: index });
    }
    render() {
        var _this = this,
            inlineStyle = { display: 'block' };
        if (_this.props.Items) {
            var menuItems = _this.props.Items.map(function (menuItem, index) {
                var listItem = null;
                var styleCss = ((_this.state.focused == index)) ? styleCss = 'active' : '';
                var menuText = (app.label.get(menuItem.Label) || menuItem.Text || '');
                if (menuItem.Items.length > 0) {
                    listItem = (
                        <li key={menuItem.Id}
                            className="dropdown"
                            onClick={_this.clicked.bind(self, index) }>
                            <Link   className="dropdown-toggle"
                                data-toggle="dropdown"
                                to={menuItem.LinkTo}>
                                {menuText}
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
                            <Link to={menuItem.LinkTo}>{menuText}</Link>
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
}

Menu.propTypes = {
    Items: React.PropTypes.array.isRequired
};

export default Menu;





