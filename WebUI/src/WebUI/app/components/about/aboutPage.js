"use strict";
var React = require('react');
var About = React.createClass({
	render: function () {
		var htmlServiceContent = app.staticPages.get('about');
		return (
			<div>
				{(() => {
					if (htmlServiceContent) {
						return <div dangerouslySetInnerHTML={{ __html: htmlServiceContent }} />
					} else {
						return <div>
							<h1>About</h1>
							<p>Use this area to provide additional information.</p>
						</div>
					}
				})() }
			</div>
		);
	}
});
module.exports = About;

