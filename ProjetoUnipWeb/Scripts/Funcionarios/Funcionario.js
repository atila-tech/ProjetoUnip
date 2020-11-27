function chamaDataTable() {
    $('#tbFuncionarios thead tr:eq(1) th:not(.nofilter)').each(function () {
        var title = $('#tbFuncionarios thead tr:eq(1) th').eq($(this).index()).text();
        if (title != '') {
            $(this).html('<input type="text" class="form-control input-sm ' + title + '" placeholder="' + title + '" />');
        }
    });

    var table = $('#tbFuncionarios').DataTable({
        destroy: true,
        //searching: true,
        orderCellsTop: true,
        lengthMenu: [[10, 25, 50, 100, -1], [10, 25, 50, 100, "Tudo"]],
        //lengthChange: true,
        pageLength: 10,
        //info: true,
        //ordering: true,
        //autoWidth: false,
        ajax: {
            url: '/Funcionario/Administrador/GetFuncionarios'
        },
        language: configLanguageDataTable(),
        pagingType: 'simple_numbers',

        dom: 'Blfrtip',
        columns: [

            { "width": "20%", "class": "text-left" },
            { "width": "20%", "class": "text-left" },
            { "width": "20%", "class": "text-center" },
            { "width": "20", "class": "text-center" },
            { "width": "20%", "class": "text-center" }

        ],
        columnDefs: [
            {
                "targets": [0],
                "orderable": true
            },

            {
                "targets": [1],
                "orderable": true
            },
            {
                "targets": [2],
                "orderable": true
            },
            {
                "targets": [3],
                "orderable": true
            },
            {
                "targets": [4],
                "orderable": true
            },
        ],

        //dom: 'Bfrtip',
        //buttons: [
        //    //botão para salvar em pdf
        //    {
        //        extend: 'pdfHtml5',
        //        text: 'Salvar em PDF',
        //        exportOptions: {
        //            modifier: {
        //                //page: 'current'
        //            }
        //        },
        //        header: true,
        //        title: 'My Table Title',
        //        orientation: 'landscape',
        //        customize: function (doc) {
        //            doc.defaultStyle.fontSize = 6; //<-- set fontsize to 16 instead of 10
        //        }
        //    },

        //    //botão para salvar em excel
        //    {
        //        extend: 'excelHtml5',
        //        text: 'Gerar Excel',
        //        orientation: 'landscape',
        //        exportOptions: {
        //            modifier: {
        //                //page: 'current'
        //            }
        //        }
        //    },
        //    //botão para imprimir
        //    {
        //        extend: 'print',
        //        text: 'Imprimir',
        //        orientation: 'landscape',
        //        customize: function (win) {
        //            $(win.document.body)
        //                .css('font-size', '6pt')
        //            //.prepend(
        //            //    '<img src="http://datatables.net/media/images/logo-fade.png" style="position:absolute; top:0; left:0;" />'
        //            //);

        //            $(win.document.body).find('table')
        //                .addClass('compact')
        //                .css('font-size', 'inherit');
        //        },
        //        exportOptions: {
        //            modifier: {
        //                //page: 'current'
        //            }
        //        }
        //    }
        //],

        //fnDrawCallback: function () {
        //    configDataTables();
        //}
    });

    table.columns().every(function (index) {
        $('#tbFuncionarios thead tr:eq(1) th:eq(' + index + ') input').on('keyup change', function () {
            table.column($(this).parent().index() + ':visible')
                .search(this.value)
                .draw();
        });
    });

    $('#tbFuncionarios tbody').on('mouseover', 'tr', function (event) {
        $(this).attr("style", "cursor:pointer");
    });
}

function configLanguageDataTable() {
    return {
        "loadingRecords": "Carregando...",
        "sProcessing": "A processar...",
        "sLengthMenu": "_MENU_",
        "sZeroRecords": "Não foram encontrados resultados",
        "sInfo": "Mostrando de _START_ até _END_ de _TOTAL_ registros",
        "sInfoEmpty": "Mostrando de 0 até 0 de 0 registos",
        "sInfoFiltered": "(filtrado de _MAX_ registos no total)",
        "sInfoPostFix": "",
        "sSearch": "",
        "sUrl": "",
        "oPaginate": {
            "sFirst": "Primeiro",
            "sPrevious": "Anterior",
            "sNext": "Seguinte",
            "sLast": "Último"
        }
    }
};