import React, {Component, PropTypes} from 'react';
import TemperatureF from './TemperatureF'
import TemperatureC from './TemperatureC'
import TemperatureK from './TemperatureK'
import TemperatureH from './TemperatureH'
import VOC from './VOC'
var Service = window.app.service;
class Sensors extends Component {
  constructor(props) {
    super(props);
    this.state = {
      temperature: {
        fahrenheit: 0,
        celcius: 0,
        kelvin: 0,
        humidity: 0
      },
      ppb: 0,
      ppm: 0,
      refreshrate: 1000,
      hashname: 'sensors'
    };
    this.isServerMounted = null;
    this.q = new Queue([{ name: 'COREALL', url: '/COREALL?serial=TESTBETA123', success: this.setStateHandler.bind(this), error: this.error.bind(this) }]);
    this.q.baseURL = 'http://pmtwebapi.azurewebsites.net/api';
  }
  componentWillMount() {
    try {
      if (kendo)
        kendo.destroy(document.body);
    } catch (error) { }
  }
  componentDidMount() {
    this.loadFromServerHandler();
    this.isServerMounted = setInterval(this.loadFromServerHandler.bind(this), this.state.refreshrate);
  }
  render() {
    return (
      <div>
        <div className="m-b-30">
          <h4>Sensor Measurements</h4>
        </div>
        <TemperatureF measurement={this.state.temperature.fahrenheit} />
        <TemperatureC measurement={this.state.temperature.celcius} />
        <TemperatureK measurement={this.state.temperature.kelvin} />
        <TemperatureH measurement={this.state.temperature.humidity} />
        <VOC ppb={this.state.ppb} ppm={this.state.ppm} />
      </div>
    );
  }

  setStateHandler(data, reqNum, url, queryData, reqTotal, isNested) {
    try {
      var responseName = this.q.prop(reqNum, 'name');
      switch (responseName) {
        case "COREALL":
          this.setState({
            temperature: {
              fahrenheit: data.Fahrenheit,
              celcius: data.Celcius,
              kelvin: data.Kelvin,
              humidity: data.Humidity
            },
            ppb: data.PPB.Measurement,
            ppm: data.PPM.Measurement
          });
          break;
        default:
          return;
      }
    } catch (err) { }
  }

  loadFromServerHandler() {
    if (window.location.hash.indexOf(this.state.hashname) <= 0) {
      clearInterval(this.isServerMounted);
      this.q.stop();
    }
    else {
      this.q.start();
    }
  }
  error(reqNum, url, queryData, errorType, errorMsg, reqTotal) {
    //console.log(errorMsg);
  }
}
export default Sensors;

