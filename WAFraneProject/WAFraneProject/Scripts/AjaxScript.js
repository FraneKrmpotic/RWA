function AjaxPost(form) {
    $.validator.unobtrusive.parse(form);
    if ($(form).valid())
    {
        var ajaxConfig = {
            type: 'POST',
            url: form.action,
            data: new FormData(form),
            success: function (response) {
                $("#firstTab").html(response);
                $('ul.nav.nav-tabs a:eq(1)').html('Add category');
            }
        }
        if ($(form).attr('enctype') == "multipart/form-data") {
            ajaxConfig["contentType"] = false;
            ajaxConfig["processData"] = false;
        }

        $.ajax(ajaxConfig);
    }
    return false;
}

function Edit(url) {
    $.ajax({
        type: 'GET',
        url: url,
        success: function (response) {
           // window.location.href = "/CRUD/AddOrEditCategory/" + url.substring(url.lastIndexOf('/') + 1);
            $("#secondTab").html(response);
            $('ul.nav.nav-tabs a:eq(1)').html('Edit');
            $('ul.nav.nav-tabs a:eq(1)').tab('show');
        }
    });
}

function Delete(url) {
    if (confirm('Are you sure you want to delete this record?') == true) {
        $.ajax({
            type: 'POST',
            url: url,
            success: function (response) {
                $("#firstTab").html(response);
            }
        });
    }
}
