import { useRoutes } from 'react-router-dom'
import { IconHome, IconMenu, IconUserGroup, IconIndentRight, IconHistogram } from '@douyinfe/semi-icons';
import About from '../../pages/About/Index';
import Home from '../../pages/Home';
import Order from '../../pages/Order/Index';
import Customer from '../../pages/Customer/Index';
import Produce from '../../pages/Produce/Index';

export function GetRouter() {
    let routes = [
        // path,element为路由字段
        // itemKey,text,link,icon为 Nav 菜单字段
        { path: "/", element: <Home />, itemKey: 'home', text: '首页', link: '/', icon: <IconHome size="large" /> },
        { path: "/order", element: <Order />, itemKey: 'order', text: '订单管理', link: '/order', icon: <IconMenu size="large" /> },
        { path: "/customer", element: <Customer />, itemKey: 'customer', text: '客户管理', link: '/customer', icon: <IconUserGroup size="large" /> },
        { path: "/produce", element: <Produce />, itemKey: 'produce', text: '产品管理', link: '/produce', icon: <IconIndentRight size="large" /> },
        { path: "about", element: <About />, itemKey: 'about', text: '关于', link: '/about', icon: <IconHistogram size="large" /> },
        // ...
    ];
    return routes;
}

function AppRoutes() {
    return useRoutes(GetRouter());
}

export default AppRoutes;
