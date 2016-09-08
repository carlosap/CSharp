import React, {Component, PropTypes} from 'react';
class EditUser extends Component {
    constructor(props) {
        super(props);
        this.state = {
            user: {
                firstname: '',
                lastname: '',
                email: '',
                phone: '',
                enableSendEmail: true,
                enableSendText: true
            },
            errors: {}
        };
        this.saveUser = this.saveUser.bind(this);
        this.setUserState = this.setUserState.bind(this);
    }
    saveUser() {
        event.preventDefault();
        //add any non-onChange input required -->>
        var switchTextInstance = $("#enableSendText").data("kendoMobileSwitch");
        var switchEmailInstance = $("#enableSendEmail").data("kendoMobileSwitch");
        var phonevalue = $("#phone").val();
        this.state.user["phone"] = phonevalue;
        this.state.user["enableSendText"] = switchTextInstance.check();
        this.state.user["enableSendEmail"] = switchEmailInstance.check();
        //<<----

        //validate
        if (!this.contactFormIsValid()) {
            return;
        }
        //save
        app.progress.show(2);
        var users = app.cache.localGet("users") || [];
        var localUserFound = this.findUser(users, this.state.user.email) || [];
        if (localUserFound.length > 0) {

            app.notify.show("user ready in the system");
        } else {
            users.push(this.state.user);
            app.cache.localSet("users", users);
            this.context.router.push('/settings');
            //app.notify.show(this.state.user.firstname + " was added to the system", "success");
            //this.clearForm();
        }
    }

    findUser(userList, userEmail) {
        return $.grep(userList, function (item, i) {
            return item.email === userEmail;
        });
    }

    setUserState(e) {

        //workarounds
        var switchTextInstance = $("#enableSendText").data("kendoMobileSwitch");
        var switchEmailInstance = $("#enableSendEmail").data("kendoMobileSwitch");
        var phonevalue = $("#phone").val();
        //native code.
        var field = e.target.name;
        var value = e.target.value;
        this.state.user[field] = value;
        this.state.user["enableSendText"] = switchTextInstance.check();
        this.state.user["enableSendEmail"] = switchEmailInstance.check();
        this.state.user["phone"] = phonevalue;
        return this.setState({ user: this.state.user });
    }
    contactFormIsValid() {
        var formIsValid = true;
        this.state.errors = {};
        if (app.utils.isNullUndefOrEmpty(this.state.user.firstname)) {
            this.state.errors.firstname = 'Name can not be empty.';
            formIsValid = false;
        }

        if (app.utils.isNullUndefOrEmpty(this.state.user.lastname)) {
            this.state.errors.lastname = 'last Name can not be empty.';
            formIsValid = false;
        }

        if (app.utils.isNullUndefOrEmpty(this.state.user.phone)) {
            this.state.errors.phone = 'Phone Number can not be empty.';
            formIsValid = false;
        }

        if (!app.utils.isEmail(this.state.user.email)) {
            this.state.errors.email = 'Invalid e-mail.';
            formIsValid = false;
        }
        this.setState({ errors: this.state.errors });
        return formIsValid;
    }

    componentWillMount() {
        if (kendo)
            kendo.destroy(document.body);

    }



    componentDidMount() {
        var _this = this;
        $("#cmdSave").kendoButton();
        $("#firstname").addClass("wide").kendoMaskedTextBox({ clearPromptChar: false });
        $("#lastname").addClass("wide").kendoMaskedTextBox({ clearPromptChar: false });
        $("#phone").kendoMaskedTextBox({ mask: "(999) 000-0000" }).addClass("wide");
        $("#email").addClass("wide").kendoMaskedTextBox({ clearPromptChar: false });
        $("#enableSendEmail").kendoMobileSwitch({ onLabel: "YES", offLabel: "NO" });
        $("#enableSendText").kendoMobileSwitch({ onLabel: "YES", offLabel: "NO" }).addClass("animated-switch");
        var switchTextInstance = $("#enableSendText").data("kendoMobileSwitch");
        var switchEmailInstance = $("#enableSendEmail").data("kendoMobileSwitch");


        //get Current User
        var users = app.cache.localGet("users") || [];
        var localUserFound = this.findUser(users, this.props.params.email) || [];
        if (localUserFound.length > 0) {
            $("#phone").val(localUserFound[0].phone);
            $("#firstname").val(localUserFound[0].firstname);
            $("#lastname").val(localUserFound[0].lastname);
            $("#email").val(localUserFound[0].email);
            switchTextInstance.check(localUserFound[0].enableSendText);
            switchEmailInstance.check(localUserFound[0].enableSendEmail);
            this.setState({ user: localUserFound[0] });
        }

    }

    render() {
        return (
            <div>
                <h4 className="m-b-20"> Edit User Information </h4>
                <div className="row m-b-20">
                    <div className="col-xs-12 col-xl-6">
                        <div className="row">

                            <div className="col-xs-12 col-xl-6">
                                <div className="form-group floating-labels is-empty">
                                    <input
                                        id="firstname"
                                        name="firstname"
                                        value={this.state.user.firstname}
                                        onChange={this.setUserState}
                                        placeholder="First name"/>
                                    <p className="error-block">{this.state.errors.firstname}</p>
                                </div>
                            </div>
                            <div className="col-xs-12 col-xl-6">
                                <div className="form-group floating-labels is-empty">
                                    <input
                                        id="lastname"
                                        name="lastname"
                                        value={this.state.user.lastname}
                                        onChange={this.setUserState}
                                        placeholder="Last name"/>
                                    <p className="error-block">{this.state.errors.lastname}</p>
                                </div>
                            </div>
                        </div>

                        <div className="row">
                            <div className="col-xs-12 col-xl-6">
                                <div className="form-group floating-labels is-empty">
                                    <input
                                        id="email"
                                        name="email"
                                        value={this.state.user.email}
                                        onChange={this.setUserState}
                                        placeholder="@Email"/>
                                    <p className="error-block">{this.state.errors.email}</p>
                                </div>
                            </div>

                            <div className="col-xs-12 col-xl-6">
                                <div className="form-group floating-labels is-empty">
                                    <input
                                        id="phone"
                                        name="phone"
                                        value={this.state.user.phone}
                                        onChange={this.setUserState}
                                        placeholder="Phone number"/>
                                    <p className="error-block">{this.state.errors.phone}</p>
                                </div>
                            </div>
                        </div>

                        <div className="row">
                            <h4 className="m-b-20"> Notifications </h4>
                            <div className="table-responsive">
                                <table className="table"
                                    data-sortable-initialized="true">
                                    <thead>
                                        <tr>
                                            <th></th>
                                            <th></th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <tr>
                                            <th scope="row">Email</th>
                                            <td className="pull-left">
                                                <input
                                                    onClick={this.setUserState}
                                                    name="enableSendEmail"
                                                    id="enableSendEmail"

                                                    />

                                            </td>
                                        </tr>

                                        <tr>
                                            <th scope="row">MSM</th>
                                            <td className="pull-left">
                                                <input
                                                    name="enableSendText"
                                                    id="enableSendText"
                                                    />
                                            </td>
                                        </tr>


                                    </tbody>
                                </table>

                            </div>
                        </div>

                        <div className="row">
                            <br/>
                            <div className="col-xs-12 col-xl-6">
                                <button
                                    id="cmdSave"
                                    className="k-primary"
                                    onClick={this.saveUser}
                                    >Save Settings
                                </button>
                            </div>


                        </div>

                    </div>

                </div>
                <span id="popupNotification"></span>
            </div>
        );
    }
}

EditUser.contextTypes = {
    router: React.PropTypes.object
};
export default EditUser;