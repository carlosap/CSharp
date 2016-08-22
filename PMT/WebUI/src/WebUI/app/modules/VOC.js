import React, {Component, PropTypes} from 'react';
class VOC extends Component {
    constructor(props) {
        super(props);
    }
    render() {
        return (

                <div className="col-xs-12 col-lg-4 m-b-5">
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

export default VOC;