import React, {Component, PropTypes} from 'react';
import Router from 'react-router';
import Logo from './logo';
import Menu from './menu';
class Header extends Component {
  constructor(props) {
    super(props);
      menu = this.props.header.menu;
      logo = this.props.header.logo;
      hTextVisible = this.props.header.visiable;
      hText = this.props.header.text;
  }
  render() {
    return (
      <nav className="navbar navbar-inverse navbar-fixed-top" role="navigation">
        <div className="container-fluid">
          <Logo
            src={this.state.logo}
            hTextVisible={this.state.hTextVisible}
            hText= {this.state.hText}
            />
          <Menu Items={this.state.menu}/>

        </div>
      </nav>
    );
  }
}
Header.propTypes = {
  header: React.PropTypes.object.isRequired
};
export default Header;



