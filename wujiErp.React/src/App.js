import 'reset-css';
import React, { Component } from 'react';
// import { Route } from 'react-router';
import NavApp from './pages/NavApp'
// import Home from './pages/Home'
// import Order from './pages/Order'
// import Product from './pages/Product'
// import Customer from './pages/Customer'

export default class App extends Component {
  render() {
    return (
      <NavApp />
      // <NavApp>
      //   <Route exact path='/' component={Home} />
      //   <Route path='/orders' component={Order} />
      //   <Route path='/products' component={Product} />
      //   <Route path='/customers' component={Customer} />
      // </NavApp>
    );
  }
}