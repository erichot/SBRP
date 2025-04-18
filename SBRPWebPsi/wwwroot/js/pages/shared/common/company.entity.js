document.addEventListener('DOMContentLoaded', () => {
    const txtPtCompanyName = document.getElementById('txtPtCompanyName');
    const txtPtCompanyNameAbbr = document.getElementById('txtPtCompanyNameAbbr');

    txtPtCompanyName.addEventListener('blur', () => {
        console.log('blur');
        JS_fnCopyInputValueAbbr(txtPtCompanyName, txtPtCompanyNameAbbr)
    });
});
