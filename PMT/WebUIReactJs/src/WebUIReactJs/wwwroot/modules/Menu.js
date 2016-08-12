import React from 'react'
import NavLink from './NavLink'

export default React.createClass({
    render() {
        return (
            <div className="row">
                <div className="sidebar-placeholder"></div>
                <div className="sidebar-outer-wrapper">
                    <div className="sidebar-inner-wrapper">
                        <div className="sidebar-1">
                            <div className="sidebar-nav">

                                <div className="sidebar-section">
                                    <div className="section-title">About Us</div>
                                    <ul className="l1 list-unstyled section-content">
                                        <li>
                                            <NavLink to="/about" className="sideline" data-id="home">About
                                                <i className="zmdi zmdi-home md-icon pull-left"></i>  <span class="title">PMT</span>
                                            </NavLink>

                                        </li>
                                    </ul>
                                </div>

                                <div className="sidebar-section">
                                    <div className="section-title">Our Products</div>
                                    <ul className="l1 list-unstyled section-content">
                                        <li>
                                            <a className="sideline" data-id="dashboards">
                                                <i className="pull-right fa fa-caret-down icon-dashboards"></i>  <i className="zmdi zmdi-view-dashboard md-icon pull-left"></i>  <span class="title">Sensors</span>
                                            </a>
                                        </li>
                                    </ul>
                                </div>

                                <div className="sidebar-section">
                                    <div className="section-title">Contact Us</div>
                                    <ul className="l1 list-unstyled section-content">
                                        <li>
                                            <a className="sideline" data-id="contactus">
                                                <i className="zmdi zmdi-account-box-phone md-icon pull-left"></i>  <span class="title">Contact</span>
                                            </a>
                                        </li>
                                    </ul>
                                </div>

                                <div className="sidebar-section">
                                    <div className="section-title">Documentation</div>
                                    <ul className="l1 list-unstyled section-content">
                                        <li>
                                            <a className="sideline" data-id="docs" >
                                                <i className="zmdi zmdi-info-outline md-icon pull-left"></i>  <span className="title">Docs</span>
                                            </a>
                                        </li>
                                    </ul>
                                </div>



                            </div>
                        </div>
                    </div>
                </div>
            </div>
        )
    }
})
