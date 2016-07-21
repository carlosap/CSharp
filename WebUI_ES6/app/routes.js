import React  from 'react';
import ReactDOM  from 'react-dom';
import { Router, Route, browserHistory } from 'react-router';
import App  from './components/App';
import Home  from './components/homePage';
import AuthorPage  from './components/authors/authorPage';
import ManageAuthorPage  from './components/authors/manageAuthorPage';
import AboutPage  from './components/about/aboutPage';
import ContactPage  from './components/contact/contactPage';
import SettingPage  from './components/settings/settingsPage';
import NotFoundPage  from './components/notFoundPage';


// var DefaultRoute = Router.DefaultRoute;
// var Route = Router.Route;
// var NotFoundRoute = Router.NotFoundRoute;
// var Redirect = Router.Redirect;


var routes = (
  <Router history={browserHistory}>
    <Route name="app" path="/" component={App}>
      <DefaultRoute component={Home} />
      <Route name="authors" path="/author" component={AuthorPage} />
      <Route name="addAuthor" path="/author" component={ManageAuthorPage} />
      <Route name="manageAuthor" path="/author/:id" component={ManageAuthorPage}  />
      <Route name="about" path="/about" component={AboutPage} />
      <Route name="contact" path="/contact" component={ContactPage} />
      <Route name="settings" path="/settings" component={SettingPage} />
      <NotFoundRoute component={NotFoundPage} />
      <Redirect from="about-us" to="about" />
      <Redirect from="awthurs" to="authors" />
      <Redirect from="about/*" to="about" />
    </Route>
  </Router>
);
ReactDOM.render(routes, document.getElementById('main'))