import React, {Component, PropTypes} from 'react';
import Router from 'react-router';
import { Link } from 'react-router';
import autoBind from 'react-autobind';

class SubMenu extends Component {
    constructor(props) {
        super(props);
        autoBind(this);

    }
    render() {
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
}

SubMenu.propTypes = {
    Items: React.PropTypes.array.isRequired
};

export default SubMenu;


