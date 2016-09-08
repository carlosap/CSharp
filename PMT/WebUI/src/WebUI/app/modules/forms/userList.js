import React, {Component, PropTypes} from 'react';
//<Link to="manageuser" params={{email: user.email}}>{index+1}</Link>
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
                        _this.context.router.push('/adduser');
                        break;
                    case 2:
                        _this.context.router.push('/settings3');
                        break;
                }
            },
            index: 0
        });
    }

    render() {
        var createUserRow = function (user, index) {
            var cellStyleEmail = '';
            var cellStyleMsM = '';
            var isEmail = user.enableSendEmail ? "Yes": "No";
            var isMsM = user.enableSendText ? "Yes": "No";
            var linkTo = "#/edituser/" + user.email;

            //---Styles------------------------------->>>
            if(isEmail === "Yes") cellStyleEmail = "label label-success"
            else cellStyleEmail = "label label-danger"
                
            if(isMsM === "Yes")cellStyleMsM = "label label-success"
            else cellStyleMsM = "label label-danger"

            //<<---Styles--------------------------------

            return (
                <tr key={index}>
                
                    <th scope="row"><a href={linkTo}>{index+1}</a></th>
                    <td>{user.firstname + " " +user.lastname}</td>
                    <td><span className={cellStyleEmail}>{isEmail}</span></td>
                    <td><span className={cellStyleMsM}>{isMsM}</span> </td>
                </tr>
            );
        };
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
                <h4 className="m-b-20"> Users / Notifications </h4>
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
                                                <th>#</th>
                                                <th>USER</th>
                                                <th>EMAIL</th>
                                                <th>SMS</th>
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