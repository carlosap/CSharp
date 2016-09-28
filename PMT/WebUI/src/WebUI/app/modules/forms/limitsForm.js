import React, {Component, PropTypes} from 'react';
class LimitsForm extends Component {
    constructor(props) {
        super(props);
        this.state = {
            temp: {
                min: 0,
                max: 0,
                msg: ''
            },
            humidity: {
                min: 0,
                max: 0,
                msg: '',
            },
            voc: {
                min: 0,
                max: 0,
                msg: ''
            }
        };
        this.setLimitState = this.setLimitState.bind(this);
        this.saveLimits = this.saveLimits.bind(this);
    }
    componentWillMount() {
        try {
            if (kendo)
                kendo.destroy(document.body);
        } catch (error) { }
    }
    componentDidMount() {
        var _this = this;
        $("#cmdSave").kendoButton();
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
            index: 1
        });

        //get grup of limits
        var localLimits = this.getLimits();
        if (!app.utils.isNullUndefOrEmpty(localLimits)) {
            this.setState({ temp: localLimits.temp });
            this.setState({ humidity: localLimits.humidity });
            this.setState({ voc: localLimits.voc });

            $("#temp_min").val(localLimits.temp.min ||'');
            $("#temp_max").val(localLimits.temp.max ||'');
            $("#temp_msg").val(localLimits.temp.msg || '');
            $("#humidity_min").val(localLimits.humidity.min || '');
            $("#humidity_max").val(localLimits.humidity.max || '');
            $("#humidity_msg").val(localLimits.humidity.msg || '');
            $("#voc_min").val(localLimits.voc.min || '');
            $("#voc_max").val(localLimits.voc.max ||'');
            $("#voc_msg").val(localLimits.voc.msg ||'');
        }

    }

    setLimitState(e) {
        var field = e.target.name;
        var value = e.target.value;
        switch (field) {
            case "temp_min":
                this.state.temp["min"] = value;
                return this.setState({ temp: this.state.temp });
            case "temp_max":
                this.state.temp["max"] = value;
                return this.setState({ temp: this.state.temp });
            case "temp_msg":
                this.state.temp["msg"] = value;
                return this.setState({ temp: this.state.temp });
            case "humidity_min":
                this.state.humidity["min"] = value;
                return this.setState({ humidity: this.state.humidity });
            case "humidity_max":
                this.state.humidity["max"] = value;
                return this.setState({ humidity: this.state.humidity });
            case "humidity_msg":
                this.state.humidity["msg"] = value;
                return this.setState({ humidity: this.state.humidity });
            case "voc_min":
                this.state.voc["min"] = value;
                return this.setState({ voc: this.state.voc });
            case "voc_max":
                this.state.voc["max"] = value;
                return this.setState({ voc: this.state.voc });
            case "voc_msg":
                this.state.voc["msg"] = value;
                return this.setState({ voc: this.state.voc });
            default:
                break;
        }
        return false;
    }
    saveLimits() {
        event.preventDefault();
        app.cache.localSet("temp", this.state.temp);
        app.cache.localSet("humidity", this.state.humidity);
        app.cache.localSet("voc", this.state.voc);
        app.service.Limits.trigger("humidity", { data: this.state.humidity });
        app.service.Limits.trigger("voc", { data: this.state.voc });
        app.service.Limits.trigger("temperature", { data: this.state.temp });
        app.notify.show("Saved!");

    }
    getLimits() {
        try {
            var results = {};
            var humidity = app.cache.localGet("humidity") ? app.cache.localGet("humidity") :{};
            var temp = app.cache.localGet("temp") ? app.cache.localGet("temp") :{};
            var voc = app.cache.localGet("voc") ? app.cache.localGet("voc") :{};
            results.humidity = humidity;
            results.temp = temp;
            results.voc = voc;
            return results;
        } catch (error) { }
    }
    keypressNumOnly(e) {
        var unicode = e.charCode ? e.charCode : e.keyCode
        if (unicode != 8 && unicode != 0 && (unicode < 48 || unicode > 57))
            return false
    }
    render() {
        return (
            <div>
                <div className="m-b-30">
                    <ul id="select-period">
                        <li><i className="zmdi zmdi-accounts m-r-5"></i>Users</li>
                        <li><i className="zmdi zmdi-exposure-alt m-r-5"></i>Limits</li>
                        <li><i className="zmdi zmdi-battery-flash m-r-5"></i>Baterry</li>
                    </ul>
                </div>
    
                <h4 className="m-b-30"> Temperature </h4>
                <div className="row">
                    <div className="col-xs-12 col-xl-6">
                        <div className="row">

                            <div className="col-xs-12 col-xl-6">
                                <div className="form-group floating-labels is-empty">
                                    <input
                                        className="wide"
                                        id="temp_min"
                                        name="temp_min"
                                        value={this.state.temp.min}
                                        onChange={this.setLimitState}
                                        onKeyPress={this.keypressNumOnly}
                                        type="number"
                                        placeholder="Min (°F)"/>
                                    <p className="error-block"></p>
                                </div>
                            </div>

                            <div className="col-xs-12 col-xl-6">
                                <div className="form-group floating-labels is-empty">
                                    <input
                                        className="wide"
                                        id="temp_max"
                                        name="temp_max"
                                        onChange={this.setLimitState}
                                        onKeyPress={this.keypressNumOnly}
                                        type="number"
                                        placeholder="Max (°F)"/>
                                    <p className="error-block"></p>
                                </div>
                            </div>

                            <div className="col-xs-12 col-xl-12">
                                <div className="form-group floating-labels is-empty">
                                    <textarea
                                        className="resize"
                                        onChange={this.setLimitState}
                                        placeholder="Enter message when Temperature is out of range"
                                        name="temp_msg"
                                        id="temp_msg"
                                        rows="3">
                                    </textarea>
                                    <p className="error-block"></p>

                                </div>
                            </div>
                        </div>
                    </div>
                </div>

                <h4 className="m-b-30" > Humidity </h4>
                <div className="row">
                    <div className="col-xs-12 col-xl-6">
                        <div className="row">

                            <div className="col-xs-12 col-xl-6">
                                <div className="form-group floating-labels is-empty">
                                    <input
                                        className="wide"
                                        id="humidity_min"
                                        name="humidity_min"
                                        onChange={this.setLimitState}
                                        onKeyPress={this.keypressNumOnly}
                                        type="number"
                                        placeholder="Min (%)"/>
                                    <p className="error-block"></p>
                                </div>
                            </div>

                            <div className="col-xs-12 col-xl-6">
                                <div className="form-group floating-labels is-empty">
                                    <input
                                        className="wide"
                                        id="humidity_max"
                                        name="humidity_max"
                                        onChange={this.setLimitState}
                                        onKeyPress={this.keypressNumOnly}
                                        type="number"
                                        placeholder="Max (%)"/>
                                    <p className="error-block"></p>
                                </div>
                            </div>

                            <div className="col-xs-12 col-xl-12">
                                <div className="form-group floating-labels is-empty">
                                    <textarea
                                        className="resize"
                                        onChange={this.setLimitState}
                                        placeholder="Enter message when humidity is out of range"
                                        name="humidity_msg"
                                        id="humidity_msg"
                                        rows="3">
                                    </textarea>
                                    <p className="error-block"></p>

                                </div>
                            </div>
                        </div>
                    </div>
                </div>


                <h4 className="m-b-30"> Volatile Organic Compounds (VOC-CO2) </h4>
                <div className="row">
                    <div className="col-xs-12 col-xl-6">
                        <div className="row">

                            <div className="col-xs-12 col-xl-6">
                                <div className="form-group floating-labels is-empty">
                                    <input
                                        className="wide"
                                        onChange={this.setLimitState}
                                        id="voc_min"
                                        name="voc_min"
                                        onChange={this.setLimitState}
                                        onKeyPress={this.keypressNumOnly}
                                        type="number"
                                        placeholder="Min (PPM)"/>
                                    <p className="error-block"></p>
                                </div>
                            </div>

                            <div className="col-xs-12 col-xl-6">
                                <div className="form-group floating-labels is-empty">
                                    <input
                                        className="wide"
                                        id="voc_max"
                                        name="voc_max"
                                        onChange={this.setLimitState}
                                        onKeyPress={this.keypressNumOnly}
                                        type="number"
                                        placeholder="Max (PPM)"/>
                                    <p className="error-block"></p>
                                </div>
                            </div>

                            <div className="col-xs-12 col-xl-12">
                                <div className="form-group floating-labels is-empty">
                                    <textarea
                                        className="resize"
                                        onChange={this.setLimitState}
                                        placeholder="Enter message when PPM is out of range"
                                        name="voc_msg"
                                        id="voc_msg"
                                        rows="3">
                                    </textarea>
                                    <p className="error-block"></p>

                                </div>
                            </div>
                        </div>
                    </div>
                </div>

                <div className="row">
                    <div className="col-xs-12 col-xl-6">
                        <button
                            id="cmdSave"
                            className="k-primary"
                            onClick={this.saveLimits}
                            >Save Sensor Limits
                        </button>
                    </div>
                </div>
                <span id="popupNotification"></span>
            </div >
        );
    }
}
LimitsForm.contextTypes = {
    router: React.PropTypes.object
};
export default LimitsForm;