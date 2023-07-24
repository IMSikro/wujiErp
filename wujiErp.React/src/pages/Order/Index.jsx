import 'reset-css';
import React, { Component } from 'react';
import { Nav, Card, Table, Layout, Form, Button, Tooltip, Tag, Modal, Upload, Row, Col } from '@douyinfe/semi-ui';
import { IconUpload } from '@douyinfe/semi-icons';
import PinyinMatch from 'pinyin-match';
import wuji from '../../api/api';

export default class Order extends Component {

    render() {
        document.title = "无忌ERP - 订单管理";
        return (
            <Layout>
                <OrderTable />
            </Layout>
        );
    }

}

class OrderTable extends Component {
    constructor() {
        super()
        const columns = [
            {
                title: '序号',
                dataIndex: 'Id',
            },
            {
                title: '下单时间',
                dataIndex: 'CreatedTime',
                render: (text, record) => {
                    const short_date = text.substring(0, 10);
                    return (<>{short_date}</>)
                }
            },
            {
                title: '客户姓名',
                dataIndex: 'Customer.Name',
            },
            {
                title: '电话',
                dataIndex: 'Customer.Phone',
            },
            {
                title: '地址',
                dataIndex: 'Customer.Addr',
                render: (text) => {
                    if (text.length <= 10)
                        return (<>{text}</>)
                    else {
                        const short_addr = text.substring(0, 8) + '...';
                        return (<Tooltip content={text}><Tag color='green'>{short_addr}</Tag></Tooltip>)
                    }
                }
            },
            {
                title: '产品名称',
                dataIndex: 'Produce.Name',
            },
            {
                title: '产品规格',
                dataIndex: 'Produce.Norm',
            },
            {
                title: '快递单号',
                dataIndex: 'OrderCode',
                width: 200,
            },
            {
                title: '零售价',
                dataIndex: 'Price',
            },
            {
                title: '成本价',
                dataIndex: 'CostPrice',
            },
            {
                title: '购买数量',
                dataIndex: 'Num',
            },
            {
                title: '总成交价',
                dataIndex: 'TotalPrice',
            },
            {
                title: '是否售后',
                dataIndex: 'IsAftersale',
                render: (text, record) => {
                    if (text)
                        return (<Tag color='green'>是</Tag>)
                    else
                        return (<Tag color='grey'>否</Tag>)
                }
            },
            {
                title: '售后价格',
                dataIndex: 'AftersalePrice',
            },
            {
                title: '利润',
                dataIndex: 'Profit',
            },
            {
                title: '订单来源',
                dataIndex: 'OrderFrom',
            },
            {
                title: '订单状态',
                dataIndex: 'OrderStatus',
            },
            {
                title: '备注',
                dataIndex: 'Remark',
                render: (text) => {
                    if (text.length <= 10)
                        return (<>{text}</>)
                    else {
                        const short_remark = text.substring(0, 8) + '...';
                        return (<Tooltip content={text}><Tag color='green'>{short_remark}</Tag></Tooltip>)
                    }
                }
            },
        ];

        const rowSelection = {
            onChange: (selectedRowKeys, selectedRows) => {
                console.log(`selectedRowKeys: ${selectedRowKeys}`, 'selectedRows: ', selectedRows);
            },
            getCheckboxProps: record => ({
                name: record.Id,
            }),
        };

        const scroll = { x: 3000, y: 800 };

        this.data = [];

        this.fields = { currentPage: 1 };
        this.fetchOrderList = async () => {
            var { currentPage } = this.fields;
            this.setState({ loading: true });
            // const response = await fetch('https://localhost:5001/WJ/Order/GetList');
            const res = await wuji.getorderlist(this.fields);
            if (res.Succeeded) {
                let pagination = { ...this.state.pagination, currentPage, total: res.Extras };
                this.setState({ orderList: res.Data, pagination, loading: false });
            }
            this.setState({
                loading: false
            });
        }

        this.state = {
            loading: true,
            columns,
            rowSelection,
            orderList: [],
            pagination: {
                currentPage: 1,
                pageSize: 10,
                total: 0,
                position: 'both',
                onPageChange: page => {
                    this.fields.currentPage = page;
                    this.fetchOrderList();
                },
            },
            scroll,
            showEditModal: false,
        };
    }

    componentDidMount() {
        this.fetchOrderList();
    }

    changeData = (val) => {//这个val就是子组件传来的
        this.setState({ showEditModal: val.visible })
    }

