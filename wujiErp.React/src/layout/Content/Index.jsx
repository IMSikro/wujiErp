import { Layout } from '@douyinfe/semi-ui';
import '../../assets/custom.css'

function Content({ children }) {
    const { Content } = Layout;
    return (
        <Content className="minHeight800">
            {children}
        </Content>
    )
}

export default Content;