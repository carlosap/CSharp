import React, {Component, PropTypes} from 'react';
import Router from 'react-router';
import AuthorForm from './authorForm';
import AuthorApi from '../../api/authorApi';
import PureRenderMixin from 'react-addons-pure-render-mixin';
import autoBind from 'react-autobind';

class ManageAuthorPage extends Component() {
	constructor() {
		super();
		autoBind(this);
		author = { id: '', firstName: '', lastName: '' };
		errors = {};
		dirty = false;
		this.shouldComponentUpdate = PureRenderMixin.shouldComponentUpdate.bind(this);

	}

	setAuthorState(event) {
		this.setState({ dirty: true });
		var field = event.target.name;
		var value = event.target.value;
		this.state.author[field] = value;
		return this.setState({ author: this.state.author });
	}


	authorFormIsValid() {
		var formIsValid = true;
		this.state.errors = {};
		if (this.state.author.firstName.length < 3) {
			this.state.errors.firstName = 'First name must be at least 3 characters.';
			formIsValid = false;
		}

		if (this.state.author.lastName.length < 3) {
			this.state.errors.lastName = 'Last name must be at least 3 characters.';
			formIsValid = false;
		}

		this.setState({ errors: this.state.errors });
		return formIsValid;
	}

	saveAuthor(event) {
		event.preventDefault();

		if (!this.authorFormIsValid()) {
			return;
		}

		AuthorApi.saveAuthor(this.state.author);
		this.setState({ dirty: false });
		toastr.success('Author saved.');
		this.transitionTo('authors');
	}
	componentDidMount() {
		//from the path '/author:id'
		var authorId = this.props.params.id;

		if (authorId) {
			this.setState({ author: AuthorApi.getAuthorById(authorId) });
		}
	}
	render() {
		return (
			<AuthorForm
				author={this.state.author}
				onChange={this.setAuthorState}
				onSave={this.saveAuthor}
				errors={this.state.errors} />
		);
	}
}

export default ManageAuthorPage;


