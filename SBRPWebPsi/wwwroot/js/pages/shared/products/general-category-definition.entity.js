console.log('ttttt');
document.addEventListener('DOMContentLoaded', () => {
    const txtPtItemIdMinLength = document.getElementById('txtPtItemIdMinLength');
    const txtPtItemIdMaxLength = document.getElementById('txtPtItemIdMaxLength');

    txtPtItemIdMinLength.addEventListener('blur', () => {
        JS_fnCopyInputValueTextClone(txtPtItemIdMinLength, txtPtItemIdMaxLength)
    });
});
