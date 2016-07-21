import React from 'react';
import Header from './layout/header/header';
import RouteHandler from 'react-router';
import Service from '../api/services';
$ = jQuery = require('jquery');
class App extends Component {
	constructor() {
		super();
        this.isMounted = null;
		this.bootstrapMaxRetries = 3;
		Service.add([
			{ name: 'labels', url: '/api/label?name=*', success: this.setStateHandler, error: this.error },
			{ name: 'static', url: '/api/static?name=*', success: this.setStateHandler, error: this.error },
			{ name: 'image', url: '/api/image?name=*', success: this.setStateHandler, error: this.error },
			{ name: 'uiconfig', url: '/api/datasource?name=uiconfig', success: this.setStateHandler, error: this.error }

		]).start();
		app.service = Service;
		uiconfig = {};
		refreshrate = 100;
		autoreload = false;
		maxRetry = this.bootstrapMaxRetries;
	}

	loadFromServerHandler() {
        this.bootstrapMaxRetries--;
        if (this.bootstrapMaxRetries <= 0) {
            if (!this.state.autoreload) {
                clearInterval(this.isMounted);
                return;
            }
        }
        else {
			if (app.utils.isNullUndefOrEmpty(app.cache.memGet('uiconfig'))) return;
			if (this.bootstrapMaxRetries === (this.state.maxRetry - 1)) return;
            Service.start();
        }
    }

	componentDidMount() {
		this.loadFromServerHandler();
        this.isMounted = setInterval(this.loadFromServerHandler, this.state.refreshrate);
	}

	setStateHandler(data, reqNum, url, queryData, reqTotal, isNested) {
		this.setState({ dirty: true });
        var responseName = Service.prop(reqNum, 'name');
        switch (responseName) {
			case "uiconfig":
				this.setState({ uiconfig: data.Result });
				break;
			case "labels":
				app.label.setItems(data);
				break;
			case "static":
				app.staticPages.setItems(data);
				break;
			case "image":
				app.image.setItems(data);
				break;
            default:
                return;
        }
    }

	error(reqNum, url, queryData, errorType, errorMsg, reqTotal) {
        console.log(errorMsg);
    }

	render() {
		var header = null;
		if (!app.utils.isNullUndefOrEmpty(this.state.uiconfig.header)) {
			header = <Header header={this.state.uiconfig.header}/>
		}
		return (
			<div className="container-fluid">
				{header}
				<br/>
				<br/>
				<div className="row">
					<RouteHandler/>
				</div>
			</div>
		);
	}
}

export default App;






