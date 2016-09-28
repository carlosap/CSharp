import React, {Component} from 'react';
import UserList from './forms/userList'
class Settings extends Component {
  constructor(props) {
    super(props);
    this.state = {
      users: [],
      errors: {}
    };
  }
  componentWillMount() {
    try {
      if (kendo) {
        kendo.destroy(document.body);
      }
      this.setState({ users: app.cache.localGet("users") });
    } catch (error) { }
  }
  render() {
    return (
      <div>
        <UserList users={this.state.users}/>
      </div>
    );
  }
}
export default Settings;