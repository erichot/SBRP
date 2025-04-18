$(document).ready(function () {
    $('#form1 input').on('keypress', function (event) {
        if (event.which === 13) { // Check if Enter key is pressed
            var submitButtonUI = $('button[type="button"].btn-primary');
            event.preventDefault(); // Prevent the default form submission behavior
            //$('#form1').submit(); // Submit the form
            submitButtonUI.click();
        }
    });
});