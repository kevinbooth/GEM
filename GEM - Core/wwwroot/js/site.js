// Write your JavaScript code.


$(document).ready(function () {
    $("#srchInput").on("keyup", function () {
        var value = $(this).val().toLowerCase();
        $("#srchTable tr").filter(function () {
            $(this).toggle($(this).text().toLowerCase().indexOf(value) > -1)
        });
    });



    $('#browseData').DataTable({
        "order": [[0, "desc"]], 
        "columnDefs": [{ "type": "formatted-num", "target": 0}]
    });

});