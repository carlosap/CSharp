import React from 'react'
import { render } from 'react-dom'
import { Router, Route, hashHistory, IndexRoute } from 'react-router'
import App from './modules/App'
import About from './modules/About'
import Contact from './modules/Contact'
import Repos from './modules/Repos'
import Repo from './modules/Repo'
import Home from './modules/Home'
import Sensors from './modules/Sensors'
import Documentations from './modules/Docs'

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
    </Route>
  </Router>
), document.getElementById('app'))
