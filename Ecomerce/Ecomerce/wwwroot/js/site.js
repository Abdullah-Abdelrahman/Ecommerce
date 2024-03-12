// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$(document).ready(function () {
    // Initialize Select2 for all select elements
    $('select').select2();

    // Other JavaScript code
    // ...
});
$('#openGIButton').on('click', function () {
    $('#GIModal').modal('show');
});

$('#closeGIButton').on('click', function () {
    $('#GIModal').modal('toggle');
});
$('#MaincloseGIButton').on('click', function () {
    $('#GIModal').modal('toggle');
});



//$('#openBlockButton').on('click', function () {
//    $('#BlockModal').modal('show');
//});

$('#closeBlockButton').on('click', function () {
    $('#BlockModal').modal('toggle');
});
$('#MaincloseBlockButton').on('click', function () {
    $('#BlockModal').modal('toggle');
});



$('#closeStyleButton').on('click', function () {
    $('#StyleModal').modal('toggle');
});
$('#MaincloseStyleButton').on('click', function () {
    $('#StyleModal').modal('toggle');
});