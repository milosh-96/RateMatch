'use strict';

const e = React.createElement;

class MatchReviewsApp extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            items: [],
            edit: { editMode: false, editItem: null },
            loggedIn:false
        };
    }
    componentDidMount() {
        fetch('/api/matchreviews/bymatch/'+matchId)
            .then(response => response.json())
            .then(response => this.setState({ items: response }));

        fetch('/api/login/is-logged-in')
            .then(response => response.json())
            .then(response => { console.log(response); this.setState({ loggedIn: response }); });

    }
    render() {
        var postMatchReview = <div>Please login to post a review</div>;
        if (this.state.loggedIn) {
            var postMatchReview = <PostMatchReview itemSubmitted={this.addNewItem.bind(this)}></PostMatchReview>
        }
        return (
            <div>
                {postMatchReview}
                <MatchReveiwsListView items={this.state.items}>
                </MatchReveiwsListView>
            </div>
        )
    }
  
    addNewItem(value) {
        console.log(value);
        console.log(matchId);
        fetch('/api/matchreviews?id=' + matchId, {
            method: 'post',
            body: JSON.stringify(value),
            headers: {
                'Accept': 'application/json, text/plain',
                'Content-Type': 'application/json;charset=UTF-8'
            },
        })
            .then((response) => response.json())
            .then((response) => console.log(response));
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
        return (<div><strong>{this.props.item.user.userName}: </strong>
            {this.props.item.reviewContent} ({this.props.item.reviewRating})
            <div>
                <small><a href={"/matchreviews/report/" + this.props.item.id}>Report</a></small>
            </div>
            <hr></hr>
        </div>)
    }
}

class ReviewRating extends React.Component {
    constructor(props) {
        super(props);
        this.state = { selectedRating: this.props.reviewRating };
    }
    componentDidUpdate(prevProps, prevState) {
        if (prevState.selectedRating !== this.props.reviewRating) {
            this.setState({ selectedRating: this.props.reviewRating });
        }
    }


    handleMouseOver(rating) {
        rating = rating + 1;
        this.setState({ selectedRating: rating })
        this.props.ratingChanged(rating);
        console.log(rating);
    }
   
    render() {
        let output = [];
        let starClasses = [
            ['fa-solid', 'fa-star'],
            ['fa-solid', 'fa-star'],
            ['fa-solid', 'fa-star'],
            ['fa-solid', 'fa-star'],
            ['fa-solid', 'fa-star']
        ];

        

        starClasses.forEach((item, index) => {
            let cssClasses = ["d-inline", "review-star"];
            if (index <= (this.state.selectedRating-1)) {
                cssClasses.push( "is-selected");
            }
           
            output.push(
                <div key={index} className={cssClasses.join(" ")} onMouseOver={() => { this.handleMouseOver(index) }}>
                    <i className={starClasses[index].join(" ")}></i>
                </div>

            );  
        })
       
        return (<div className="reviews-rate-widget">
            {output }
        </div>
        )
    }
}

class PostMatchReview extends React.Component {
    constructor(props) {
        super(props);
        this.state = { user: {id:null,userName:"",email:"",phoneNumber:""}, reviewContent: "",reviewRating: 5};
    }

    async componentDidMount() {
        await fetch('/api/user/getcurrent').then((response) => response.json()).then((data) => this.setState({ user: data }));
      }
    handleReviewRatingChange(value) {
        this.setState({ reviewRating: (value) });
    }
    handleReviewContentChange(event) { this.setState({ reviewContent: event.target.value }); }
    //handleAuthorNameChange(event) { this.setState({ authorName: event.target.value }); }
    render() {
        let output = "";
        if (this.state.user) {
            output = <div>
                <ReviewRating ratingChanged={this.handleReviewRatingChange.bind(this)} reviewRating={this.state.reviewRating}></ReviewRating>
                <div className="form-group">
                    <label title={this.state.user.userName}>
                        <strong>You:&nbsp;</strong>
                    </label>
                    <input
                        placeholder="Enter review..."
                        type="text"
                        value={this.state.reviewContent}
                        onChange={this.handleReviewContentChange.bind(this)}
                    />
                    <button className="btn btn-primary rounded-0" onClick={this.addNewItem.bind(this)}>Submit</button>
                </div>
            </div>
        }
        return (
            output
        );
    }
    addNewItem() {
        if (this.state.user != null) {
            if (this.state.reviewContent.length > 3) {

                this.props.itemSubmitted({
                    user: this.state.user,
                    userId: this.state.user.id,
                    authorName: this.state.userName,
                    reviewContent: this.state.reviewContent,
                    reviewRating: this.state.reviewRating
                });
                this.setState({ user: this.state.user, reviewRating: 5, reviewContent: "" });

            }
            else {
                alert("Name and Review must  be greater than 3 letters.");
            }
        }
    }
}

const container = document.querySelector('#match-reviews-app');
const root = ReactDOM.createRoot(container);
root.render(e(MatchReviewsApp));