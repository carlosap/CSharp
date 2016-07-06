"use strict";
var React = require('react');
var Contact = React.createClass({
    render: function () {
        var htmlServiceContent = app.staticPages.get("contact");
        return (
            <div className="page-footer">
                {(() => {
                    if (htmlServiceContent) {
                        return <div dangerouslySetInnerHTML={{ __html: htmlServiceContent }} />
                    } else {
                        return <div>
                            <h1>Contact</h1>
                            <address>
                                One Microsoft Way<br />
                                Redmond, WA 98052-6399<br />
                                <abbr title="Phone">P: </abbr>
                                425.555.0100
                            </address>

                            <address>
                                <strong>Support: </strong> <a href="mailto:Support@example.com">Support @example.com</a><br />
                                <strong>Marketing: </strong> <a href="mailto:Marketing@example.com">Marketing @example.com</a>
                            </address>
                        </div>
                    }
                })() }
            </div>
        );
    }
});

module.exports = Contact;