import React, {Component, PropTypes} from 'react';
import Router from 'react-router';
import { Link } from 'react-router';
import AuthorApi from '../../api/authorApi';
import AuthorList from './authorList';

class AuthorPage extends Component {
	constructor(props) {
		super(props);
		authors = [];

	}
	componentDidMount() {
		if (this.isMounted()) {
			this.setState({ authors: AuthorApi.getAllAuthors() });
		}
	}
	render() {
		return (
			<div>
				<h1>Authors</h1>
				<Link to="addAuthor" className="btn btn-default">Add Author</Link>
				<AuthorList authors={this.state.authors} />
			</div>
		);
	}
}
export default AuthorPage;

