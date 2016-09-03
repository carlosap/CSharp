import React, {Component, PropTypes} from 'react';

class SettingsForm extends Component {
    constructor(props) {
        super(props);

    }

    componentWillMount() {

    }

    componentDidMount() {
        $("#firstname").addClass("wide").kendoMaskedTextBox({ clearPromptChar: false });
        $("#lastname").addClass("wide").kendoMaskedTextBox({ clearPromptChar: false });
        $("#telephone").kendoMaskedTextBox({ mask: "(999) 000-0000" }).addClass("wide");
        $("#email").addClass("wide").kendoMaskedTextBox({ clearPromptChar: false });
        $("#comments").addClass("resize");
    }

    componentWillUnmount() {

    }

    render() {
        return (
            <div>
                <div className="row m-b-20">
                    <div className="col-xs-12 col-xl-6">
                        <div className="row">

                            <div className="col-xs-12 col-xl-6">
                                <div className="form-group floating-labels is-empty">
                                    <input
                                        id="firstname"
                                        name="firstname"
                                        value={this.props.contact.firstname}
                                        onChange={this.props.onChange}
                                        placeholder="First name"/>
                                    <p className="error-block">{this.props.errors.firstname}</p>
                                </div>
                            </div>
                            <div className="col-xs-12 col-xl-6">
                                <div className="form-group floating-labels is-empty">
                                    <input
                                        id="lastname"
                                        name="lastname"
                                        value={this.props.contact.lastname}
                                        onChange={this.props.onChange}
                                        placeholder="Last name"/>
                                    <p className="error-block">{this.props.errors.lastname}</p>
                                </div>
                            </div>
                        </div>

                        <div className="row">
                            <div className="col-xs-12 col-xl-6">
                                <div className="form-group floating-labels is-empty">
                                    <input
                                        id="email"
                                        name="email"
                                        value={this.props.contact.email}
                                        onChange={this.props.onChange}
                                        error={this.props.errors.email}
                                        placeholder="@Email"/>
                                    <p className="error-block">{this.props.errors.email}</p>
                                </div>
                            </div>

                            <div className="col-xs-12 col-xl-6">
                                <div className="form-group floating-labels is-empty">
                                    <input
                                        id="telephone"
                                        name="telephone"
                                        value={this.props.contact.telephone}
                                        onChange={this.props.onChange}
                                        error={this.props.errors.telephone}
                                        placeholder="Phone number"/>
                                    <p className="error-block">{this.props.errors.telephone}</p>
                                </div>
                            </div>
                        </div>

                        <div className="row">
                            <div className="col-xs-12 col-xl-12">
                                <div className="table-responsive">
                                    <table className="table table-hover table-striped sortable-theme-bootstrap" data-sortable="" data-sortable-initialized="true">
                                        <thead>
                                            <tr>
                                                <th>#</th>
                                                <th>Company</th>
                                                <th>Country</th>
                                                <th>Status</th>
                                            </tr>
                                        </thead>
                                        <tbody>
                                            <tr>
                                                <th scope="row">1</th>
                                                <td>Facebook</td>
                                                <td>Mexico</td>
                                                <td> <span className="label label-danger">danger</span> </td>
                                            </tr>
                                            <tr>
                                                <th scope="row">2</th>
                                                <td>LG Electronics</td>
                                                <td>France</td>
                                                <td> <span className="label label-danger">danger</span> </td>
                                            </tr>
                                            <tr>
                                                <th scope="row">3</th>
                                                <td>Pinterest</td>
                                                <td>Sweden</td>
                                                <td> <span className="label label-success">success</span> </td>
                                            </tr>
                                            <tr>
                                                <th scope="row">4</th>
                                                <td>Google Inc.</td>
                                                <td>USA</td>
                                                <td> <span className="label label-warning">warning</span> </td>
                                            </tr>
                                            <tr>
                                                <th scope="row">5</th>
                                                <td>Uber</td>
                                                <td>England</td>
                                                <td> <span className="label label-danger">danger</span> </td>
                                            </tr>
                                            <tr>
                                                <th scope="row">6</th>
                                                <td>Microsoft Inc.</td>
                                                <td>Brazil</td>
                                                <td> <span className="label label-info">info</span> </td>
                                            </tr>
                                            <tr>
                                                <th scope="row">7</th>
                                                <td>Twitter</td>
                                                <td>Argentina</td>
                                                <td> <span className="label label-success">success</span> </td>
                                            </tr>
                                            <tr>
                                                <th scope="row">8</th>
                                                <td>Facebook</td>
                                                <td>USA</td>
                                                <td> <span className="label label-danger">danger</span> </td>
                                            </tr>
                                            <tr>
                                                <th scope="row">9</th>
                                                <td>Tinder</td>
                                                <td>Canada</td>
                                                <td> <span className="label label-warning">warning</span> </td>
                                            </tr>
                                            <tr>
                                                <th scope="row">10</th>
                                                <td>Apple, Inc.</td>
                                                <td>Germany</td>
                                                <td> <span className="label label-primary">primary</span> </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </div>
                            </div>
                        </div>





                        <div className="row">
                            <div className="col-xs-12 col-xl-6">
                                <button type="submit"
                                    className="btn btn-warning"
                                    onClick={this.props.onSave}>
                                    Submit
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

SettingsForm.propTypes = {
    contact: React.PropTypes.object.isRequired,
    onSave: React.PropTypes.func.isRequired,
    onChange: React.PropTypes.func.isRequired,
    errors: React.PropTypes.object
};

export default SettingsForm;