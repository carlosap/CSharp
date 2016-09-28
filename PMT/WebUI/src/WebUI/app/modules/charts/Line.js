import React, {Component, PropTypes} from 'react';
class ChartLine extends Component {
    constructor(props) {
        super(props);
        this.header = this.props.params.header;
        this.sensorType = this.props.params.type;
        this.hashname = 'chartline';
        this.refreshrate = '2000';
        this.createLineChart = this.createLineChart.bind(this);
        this.isServerMounted = null;
        this.q = new Queue([{ name: 'COREALL', url: '/COREALL?serial=TESTBETA123', success: this.setStateHandler.bind(this), error: this.error.bind(this) }]);
        this.q.baseURL = 'http://pmtwebapi.azurewebsites.net/api';
        this.dataSource = new kendo.data.DataSource({
            data: [
                { x: 0, y: 0 },
                { x: 1, y: 0 },
                { x: 2, y: 0 },
                { x: 3, y: 0 },
                { x: 4, y: 0 },
                { x: 5, y: 0 },
                { x: 6, y: 0 },
                { x: 7, y: 0 },
                { x: 8, y: 0 },
                { x: 9, y: 0 }
            ]
        });
    }
    setStateHandler(data, reqNum, url, queryData, reqTotal, isNested) {
        try {
            var _this = this;
            if (this.header === "FAHRENHEIT") this.createLineChart(data.FahrenheitHistogram.Q);
            if (this.header === "CELCIUS") this.createLineChart(data.CelciusHistogram.Q);
            if (this.header === "HUMIDITY") this.createLineChart(data.HumidityHistogram.Q);
            if (this.header === "KELVIN") this.createLineChart(data.KelvinHistogram.Q);
            if (this.header === "CO2") this.createLineChart(data.PPM.Histogram.Q);
        } catch (err) { }
    }

    getChartData(data) {
        var histogram = [];
        _.each(data, function (record, index) {
            var item = { "x": index, "y": record }
            _this.histogram.push(item);
        });
        return histogram;

    }
    loadFromServerHandler() {
        if (window.location.hash.indexOf(this.hashname) <= 0) {
            clearInterval(this.isServerMounted);
            this.q.stop();
        }
        else {
            this.q.start();
        }
    }
    error(reqNum, url, queryData, errorType, errorMsg, reqTotal) {
        console.log(errorMsg);
    }
    componentWillMount() {
        try {
            if (kendo)
                kendo.destroy(document.body);
        } catch (error) { }
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

        $("#chart_line").kendoChart({
            transitions: false,
            dataSource: _this.dataSource,
            title: {
                text: ""
            },
            legend: {
                visible: false
            },
            seriesDefaults: {
                type: "line",
                labels: {
                    visible: true,
                    format: "{0}",
                    background: "transparent"
                }
            },
            series: [{
                field: "y",
                name: ""
            }],
            valueAxis: {
                labels: {
                    format: "{0}"
                },
                line: {
                    visible: false
                }
            },
            categoryAxis: {
                field: "x",
                majorGridLines: {
                    visible: false
                }
            }
        });

        this.loadFromServerHandler();
        this.isServerMounted = setInterval(this.loadFromServerHandler.bind(this), this.refreshrate);
    }

    createLineChart(remoteData) {
        var newData = [
            { x: 0, y: remoteData[0] },
            { x: 1, y: remoteData[1] },
            { x: 2, y: remoteData[2] },
            { x: 3, y: remoteData[3] },
            { x: 4, y: remoteData[4] },
            { x: 5, y: remoteData[5] },
            { x: 6, y: remoteData[6] },
            { x: 7, y: remoteData[7] },
            { x: 8, y: remoteData[8] },
            { x: 9, y: remoteData[9] }
        ];
        var chart = $("#chart_line").data("kendoChart");
        chart.dataSource.data(newData);
        chart.refresh();
    }
    render() {
        return (

            <div className="row">

                <div className="m-b-30">
                    <ul id="select-period">
                        <li><i className="zmdi zmdi-widgets m-r-5"></i>Retum to Sensors</li>
                        <li>{this.header}</li>
                    </ul>
                </div>

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