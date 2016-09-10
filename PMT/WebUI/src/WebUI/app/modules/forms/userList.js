import React, {Component, PropTypes} from 'react';
class UserList extends Component {
    constructor(props) {
        super(props);
    }
    componentWillMount() {
        if (kendo) {
            kendo.destroy(document.body);
        }
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
            index: 0
        });

        $("#select-usermenu").kendoMobileButtonGroup({
            select: function (e) {
                switch (e.index) {
                    case 0:
                        _this.context.router.push('/adduser');
                        break;
                }
            }
        });

    }

    render() {
        var createUserRow = function (user, index) {
            var cellStyleEmail = '';
            var cellStyleMsM = '';
            var isEmail = user.enableSendEmail ? "Yes" : "No";
            var isMsM = user.enableSendText ? "Yes" : "No";
            var linkTo = "#/edituser/" + user.email;

            //---Styles------------------------------->>>
            if (isEmail === "Yes") cellStyleEmail = "label label-success"
            else cellStyleEmail = "label label-danger"

            if (isMsM === "Yes") cellStyleMsM = "label label-success"
            else cellStyleMsM = "label label-danger"

            //<<---Styles--------------------------------

            return (
                <tr key={index}>

                    <th scope="row">

                        <a className="btn btn-warning btn-sm" href={linkTo}>
                            <i className="zmdi zmdi-edit m-r-5"></i>Edit
                        </a>
                    </th>
                    <td>{user.firstname + " " + user.lastname}</td>
                    <td><span className={cellStyleEmail}>{isEmail}</span></td>
                    <td><span className={cellStyleMsM}>{isMsM}</span> </td>
                </tr>
            );
        };
        return (
            <div>
                <div>
                    <ul id="select-period">
                        <li><i className="zmdi zmdi-accounts m-r-5"></i>Users</li>
                        <li><i className="zmdi zmdi-widgets m-r-5"></i>Sensors</li>
                        <li><i className="zmdi zmdi-network-setting m-r-5"></i>Network</li>
                    </ul>
                </div>

                <hr id="hrHeader"className="shadow"/>
                <h4 className="m-b-30"> Users / Notifications </h4>
                <div className="m-b-20">
                    <ul id="select-usermenu">
                        <li><i className="zmdi zmdi-account-add m-r-5"></i>Add User</li>
                    </ul>

                </div>
                <div className="row m-b-20">
                    <div className="col-xs-12 col-xl-6">
                        <div className="row">
                            <div className="col-xs-12 col-xl-12">
                                <div className="table-responsive">
                                    <table className="table table-hover table-striped sortable-theme-bootstrap"
                                        data-sortable=""
                                        data-sortable-initialized="true">
                                        <thead>
                                            <tr>
                                                <th></th>
                                                <th>Users <i className="zmdi zmdi-account m-r-5"></i></th>
                                                <th>EMAIL <i className="zmdi zmdi-account-box-mail m-r-5"></i></th>
                                                <th>Phone Message <i className="zmdi zmdi-phone-msg m-r-5"></i></th>
                                            </tr>
                                        </thead>
                                        <tbody>
                                            {this.props.users.map(createUserRow, this) }
                                        </tbody>
                                    </table>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        );
    }
}

UserList.propTypes = {
    users: React.PropTypes.array.isRequired
};

UserList.contextTypes = {
    router: React.PropTypes.object
};
export default UserList;