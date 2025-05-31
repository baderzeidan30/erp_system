var DetailTenant = function (id) {
    var url = "/Tenant/Details?id=" + id;
    OpenModalView(url, "modal-lg", 'Tenant Details');
};


var AddEditTenant = function (id) {
    var url = "/Tenant/AddEdit?id=" + id;
    var ModalTitle = "Add Tenant";
    if (id > 0) {
        ModalTitle = "Edit Tenant";
    }
    OpenModalView(url, "modal-lg", ModalTitle);
};

var SaveTenant = function () {
    if (!$("#frmTenant").valid()) {
        return;
    }

    var _frmTenant = $("#frmTenant").serialize();
    $("#btnSaveTenant").val("Please Wait");
    $('#btnSaveTenant').attr('disabled', 'disabled');

    $.ajax({
        type: "POST",
        url: "/Tenant/AddEdit",
        data: _frmTenant,
        success: function (result) {
            if (result.IsSuccess) {
                Swal.fire({
                    title: result.AlertMessage,
                    icon: "success"
                }).then(function () {
                    document.getElementById("btnCloseTenant").click();
                    $("#btnSaveTenant").val("Save");
                    $('#btnSaveTenant').removeAttr('disabled');
                    if (result.CurrentURL == "/Items/Index") {
                        $('#tblItem').DataTable().ajax.reload();
                    }
                    else {
                        $('#tblTenant').DataTable().ajax.reload();
                    }
                });
            }
            else {
                Swal.fire({
                    title: result.AlertMessage,
                    icon: "warning"
                }).then(function () {
                    setTimeout(function () {
                        $('#Name').focus();
                    }, 400);
                });
            }
        },
        error: function (errormessage) {
            SwalSimpleAlert(errormessage.responseText, "warning");
        }
    });
}

var DeleteTenant = function (id) {
    var UIName = "Tenant";
    var _url = `/${UIName}/Delete?id=` + id;
    var _tableName = `tbl${UIName}`;

    var subMessage = addSpaceToUppercase(UIName);
    var _message = `${subMessage} has been deleted successfully. ${subMessage} ID: `;
    DeleteBase(_url, _message, _tableName);
};
