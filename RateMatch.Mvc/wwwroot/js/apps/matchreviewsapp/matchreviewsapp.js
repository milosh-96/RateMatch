'use strict';

const e = React.createElement;

class MatchReviewsApp extends React.Component {
    constructor(props) {
        super(props);
        this.state = { items: ["What a great match!","Amazing!!!"] };
    }
    render() {
        return (<div>
            <PostMatchReview itemSubmitted={this.addNewItem.bind(this)}></PostMatchReview>
            <MatchReveiwsListView items={this.state.items}>
            </MatchReveiwsListView></div>
        )
    }
    addNewItem(value) {
        this.setState(prevState => ({
            items: [value, ...prevState.items]
        }));
        //
        
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

class PostMatchReview extends React.Component {
    constructor(props) {
        super(props);
        this.state = { reviewContent: "" };
    }
    handleReviewContentChange(event) { this.setState({ reviewContent: event.target.value }); }
    render() {
        return (<div className="form-group">
            <input
                type="text"
                value={this.state.reviewContent}
                onChange={this.handleReviewContentChange.bind(this)}
                style={{ padding: "3px" }} />
            <button className="btn btn-primary rounded-0" onClick={this.addNewItem.bind(this)}>Submit</button>
        </div>)
    }
    addNewItem() {
        this.props.itemSubmitted(this.state.reviewContent);
        this.setState({ reviewContent: "" });
    }
}

const container = document.querySelector('#match-reviews-app');
const root = ReactDOM.createRoot(container);
root.render(e(MatchReviewsApp));