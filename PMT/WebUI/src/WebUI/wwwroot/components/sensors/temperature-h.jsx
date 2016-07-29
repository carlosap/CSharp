var TemperatureH = React.createClass({
    render: function () {
        return (

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
                                          <span className="amount">46.22 %</span>
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

ReactDOM.render(<TemperatureH />,document.getElementById('temperature-h'));