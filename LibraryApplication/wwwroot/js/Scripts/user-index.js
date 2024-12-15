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
            Id: { // Match the JSON property name
                key: true,
                title: 'Id',
                width: '10%'
            },
            Email: { // Match the JSON property name
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

                    loadChildRecords(record.Id, record.FullName);
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

        parentEntityId = entityId;

        $('#data-child-container').jtable({
            title: 'Roles of ' + entityName,
            jqueryuiTheme: true,
            sorting: false,
            actions: {
                listAction: '/Role/ListUserRoles/' + entityId,
                createAction: '/Role/AddRole/' + entityId,
                updateAction: '/Role/UpdateRole/' + entityId,
                deleteAction: '/Role/DeleteRole/' + entityId,
            },
            fields: {
                UserId: {
                    type: 'hidden',
                    defaultValue: entityId
                },
                Id: {
                    key: true,
                    create: false,
                    edit: false,
                    list: false
                },
                Name: {
                    create: false,
                    title: 'Name',
                    width: '30%',
                }
            }
        });

        $('#data-child-container').jtable('load');
    }

    // Load data into the table
    $('#data-container').jtable('load', {
        isActive: true
    });
});
