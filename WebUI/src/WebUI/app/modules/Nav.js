import React from 'react'
export default React.createClass({
  render() {
    return <nav className="navbar navbar-fixed-top navbar-1">
    <img className="navbar-brand" src="images/logo.png" />

    <ul className="nav navbar-nav pull-right toggle-layout">
        <li className="nav-item">
            <a className="nav-link" data-click="toggle-layout">
                <i className="zmdi zmdi-menu"></i>
            </a>
        </li>
    </ul>
</nav>
  }
})
