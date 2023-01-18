'use strict';

const e = React.createElement;

class MatchReviewsApp extends React.Component {
    constructor(props) {
        super(props);
        this.state = { items: ["What a great match!","Amazing!!!"] };
    }
    render() {
        return (<div>
            <button onClick={this.addNewItem.bind(this)}>Add</button>
            <MatchReveiwsListView items={this.state.items}>
            </MatchReveiwsListView></div>
        )
    }
    addNewItem() {
        this.setState(prevState => ({
            items: ["I'm new :)", ...prevState.items]
        }));
    }
}

class MatchReveiwsListView extends React.Component {
    constructor(props) {
        super(props);
    }
    render() {
        return (<div>
            {this.props.items.map((item, index) => {
                return <React.Fragment key={index}>
                    <MatchReviewsListViewItem item={item}></MatchReviewsListViewItem>
                </React.Fragment>
            })
            }
          
        </div>)
    }
}

class MatchReviewsListViewItem extends React.Component {
    constructor(props) {
        super(props);
    }
    render() {
        return (<div>{this.props.item}</div>)
    }
}

const container = document.querySelector('#match-reviews-app');
const root = ReactDOM.createRoot(container);
root.render(e(MatchReviewsApp));