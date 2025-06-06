$(document).ready(function () {
    document.title = 'Email Config';

    $("#tblEmailConfig").DataTable({
        paging: true,
        select: true,
        "order": [[0, "desc"]],
        dom: 'Bfrtip',


        buttons: [
            'pageLength',
        ],


        "processing": true,
        "serverSide": true,
        "filter": true, //Search Box
        "orderMulti": false,
        "stateSave": true,

        "ajax": {
            "url": "/EmailConfig/GetDataTabelData",
            "type": "POST",
            "datatype": "json"
        },


        "columns": [
            {
                data: "Id", "name": "Id", render: function (data, type, row) {
                    return "<a href='#' onclick=DetailsEmailConfig('" + row.Id + "');>" + row.Id + "</a>";
                }
            },
            { "data": "Email", "name": "Email" },            
            {
                data: null, render: function (data, type, row) {
                    return "<input value='" + row.Password + "' type='password' readonly>";
                }
            },
            { "data": "Hostname", "name": "Hostname" },
            { "data": "Port", "name": "Port" },
            {
                data: null, render: function (data, type, row) {
                    if (row.IsDefaultDisplay == 'Yes') {
                        return "<button class='btn btn-xs btn-success'><span>Yes</span ><i class='fa fa-check-circle' aria-hidden='true'></i></button>";
                    }
                    else {
                        return "<button class='btn btn-xs'><span>No</span ><i class='fa fa-flag' aria-hidden='true'></i></button>";
                    }
                }
            },
            {
                "data": "CreatedDate",
                "name": "CreatedDate",
                "autoWidth": true,
                "render": function (data) {
                    var date = new Date(data);
                    var month = date.getMonth() + 1;
                    return (month.length > 1 ? month : month) + "/" + date.getDate() + "/" + date.getFullYear();
                }
            },
            {
                "data": "ModifiedDate",
                "name": "ModifiedDate",
                "autoWidth": true,
                "render": function (data) {
                    var date = new Date(data);
                    var month = date.getMonth() + 1;
                    return (month.length > 1 ? month : month) + "/" + date.getDate() + "/" + date.getFullYear();
                }
            },
            {
                data: null, render: function (data, type, row) {
                    return "<a href='#' class='btn btn-info btn-xs' onclick=AddEditEmailConfig('" + row.Id + "');>Edit</a>";
                }
            },
            {
                data: null, render: function (data, type, row) {
                    return "<a href='#' class='btn btn-danger btn-xs' onclick=DeleteEmailConfig('" + row.Id + "'); >Delete</a>";
                }
            }
        ],

        'columnDefs': [{
            'targets': [7, 8],
            'orderable': false,
        }],

        "lengthMenu": [[20, 10, 15, 25, 50, 100, 200], [20, 10, 15, 25, 50, 100, 200]]
    });

});

