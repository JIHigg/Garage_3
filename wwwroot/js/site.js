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

$(document).ready(function () {
    $('#dtMembers').DataTable();
    $('.dataTables_length').addClass('bs-select');
});