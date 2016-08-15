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
            fahrenheit: 23.3,
            celcius: 54.9,
            kelvin: 333,
            humidity: 40
        },
        ppb: 0,
        ppm: 0,
        refreshrate: 3000
    };
    this.isServerMounted = null;
    Service.add([
            { name: 'COREALL', url: '/COREALL?serial=TESTBETA123', success: this.setStateHandler.bind(this), error: this.error.bind(this) }

    ]);
  }
  componentDidMount() {
        this.loadFromServerHandler();
        this.isServerMounted = setInterval(this.loadFromServerHandler, this.state.refreshrate);

  }
  render() {
    return (
      <div>
        <TemperatureF measurement={this.state.temperature.fahrenheit} />
        <TemperatureC measurement={this.state.temperature.celcius} />
        <TemperatureK measurement={this.state.temperature.kelvin} />
        <TemperatureH measurement={this.state.temperature.humidity} />
        <VOC ppb={this.state.ppb} ppm={this.state.ppm} />
      </div>
    );
  }

  setStateHandler(data, reqNum, url, queryData, reqTotal, isNested) {
        var responseName = Service.prop(reqNum, 'name');
        switch (responseName) {
            case "COREALL":
                this.setState({
                    temperature: {
                                  fahrenheit: data.Fahrenheit,
                                  celcius: data.Celcius,
                                  kelvin: data.Kelvin,
                                  humidity: data.Humidity
                              }
                });
                this.setState({ ppb: data.PPB.Measurement, ppm: data.PPM.Measurement });
                break;

            default:
                return;
        }
  }

  loadFromServerHandler() {
        window.app.service.start();
  }
  
  error(reqNum, url, queryData, errorType, errorMsg, reqTotal) {
        console.log(errorMsg);
  }

}

export default Sensors;

