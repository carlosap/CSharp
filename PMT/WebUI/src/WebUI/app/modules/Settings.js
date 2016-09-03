import React, {Component} from 'react';
import SettingsForm from './forms/settingsForm'
class Settings extends Component {
    constructor(props) {
        super(props);
        this.state = {
            contact: { emailto: 'perezca6576@yahoo.com', firstname: '', email: '', comments: '' },
            errors: {},

        };
        this.thankyou_msg = "Thank you,<br> so one of our Customer Service colleagues<br> will get back to you within a few hours.";
        this.saveContact = this.saveContact.bind(this);
        this.setContactState = this.setContactState.bind(this);
    }

    send(contact) {

        app.service.request("/sendemail?emailto=" + contact.emailto + "&" +
            "emailfrom=" + contact.email + "&" +
            "emailsubject=Feedback and Comments from client&" +
            "emailtext=Name: " + contact.firstname + " <br>Comments: " + contact.comments + "&" +
            "emailattachment=&" +
            "emailtype=&" +
            "cache=no", this.success.bind(this), this.error.bind(this));



    }
    success(data, reqNum, url, queryData, reqTotal, isNested) {
        app.progress.hide();
        app.notify.show(this.thankyou_msg , "info");
    }
    error(reqNum, url, queryData, errorType, errorMsg, reqTotal) {
        app.progress.hide();
        app.notify.show("Please check network connection and try again." , "warning");
    }
    setContactState(e) {
        var field = e.target.name;
        var value = e.target.value;
        this.state.contact[field] = value;
        return this.setState({ contact: this.state.contact });

    }

    saveContact() {
        event.preventDefault();
        if (!this.contactFormIsValid()) {
            return;
        }

        app.progress.show(2);
        this.send(this.state.contact);
    }

    contactFormIsValid() {
        var formIsValid = true;
        this.state.errors = {}; 
        if (app.utils.isNullUndefOrEmpty(this.state.contact.firstname)) {
            this.state.errors.firstname = 'Name can not be empty.';
            formIsValid = false;
        }

        if (!app.utils.isEmail(this.state.contact.email)) {
            this.state.errors.email = 'Invalid e-mail.';
            formIsValid = false;
        }

        if (app.utils.isNullUndefOrEmpty(this.state.contact.comments)) {
            this.state.errors.comments = 'Comments are required.';
            formIsValid = false;
        }
        this.setState({ errors: this.state.errors });
        return formIsValid;
    }

  render() {
    return (
      <div>
        <h4 className="m-b-20"> Floating labels </h4>
        <SettingsForm
          contact={this.state.contact}
          onChange={this.setContactState}
          onSave={this.saveContact}
          errors={this.state.errors}

          />
      </div>
    );
  }
}
export default Settings;