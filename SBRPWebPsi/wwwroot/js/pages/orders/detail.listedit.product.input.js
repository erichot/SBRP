
$(function() {




    $('#txtPtProductId_SingleInput').on('keydown', function (event) {
        if (event.key === "Enter") {
            $('#btnPtProductId_SingleInput').click();
        }
    });

});