"use strict";
var React = require('react');
var Router = require('react-router');
var Service = require('../../api/services').http;
var Logo = require('./logo');
var Menu = require('./menu');
var Header = React.createClass({
  getInitialState: function () {
    Service.add([{ name: 'menu', url: '/api/menu', success: this.setStateHandler, error: this.error }]).start();
    return {
      menu: [],
      logo: ''
    };
  },
  setStateHandler: function (data, reqNum, url, queryData, reqTotal, isNested) {
    var responseName = Service.prop(reqNum, 'name');
    switch (responseName) {
      case "menu":
        this.setState({ menu: data });
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
      <nav className="navbar navbar-default">
        <div className="container-fluid">
          <Logo />
          <Menu Items={this.state.menu}/>
        </div>
      </nav>
    );
  }
});
module.exports = Header;
