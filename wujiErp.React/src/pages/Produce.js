import 'reset-css';
import React, { Component } from 'react';
import { Table, } from '@douyinfe/semi-ui';
import wuji from '../api/api';


export default class Produce extends Component {
    render() {
        document.title = "无忌ERP - 产品管理";
        return (
            <ProduceTable />
        );
    }
}


class ProduceTable extends Component {
    constructor() {
        super()
        const columns = [
            {
                title: '序号',
                dataIndex: 'Id',
            },
            {
                title: '商品名',
                dataIndex: 'Name',
            },
            {
                title: '规格',
                dataIndex: 'Norm',
            },
            {
                title: '零售价',
                dataIndex: 'Price',
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

        this.fetchProduceList = async (currentPage = 1) => {
            this.setState({ loading: true });
            const res = await wuji.getproducelist();
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
                onPageChange: page => this.fetchProduceList(page),
            },
            scroll,
        };
    }

    componentDidMount() {
        this.fetchProduceList();
    }


    render() {
        let { columns, orderList, pagination, loading, rowSelection, scroll } = this.state;
        return <Table rowKey="Id" columns={columns} dataSource={orderList} pagination={pagination} rowSelection={rowSelection} scroll={scroll} loading={loading} />;
    }
}