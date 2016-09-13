import React, {Component, PropTypes} from 'react';
class TemperatureH extends Component {
    constructor(props) {
        super(props);
        this.sensorClick = this.sensorClick.bind(this);
    }

    sensorClick(e) {
        this.context.router.push('/chartline/HUMIDITY/Temperature');
        return false;
    }
    render() {
        return (

            <div id="TemperatureH" className="col-xs-12 col-lg-4 m-b-5" onClick={this.sensorClick} >
                <div className="text-widget-4 bg-info-700 color-white text-center">
                    <div className="title">Temperature</div>
                    <div className="subtitle">Humidity</div>
                    <span className="amount" count-to-currency="200" value="0" duration="1">{this.props.measurement} %</span>
                    <span className="label label-white-outline">Sensor</span>
                    <span count-to-percent="100" value="0" duration="1" className="percent">ENS210</span>
                </div>
            </div>

        );
    }
}

TemperatureH.propTypes = {
    measurement: React.PropTypes.number,
};

TemperatureH.contextTypes = {
    router: React.PropTypes.object
};

export default TemperatureH;