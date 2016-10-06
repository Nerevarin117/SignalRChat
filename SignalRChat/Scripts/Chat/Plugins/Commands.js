function executeCommands(message) {

    if (message.indexOf("/") != 0) return false;

    if (message.indexOf("/clear") == 0) {
        $("#discussion").empty();
        return true;
    }


}