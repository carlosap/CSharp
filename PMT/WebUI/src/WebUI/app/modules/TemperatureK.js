import React, {Component, PropTypes} from 'react';
class TemperatureK extends Component {
    constructor(props) {
        super(props);
        this.sensorClick = this.sensorClick.bind(this);

    }
    sensorClick(e) {
        this.context.router.push('/chartline/KELVIN/Temperature');
        return false;
    }
    render() {
        return (

            <div id="TemperatureK" className="col-xs-12 col-lg-4 m-b-5" onClick={this.sensorClick} >
                <div className="text-widget-4 bg-info-700 color-white text-center">
                    <div className="title">KELVIN</div>
                    <div className="subtitle"></div>
                    <span className="amount" count-to-currency="200" value="0" duration="1">{this.props.measurement} K</span>
                    <span className="label label-white-outline">Sensor</span>
                    <span count-to-percent="100" value="0" duration="1" className="percent">ENS210</span>
                </div>
            </div>
        );
    }
}

TemperatureK.propTypes = {
    measurement: React.PropTypes.number,
};

TemperatureK.contextTypes = {
    router: React.PropTypes.object
};

export default TemperatureK;