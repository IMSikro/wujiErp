// const base = `https://sikro.ml`;
const base = `http://120.26.200.109:520`;

let wuji = {};

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

wuji.getorderlist = async (props) => {
    const paramsStr = setPropsToParams(props);
    const url = `${base}/WJ/Order/GetList?${paramsStr}`;
    const orderlist = await fetch(url);
    return await orderlist.json();
};

wuji.orderadd = async (data) => {
    const url = `${base}/WJ/Order/OrderAdd`;
    const addResult = await fetch(url, {
        method: 'POST', // *GET, POST, PUT, DELETE, etc.
        // mode: 'cors', // no-cors, *cors, same-origin
        //cache: 'no-cache', // *default, no-cache, reload, force-cache, only-if-cached
        headers: {
            'Content-Type': 'application/json'
            // 'Content-Type': 'application/x-www-form-urlencoded',
        },
        referrerPolicy: 'no-referrer', // no-referrer, *no-referrer-when-downgrade, origin, origin-when-cross-origin, same-origin, strict-origin, strict-origin-when-cross-origin, unsafe-url
        body: JSON.stringify(data) // body data type must match "Content-Type" header
    });
    return await addResult.json();
};

wuji.getproducelist = async (props) => {
    const paramsStr = setPropsToParams(props);
    const producelist = await fetch(`${base}/WJ/Produce/GetList?${paramsStr}`);
    return await producelist.json();
};

wuji.getcustomerlist = async (props) => {
    const paramsStr = setPropsToParams(props);
    const customerlist = await fetch(`${base}/WJ/Customer/GetList?${paramsStr}`);
    return await customerlist.json();
};

export default wuji;