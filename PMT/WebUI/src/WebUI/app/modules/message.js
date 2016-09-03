import React, {Component, PropTypes} from 'react';

class Message extends Component {
    constructor(props) {
        super(props);

    }
    render() {
        return (
            <div>
                     <h2>{this.props.params.header}</h2>
                     <p>{this.props.params.msg}</p>
            </div>
        );
    }
}

export default Message;