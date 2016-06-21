var React = require('react');
var Router = require('react-router');
var Link = Router.Link;
var Logo = React.createClass({
  render: function () {
    return (
      <Link to="app" className="navbar-brand">
        <img src="images/logo.png" />
      </Link>
    );
  }
});
module.exports = Logo;