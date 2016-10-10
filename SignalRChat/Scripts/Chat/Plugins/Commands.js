function executeCommands(message) {

    if (message.indexOf("/") != 0) return false;

    if (message.indexOf("/clear") == 0) {
        $("#discussion").empty();
        return true;
    }

    if (message.indexOf("/gifs") == 0) {
        message.replace("/gifs", "");
        message.replace(" ", "+");
        $.getJSON( "http://api.giphy.com/v1/gifs/search?q=" + message + "&api_key=dc6zaTOxFJmzC")
        .done(function( result ) {
            
        });

        return true;
    }



}