// import React from 'react';
// import ReactDOM from 'react-dom';
// import App from './App';
// // import reportWebVitals from './reportWebVitals';

// ReactDOM.render(
//   <App />,
//   document.getElementById('root')
// );

// // If you want to start measuring performance in your app, pass a function
// // to log results (for example: reportWebVitals(console.log))
// // or send to an analytics endpoint. Learn more: https://bit.ly/CRA-vitals
// // reportWebVitals();

import React from 'react';
import ReactDOM from 'react-dom';
import { BrowserRouter, useHistory } from 'react-router-dom';
import App from './App';
import registerServiceWorker from './registerServiceWorker';

const baseUrl = document.getElementsByTagName('base')[0].getAttribute('href');
const rootElement = document.getElementById('root');
const history = useHistory();

ReactDOM.render(
    <BrowserRouter basename={baseUrl} history={history}>
        <App />
    </BrowserRouter>,
    rootElement);

registerServiceWorker();

// import React from 'react';
// import ReactDOM from 'react-dom';
// import App from './App';


// ReactDOM.render(<App />, document.querySelector('#root'));
