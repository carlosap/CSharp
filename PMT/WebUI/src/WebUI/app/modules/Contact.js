import React, {Component} from 'react';
class Contact extends Component {
    constructor(props) {
        super(props);

    }

    componentDidMount() {


        $("#firstname").addClass("wide").kendoMaskedTextBox({
            clearPromptChar: true
        });

        $("#email").addClass("wide").kendoMaskedTextBox({
            clearPromptChar: true
        });

        $("#comments").addClass("resize");

    }
    render() {
        return (
            <div>
                <div className="col-xs-12">
                    <div className="row">
                        <h3>We’d Love to Hear from You!</h3>
                        <p>
                            Do you have questions on how to accept payments for your business? 
                            Complete your details and we will contact you shortly.
                        </p>
                    </div>
                </div>
                <div className="row m-b-20">
                    <div className="col-xs-12 col-xl-6">
                        <div className="row">
                            <div className="col-xs-12 col-xl-6">
                                <div className="form-group floating-labels is-empty">
                                    <input id="firstname" placeholder="First name"/>
                                </div>
                            </div>

                            <div className="col-xs-12 col-xl-6">
                                <div className="form-group floating-labels is-empty">
                                    <input id="email" placeholder="@Email"/>
                                </div>
                            </div>

                            <div className="col-xs-12 col-xl-12">
                                <div className="form-group floating-labels is-empty">
                                    <textarea
                                        placeholder="Enter Comments"
                                        id="comments" rows="5">
                                    </textarea>
                                </div>
                            </div>
                        </div>


                        <div className="row">
                            <div className="col-xs-12 col-xl-6">
                                <button type="submit"
                                    className="btn btn-warning">Submit
                                </button>
                            </div>

                        </div>
                    </div>
                </div>

            </div>
        );
    }
}
export default Contact;

