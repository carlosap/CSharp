"use strict";
var React = require('react');
var Router = require('react-router');
var Logo = require('./logo');
var Menu = require('./menu');
var Header = React.createClass({
  propTypes: {
    header: React.PropTypes.object.isRequired
  },
  getInitialState: function () {
    return {
      menu: this.props.header.menu,
      logo: this.props.header.logo,
      hTextVisible: this.props.header.visiable,
      hText: this.props.header.text
    };
  },
  render: function () {
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
});
module.exports = Header;
