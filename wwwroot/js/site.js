// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

//const { Modal } = require("../lib/bootstrap/dist/js/bootstrap.esm");

// Write your JavaScript code.

$('#markDoneModal').on('show.bs.modal', function (event) {
    var link = $(event.relatedTarget); // Leiame lingi, mis modaalakna lahti tegi
    var incid = link.data('bs-id'); //Loeme GUID väärtuse just sellelt lingilt, millega selle modaalakna avasine
    var incdesc = link.data('bs-description');
    var inccreated = link.data('bs-datetimecreated');
    var incdeadline = link.data('bs-deadline');
    var modal = $(this);
    modal.find('.modal-body #incidentID').val(incid); //Saadame GUID väärtuse modaalakna input hidden elementi
    modal.find('.modal-body .row .col-sm-10 #description').html(incdesc);
    modal.find('.modal-body .row .col-sm-10 #dateTimeAdded').html(inccreated);
    modal.find('.modal-body .row .col-sm-10 #deadline').html(incdeadline);
});

//Bootstrap tooltip initsialiseerimiskood
var tooltipTriggerList = [].slice.call(document.querySelectorAll('[data-bs-toggle="tooltip"]'));
var tooltipList = tooltipTriggerList.map(function (tooltipTriggerEl) {
    return new bootstrap.Tooltip(tooltipTriggerEl);
});

    //var incidlink = document.getElementById('incidentidentifier');
    //var incidLinkDataID = incidlink.getAttribute('data-incident-id');
    //window.alert(incidLinkDataID);
    //var modalincidentID = document.getElementById('incidentID');
    //modalincidentID.setAttribute('value', incidLinkDataID);

/*});*/
//$("#markDoneModal").on('show.bs.modal', function (event) {
//    var button = $(event.relatedTarget) //Button that triggered the modal
//    var id = button.find('button').data('id') //need to find the button and get id
//    var url = '/MarkDone/' + id; //url

//    console.log('data-id= ' + id) //15

//    //Click delete task in modal
//    $(document).on('click', '.delete_task', function () {
//        if (confirm('Delete task')) {
//            $.ajax({
//                url: url,
//                type: "DELETE",
//                success: function (result) {
//                    $('#markDoneModal').modal('hide') //hide modal on success
//                    window.location.href = '/';
//                },
//                error: function (err) {
//                    console.log(err);
//                }
//            })
//        }
//    })
//})

