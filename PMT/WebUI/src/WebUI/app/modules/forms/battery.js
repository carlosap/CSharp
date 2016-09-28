import React, {Component, PropTypes} from 'react';
class BatteryForm extends Component {
    constructor(props) {
        super(props);
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
                        _this.context.router.push('/settings');
                        break;
                    case 1:
                        _this.context.router.push('/limits');
                        break;
                    case 2:
                        _this.context.router.push('/battery');
                        break;
                }
            },
            index: 2
        });

        $("#batteryrate").kendoDropDownList({
            dataTextField: "text",
            dataValueField: "value",
            dataSource: [
                { text: "Demo (2 secs)", value: "1" },
                { text: "Every Minute", value: "2" },
                { text: "Every Hour", value: "3" },
                { text: "Once Per Day", value: "4" }
            ],
            index: 0
        });
    }
    render() {
        return (
            <div>
                <div className="m-b-30">
                    <ul id="select-period">
                        <li><i className="zmdi zmdi-accounts m-r-5"></i>Users</li>
                        <li><i className="zmdi zmdi-exposure-alt m-r-5"></i>Sensors</li>
                        <li><i className="zmdi zmdi-battery-flash m-r-2"></i>Battery</li>
                    </ul>
                </div>

                <h4 className="m-b-30"> Battery Saver Mode </h4>
                <p>
                    The Battery Saver mode is configurable, enabling you to enable or disable
                    further elements such as your data connection, sensor activities,
                    and CPU usage.
                </p>
                <div className="row">
                    <div className="col-xs-12 col-xl-6">
                        <div className="row">

                            <div className="col-xs-12 col-xl-6">
                                <div className="form-group floating-labels is-empty">
                                    <input
                                        className="wide"
                                        id="batteryrate"
                                        name="batteryrate"
                                        placeholder="Select battery saver mode"/>
                                    <p className="error-block"></p>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div >
        );
    }
}
BatteryForm.contextTypes = {
    router: React.PropTypes.object
};
export default BatteryForm;