import React, {Component, PropTypes} from 'react';
class EditUser extends Component {
    constructor(props) {
        super(props);
        this.users = [],
            this.Id = this.props.params.email;
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
        //CRUD functions and Bindings(MIXINGS)
        this.saveUser = this.saveUser.bind(this);
        this.addUser = this.addUser.bind(this);
        this.deleteUser = this.deleteUser.bind(this);
        this.setUserState = this.setUserState.bind(this);
        this.findUser = this.findUser.bind(this);
        this.updateUser = this.updateUser.bind(this);
        
    }
    saveUser() {
        event.preventDefault();
        try {
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
            var localUserFound = this.findUser() || [];
            if (localUserFound.length > 0) {
                //update
                this.updateUser();
                app.service.user.trigger("update", { data: this.state.user });
                this.context.router.push('/settings');
            } else {
                //new
                this.addUser();
                users.push(this.state.user);
                this.context.router.push('/settings');
            }
        } catch (error) { }
    }

    findUser() {
        try {
            var _this = this;
            var users = app.cache.localGet("users") || [];
            return $.grep(users, function (item, i) {
                return item.email === _this.Id;
            });
        } catch (error) { }
    }
    addUser() {
        try {
            var users = app.cache.localGet("users") || [];
            users.push(this.state.user);
            app.cache.localSet("users", users);
            app.service.user.trigger("create", { data: this.state.user });
        } catch (error) { }
    }

    deleteUser() {
        try {
            var _this = this;
            var user = _this.state.user;
            var users = app.cache.localGet("users") || [];
            var filtered = users.filter(function (element) {
                return element.email !== _this.Id;
            });
            app.cache.localSet("users", filtered);
            app.service.user.trigger("delete", { data: user });
            _this.context.router.push('/settings');
        } catch (error) { }
    }
    updateUser() {
        try {
            var _this = this;
            var user = _this.state.user;
            var users = app.cache.localGet("users") || [];
            var filtered = users.filter(function (element) {
                return element.email !== _this.Id;
            });
            filtered.push(this.state.user);
            app.cache.localSet("users", filtered);
        } catch (error) { }
    }

    setUserState(e) {
        try {
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
        } catch (error) { }

    }
    contactFormIsValid() {
        try {
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
        } catch (error) { }
    }

    componentWillMount() {
        try {
            if (kendo)
                kendo.destroy(document.body);

        } catch (error) { }
    }
    componentDidMount() {
        try {
            var _this = this;
            $("#cmdSave").kendoButton();
            $("#cmdDelete").kendoButton();
            $("#firstname").addClass("wide").kendoMaskedTextBox({ clearPromptChar: false });
            $("#lastname").addClass("wide").kendoMaskedTextBox({ clearPromptChar: false });
            $("#phone").kendoMaskedTextBox({ mask: "(999) 000-0000" }).addClass("wide");
            $("#email").addClass("wide").kendoMaskedTextBox({ clearPromptChar: false });
            $("#enableSendEmail").kendoMobileSwitch({ onLabel: "YES", offLabel: "NO" });
            $("#enableSendText").kendoMobileSwitch({ onLabel: "YES", offLabel: "NO" }).addClass("animated-switch");
            var switchTextInstance = $("#enableSendText").data("kendoMobileSwitch");
            var switchEmailInstance = $("#enableSendEmail").data("kendoMobileSwitch");
            var localUserFound = this.findUser() || [];
            if (localUserFound.length > 0) {
                $("#phone").val(localUserFound[0].phone);
                $("#firstname").val(localUserFound[0].firstname);
                $("#lastname").val(localUserFound[0].lastname);
                $("#email").val(localUserFound[0].email);
                switchTextInstance.check(localUserFound[0].enableSendText);
                switchEmailInstance.check(localUserFound[0].enableSendEmail);
                this.setState({ user: localUserFound[0] });
            }

            $("#select-period").kendoMobileButtonGroup({
                select: function (e) {
                    switch (e.index) {
                        case 0:
                            _this.context.router.push('/settings');
                            break;
                    }
                },
                index: 1
            });

        } catch (error) { }
    }

    render() {
        return (
            <div>
                <div className="m-b-30">
                    <ul id="select-period">
                        <li><i className="zmdi zmdi-rotate-left m-r-5"></i>Return to Users</li>
                        <li>Edit User</li>
                    </ul>
                </div>

     
                <h4 className="m-b-30"> Edit User Information </h4>
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
                                    > Save
                                </button>
                                {'\u00b7'}
                                {'\u00b7'}
                                <button
                                    id="cmdDelete"
                                    className="btn btn-lg btn-danger"
                                    onClick={this.deleteUser}
                                    >Delete
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