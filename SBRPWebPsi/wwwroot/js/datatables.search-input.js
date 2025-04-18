
$(function () {
    $('div.dt-search input').on('keypress', function (e) {
        //console.log('sssss');
        //if (e.key === 'Enter') {
        //    table
        //        .one('draw', function () {
        //            table.processing(false);
        //        })
        //        .processing(true);
        //}
    });

    $('div.dt-search input').on('keydown', function (e) {
        if (e.keyCode == 27) {
            $(this).val('');
        }
    });
});
