import React, {Component, PropTypes} from 'react';
class Docs extends Component {
    constructor(props) {
        super(props);
    }
    render() {
        return (
            <div className="col-xs-12">
                <p> 
                    This section shows example documentation used to communicate with the AMS ENS210
                    Relative Humidity and Temperature Sensor to display the measurements on a simple LCD display.This
                    reference design is not intended to be a production ready solution, but provides a framework for the
                    customer to develop solutions that address their needs.
                </p>
            </div>
        );
    }
};

export default Docs;