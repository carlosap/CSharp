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
import Documentations from './modules/Docs'
import Message from './modules/message'

//settings Pages
import Settings from './modules/Settings'
import UserList from './modules/forms/userList'
import AddUser from './modules/forms/addUser'
import EditUser from './modules/forms/editUser'
import Settings3 from './modules/forms/settingsForm3'

//chart
import HistogramChart from './modules/HistogramChart'

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
      <Route path="/message/:header/:msg" component={Message}/>

      <Route path="/settings" component={Settings}/>
      <Route path="/userlist" component={UserList}/>
      <Route path="/adduser" component={AddUser}/>
      <Route path="/edituser/:email" component={EditUser}/>
      <Route path="/settings3" component={Settings3}/>
      <Route path="/histogram" component={HistogramChart}/>

    </Route>
  </Router>
), document.getElementById('app'))
