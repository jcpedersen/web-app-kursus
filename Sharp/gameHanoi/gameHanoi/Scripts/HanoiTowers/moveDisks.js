function move(currentElm) {
    if (actToFrom == 0) {
        elmCurrent = $(currentElm).find(">:first-child");
        cDataSize = $(elmCurrent).data("size");
        if (0 < cDataSize) {
            savedElement = elmCurrent;
            actToFrom = 1;
        }
        $(elmCurrent).remove();
    }
    else {
        elmCurrent = $(currentElm).find(">:first-child");
        cDataSize = $(elmCurrent).data("size");

        if ($.type(cDataSize) == "undefined")
            cDataSize = 999;

        sDataSize = $(savedElement).data("size");
        if (cDataSize > sDataSize) {
            $(currentElm).prepend(savedElement)
            createArray();
            savedElement = null;
            actToFrom = 0;
        }
        else {
            alert("Sorry");
        }
    }
}

function moveCheck(event) {
    if ($(event.target).hasClass('allowClick')) {
        move(event.target);
    }
    else {
        if ($(event.target).parent().hasClass('allowClick')) {
            tCurrent = $(event.target).parent();
            move(tCurrent);
        }
    }
}