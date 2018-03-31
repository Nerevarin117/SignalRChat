
function selectGif(url) {

    // Clear text box and reset focus for next comment.
    $('#message').val('').focus();
    chat.server.send($('#displayname').val(), '<img src="' + url + '" title="Powered By Giphy" alt="Powered By Giphy" />');

    $("#gifSelectionPanel").remove();

}

$("#formLoader").submit(function (e) {
    e.preventDefault();

    $.ajax({
        url: "/Gif/Select",
        type: "GET",
        data: $("#formLoader").serialize(),
        success: function (response) {
            $('#gifSelectorContainer').html(response);
        },
        error: function () {
            alert("Error with Command /gifs");
        }
    });
});

function cancel() {
    $("#gifSelectionPanel").remove();
}