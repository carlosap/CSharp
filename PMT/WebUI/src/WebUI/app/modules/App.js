import React, {Component} from 'react';
import NavLink from './NavLink'
import Nav from './Nav'
class App extends Component {
  constructor(props) {
    super(props);
  }
  componentWillMount() {
    try {
      if (kendo)
        kendo.destroy(document.body);
    } catch (error) { }
  }
  componentDidMount() {
    app.service.user.trigger("read");
    app.service.Limits.trigger("get:humidity");
    app.service.Limits.trigger("get:temp");
    app.service.Limits.trigger("get:voc");
  }
  render() {
    return (
      <div>
        {this.props.children}
      </div>
    );
  }
}
export default App;