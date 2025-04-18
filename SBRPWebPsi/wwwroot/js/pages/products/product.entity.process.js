
$(function () {
    $(".cssPtPGCItemNo").kendoDropDownList({
        filter: "contains"
    });


    $('#txtProductPrice0').val($('#txtProductPrice_Panel_0').val());
    $('#txtProductPrice_Panel_0').on('input', function () {
        $('#txtProductPrice0').val($(this).val());
    });
    $('#txtProductPrice0').on('input', function () {
        $('#txtProductPrice_Panel_0').val($(this).val());
    });



    $('.open-popup-link').magnificPopup({
        type: 'inline',
        preloader: false,
        focus: '#txtProductPrice_Panel_0',
        closeBtnInside: true,
        midClick: true // Allow opening popup on middle mouse click. Always set it to true if you don't provide alternative source in href.        
    });
    // inline is the default content type (from v0.8.4), so you may skip its definition.








});