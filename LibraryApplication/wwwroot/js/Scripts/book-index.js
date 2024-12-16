$(document).ready(function () {

    $('#data-container').jtable({
        title: 'Books',
        jqueryuiTheme: true,
        paging: true,
        pageSize: 10,
        actions: {
            listAction: '/Book/ListBooks',
            createAction: '/Book/AddBook',
            updateAction: '/Book/UpdateBook',
            deleteAction: '/Book/DeleteBook'
        },
        fields: {
            Id: {
                key: true,
                title: 'Id',
                width: '10%',
                create: false, 
                edit: false,
                list: false
            },
            Title: {
                title: 'Title',
                width: '15%',
                inputClass: 'form-control'  // For proper styling
            },
            Author: {
                title: 'Author',
                width: '15%',
                inputClass: 'form-control'
            },
            PublicationYear: {
                title: 'Publication Year',
                width: '10%',
                type: 'number',
                create: true,
                edit: true,
                inputClass: 'form-control'
            },
            ISBN: {
                title: 'ISBN',
                width: '15%',
                inputClass: 'form-control'
            },
            Genre: {
                title: 'Genre',
                list:false,
                width: '10%',
                inputClass: 'form-control'
            },
            Publisher: {
                title: 'Publisher',
                list: false,
                width: '15%',
                inputClass: 'form-control'
            },
            PageCount: {
                title: 'Page Count',
                width: '10%',
                type: 'number',
                create: true,
                edit: true,
                list: false,
                inputClass: 'form-control'
            },
            Language: {
                title: 'Language',
                width: '10%',
                list: false,
                inputClass: 'form-control'
            },
            Summary: {
                title: 'Summary',
                list: false,
                width: '20%',
                type: 'textarea',
                inputClass: 'form-control'
            },
            AvailableCopies: {
                title: 'Available Copies',
                width: '10%',
                type: 'number',
                create: true,
                edit: true,
                list: false,
                inputClass: 'form-control'
            },
            Details: {
                title: 'Details',
                width: '10%',
                display: function (data) {
                    return '<a href="/Book/Detail/' + data.record.Id + '" class="text-primary">View Details</a>';
                }
            }
        }
    });
    $('#data-container').jtable('load', {
        isActive: true
    });
});