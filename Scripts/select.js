$(document).ready(function () {
    var table = $('#example').DataTable();

    $('#example tbody').on('dblclick', 'tr', function () {
        if ($(this).hasClass('selected')) {
            $(this).removeClass('selected');
        }
        else {
            table.$('tr.selected').removeClass('selected');
            $(this).addClass('selected');
            $('.id-label').text($(this).closest('tr').find('td:first').text());
            $('#classModal').modal('hide');
        }
    });
});