    render() {
        let { columns, orderList, pagination, loading, rowSelection, scroll, showEditModal } = this.state;

        return (
            <>
                {showEditModal ? (<OrderEditModal visible={showEditModal} changeData={this.changeData} fetchOrderList={this.fetchOrderList} />) : null}
                <Layout>
                    <Nav mode="horizontal">
                        <Nav.Header>
                            <Button theme="solid" className="btn_margin_right_8" onClick={() => this.setState({ showEditModal: true })} >添加</Button>
                        </Nav.Header>
                        <Nav.Footer>
                            <Upload action={wuji.base + '/WJ/Upload/OrderExcel'} >
                                <Button theme="solid" className="btn_margin_right_8" icon={<IconUpload />}>
                                    点击上传
                                </Button>
                            </Upload>
                            <Button theme="solid" className="btn_margin_right_8" onClick={this.fetchOrderList}>导入</Button>
                        </Nav.Footer>
                    </Nav>
                </Layout>
                <Layout>
                    <Card>
                        根据条件查询
                    </Card>
                    <Form layout='horizontal' labelPosition={"left"} >
                        {
                            ({ formState, values, formApi }) => (
                                <Nav mode="horizontal">
                                    <Nav.Header>
                                        <Form.Input
                                            field="CustomerInfo"
                                            label="姓名或手机号"
                                            trigger='blur'
                                        />
                                        <Form.Input
                                            field="OrderCode"
                                            label="单号"
                                            trigger='blur'
                                        />
                                        <Form.Input
                                            field="ProduceName"
                                            label="产品名称"
                                            trigger='blur'
                                        />
                                    </Nav.Header>
                                    <Nav.Footer>
                                        <Button theme="solid" type="primary" htmlType="submit" className="btn_margin_right_8" onClick={() => {
                                            this.fields = { currentPage: 1, ...values, };
                                            this.fetchOrderList();
                                        }}>确认</Button>
                                        <Button theme="solid" htmlType="reset" onClick={() => {
                                            this.fields = { currentPage: 1 };
                                            this.fetchOrderList();
                                        }}>清空</Button>
                                    </Nav.Footer>
                                </Nav>
                            )
                        }
                    </Form>
                </Layout>
                <Table rowKey="Id" columns={columns} dataSource={orderList} pagination={pagination} rowSelection={rowSelection} scroll={scroll} loading={loading} bordered={true} />
            </>
        );
    }
}

class OrderEditModal extends Component {
    constructor(props) {
        super(props);
        this.state = {
            visible: props.visible,
        };
    }

    Ok = () => {
        // todo 保存内容
        // console.log(this.formApi.getValues());

        this.setState({ visible: false })
        this.props.changeData({ visible: false })
        this.props.fetchOrderList()

    }
    Cancel = () => {
        this.setState({ visible: false })
        this.props.changeData({ visible: false })
    }

    SearchSelectOrderFrom = (sugInput, option) => {
        if (!sugInput) return true;
        let label = option.label;
        let sug = sugInput.toLowerCase();
        return PinyinMatch.match(label, sug);
    }

    getFormApi = (formApi) => {
        this.formApi = formApi;
    }

    render() {
        const { visible } = this.state;
        const list = [
            { value: '微信号', label: '微信号', otherKey: 0 },
            { value: '群聊', label: '群聊', otherKey: 1 },
            { value: '团长', label: '团长', otherKey: 2 },
        ];
        // let Id = 322;
        return (
            <Modal
                title="添加订单"
                style={{ width: 1000 }}
                maskClosable={false}
                visible={visible}
                onOk={this.Ok}
                onCancel={this.Cancel}
            >
                <Form getFormApi={this.getFormApi}>
                    {/* <input type="hidden" name='Id' id='Id' value="" /> */}
                    <Row>
                        <Col span={10}>
                            <Form.InputNumber style={{ width: '100%' }} field="Num" label="购买数量" trigger='blur' initValue={1}
                                rules={[
                                    { required: true, message: '必填项' },
                                ]} />
                        </Col>
                        <Col span={10} offset={2}>
                            <Form.Input style={{ width: '100%' }} field="ProductId" label="商品外键" trigger='blur'
                                rules={[
                                    { required: true, message: '必填项' },
                                ]} />
                        </Col>
                    </Row>
                    <Row>
                        <Col span={10}>
                            <Form.Input style={{ width: '100%' }} field="CostPrice" label="成本价" trigger='blur' />
                        </Col>
                        <Col span={10} offset={2}>
                            <Form.Input style={{ width: '100%' }} field="Price" label="零售价" trigger='blur' />
                        </Col>
                    </Row>
                    <Row>
                        <Col span={10}>
                            <Form.Input style={{ width: '100%' }} field="CustomerId" label="客户外键" trigger='blur'
                                rules={[
                                    { required: true, message: '必填项' },
                                ]} />
                        </Col>
                        <Col span={10} offset={2}>
                            <Form.Input style={{ width: '100%' }} field="OtherAddr" label="非常用地址" trigger='blur' />
                        </Col>
                    </Row>
                    <Row>
                        <Col span={22}>
                            <Form.Input style={{ width: '100%' }} field="OrderCode" label="快递单号" trigger='blur' />
                        </Col>
                    </Row>
                    <Row>
                        <Col span={5}>
                            <Form.Switch label={{ text: '是否售后', required: true }} checkedText='是' uncheckedText='否' field="IsAftersale" trigger='blur' />
                        </Col>
                        <Col span={15} offset={2}>
                            <Form.Input style={{ width: '100%' }} field="AftersalePrice" label="售后价格" trigger='blur' />
                        </Col>
                    </Row>
                    <Row>
                        <Col span={22}>
                            <Form.Select style={{ width: '30%' }} field="OrderFrom" label="订单来源" trigger='blur' optionList={list} placeholder='请选择订单来源'
                                filter={this.SearchSelectOrderFrom}
                                rules={[
                                    { required: true, message: '必填项' },
                                ]}>
                            </Form.Select>
                        </Col>
                    </Row>
                    <Row>
                        <Col span={22}>
                            <Form.TextArea style={{ width: '100%' }} field="Remark" label="备注" trigger='blur' />
                        </Col>
                    </Row>
                </Form>
            </Modal>
        );
    }
}