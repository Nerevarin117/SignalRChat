function executeCommands(message,name) {

    if (message.indexOf("/") != 0) return false;

    if (message.indexOf("/clear") == 0) {
        $("#discussion").empty();
        return true;
    }

    if (message.indexOf("/gifs") == 0) {
        var param = message.replace("/gifs", "");
        param = param.replace(" ", "+");
     
        $.ajax({
            url: "/Gif/Select?Keywords=" + param,
            type: "GET",
            success: function (response) {
                $('#discussion').append('<li id="gifSelectorContainer">' + response + '</li>');
            },
            error: function (response) {
                alert("Error with Command /gifs");
            }
        });

        return true;
    }


    return false;
}