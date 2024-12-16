$(document).ready(function () {

    $('#data-container').jtable({
        title: 'Roles',
        jqueryuiTheme: true,
        actions: {
            listAction: '/Role/GetRoles',
            createAction: '/Role/AddRole',
            updateAction: '/Role/UpdateRole',
            deleteAction: '/Role/DeleteRole'
        },
        fields: {
            RoleName: {
                key: true,
                edit: false,
                create: true,
                title: 'Role Name',
                width: '10%'
            },
            NewRoleName: {
                title: 'New Role Name',
                edit: true,
                create: false,
                list: false, 
                width: '10%'
            },
        },
    });
    $('#data-container').jtable('load', {
        isActive: true
    });
});
