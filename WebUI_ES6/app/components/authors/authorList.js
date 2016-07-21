import React, {Component, PropTypes} from 'react';
import Router from 'react-router';
import { Link } from 'react-router';
class AuthorList extends Component {
	constructor(props) {
		super(props);

	}
	render() {
		var createAuthorRow = function (author) {
			return (
				<tr key={author.id}>
					<td><Link to="manageAuthor" params={{ id: author.id }}>{author.id}</Link></td>
					<td>{author.firstName} {author.lastName}</td>
				</tr>
			);
		};
		return (
			<div>
				<table className="table">
					<thead>
						<th>ID</th>
						<th>Name</th>
					</thead>
					<tbody>
						{this.props.authors.map(createAuthorRow, this) }
					</tbody>
				</table>
			</div>
		);
	}
}

AuthorList.propTypes = {
	authors: React.PropTypes.array.isRequired
};

export default AuthorList;


