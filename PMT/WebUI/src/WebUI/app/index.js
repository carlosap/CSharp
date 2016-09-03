import React from 'react'
import { render } from 'react-dom'
import { Router, Route, hashHistory, IndexRoute,transitionTo } from 'react-router'
import App from './modules/App'
import About from './modules/About'
import Contact from './modules/Contact'
import Repos from './modules/Repos'
import Repo from './modules/Repo'
import Home from './modules/Home'
import Sensors from './modules/Sensors'
import Settings from './modules/Settings'
import Documentations from './modules/Docs'
import Message from './modules/message'

render((
  <Router history={hashHistory}>
    <Route path="/" component={App}>
      <IndexRoute component={Home}/>
      <Route path="/repos" component={Repos}>
        <Route path="/repos/:userName/:repoName" component={Repo}/>
      </Route>
      <Route path="/about" component={About}/>
      <Route path="/contact" component={Contact}/>
      <Route path="/sensors" component={Sensors}/>
      <Route path="/docs" component={Documentations}/>
      <Route path="/settings" component={Settings}/>
      <Route path="/message/:header/:msg" component={Message}/>

    </Route>
  </Router>
), document.getElementById('app'))
