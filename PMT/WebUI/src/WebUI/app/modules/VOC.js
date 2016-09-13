import React, {Component, PropTypes} from 'react';
class VOC extends Component {
    constructor(props) {
        super(props);
        this.sensorClick = this.sensorClick.bind(this);
    }
    sensorClick(e) {
        this.context.router.push('/chartline/CO2/PPM');
        return false;
    }
    render() {
        return (

            <div id="vocChart" className="col-xs-12 col-lg-4 m-b-5" onClick={this.sensorClick} >
                <div className="text-widget-4 bg-warning-700 color-white text-center">
                    <div className="title">Volatile Organic Compounds</div>
                    <div className="subtitle">VOC</div>
                    <span className="amount" count-to-currency="200" value="0" duration="1">{this.props.ppm} PPM &nbsp; &nbsp; {this.props.ppb} PPB</span>
                    <span className="label label-white-outline">Sensor</span>
                    <span count-to-percent="100" value="0" duration="1" className="percent">IAQCORE</span>
                </div>
            </div>

        );
    }
}

VOC.propTypes = {
    ppm: React.PropTypes.number,
    ppb: React.PropTypes.number,

};
VOC.contextTypes = {
    router: React.PropTypes.object
};
export default VOC;