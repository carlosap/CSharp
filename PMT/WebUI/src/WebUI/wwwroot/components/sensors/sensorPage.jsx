var Service = window.app.service;
var TemperatureF = React.createClass({

    render: function () {
        return (
            <div className="col-xs-12 col-lg-4 m-b-5">
              <div className="text-widget-1">
                  <div className="row">
                      <div className="col-xs-4">
                          <span className="fa-stack fa-stack-2x pull-left"></span>
                      </div>
                      <div className="col-xs-8 text-left">
                          <div className="row">
                              <div className="col-xs-12">
                                  <div className="title">FAHRENHEIT</div>
                              </div>
                          </div>
                          <div className="row">
                              <div className="col-xs-12">
                                  <div className="numbers">
                                      <div>
                                          <span className="amount">{this.props.measurement}</span>
                                      </div>
                                  </div>
                              </div>
                          </div>
                      </div>
                  </div>
              </div>
            </div>
		);
    }

});


var TemperatureC = React.createClass({

    render: function () {
        return (
            <div className="col-xs-12 col-lg-4 m-b-5">
              <div className="text-widget-1">
                  <div className="row">
                      <div className="col-xs-4">
                          <span className="fa-stack fa-stack-2x pull-left"></span>
                      </div>
                      <div className="col-xs-8 text-left">
                          <div className="row">
                              <div className="col-xs-12">
                                  <div className="title">CELCIUS</div>
                              </div>
                          </div>
                          <div className="row">
                              <div className="col-xs-12">
                                  <div className="numbers">
                                      <div>
                                          <span className="amount">{this.props.measurement}</span>
                                      </div>
                                  </div>
                              </div>
                          </div>
                      </div>
                  </div>
              </div>
            </div>

		);
    }
});

var TemperatureK = React.createClass({

    render: function () {
        return (
            <div className="col-xs-12 col-lg-4 m-b-5">
              <div className="text-widget-1">
                  <div className="row">
                      <div className="col-xs-4">
                          <span className="fa-stack fa-stack-2x pull-left"></span>
                      </div>
                      <div className="col-xs-8 text-left">
                          <div className="row">
                              <div className="col-xs-12">
                                  <div className="title">KELVIN</div>
                              </div>
                          </div>
                          <div className="row">
                              <div className="col-xs-12">
                                  <div className="numbers">
                                      <div>
                                          <span className="amount">{this.props.measurement}</span>
                                      </div>
                                  </div>
                              </div>
                          </div>
                      </div>
                  </div>
              </div>
            </div>

		);
    }
});

var TemperatureH = React.createClass({

    render: function () {
        return (
            <div className="col-xs-12 col-lg-4 m-b-5">
              <div className="text-widget-1">
                  <div className="row">
                      <div className="col-xs-4">
                          <span className="fa-stack fa-stack-2x pull-left"></span>
                      </div>
                      <div className="col-xs-8 text-left">
                          <div className="row">
                              <div className="col-xs-12">
                                  <div className="title">Humidity</div>
                              </div>
                          </div>
                          <div className="row">
                              <div className="col-xs-12">
                                  <div className="numbers">
                                      <div>
                                          <span className="amount">{this.props.measurement}</span>
                                      </div>
                                  </div>
                              </div>
                          </div>
                      </div>
                  </div>
              </div>
            </div>

		);
    }
});


var VOC = React.createClass({

    render: function () {
        return (
            <div className="col-xs-12 col-lg-4 m-b-5">
              <div className="text-widget-1">
                  <div className="row">
                      <div className="col-xs-4">
                          <span className="fa-stack fa-stack-2x pull-left"></span>
                      </div>
                      <div className="col-xs-8 text-left">
                          <div className="row">
                              <div className="col-xs-12">
                                  <div className="title">Vol</div>
                              </div>
                          </div>
                          <div className="row">
                              <div className="col-xs-12">
                                  <div className="numbers">
                                      <div>
                                          <span className="amount">{this.props.measurement}</span>
                                      </div>
                                  </div>
                              </div>
                          </div>
                      </div>
                  </div>
              </div>
            </div>

		);
    }
});


var SensorPage = React.createClass({

    getInitialState: function () {
        this.isServerMounted = null;
        Service.add([
            { name: 'ENS210', url: '/ENS210?serial=TESTBETA123', success: this.setStateHandler, error: this.error }
        ]);

        return {
            temperature: {
                fahrenheit: '',
                celcius: '',
                kelvin: '',
                humidity: ''
            },
            vco: '--- VOC',
            refreshrate: 800
        };
    },
    componentDidMount: function () {
        if (this.isMounted()) {
            this.loadFromServerHandler();
            this.isServerMounted = setInterval(this.loadFromServerHandler, this.state.refreshrate);
        }
    },
    render: function () {
        return (

              <div>
                  <TemperatureF measurement={this.state.temperature.fahrenheit} />
                  <TemperatureC measurement={this.state.temperature.celcius} />
                  <TemperatureK measurement={this.state.temperature.kelvin} />
                  <TemperatureH measurement={this.state.temperature.humidity} />
                  <VOC measurement={this.state.vco} />
              </div>

		);
    },
    loadFromServerHandler: function () {
        window.app.service.start();
    },
    setStateHandler: function (data, reqNum, url, queryData, reqTotal, isNested) {
        var responseName = Service.prop(reqNum, 'name');
        switch (responseName) {
            case "ENS210":
                this.setState({
                    temperature: {
                        fahrenheit: data.Fahrenheit,
                        celcius: data.Celcius,
                        kelvin: data.Kelvin,
                        humidity: data.Humidity
                    }
                });
                break;
            default:
                return;
        }
    },
    error: function (reqNum, url, queryData, errorType, errorMsg, reqTotal) {
        console.log(errorMsg);
    }
});

ReactDOM.render(<SensorPage />, document.getElementById('sensorpage'));