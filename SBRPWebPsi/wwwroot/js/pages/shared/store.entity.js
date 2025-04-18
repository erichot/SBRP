document.addEventListener('DOMContentLoaded', () => {
    const txtPtStoreName = document.getElementById('txtPtStoreName');
    const txtPtStoreNameAbbr = document.getElementById('txtPtStoreNameAbbr');

    txtPtStoreName.addEventListener('blur', () => {
        JS_fnCopyInputValueAbbr(txtPtStoreName, txtPtStoreNameAbbr)
    });
});
