"use strict";
var React = require('react');
var Router = require('react-router');
var Link = Router.Link;
var Home = React.createClass({
	render: function () {
		var imgFlag = app.image.get("Flag.Country");
		var imgFlagStyle = {
			width: '32px',
			height: '24px'
		};
		return (

			<div ClassName="row">
				
				<h1>ASP.Net 5 Core 1<span><img src={imgFlag} style={imgFlagStyle}/></span></h1>			
				<p>.Net and React JS</p>
				<Link to="about" ClassName="btn btn-primary btn-lg">Learn more</Link>
				
			</div>

		);
	}
});
module.exports = Home;