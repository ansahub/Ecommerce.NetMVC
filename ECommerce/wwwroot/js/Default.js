
var timesClicked = 0;

function clickCart() {
    timesClicked++;

    document.getElementById('amount').innerHTML = timesClicked;
    return true
}