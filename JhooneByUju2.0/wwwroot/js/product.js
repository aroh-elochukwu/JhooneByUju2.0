$(document).ready(function () {
    loadDataTable();

});

function loadDataTable() {
    dataTable = $('#tblData').DataTable({
        "ajax": { url: '/admin/product/getall' },
        "columns": [
            { data: 'title', "width": "25%" },
            { data: 'designer', "width": "20%" },
            { data: 'price', "width": "10%" },
            { data: 'storeCode', "width": "10%" },
            { data: 'category.name', "width": "20%" }
        ]

    });
}

