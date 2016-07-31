var HelloWorld = React.createClass({
  render: function() {
    return (
      <div>{this.props.date.toTimeString()}</div>
    );
  }
});

setInterval(function() {
  ReactDOM.render(
    <HelloWorld date={new Date()} />,
    document.getElementById('displaydatetime')
  );
}, 500);