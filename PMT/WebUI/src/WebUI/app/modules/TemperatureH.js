import React, {Component, PropTypes} from 'react';
class TemperatureH extends Component {
    constructor(props) {
        super(props);

    }
    render() {
        return (

            <div className="col-xs-12 col-lg-4 m-b-5">
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

export default TemperatureH;