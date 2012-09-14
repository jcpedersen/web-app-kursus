function hanoiNewGame(diskCount) {
    for (i = 1; i <= diskCount; i++)
        $("#tower1").append('<div id="disk' + i + '" data-size="' + i + '">disk' + i + '</div>');
}

function hanoiGameFromJSON(jsonArray) {
    var gameArray = $.parseJSON(jsonArray);
    diskCount = 0;
    for (j = 1; j <= 3; j++)
        for (i = diskCount; i > 0; i--)
            if (gameArray[j][i] != "-1")
                $("#tower" + j).append('<div id="disk' + gameArray[j][i] + '" data-size="' + gameArray[j][i] + '">disk' + gameArray[j][i] + '</div>');
}