import { Layout, Nav, Avatar } from '@douyinfe/semi-ui';
import { IconLayers, IconMember } from '@douyinfe/semi-icons';
import { useLocation, useNavigate } from "react-router-dom";
import Content from '../Content/Index'
import AppRoutes, { GetRouter } from '../Routes/Index';

function Sider() {
    const { Header, Footer, Sider } = Layout;
    let location = useLocation();
    let items = GetRouter();
    let itemkey;
    let baseUrlEnv = import.meta.env.VITE_ROUTER_BASE || '/';
    var path = location.pathname.toLowerCase().replace(baseUrlEnv.toLowerCase(), '');
    // console.log(import.meta.env);
    // console.log(location.pathname, path);
    switch (path) {
        case '':
            itemkey = 'home';
            break;
        default:
            itemkey = path;
    }

    const navigate = useNavigate();

    return (
        <Layout style={{ border: '1px solid var(--semi-color-border)' }}>
            <Sider style={{ backgroundColor: 'var(--semi-color-bg-1)' }}>
                <Nav
                    defaultIsCollapsed={true}
                    style={{ maxWidth: 220, height: '100%' }}
                    items={items}
                    selectedKeys={[itemkey]}
                    onClick={({ itemKey }) => {
                        let path = items.find(i => i.itemKey == itemKey).path;
                        navigate(path);
                    }}
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
                <Content>
                    <AppRoutes />
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
    )
}

export default Sider;