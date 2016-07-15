"use strict";
var React = require('react');
var About = React.createClass({
	render: function () {
		var htmlServiceContent = app.staticPages.get('about');
		return (
			<div ClassName="row">
				<h1>About</h1>
				{(() => {
					if (htmlServiceContent) {
						return <div dangerouslySetInnerHTML={{ __html: htmlServiceContent }} />
					} else {
						return <div>
							<p>
								The first preview release of ASP.NET came out almost 15 years ago as part of the.NET Framework.
								Since then millions of developers have used it to build and run great web apps, and over
								the years we have added and evolved many capabilities to it.
							</p>
						</div>
					}
				})() }
			</div>
		);
	}
});
module.exports = About;


