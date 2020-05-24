// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
// Material Select Initialization

// function for data load at seach btn submit

function fillAudienceInfo(data) {
    $("#audience-image").attr("src", `data:image/jpeg;base64,${data[0].imageBytes}`);
}


async function submitSearch(event) {
    let _audience = $("#input_search").val();
    let _url = "https://localhost:44395/api/universitynavigator/audience/" + _audience;

    await $.ajax({
        type: 'GET',
        url: _url,
    }).done(data => fillAudienceInfo(data));
}

$(document).ready(function () {
    $("#search-btn").click(submitSearch);
});