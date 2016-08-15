import React from 'react'
import NavLink from './NavLink'
import Nav from './Nav'

export default React.createClass({
  render() {
    return (
      <div>
        {this.props.children}
      </div>
    )
  }
})



