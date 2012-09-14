

/// summary: create a javascript array of the child div's in the tower.
/// param:   string="currentTower" tower's id
/// returns: javascript of child div's in tower div
/// usedBy:  function createArray()
function createArrayTower(currentTower) {
    var towerOneArray = new Array();
    var count = 8;
    //set default of array (-1 == none)
    for (i = 0; i < 9; i++)
        towerOneArray[i] = -1;

    //Loop tower, all child divs (one div == one disk)
    $(currentTower).children().each(
            function () {
                //grep size of disk
                cDataSize = $(this).data("size");
                //save size to array
                towerOneArray[count] = cDataSize;
                //count for next in array
                count--;
            });
    //return array
    return towerOneArray;
}

//Used to create a json array of all towers
function createArray() {
    //create array for all infomation we need to save.
    var towerArray = new Array();
    //move count
    moveCount++;
    //Add count of moves to array
    towerArray[0] = moveCount;
    //Add towers to array
    towerArray[1] = createArrayTower("#tower1");
    towerArray[2] = createArrayTower("#tower2");
    towerArray[3] = createArrayTower("#tower3");
    //serializer array to JSON
    _jsonOfTowers = $.toJSON(towerArray);
}
