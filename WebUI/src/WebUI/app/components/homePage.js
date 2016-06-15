"use strict";
var React = require('react');
var Router = require('react-router');
var Link = Router.Link;
var Home = React.createClass({
	render: function() {
		return (
			<div ClassName="jumbotron">
				<h1>ASP.Net 5 Core 1</h1>
				<p>.Net and React JS</p>
				<Link to="about" ClassName="btn btn-primary btn-lg">Learn more</Link>
			</div>
		);
	}
});
module.exports = Home;