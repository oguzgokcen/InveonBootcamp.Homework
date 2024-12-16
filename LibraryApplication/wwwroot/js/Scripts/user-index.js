$(document).ready(function () {

    $('#data-container').jtable({
        title: 'Users',
        jqueryuiTheme: true,
        selecting: true,
        actions: {
            listAction: '/Role/ListUsers',
            createAction: '/Role/AddUser',
            updateAction: '/Role/UpdateUser',
            deleteAction: '/Role/DeleteUser'
        },
        fields: {
            UserId: {
                key: true,
                title: 'Id',
                width: '10%'
            },
            Email: {
                title: 'Email',
                width: '15%'
            },
            Password: {
                update: false,
                list: false,
                edit: false,
                type: "password",
                title: 'Password',
                width: '20%'
            },
            FullName: {
                title: 'Full name',
                width: '15%'
            }
        },
        formSubmitting: function (event, data) {
            if (data.formType == "create") {
                var password = $("#Edit-Password").val();
                $(".jtable-password-input").append("<br/><small id='password-error' style='color:red'></small>");
                var test = checkPassword(password);
                if (!test) {
                    $('#password-error').text("Invalid password");
                    $('#password-error').show();
                } else {
                    $('#password-error').hide();
                }
                return test;
            }
        },
        selectionChanged: function () {

            var $selectedRows = $('#data-container').jtable('selectedRows');

            if ($selectedRows.length > 0) {

                $selectedRows.each(function () {

                    if ($("#data-child-container").html() != '')
                        $('#data-child-container').jtable('destroy');

                    var record = $(this).data('record');

                    loadChildRecords(record.UserId, record.FullName);
                });
            }
        },
    });

    function checkPassword(str) {
        // min length 8 , min 1 number, 1 lowercase, 1 uppercase and 1 special character
        var re = /^(?=.*\d)(?=.*[!@#$%^&*])(?=.*[a-z])(?=.*[A-Z]).{8,}$/;
        return re.test(str);
    }
    function loadChildRecords(entityId, entityName) {

        $('#data-child-container').jtable({
            title: 'Roles of ' + entityName,
            jqueryuiTheme: true,
            sorting: false,
            actions: {
                listAction: '/Role/ListUserRoles?UserId=' + entityId,
                createAction: '/Role/AddRoleToUser',
                deleteAction: function (postData) {
                    return $.Deferred(function ($dfd) {
                        $.ajax({
                            url: '/Role/DeleteRoleFromUser',
                            type: 'POST',
                            dataType: 'json',
                            data: { UserId: entityId, RoleName: postData.RoleName },
                            success: function (data) {
                                $dfd.resolve(data);
                            },
                            error: function () {
                                $dfd.reject();
                            }
                        });
                    });
                }
            },
            fields: {
                UserId: {
                    type: 'hidden',
                    defaultValue: entityId
                },
                RoleName: {
                    key: true,
                    create:true,
                    title: 'Name',
                    width: '30%',
                    edit: true
                }
            }
        });

        $('#data-child-container').jtable('load');
    }

    $('#data-container').jtable('load', {
    });
});
