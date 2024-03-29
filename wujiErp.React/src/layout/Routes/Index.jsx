import { useRoutes } from 'react-router-dom'
import { IconHome, IconMenu, IconUserGroup, IconIndentRight, IconHistogram } from '@douyinfe/semi-icons';
import About from '../../pages/About/Index';
import Home from '../../pages/Home';
import Order from '../../pages/Order/Index';
import Customer from '../../pages/Customer/Index';
import Produce from '../../pages/Produce/Index';

export function GetRouter() {
    const base = import.meta.env.VITE_ROUTER_BASE || '/' //"/Erp/Wuji/"
    let routes = [
        // path,element为路由字段
        // itemKey,text,icon为 Nav 菜单字段
        { path: base, element: <Home />, itemKey: 'home', text: '首页', icon: <IconHome size="large" /> },
        { path: base + "order", element: <Order />, itemKey: 'order', text: '订单管理', icon: <IconMenu size="large" /> },
        { path: base + "customer", element: <Customer />, itemKey: 'customer', text: '客户管理', icon: <IconUserGroup size="large" /> },
        { path: base + "produce", element: <Produce />, itemKey: 'produce', text: '产品管理', icon: <IconIndentRight size="large" /> },
        { path: base + "about", element: <About />, itemKey: 'about', text: '关于', icon: <IconHistogram size="large" /> },
        // ...
    ];
    return routes;
}

function AppRoutes() {
    return useRoutes(GetRouter());
}

export default AppRoutes;
