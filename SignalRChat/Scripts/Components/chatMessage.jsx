class CommentBox extends React.Component {
    render() {
        return (
            <div className="media">
                <div className="media-left">
                    <a href="#">
                        <img className="media-object" src="/Content/BotThumb/author.jpg" height="60" alt="..." />
                    </a>
                </div>
                <div className="media-body">
                    <h4 className="media-heading">Media heading
                    <small><i>posté le xx/xx/xxxx</i></small></h4>
                    {this.props.data.message}
                </div>
            </div>
        );
    }
}
/*
var CommentBox = React.createClass({
    render: function () {
        return (
            <div class="media" className="commentBox">
                <div class="media-left">
                    <a href="#">
                        <img class="media-object" src="~/Content/BotThumb/author.jpg" height="60" alt="..."/>
                    </a>
                </div>
                <div class="media-body">
                    <h4 class="media-heading">Media heading
                    <small><i>posté le xx/xx/xxxx</i></small></h4>
                    {this.props.data.message}
                </div>
            </div>
        );
    }
});*/








