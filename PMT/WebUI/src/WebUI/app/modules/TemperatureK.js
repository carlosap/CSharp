import React, {Component, PropTypes} from 'react';
class TemperatureK extends Component {
  constructor(props) {
    super(props);

  }
  render() {
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
                                          <span className="amount">{this.props.measurement} K</span>
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
}

TemperatureK.propTypes = {
    measurement:      React.PropTypes.number,
};

export default TemperatureK;