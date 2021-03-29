$(function () {
    $('[data-toggle="tooltip"]').tooltip()
})

function window_print() {
    var ButtonControl = document.getElementById("btnprint");
    ButtonControl.style.visibility = "hidden";
    window.print();
}



var myModal = document.getElementById('CreateNewVehicleTypeModal')
var myInput = document.getElementById('NewVehicleType')

myModal.addEventListener('shown.bs.modal', function () {
    myInput.focus()
})