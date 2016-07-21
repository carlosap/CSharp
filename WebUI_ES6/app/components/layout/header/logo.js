import React, {Component, PropTypes} from 'react';
import Router from 'react-router';
import { Link } from 'react-router';
class Logo extends Component {
  constructor(props) {
    super(props);

  }
  render() {
    var brand = null;
    if (this.props.hTextVisible) brand = (<Link to="app" className="navbar-brand">{this.props.hText}</Link>)
    else brand = (<Link to="app" className="navbar-brand"><img  src={this.props.src} /></Link>)

    return (
      <div class="navbar-header">
        {brand}
      </div>
    );
  }
}
Logo.propTypes = {
  src: React.PropTypes.string.require,
  hText: React.PropTypes.string.require,
  hTextVisible: React.PropTypes.bool
};
export default Logo;


