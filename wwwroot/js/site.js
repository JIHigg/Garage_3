$(function () {
    $('[data-toggle="tooltip"]').tooltip()
})

function window_print() {
    var ButtonControl = document.getElementById("btnprint");
    ButtonControl.style.visibility = "hidden";
    window.print();
}