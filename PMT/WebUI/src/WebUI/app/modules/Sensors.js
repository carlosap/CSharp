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
        <div className="row">
          <div className="col-xs-12">
            <h1>Relative humidity and temperature sensor ENS210</h1>
            <p>
              The ENS210 integrates one relative humidity sensor and one high-accuracy
              temperature sensor.The device is encapsulated in a HWSON4 package and
              includes an I2C slave interface for communication with a master processor.
            </p>
          </div>
        </div>
        <TemperatureF measurement={this.state.temperature.fahrenheit} />
        <TemperatureC measurement={this.state.temperature.celcius} />
        <TemperatureK measurement={this.state.temperature.kelvin} />
        <TemperatureH measurement={this.state.temperature.humidity} />

        <div className="row">
          <div className="col-xs-12">
            <hr/>
            <h1>Volatile Organic Compounds (VOCs) - IAQCORE </h1>
            <p>
              Volatile organic compounds (VOCs) are emitted as gases from certain solids or liquids.
              VOCs include a variety of chemicals, some of which may have short- and long-term adverse health effects.
              Concentrations of many VOCs are consistently higher indoors (up to ten times higher) than outdoors.
              VOCs are emitted by a wide array of products numbering in the thousands.
              Organic chemicals are widely used as ingredients in household products.Paints, varnishes; and wax all contain organic solvents, as do many cleaning, disinfecting, cosmetic, degreasing and hobby products.Fuels are made up of organic chemicals.All of these products can release organic compounds while you are using them, and, to some degree, when they are stored.
            </p>
          </div>
        </div>
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

