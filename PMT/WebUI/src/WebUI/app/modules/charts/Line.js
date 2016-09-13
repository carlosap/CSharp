import React, {Component, PropTypes} from 'react';
//var Service = window.app.service;
class ChartLine extends Component {
    constructor(props) {
        super(props);
        this.header = this.props.params.header;
        this.sensorType = this.props.params.type;
        this.hashname = 'chartline';
        this.refreshrate = '2500';
        this.isServerMounted = null;
        this.createLineChart = this.createLineChart.bind(this);
    }
    setStateHandler(data, reqNum, url, queryData, reqTotal, isNested) {
        try {
            if (this.header === "FAHRENHEIT") this.createLineChart(data.FahrenheitHistogram.Q);
            if (this.header === "CELCIUS") this.createLineChart(data.CelciusHistogram.Q);
            if (this.header === "HUMIDITY") this.createLineChart(data.HumidityHistogram.Q);
            if (this.header === "KELVIN") this.createLineChart(data.KelvinHistogram.Q);
            if (this.header === "CO2") this.createLineChart(data.PPM.Histogram.Q);
        } catch (err) { }
    }

    loadFromServerHandler() {
        if (window.location.hash.indexOf(this.hashname) <= 0) {
            clearInterval(this.isServerMounted);
            window.app.service.clear();
        }
        else {
            app.service.request("/COREALL?serial=TESTBETA123", this.setStateHandler.bind(this), this.error.bind(this));
        }
    }
    error(reqNum, url, queryData, errorType, errorMsg, reqTotal) {
        console.log(errorMsg);
    }
    componentWillMount() {
        this.clearWidgets();
    }
    componentDidMount() {
        var _this = this;
        $("#select-period").kendoMobileButtonGroup({
            select: function (e) {
                switch (e.index) {
                    case 0:
                        _this.context.router.push('/sensors');
                        break;
                    case 1:
                        break;
                }
            },
            index: 1
        });
        this.loadFromServerHandler();
        this.isServerMounted = setInterval(this.loadFromServerHandler.bind(this), this.refreshrate);
    }
    clearWidgets() {
        if (kendo) {
            kendo.destroy(document.body);
        }
    }
    createLineChart(remoteData) {
       // this.clearWidgets();
        var titleText = this.header;        //fahrenheit
        var seriesType = this.sensorType;   //Temperatures
        $("#chart_line").kendoChart({
            title: {
                text: seriesType
            },
            legend: {
                position: "bottom"
            },
            chartArea: {
                background: ""
            },
            seriesDefaults: {
                type: "line",
                style: "smooth"
            },
            series: [{
                name: seriesType,
                data: remoteData

            }],
            valueAxis: {
                labels: {
                    format: "{0}"
                },
                line: {
                    visible: false
                },
                axisCrossingValue: -10
            },
            categoryAxis: {
                categories: [1, 2, 3, 4, 5, 6, 7, 8, 9, 10],
                majorGridLines: {
                    visible: false
                },
                labels: {
                    rotation: "auto"
                }
            },
            tooltip: {
                visible: true,
                format: "{0}F",
                template: "#= series.name #: #= value #"
            }
        });
    }
    render() {
        return (

            <div className="row">
                
                <div>
                    <ul id="select-period">
                        <li><i className="zmdi zmdi-widgets m-r-5"></i>Retum to Sensors</li>
                        <li>{this.header}</li>
                    </ul>
                </div>
                <hr className="shadow"/>
                <h4>{this.header}</h4>
                <div className="col-xs-12 col-xl-12">
                    <div id="chart_line"></div>
                </div>
            </div>
        );
    }
}

ChartLine.contextTypes = {
    router: React.PropTypes.object
};

export default ChartLine;