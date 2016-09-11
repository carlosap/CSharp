import React, {Component, PropTypes} from 'react';
class LimitsForm extends Component {
    constructor(props) {
        super(props);
        this.state = {
            limits: {
                temp_min: 0,
                temp_max: 0,
                temp_msg: '',
                humidity_min: 0,
                humidity_max: 0,
                humidity_msg: '',
                voc_min: 0,
                voc_max: 0,
                voc_msg: ''
            },
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
                        _this.context.router.push('/network');
                        break;
                }
            },
            index: 1
        });

        var localLimits = this.getLimits();
        if (!app.utils.isNullUndefOrEmpty(localLimits)) {
            this.setState({ limits: localLimits });
            $("#temp_min").val(localLimits.temp_min);
            $("#temp_max").val(localLimits.temp_max);
            $("#temp_msg").val(localLimits.temp_msg);
            $("#humidity_min").val(localLimits.humidity_min);
            $("#humidity_max").val(localLimits.humidity_max);
            $("#humidity_msg").val(localLimits.humidity_msg);
            $("#temp_min").val(localLimits.temp_min);
            $("#voc_min").val(localLimits.voc_min);
            $("#voc_max").val(localLimits.voc_max);
            $("#voc_msg").val(localLimits.voc_msg);
        }
    }

    setLimitState(e) {
        var field = e.target.name;
        var value = e.target.value;
        this.state.limits[field] = value;
        return this.setState({ limits: this.state.limits });
    }
    saveLimits() {
        event.preventDefault();
        app.cache.localSet("limits", this.state.limits);
        this.context.router.push('/settings');
    }
    getLimits() {
        try {
            var _this = this;
            var limits = app.cache.localGet("limits") || {};
            return limits;
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
                <div>
                    <ul id="select-period">
                        <li><i className="zmdi zmdi-accounts m-r-5"></i>Users</li>
                        <li><i className="zmdi zmdi-exposure-alt m-r-5"></i>Limits</li>
                        <li><i className="zmdi zmdi-network-setting m-r-5"></i>Network</li>
                    </ul>
                </div>
                <hr className="shadow"/>
                <h4 className="m-b-20"> Temperature </h4>
                <div className="row">
                    <div className="col-xs-12 col-xl-6">
                        <div className="row">

                            <div className="col-xs-12 col-xl-6">
                                <div className="form-group floating-labels is-empty">
                                    <input
                                        className="wide"
                                        id="temp_min"
                                        name="temp_min"
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


                <h4 className="m-b-30"> Volatile Organic Compounds (VOC) </h4>
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
            </div >
        );
    }
}
LimitsForm.contextTypes = {
    router: React.PropTypes.object
};
export default LimitsForm;