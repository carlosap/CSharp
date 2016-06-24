/*eslint-disable strict */ //Disabling check because we can't run strict mode. Need global vars.

var React = require('react');
var Header = require('./layout/header/header');
var RouteHandler = require('react-router').RouteHandler;
$ = jQuery = require('jquery');

var App = React.createClass({
	render: function () {
		return (
			<div className="container-fluid">
				<Header/>
				<br/>
				<br/>
				<div className="row">
						<RouteHandler/>
				</div>
			</div>
		);
	}
});

module.exports = App;