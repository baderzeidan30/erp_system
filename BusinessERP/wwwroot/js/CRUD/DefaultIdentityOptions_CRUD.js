﻿var Edit = function (id) {
    var url = "/IdentitySetting/Edit?id=" + id;
    OpenModalView(url, "modal-lg", 'Edit Default Identity Option');
};


var UpdateDefaultIdentityOptions = function () {
    var _frmDefaultIdentityOptions = $("#frmDefaultIdentityOptions").serialize();
    $.ajax({
        type: "POST",
        url: "/IdentitySetting/Edit",
        data: _frmDefaultIdentityOptions,
        success: function (result) {
            Swal.fire({
                title: result.AlertMessage,
                icon: "success"
            }).then(function () {
                document.getElementById("btnClose").click();
                setTimeout(function () {
                    $("#tblDefaultIdentityOptions").load("/IdentitySetting/Index #tblDefaultIdentityOptions");
                }, 100);
            });
        },
        error: function (errormessage) {
            SwalSimpleAlert(errormessage.responseText, "warning");
        }
    });
}
