// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
// Material Select Initialization

// function for data load at seach btn submit
function submitSearch(event) {
    let audience = $("#search-btn").val();

    await $.ajax({
        type: 'GET',
        url: '',
        data: { audienceId = audienceId }
    }).done(function (img) {

    })
}

$(document).ready(function () {
    $("#search-btn").click(submitSearch);
});