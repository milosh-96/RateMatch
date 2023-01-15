// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
'use strict';

const e = React.createElement;

class LikeButton extends React.Component {
    constructor(props) {
        super(props);
        this.state = { liked: false };
    }

    render() {
        if (this.state.liked) {
            return 'You liked this.';
        }

        return e(
            'button',
            { onClick: () => this.setState({ liked: true }) },
            'Like'
        );
    }
}
const domContainer = document.querySelector('#like_button_container'); const root = ReactDOM.createRoot(domContainer); root.render(e(LikeButton));