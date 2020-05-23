// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
// Material Select Initialization

// function for data load at seach btn submit
async function submitSearch(event) {
    let audience = $("#input_search").val();
    var _url = "https://localhost:44395/api/universitynavigator/audience/" + audience;
    await $.ajax({
        type: 'GET',
        url: _url,
        error: function () {
            alert("ERROR");
        }
    }).done(function (data) {
        $(data).each(function (index, item) {
            alert(item.audienceId);
        })
    })
}

$(document).ready(function () {
    $("#search-btn").click(submitSearch);
});