var React = require('react');
var Router = require('react-router');
var Link = Router.Link;
var Logo = React.createClass({
  propTypes: {
    src: React.PropTypes.string.require,
    hText: React.PropTypes.string.require,
    hTextVisible: React.PropTypes.bool
  },
  render: function () {
    var brand = null;
    if (this.props.hTextVisible) brand = (<Link to="app" className="navbar-brand">{this.props.hText}</Link>)
    else brand = (<Link to="app" className="navbar-brand"><img  src={this.props.src} /></Link>)   
    return (
      <div class="navbar-header">
        {brand}
      </div>

    );
  }
});
module.exports = Logo;