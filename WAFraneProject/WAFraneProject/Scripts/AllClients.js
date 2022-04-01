$(function () {
    $.ajax({
        type: "POST",
        url: "AllClients.aspx/GetCustomers",
        data: '{}',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: OnSuccess,
        failure: function (response) {
            alert(response.d);
        },
        error: function (response) {
            alert(response.d);
        }
    });
});

function OnSuccess(response) {
    $("#gvCustomers").DataTable(
        {
            bLengthChange: true,
            lengthMenu: [[5, 10, 20, 50], [5, 10, 20, 50]],
            bFilter: true,
            bSort: true,
            bPaginate: true,
            data: response.d,
            columns: [{ 'data': 'FirstName' },
            { 'data': 'LastName' },
            { 'data': 'Email' },
            { 'data': 'Phone' },
            { 'data': 'City' },
            { 'data': 'Country' },
            { 'data': ' ' }],
            columnDefs: [{
                "targets": -1,
                "data": "IDClient",
                "render": function (data, type, row, meta) {
                    return '<button class="btn btn-info" type="button" id="' + row.IDClient + '" onclick="edit(' + row.IDClient + ')"><i class="glyphicon glyphicon-pencil"></i></button><button class="btn btn-warning" type="button" id="' + row.IDClient + '" onclick="viewReceipts(' + row.IDClient + ')"><i class="glyphicon glyphicon-search"></i></button>';
                }
            }]
        });
};

function edit(id) {
    window.location.href = "EditClient.aspx/" + id;
}

function viewReceipts(id) {
    window.location.href = "/Receipt/ShowAll/" + id;
}
