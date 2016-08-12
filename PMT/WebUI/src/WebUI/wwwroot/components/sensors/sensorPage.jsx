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

var app = app || {};
app.TemperatureK = React.createClass({

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
                                  <div className="title">IAQCORE (VOC)</div>
                              </div>
                          </div>
                          <div className="row">
                              <div className="col-xs-12">
                                  <div className="numbers">
                                      <div>
                                          <span className="amount">{this.props.ppm} PPM</span>
                                      </div>
                                      <div>
                                          <span className="amount">{this.props.ppb} PPB</span>
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
            { name: 'ENS210', url: '/ENS210?serial=TESTBETA123', success: this.setStateHandler, error: this.error },
            { name: 'IAQCORE', url: '/IAQCORE?serial=TESTBETA123', success: this.setStateHandler, error: this.error },

        ]);

        return {
            temperature: {
                fahrenheit: '',
                celcius: '',
                kelvin: '',
                humidity: ''
            },
            temperatureLimits: {
                low: 50,
                max: 75
            },
            vco_ppb: '--- PPB',
            vco_ppm: '--- PPM',
            refreshrate: 1000
        };
    },
    componentDidMount: function () {
        if (this.isMounted()) {
            this.loadFromServerHandler();
            this.isServerMounted = setInterval(this.loadFromServerHandler, this.state.refreshrate);
        }
    },
    isTempBetween: function (x) {
        var min = this.state.temperatureLimits.low;
        var max = this.state.temperatureLimits.max;
        return x >= min && x <= max;
    },
    isBelowTemp: function(x){
    
    },
    isAboveTemp: function(x){
    
    },
    render: function () {
        return (

              <div>
                  <TemperatureF measurement={this.state.temperature.fahrenheit} />
                  <TemperatureC measurement={this.state.temperature.celcius} />
                  <app.TemperatureK measurement={this.state.temperature.kelvin} />
                  <TemperatureH measurement={this.state.temperature.humidity} />
                  <VOC ppb={this.state.vco_ppb} ppm={this.state.vco_ppm} />
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
            case "IAQCORE":
                this.setState({ vco_ppb: data.PPB.Measurement, vco_ppm: data.PPM.Measurement });
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