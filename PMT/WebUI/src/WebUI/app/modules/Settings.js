import React, {Component} from 'react';
import UserList from './forms/userList'
class Settings extends Component {
  constructor(props) {
    super(props);
    this.state = {
      users: [],
      errors: {},

    };
  }
  componentWillMount() {
    if (kendo) {
      kendo.destroy(document.body);
    }
    var localusers = app.cache.localGet("users") || [];
    this.setState({users: localusers})
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