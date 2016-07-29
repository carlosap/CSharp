import React from "react";
import Router from "react";
import { Link } from 'react-router';
class Home extends Component {
	render() {
		var htmlServiceContent = app.staticPages.get("home");
		var imgFlag = app.image.get("Flag.Country");
		var imgFlagStyle = {
			width: '32px',
			height: '24px'
		};
		return (
			<div ClassName="row">
				<h1>ASP.Net 5 Core 1<span><img src={imgFlag} style={imgFlagStyle}/></span></h1>
				{(() => {
                    if (htmlServiceContent) {
                        return <div dangerouslySetInnerHTML={{ __html: htmlServiceContent }} />
                    } else {
                        return <p>
							ASP.NET Core is a new open-source and cross-platform framework for building modern cloud based internet connected applications, such as web apps, IoT apps and mobile backends.ASP.NET Core apps can run on.NET Core or on the full.NET Framework.It was architected to provide an optimized development framework for apps that are deployed to the cloud or run on-premises.It consists of modular components with minimal overhead, so you retain flexibility while constructing your solutions.You can develop and run your ASP.NET Core apps cross-platform on Windows, Mac and Linux.ASP.NET Core is open source at GitHub.
						</p>
                    }
                })() }
				<Link to="about" ClassName="btn btn-primary btn-lg">Learn more</Link>
			</div>
		);
	}
}

export default Home;
