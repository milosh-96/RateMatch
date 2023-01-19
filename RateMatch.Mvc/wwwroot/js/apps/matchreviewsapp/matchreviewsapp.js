'use strict';

const e = React.createElement;

class MatchReviewsApp extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            items: [
                {
                    reviewContent: "What a great match!",
                    reviewRating:5
                },
                {
                    reviewContent: "What a great match 1!",
                    reviewRating:5
                },
                {
                    reviewContent: "What a great match 2 !",
                    reviewRating:5
                },
               
            ]
        };
    }
    render() {
        return (<div>
            <ReviewRating reviewRating="5"></ReviewRate>
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
        return (<div>{this.props.item.reviewContent} ({this.props.item.reviewRating})</div>)
    }
}

class ReviewRating extends React.Component {
    constructor(props) {
        super(props);
    }
    render() {
        let output = [];
        for (let i = 0; i < 5; i++) {
            output.push(<React.Fragment key={i}>
                <div className="d-inline review-star"><i className={'fa-solid fa-star'}></i></div>
            </React.Fragment>);
        }
        return (<div className="reviews-rate-widget">
            {output }
        </div>
        )
    }
}

class PostMatchReview extends React.Component {
    constructor(props) {
        super(props);
        this.state = { reviewContent: "",reviewRating: 5};
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
        this.props.itemSubmitted({
            reviewContent: this.state.reviewContent,
            reviewRating: this.state.reviewRating
        });
        this.setState({reviewRating:5, reviewContent: "" });
    }
}

const container = document.querySelector('#match-reviews-app');
const root = ReactDOM.createRoot(container);
root.render(e(MatchReviewsApp));