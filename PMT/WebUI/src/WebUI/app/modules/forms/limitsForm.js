import React, {Component, PropTypes} from 'react';
class LimitsForm extends Component {
    constructor(props) {
        super(props);
        this.setState = this.setState.bind(this);
    }
    componentWillMount() {
        try {
            if (kendo)
                kendo.destroy(document.body);

        } catch (error) { }
    }
    componentDidMount() {
        var _this = this;
        $("#lowtemp").addClass("wide");
        $("#hightemp").addClass("wide");
        $("#tempmsg").addClass("resize");

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
    }

    setState(e) {
        var field = e.target.name;
        var value = e.target.value;
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
                                        id="lowtemp"
                                        name="lowtemp"
                                        onChange={this.setState}
                                        onKeyPress={this.keypressNumOnly}
                                        type="number"
                                        placeholder="Min (°F)"/>
                                    <p className="error-block"></p>
                                </div>
                            </div>

                            <div className="col-xs-12 col-xl-6">
                                <div className="form-group floating-labels is-empty">
                                    <input
                                        id="hightemp"
                                        name="hightemp"
                                        onChange={this.setState}
                                        onKeyPress={this.keypressNumOnly}
                                        type="number"
                                        placeholder="Max (°F)"/>
                                    <p className="error-block"></p>
                                </div>
                            </div>

                            <div className="col-xs-12 col-xl-12">
                                <div className="form-group floating-labels is-empty">
                                    <textarea
                                        placeholder="Enter message when Temperature is out of range"
                                        name="tempmsg"
                                        id="tempmsg"
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
                                        id="lowhumidity"
                                        name="lowhumidity"
                                        onChange={this.setState}
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
                                        id="highhumidity"
                                        name="highhumidity"
                                        onChange={this.setState}
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
                                        placeholder="Enter message when humidity is out of range"
                                        name="humiditymsg"
                                        id="humiditymsg"
                                        rows="3">
                                    </textarea>
                                    <p className="error-block"></p>

                                </div>
                            </div>
                        </div>
                    </div>
                </div>


                <h4 className="m-b-30"> Volatile Organic Compounds (VOC)</h4>
                <div className="row">
                    <div className="col-xs-12 col-xl-6">
                        <div className="row">

                            <div className="col-xs-12 col-xl-6">
                                <div className="form-group floating-labels is-empty">
                                    <input
                                        className="wide"
                                        id="lowppm"
                                        name="lowppm"
                                        onChange={this.setState}
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
                                        id="highppm"
                                        name="highppm"
                                        onChange={this.setState}
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
                                        placeholder="Enter message when PPM is out of range"
                                        name="ppmmsg"
                                        id="ppmmsg"
                                        rows="3">
                                    </textarea>
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
LimitsForm.contextTypes = {
    router: React.PropTypes.object
};
export default LimitsForm;