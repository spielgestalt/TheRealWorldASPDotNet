import React from 'react';
import Page from './page.jsx'
class PageList extends React.Component {
     constructor(props) {
          super(props);
          this.state = { data: [] };
     }
     loadPages() {
          const xhr = new XMLHttpRequest();
          xhr.open('get', this.props.url, false);
          xhr.onload = () => {
               const data = JSON.parse(xhr.responseText);
               this.setState({ data: data });
          };
          xhr.send();
     }
     componentWillMount() {
          this.loadPages();
     }
     render() {
          const pages = this.state.data.map(page => (
          <Page key={page.id} pageTitle={page.title} pageParentId={page.parentId} />
          ));
          return (
               <div>{pages}</div>
          );
     }
};
export default PageList;