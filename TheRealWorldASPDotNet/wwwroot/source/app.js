import React from 'react';
import ReactDOM from 'react-dom';
import PageList from './pageList.jsx';
class App extends React.Component {
     render() {
          return (
               <div>
                    <PageList url="/api/pages" />
               </div>
          );
     }
}
ReactDOM.render(
     <App />,
     document.getElementById('container')
);

module.hot.accept();