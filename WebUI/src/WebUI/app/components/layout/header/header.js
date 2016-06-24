"use strict";
var React = require('react');
var Router = require('react-router');
var Service = require('../../../api/services').http;
var Logo = require('./logo');
var Menu = require('./menu');
var Header = React.createClass({
  getInitialState: function () {
    Service.add([
      { name: 'menu', url: '/api/menu', success: this.setStateHandler, error: this.error },
      { name: 'uiconfig', url: '/api/datasource?name=uiconfig', success: this.setStateHandler, error: this.error }
    ]).start();
    return {
      menu: [],
      logo: '',
      hTextVisible: false,
      hText: ''
    };
  },
  setStateHandler: function (data, reqNum, url, queryData, reqTotal, isNested) {
    var responseName = Service.prop(reqNum, 'name');
    switch (responseName) {
      case "menu":
        this.setState({ menu: data });
        break;
      case "uiconfig":
        this.setState({ logo: data.logo });
        this.setState({ hTextVisible: data.header.visiable });
        this.setState({ hText: data.header.text });
        break;
      default:
        return;
    }
  },
  error: function (reqNum, url, queryData, errorType, errorMsg, reqTotal) {
    console.log(errorMsg);
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
