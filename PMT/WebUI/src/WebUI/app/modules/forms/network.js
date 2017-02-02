import React, {Component, PropTypes} from 'react';
class NetworkForm extends Component {
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
            index: 2
        });

        $("#network").kendoDropDownList({
            dataTextField: "text",
            dataValueField: "value",
            dataSource: [
                { text: "Select Network..", value: "1" },
                { text: "PMT-Wifi", value: "2" },
                { text: "ATT&T-HOTSPOT232", value: "3" },
                { text: "HOST-Wifi", value: "4" }
            ],
            index: 0
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
                        <li><i className="zmdi zmdi-exposure-alt m-r-5"></i>Sensors</li>
                        <li><i className="zmdi zmdi-network-setting m-r-5"></i>Wireless</li>
                    </ul>
                </div>
    
                <h4 className="m-b-20"> Network Settings </h4>
                <p>
                    Setting up network is a good way to get more out of your system. 
                    Networking allows you to manage all of the operations 
                    of data transfer, and storage.
                </p>
                <div className="row">

                    <div className="row">
                        <div className="col-xs-12 col-xl-6">
                            <div className="form-group floating-labels is-empty">
                                <input
                                    className="wide"
                                    id="network"
                                    name="network"
                                    placeholder="Select Network"/>
                                <p className="error-block"></p>
                            </div>
                        </div>
                    </div>




                    <div className="row">
                        <div className="col-xs-12 col-xl-6">
                            <div className="form-group floating-labels is-empty">
                                <input
                                    className="wide"
                                    id="password"
                                    name="password"
                                    type="password"
                                    placeholder="Enter Password"/>
                                <p className="error-block"></p>
                            </div>
                        </div>
                    </div>

                </div>
            </div >
        );
    }
}
NetworkForm.contextTypes = {
    router: React.PropTypes.object
};
export default NetworkForm;