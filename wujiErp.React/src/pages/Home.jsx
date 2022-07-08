import React, { Component } from 'react';
import { Button, Layout, Upload } from '@douyinfe/semi-ui';
import { IconUpload } from '@douyinfe/semi-icons';
import wuji from '../api/api';


export default class Home extends Component {
    render() {
        const { Content } = Layout;
        document.title = "无忌ERP - 首页";
        return (
            <Content>

                <Upload action={wuji.base + '/WJ/Upload/Video'} accept={'video/*'} style={{ marginBottom: 12 }}>
                    <Button icon={<IconUpload />} >
                        上传视频
                    </Button>
                </Upload>
                {/* <Button onClick={() => {
                    var uploader = new Uploader({
                        target: '/api/photo/redeem-upload-token'
                    })
                }}>点击</Button> */}
            </Content>
        );
    }
}