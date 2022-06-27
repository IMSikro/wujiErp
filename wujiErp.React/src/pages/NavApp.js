import 'reset-css';
import React, { Component } from 'react';
import {
  Route,
  useHistory
} from 'react-router-dom'
import { Layout, Nav, Avatar } from '@douyinfe/semi-ui';
import { IconLayers, IconHome, IconMenu, IconUserGroup, IconIndentRight, IconMember } from '@douyinfe/semi-icons';

import '../css/custum.css'

import Home from './Home'
// import Order from './Order'
// import Produce from './Produce'
// import Customer from './Customer'
import Order from './Order/Index'
import Produce from './Produce/Index'
import Customer from './Customer/Index'

export default class NavApp extends Component {

  constructor(props) {
    super(props);

    this.state = { items: [] };
  }

  componentDidMount() {
    this.setStateNavItems();
  }

  setStateNavItems() {
    let items = [
      { itemKey: 'Home', text: '首页', link: '/', icon: <IconHome size="large" /> },
      { itemKey: 'Order', text: '订单管理', link: '/order', icon: <IconMenu size="large" /> },
      { itemKey: 'Customer', text: '客户管理', link: '/customer', icon: <IconUserGroup size="large" /> },
      { itemKey: 'Produce', text: '产品管理', link: '/produce', icon: <IconIndentRight size="large" /> },
    ];
    this.setState({ items });
  }

  getRouteItems() {
    return (
      <>
        <Route exact path='/' component={Home} />
        <Route path='/order' component={Order} />
        <Route path='/customer' component={Customer} />
        <Route path='/produce' component={Produce} />
      </>
    );
  }

  render() {
    const { Header, Footer, Sider, Content } = Layout;
    let { items } = this.state;
    let router = this.getRouteItems();

    let history = useHistory();
    console.log('history: ', history);

    return (
      <Layout style={{ border: '1px solid var(--semi-color-border)' }}>
        <Sider style={{ backgroundColor: 'var(--semi-color-bg-1)' }}>
          <Nav
            style={{ maxWidth: 220, height: '100%' }}
            // defaultSelectedKeys={defaultSelectedKeys}
            items={items}
            footer={{
              collapseButton: true,
            }}
          />
        </Sider>
        <Layout>
          <Header style={{ backgroundColor: 'var(--semi-color-bg-1)' }}>
            <Nav mode="horizontal">
              <Nav.Header>
                <IconLayers />
              </Nav.Header>
              <span
                style={{
                  color: 'var(--semi-color-text-2)',
                }}
              >
                <span
                  style={{
                    marginRight: '24px',
                    color: 'var(--semi-color-text-0)',
                    fontWeight: '600',
                  }}
                >
                  无忌ERP
                </span>
              </span>
              <Nav.Footer>
                <Avatar size="small" style={{ color: '#f56a00', backgroundColor: '#fde3cf' }}>
                  WJ
                </Avatar>
              </Nav.Footer>
            </Nav>
          </Header>
          <Content className="minHeight800">
            {router}
          </Content>
          <Footer
            style={{
              display: 'flex',
              justifyContent: 'space-between',
              padding: '20px',
              color: 'var(--semi-color-text-2)',
              backgroundColor: 'rgba(var(--semi-grey-0), 1)',
            }}
          >
            <span
              style={{
                display: 'flex',
                alignItems: 'center',
              }}
            >
              <IconMember size="large" style={{ marginRight: '18px', color: 'orange' }} />
              <span>Copyright © 2021 斤之水. All Rights Reserved. </span>
            </span>
            <span>
              <span>反馈建议</span>
            </span>
          </Footer>
        </Layout>
      </Layout>
    );
  }
}