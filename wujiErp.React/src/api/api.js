import axios from 'axios';

// const base = `https://sikro.ml`;
// const base = `http://120.26.200.109:5210`;
// const base = `http://localhost:5210`;
const base = import.meta.env.VITE_API_URL || '';

let wuji = {};
wuji.base = base;

function setPropsToParams(props) {
    if (!props)
        return "";
    var paramArrays = [];
    for (const key in props) {
        if (Object.hasOwnProperty.call(props, key)) {
            const element = props[key];
            paramArrays.push(`${key}=${element}`);
        }
    }
    return paramArrays.join("&");
}

function get(url) {
    return new Promise((resolve, reject) => {
        axios.get(url, {
            // withCredentials 表示跨域请求时是否需要使用凭证
            withCredentials: false,    // default
        }).then(
            (response) => {
                resolve(response.data);
            },
            (err) => {
                if (err.Cancel) {
                    console.log(err);
                } else {
                    reject(err);
                }
            }
        ).catch((err) => reject(err));
    });
}

function post(url, data) {
    return new Promise((resolve, reject) => {
        axios.post(url, {
            // withCredentials 表示跨域请求时是否需要使用凭证
            withCredentials: false,    // default
            headers: {
                'X-Requested-With': 'XMLHttpRequest',
                'Content-Type': 'application/json'
            },
            data
        }).then(
            (response) => {
                resolve(response.data);
            },
            (err) => {
                if (err.Cancel) {
                    console.log(err);
                } else {
                    reject(err);
                }
            }
        ).catch((err) => reject(err));
    })
}

wuji.getorderlist = (props) => {
    const paramsStr = setPropsToParams(props);
    const url = `${base}/WJ/Order/GetList?${paramsStr}`;
    const orderlist = get(url)
    return orderlist;
};

wuji.orderadd = (data) => {
    const url = `${base}/WJ/Order/OrderAdd`;
    const addResult = post(url, data)
    return addResult;
};

wuji.getproducelist = (props) => {
    const paramsStr = setPropsToParams(props);
    const producelist = get(`${base}/WJ/Produce/GetList?${paramsStr}`);
    return producelist;
};

wuji.getcustomerlist = (props) => {
    const paramsStr = setPropsToParams(props);
    const customerlist = get(`${base}/WJ/Customer/GetList?${paramsStr}`);
    return customerlist;
};

export default wuji;