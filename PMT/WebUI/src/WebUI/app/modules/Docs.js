import React, {Component, PropTypes} from 'react';
class Docs extends Component {
  constructor(props) {
     super(props);
  }
  render() {
    return (
      <div ng-view="" autoscroll="true">
    <div className="row documentation">
        <div className="col-xs-12">
            <div className="bs-nav-tabs nav-tabs-warning">
                <ul className="nav nav-tabs nav-animated-border-from-center">
                    <li className="nav-item"> <a href="" className="nav-link active" data-toggle="tab" data-target="#nav-tabs-0-8">Getting started</a></li>
                    <li className="nav-item"> <a href="" className="nav-link" data-toggle="tab" data-target="#nav-tabs-0-1">AngularJS</a> </li>
                </ul>

                <div className="tab-content">

                    <div role="tabpanel" className="tab-pane in active" id="nav-tabs-0-8">
                        <p>Thanks for purchasing <b>Marino</b>. Marino is here to help you with your next project. If you have
                            any questions that are beyond the scope of this help file, please feel free to contact us via
                            email at support@batchthemes.com or through our contact form in our Theme Forest profile.</p>
                        <p> <b>Marino</b> is an advanced, responsive dashboard UI kit built using <a href="http://v4-alpha.getbootstrap.com/"><b>Bootstrap 4</b></a>,
                            the most popular HTML, CSS, and JS framework for developing responsive, mobile first projects
                            on the web, <a href="https://angularjs.org" target="_blank"><b>AngularJS</b></a>, the Superheroic
                            JavaScript MVW Framework which enhances your HTML for web apps and <a href="http://jquery.com/"
                                target="_blank"><b>jQuery</b></a>, the fast, small, and feature-rich JavaScript library. It includes
                            9 different layouts, 23 color schemes, more than 150 HTML files and lots of widgets and custom
                            made reusable components to help you develop your next application.</p>
                        <h4> Template versions </h4>
                        <p><b>Marino</b> is available in PHP, HTML with jQuery and AngularJS versions. To try the demos, please
                            click <a href="http://marino.batchthemes.com" target="_blank">here</a>.</p>
                        <h4> Ready to use files </h4>
                        <p>To help you get started, we have compiled and ready to use versions of <b>Marino</b> in the <code>dist</code>folder
                            in the root folder of every version. Just go to the version you want to try, open any server
                            and you are ready to go.</p>
                    </div>

                    <div role="tabpanel" className="tab-pane" id="nav-tabs-0-1">
                        <h4> Template requirements </h4>
                        <p>The following frameworks, components and dependencies are required to install <b>Marino</b>:</p>
                        <ul>
                            <li>
                                <h5> <b>AngularJS 1.4+</b> </h5>
                                <p>HTML enhanced for web apps!</p>
                                <p>
                                    <a href="https://angularjs.org/" target="_blank"> <i className="fa fa-book"></i> Official Documentation</a>
                                </p>
                            </li>
                            <li>
                                <h5> <b>Bootstrap 4</b> </h5>
                                <p>Bootstrap is the most popular HTML, CSS, and JS framework for developing responsive, mobile
                                    first projects on the web.</p>
                                <p>
                                    <a href="http://v4-alpha.getotbootstrap.com" target="_blank"> <i className="fa fa-book"></i> Official Documentation</a>
                                </p>
                            </li>
                            <li>
                                <h5> <b>jQuery</b> </h5>
                                <p>jQuery is a fast, small, and feature-rich JavaScript library.</p>
                                <p>
                                    <a href="http://jquery.com/" target="_blank"> <i className="fa fa-book"></i> Official Documentation</a>
                                </p>
                            </li>
                            <li>
                                <h5> <b>NodeJS</b> </h5>
                                <p>Node.js is a platform built on Chrome's JavaScript runtime for easily building fast, scalable
                                    network applications. Node.js uses an event-driven, non-blocking I/O model that makes
                                    it lightweight and efficient, perfect for data-intensive real-time applications that
                                    run across distributed devices.</p>
                                <p>
                                    <a href="https://nodejs.org/" target="_blank"> <i className="fa fa-book"></i> Official Documentation</a>
                                </p>
                            </li>
                            <li>
                                <h5> <b>Bower</b> </h5>
                                <p>A package manager for the web. Web sites are made of lots of things — frameworks, libraries,
                                    assets, and utilities. Bower manages all these things for you.</p>
                                <p>
                                    <a href="http://bower.io/" target="_blank"> <i className="fa fa-book"></i> Official Documentation</a>
                                </p>
                            </li>
                            <li>
                                <h5> <b>Grunt</b> </h5>
                                <p>The JavaScript Task Runner. With literally hundreds of plugins to choose from, you can use
                                    Grunt to automate just about anything with a minimum of effort.</p>
                                <p>
                                    <a href="http://gruntjs.com/" target="_blank"> <i className="fa fa-book"></i> Official Documentation</a>
                                </p>
                            </li>
                            <li>
                                <h5> <b>SASS</b> </h5>
                                <p>CSS with superpowers. Sass is the most mature, stable, and powerful professional grade CSS
                                    extension language in the world.</p>
                                <p>
                                    <a href="http://sass-lang.com/" target="_blank"> <i className="fa fa-book"></i> Official Documentation</a>
                                </p>
                            </li>
                        </ul>
                        <h4> Installation instructions for local development </h4>
                        <p>After installing all the required frameworks, components and dependencies, go to the root folder
                            of and run the following commands from the command line:</p>
                        <ul>
                            <li> <code>npm install</code> </li>
                            <li> <code>bower install</code> </li>
                            <li> <code>grunt serve</code> </li>
                        </ul>
                        <p>If everything was installed correctly, you should see the AngularJS version of <b>Marino</b> running
                            in <code>http://localhost:9003/</code> </p>
                        <h4> Compilation instructions </h4>
                        <p>If you want to compile the application to deploy it to a remote server, run the following command:</p>
                        <ul>
                            <li> <code>grunt build</code> </li>
                        </ul>
                        <p>Your application is now ready to deploy and can be found in the <code>dist/</code> folder.</p>
                        <h4>
                        Source code structure </h4>
                        <p>The main folders of the AngularJS version of <b>Marino</b> are:</p>
                        <ul>
                            <li>
                                <h4> <b>app</b> </h4>
                                <p>Includes the entire application and its development files</p>
                            </li>
                            <li>
                                <h4> <b>bower_components</b> </h4>
                                <p>Includes all the dependencies installed with bower</p>
                            </li>
                            <li>
                                <h4> <b>node_modules</b> </h4>
                                <p>Includes all node packages, components and dependencies installed with NPM</p>
                            </li>
                            <li>
                                <h4> <b>dist</b> </h4>
                                <p>After compiling the application with the grunt build command, this folder is created and
                                    all production ready files and folders are put in this folder. This is the folder you
                                    have to upload if you want to publish your application to the world </p>
                            </li>
                        </ul>
                        <h4> Important files</h4>
                        <ul>
                            <li>
                                <h4> <b>app/index.html</b> </h4>
                                <p>Main application file. This file includes every script, stylesheet and template used in the
                                    application</p>
                            </li>
                            <li>
                                <h4> <b>scripts/app.js</b> </h4>
                                <p>Main javascript file. Includes module and route definitions, global theme and component configuration</p>
                            </li>
                            <li>
                                <h4> <b>styles/main.scss</b> </h4>
                                <p>Main SCSS stylesheet of the application. Any global style or additional <code>.scss</code>                                    
                                file added to the application must be included in this file</p>
                            </li>
                            <li>
                                <h4> <b>styles/_variables.scss</b> </h4>
                                <p>Global SCSS variables are defined here.</p>
                            </li>
                            <li>
                                <h4> <b>styles/_palettes.scss</b> </h4>
                                <p>Colour palettes are defined here.</p>
                            </li>
                            <li>
                                <h4> <b>styles/layouts/*.scss</b> </h4>
                                <p>Template layouts are defined in this folder</p>
                            </li>
                            <li>
                                <h4> <b>styles/helpers/*.scss</b> </h4>
                                <p>Includes global CSS and SCSS helpers</p>
                            </li>
                            <li>
                                <h4> <b>styles/_mixins.scss</b> </h4>
                                <p>Includes SASS mixins used in some parts of the application</p>
                            </li>
                            <li>
                                <h4> <b>scripts/services/colors.js</b> </h4>
                                <p>Global colors used in <code>.js</code> files are defined here. This file is the javascript
                                    version of the <code>styles/_variables.scss</code> file</p>
                            </li>
                            <li>
                                <h4> <b>scripts/services/functions.js</b> </h4>
                                <p>Global functions used in the application are defined here</p>
                            </li>
                            <li>
                                <h4> <b>scripts/services/dashboards.js</b> </h4>
                                <p>Common functions used in every dashboard view are defined here. This includes the maps, charts
                                    and notifications that are reused in the dashboard views</p>
                            </li>
                            <li>
                                <h4> <b>scripts/services/navigation.js</b> </h4>
                                <p>Global menus and navigation links are defined here. This includes the left sidebar, navbar
                                    and horizontal navigation links and menus</p>
                            </li>
                            <li>
                                <h4> <b>scripts/services/sample-data.js</b> </h4>
                                <p>All the sample data used in the controllers and in some directives is defined here</p>
                            </li>
                        </ul>
                        <h4> Naming convention for widgets </h4>
                        <p>
                            All the widgets used in the application are directives and they use the following coding and
                            naming convention</p>

                        <ul>
                            <li>HTML files are located in the <code>app/views/activity-widgets</code> folder</li>
                            <li>SCSS files are located in the <code>app/styles/activity-widgets</code> folder</li>
                            <li>JS files are located in the <code>app/scripts/directives</code> folder</li>
                            <li>
                                <p>In this case, for this widget the file names are the following:</p>
                                <ol>
                                    <li> <code>app/views/activity-widgets/activity-widget-1.js</code> </li>
                                    <li> <code>app/styles/activity-widgets/activity-widget-1.html</code> </li>
                                    <li> <code>app/scripts/directives/_activity-widget-1.scss</code> </li>
                                </ol>
                            </li>
                        </ul>
                    </div>

                </div>
            </div>
        </div>
    </div>
</div>
    );
  }
};

export default Docs;