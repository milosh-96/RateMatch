'use strict';

const e = React.createElement;

class SportsTriviaQuiz extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            error: null,
            isLoaded: false,
            items: [],
            currentQuestion: 0
        };
    }
    changeQuestion(answer) {
        if (this.state.items[this.state.currentQuestion].correct_answer == answer) {
            alert("Good Job!");
        }
        else {
            alert("Wrong");
        }
        this.setState({
            currentQuestion: (this.state.currentQuestion + 1)
        });
    }
    componentDidMount() {
        fetch("https://opentdb.com/api.php?amount=10&category=21&type=boolean")
                .then(res => res.json())
                .then(
                    (result) => {
                        this.setState({
                            isLoaded: true,
                            items: result.results
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
        if (this.state.error != null) {
           return (<div>ERROR!</div>)
        }
        else if (!this.state.isLoaded) {
            return ("");
        }
        else {
            if (this.state.currentQuestion < this.state.items.length) {
                return (
                    <div>
                        <Question handleAnswer={this.changeQuestion.bind(this)} item={this.state.items[this.state.currentQuestion]}></Question>
                    </div>
                )
            }
            else {
                return (<div>No more quesitons. Thank you for playing. Check back later for new content.</div>)
            }
        }
    }
}

class Question extends React.Component {
    constructor(props) {
        super(props);
    }
    render() {
        const output = (
            <div className="card" style={{width: "100%"}}>
                <div className="card-body">
                    <h5 className="card-title" dangerouslySetInnerHTML={{ __html: this.props.item.question }}>
                    </h5>
                    <button className="btn btn-success" onClick={this.props.handleAnswer.bind(this,"True")}>True</button>
                    <button className="btn btn-danger" onClick={this.props.handleAnswer.bind(this,"False")}>False</button>
                </div>
            </div>);
            return output;
    }
}

const container = document.getElementById('sports-trivia-quiz');
const root = ReactDOM.createRoot(container);
root.render(e(SportsTriviaQuiz));





