$(document).ready(function () {
    document.title = 'Tenant';

    $("#tblTenant").DataTable({
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
            "url": "/Tenant/GetDataTabelData",
            "type": "POST",
            "datatype": "json"
        },


        "columns": [
            {
                data: "TenantId", "name": "TenantId", render: function (data, type, row) {
                    return "<a href='#' onclick=DetailTenant('" + row.TenantId + "');>" + row.TenantId + "</a>";
                }
            },
            { "data": "FullName", "name": "FullName" },
            { "data": "TenancyName", "name": "TenancyName" },
            { "data": "EInvoiceCompanyID", "name": "EInvoiceCompanyID" },
            { "data": "PhoneNumber", "name": "PhoneNumber" },
            { "data": "EInvoiceRegistrationName", "name": "EInvoiceRegistrationName" },


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
                data: null, render: function (data, type, row) {
                    return "<a href='#' class='btn btn-info btn-xs' onclick=AddEditTenant('" + row.TenantId + "');>Edit</a>";
                }
            },
            {
                data: null, render: function (data, type, row) {
                    return "<a href='#' class='btn btn-danger btn-xs' onclick=DeleteTenant('" + row.TenantId + "'); >Delete</a>";
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

