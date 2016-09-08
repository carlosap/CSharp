import React, {Component, PropTypes} from 'react';
class SettingsForm3 extends Component {
    constructor(props) {
        super(props);

    }

    componentDidMount() {
        this.context.router.push('/message/hello');
        var _this = this;
        $("#select-period").kendoMobileButtonGroup({
            select: function (e) {
                switch(e.index){
                    case 0:
                        _this.context.router.push('/settings');
                        break;
                    case 1:
                        _this.context.router.push('/adduser');
                        break;
                    case 2:
                        _this.context.router.push('/settings3');
                        break;
                }  
            },
            index: 2
        });
    }
    render() {
        return (
            <div>
                <div className="k-content">
                    <ul id="select-period">
                        <li>
                            Users
                        </li>
                        <li>
                            Add User
                        </li>
                        <li>
                            Limits
                        </li>
                    </ul>
                </div>
                 <br/>
                <h4 className="m-b-20"> Set Sensor Limits </h4>
                <span id="popupNotification"></span>
            </div>
        );
    }
}
SettingsForm3.propTypes = {

};
SettingsForm3.contextTypes = {
  router: React.PropTypes.object
};
export default SettingsForm3;