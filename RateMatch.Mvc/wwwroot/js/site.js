// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
'use strict';

const e = React.createElement;

class MatchItemsView extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            error: null,
            isLoaded: false,
            items: []
        };
    }
    componentDidMount() {
        fetch("/api/matches")
            .then(res => res.json())
            .then(
                (result) => {
                    this.setState({
                        isLoaded: true,
                        items: result
                    });
                },
                // Note: it's important to handle errors here
                // instead of a catch() block so that we don't swallow
                // exceptions from actual bugs in components.
                (error) => {
                    this.setState({
                        isLoaded: true,
                        error
                    });
                }
            )
    }
    render() {
        return (
            <div>
                {this.state.items.map((item,index) => (
                    <React.Fragment key={item.id}>
                        <MatchItemCard item={item}></MatchItemCard>
                    </React.Fragment>
                ))}
            </div>
            )
    }
}

class MatchItemCard extends React.Component {
    constructor(props) {
        super(props);
    }
    render() {
        console.log("AAA");
        const output = (
            <div className="card" style={{width: "100%"}}>
                <div className="card-body">
                    <h5 className="card-title">
                        <a href="">{this.props.item.matchName} {this.props.item.matchResult}</a>
                    </h5>
               
                    <a href="#" className="btn btn-sm btn-primary">Reviews</a>
                    <a href="#" className="btn btn-sm btn-primary">Match Highlights (external)</a>
                </div>
            </div>);
            return output;
    }
}
const domContainer = document.querySelector('.match-cards-view'); const root = ReactDOM.createRoot(domContainer);
root.render(e(MatchItemsView));