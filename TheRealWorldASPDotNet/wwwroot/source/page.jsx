import React from 'react';
class Page extends React.Component{
     render() {
          return (
               <div>{this.props.pageTitle} ({this.props.pageParentId})</div>
          );
      }
};
export default Page;