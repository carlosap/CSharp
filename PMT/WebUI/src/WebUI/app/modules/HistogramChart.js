import React, {Component, PropTypes} from 'react';
class HistogramCart extends Component {
    constructor(props) {
        super(props);

    }
    componentWillMount() {
        if (kendo) {
            kendo.destroy(document.body);
        }
    }
    componentDidMount() {
        this.createTempChart();
        this.createVocChart();


    }
    createVocChart(){
                $("#chart_voc").kendoChart({
            title: {
                text: "VOC"
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
                name: "PPM",
                data: [500, 1200, 1550, 1350, 1100, 2200, 2800, 3800, 2800, 1200],
                color: "#b8b8b8"
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
                format: "{0}PPM",
                template: "#= series.name #: #= value #"
            }
        });
    }
    createTempChart() {

        $("#chart_temperature").kendoChart({
            title: {
                text: "Temperatures"
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
                name: "FAHRENHEIT",
                data: [33.2, 40.5, 55, 67.0, 89.0, 94.2, 80.0, 65.0, 45.0, 32.0]

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

        //var tempChart = $("#chart_temperature").kendoChart();
        //$("#rangeslider").kendoRangeSlider();
        // var rangeSlider = $("#rangeslider").getKendoRangeSlider();
        // rangeSlider.wrapper.css("width", "400px");
        // rangeSlider.resize();

        //tempChart.resize();
    }
    render() {
        return (

            <div className="row">
                <div className="col-xs-12 col-xl-6">
                    <div id="chart_temperature"></div>
                </div>
                <div className="col-xs-12 col-xl-6">
                    <div id="chart_voc"></div>
                </div>
            </div>




        );
    }
}

export default HistogramCart;