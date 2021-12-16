import 'reset-css';
import React, { Component } from 'react';
import { Table } from '@douyinfe/semi-ui';
import wuji from '../api/api'


export default class Customer extends Component {
    render() {
        document.title = "无忌ERP - 客户管理";
        return (
            <CustomerTable />
        );
    }
}

class CustomerTable extends Component {
    constructor() {
        super()
        const columns = [
            {
                title: '序号',
                dataIndex: 'Id',
            },
            {
                title: '姓名',
                dataIndex: 'Name',
            },
            {
                title: '电话',
                dataIndex: 'Phone',
            },
            {
                title: '地址',
                dataIndex: 'Addr',
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

        const scroll = { y: 800 };

        this.data = [];

        this.fetchCustomerList = async (currentPage = 1) => {
            this.setState({ loading: true });
            const res = await wuji.getcustomerlist();
            if (res.Succeeded) {
                let pagination = { ...this.state.pagination, currentPage, total: res.Data.length };
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
                onPageChange: page => this.fetchCustomerList(page),
            },
            scroll,
        };
    }

    componentDidMount() {
        this.fetchCustomerList();
    }


    render() {
        let { columns, orderList, pagination, loading, rowSelection, scroll } = this.state;
        return <Table rowKey="Id" columns={columns} dataSource={orderList} pagination={pagination} rowSelection={rowSelection} scroll={scroll} loading={loading} />;
    }
}