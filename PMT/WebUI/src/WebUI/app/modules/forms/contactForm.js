import React, {Component, PropTypes} from 'react';

class ContactForm extends Component {
    constructor(props) {
        super(props);

    }

    componentWillMount() {
        if (kendo) {
            kendo.destroy(document.body);
        }
    }
    componentDidMount() {
        $("#cmdSave").kendoButton();
        $("#firstname").addClass("wide").kendoMaskedTextBox({ clearPromptChar: false });
        $("#email").addClass("wide").kendoMaskedTextBox({ clearPromptChar: false });
        $("#comments").addClass("resize");
    }

    componentWillUnmount() {

    }

    render() {
        return (
            <div>
                <div className="col-xs-12">
                    <div className="row">
                        <span id="popupNotification"></span>
                        <h3>We’d Love to Hear from You!</h3>
                        <p>
                           
                            Complete your details and we will contact you shortly.
                        </p>
                    </div>
                </div>
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
                                        id="email"
                                        name="email"
                                        value={this.props.contact.email}
                                        onChange={this.props.onChange}
                                        error={this.props.errors.email}
                                        placeholder="@Email"/>
                                    <p className="error-block">{this.props.errors.email}</p>
                                </div>
                            </div>

                            <div className="col-xs-12 col-xl-12">
                                <div className="form-group floating-labels is-empty">
                                    <textarea
                                        placeholder="Enter Comments"
                                        name="comments"
                                        id="comments"
                                        value={this.props.contact.comments}
                                        onChange={this.props.onChange}
                                        error={this.props.errors}
                                        rows="5">
                                    </textarea>
                                    <p className="error-block">{this.props.errors.comments}</p>

                                </div>
                            </div>
                        </div>


                        <div className="row">
                            <div className="col-xs-12 col-xl-6">
                                <button
                                    id="cmdSave"
                                    className="k-primary"
                                    onClick={this.props.onSave}
                                    >Submit
                                </button>
                            </div>


                        </div>

                    </div>

                </div>

            </div>
        );
    }
}

ContactForm.propTypes = {
    contact: React.PropTypes.object.isRequired,
    onSave: React.PropTypes.func.isRequired,
    onChange: React.PropTypes.func.isRequired,
    errors: React.PropTypes.object
};

export default ContactForm;