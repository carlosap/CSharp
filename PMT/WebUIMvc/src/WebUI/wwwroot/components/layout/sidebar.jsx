var Sidebar = React.createClass({
    render: function() {
        return (
                    <div className="sidebar-inner-wrapper">
                    <div className="sidebar-1">
                        <div className="sidebar-nav">

                            <div className="sidebar-section">
                                <div className="section-title">About Us</div>
                                <ul className="l1 list-unstyled section-content">
                                    <li>
                                        <a className="sideline" data-id="home" asp-controller="Home" asp-action="Index">
                                            <i className="zmdi zmdi-home md-icon pull-left"></i> <span className="title">PMT</span>
                                        </a>
                                    </li>
                                </ul>
                            </div>

                            <div className="sidebar-section">
                                <div className="section-title">Our Products</div>
                                <ul className="l1 list-unstyled section-content">
                                    <li>
                                        <a className="sideline" data-id="dashboards" asp-controller="Sensors" asp-action="Index">
                                            <i className="pull-right fa fa-caret-down icon-dashboards"></i> <i className="zmdi zmdi-view-dashboard md-icon pull-left"></i> <span className="title">Sensors</span>
                                        </a>
                                    </li>
                                </ul>
                            </div>

                            <div className="sidebar-section">
                                <div className="section-title">Contact Us</div>
                                <ul className="l1 list-unstyled section-content">
                                    <li>
                                        <a className="sideline" data-id="contactus" asp-controller="Contact" asp-action="Index">
                                            <i className="zmdi zmdi-account-box-phone md-icon pull-left"></i> <span className="title">Contact</span>
                                        </a>
                                    </li>
                                </ul>
                            </div>

                            <div className="sidebar-section">
                                <div className="section-title">Documentation</div>
                                <ul className="l1 list-unstyled section-content">
                                    <li>
                                        <a className="sideline" data-id="docs" asp-controller="Documentation" asp-action="Index">
                                            <i className="zmdi zmdi-info-outline md-icon pull-left"></i> <span className="title">Docs</span>
                                        </a>
                                    </li>
                                </ul>
                            </div>



                        </div>
                    </div>
          </div>
        );
    }
});

setInterval(function() {
    ReactDOM.render(<Sidebar  />,document.getElementById('sidebar')
  );
}, 500);