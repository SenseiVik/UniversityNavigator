// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
// Material Select Initialization

// function for data load at seach btn submit

function fillAudienceInfo(data) {
    $("#audience-data").hide("400");

    $("#audience-name").text(`Аудиторія: ${data[0].audienceId}`);
    $("#audience-building").text(`Корпус: ${data[0].building}`);
    $("#audience-floor").text(`Поверх: ${data[0].floor}`);
    $("#audience-image").attr("src", `data:image/jpeg;base64,${data[0].imageBytes}`);

    $("#audience-data").show("slow");
}


function submitSearch(event) {
    let _audience = $("#input_search").val();
    let _url = "https://localhost:44395/api/universitynavigator/audience/" + _audience;

    $.ajax({
        type: 'GET',
        url: _url,
    }).done(data => fillAudienceInfo(data));

}

$(document).ready(function () {
    $("#audience-data").hide();

    $("#search-btn").click(submitSearch);
    })
});