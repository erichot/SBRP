const regexElementAttrIndex = /\[\d+\]|\(\d+\)|_\d+/;
const regexDigit = /\d/;




$(function () {
    
    $(".date-picker-mmdd").datepicker({
        minDate: new Date((new Date()).getFullYear(), 0, 1),
        maxDate: new Date((new Date()).getFullYear(), 11, 31),
        hideIfNoPrevNext: true,
        dateFormat: 'mm/dd'
    });


    $("select.cssPtContactPhoneType").on("change", function() {
        var attrId = $(this).attr('id');        
        var contactPhoneType = JS_fnParseNumber($(this).val());
        
        console.log('attrId=', attrId);
        console.log('selectedVal=', contactPhoneType);

        var matchedDigit = attrId.match(regexDigit);
        if (matchedDigit) {
            var index = JS_fnParseNumber(matchedDigit[0]);
            //console.log('index=', index);
            fnTxtPhoneNumber_Initial(index, contactPhoneType);
        }        
    });
});








function fnTxtPhoneNumber_Initial(index, contactPhoneType) {
    var maskFormat;

    switch (contactPhoneType) {
        case JS_ContactPhoneType_Landline:
        case JS_ContactPhoneType_Fax:
            maskFormat = '(00)0000-0000';
            break;

        case JS_ContactPhoneType_LandlineWithExt:
            maskFormat = '(00)0000-0000 00000';
            break;

        default:
            maskFormat = '0000-000-000';
            break;
    }

    var enableInitial = false;
    var maskPhoneNumber = $('#txt' + jsDvPtPCP_ChildRow_PrefixName + index).data("kendoMaskedTextBox");
    if (maskPhoneNumber === undefined) {
        enableInitial = true;
    }

    if (enableInitial == false)
        console.log('maskPhoneNumber.options.mask=', maskPhoneNumber.options.mask);

    if (enableInitial == false && maskPhoneNumber.options.mask != maskFormat) {
        console.log('maskPhoneNumber.destroy()');
        maskPhoneNumber.destroy();
        enableInitial = true;
    }

    if (enableInitial) {
        console.log('enableInitial_maskFormat=', maskFormat);
        $('#txt' + jsDvPtPCP_ChildRow_PrefixName + index).kendoMaskedTextBox({
            fillMode: 'none',
            rounded: 'none',
            size: 'none',
            culture: "zh-TW",
            mask: maskFormat
        });
    }
    
};







function fnDetailCloneChild(index) {
    var nextIndex = index + 1;
    console.log('nextIndex=', nextIndex);

    //var container = document.getElementById("childrenContainer");
    var $containerRows = $('#' + jsDvPtPCP_Container);
    console.log('L9_$(container).children.length=', $containerRows.children().length);
    var $children = $containerRows.children();
    //console.log('$children.length=', $children.length);


    var $selectedChildRow = $('#' + jsDvPtPCP_ChildRow_PrefixName + index);
    console.log('$selectedChildRow.length=', $selectedChildRow.length);
    console.log('$selectedChildRow.children().length=', $selectedChildRow.children().length);



    // ---------------------------------------------------------
    // Sibling next brother element and increment the index value before insert 
    console.log('$($selectedChildRow).nextAll().length=', $($selectedChildRow).nextAll().length);
    $($selectedChildRow).nextAll().each(function () {     
        // dvPtPCP_ChildRow_[index]
        fnReplaceIndexWithAttribute($(this), null, 1);

        var $nextInputElements = $(this).find('input, button, select').filter(function () {
            var nextNameAttr = $(this).attr('name');
            var nextIdAttr = $(this).attr('id');
            return regexElementAttrIndex.test(nextNameAttr) || regexElementAttrIndex.test(nextIdAttr);
        });
        console.log('$nextInputElements.length=', $nextInputElements.length);
        //console.log('$nextInputElements[0].attr(id)=', $nextInputElements[0]);
        $nextInputElements.each(function () {
            fnReplaceIndexWithAttribute($(this), null, 1);
        });
    });


    // ---------------------------------------------------------
    // Insert the new child at the position next to index
    var $newDivRow = jQuery('<div>', {
        id: jsDvPtPCP_ChildRow_PrefixName + nextIndex,
        class: ''
    });
    $selectedChildRow.after($newDivRow);
    //var $newDivRow = $('#' + jsDvPtPCP_ChildRow_PrefixName + nextIndex);
    console.log('$newDivRow.length=', $newDivRow.length);


    // Clone the elements from the source child div
    var $clonedElements = $selectedChildRow.children().clone();


    // ----------------------------------------------------------------------------------
    // Find the matched element which require to increment index value    
    var $clonedInputElements = $clonedElements.find('input, button, select').filter(function () {
        //return /\[\d+\]|\(\d+\)/.test($(this).attr('name'));
        //return /\[\d+\]|\(\d+\)|_\d+_/.test($(this).attr('name'));
        var nameAttr = $(this).attr('name');
        var idAttr = $(this).attr('id');
        return regexElementAttrIndex.test(nameAttr) || regexElementAttrIndex.test(idAttr);
    });
    console.log('$clonedInputElements.length=', $clonedInputElements.length);

    var $resultAddedInput;
    // Iterate through the cloned elements and update the name attributes
    $clonedInputElements.each(function () {
        var $currentClonedElement = $(this);
        if ($(this).is('input[type="text"]')) {
            $resultAddedInput = $(this);            
        }
        fnReplaceIndexWithAttribute($currentClonedElement, index, nextIndex); 
    });


    // ============================================================
    $newDivRow.append($clonedElements);
    //$containerRows.append($newDivRow);
    //$newDivRow.before($selectedChildRow);
    console.log('L75_$(container).children.length=', $containerRows.children().length);
    fnPtCEO_Btn_SetEnabledOrDisableByLength($containerRows.children().length);
    //$selectedChildRow.after($newDivRow);

    //if (index >= children.length) {
    //    $(container).append($newDiv);
    //} else {
    //    children.eq(index).before($newDiv);
    //}
    fnTxtPhoneNumber_Initial(index, null);
    $resultAddedInput.val('');
    $resultAddedInput.focus();
};




function fnDetailRemoveChild(index) 
{
    var $containerRows = $('#' + jsDvPtPCP_Container);
    var $selectedChildRow = $('#' + jsDvPtPCP_ChildRow_PrefixName + index);

    console.log('【fnDetailRemoveChild】# + jsDvPtPCP_ChildRow_PrefixName + index', '#' + jsDvPtPCP_ChildRow_PrefixName + index);
    console.log('【fnDetailRemoveChild】$selectedChildRow.length=', $selectedChildRow.length);
    console.log('【fnDetailRemoveChild】_before_$(#dvPtPCP_Container).children().length=', $('#dvPtPCP_Container').children().length);

    $($selectedChildRow).nextAll().each(function () {
        // dvPtPCP_ChildRow_[index]
        fnReplaceIndexWithAttribute($(this), null, -1);

        var $nextInputElements = $(this).find('input, button, select').filter(function () {
            var nextNameAttr = $(this).attr('name');
            var nextIdAttr = $(this).attr('id');
            return regexElementAttrIndex.test(nextNameAttr) || regexElementAttrIndex.test(nextIdAttr);
        });
        $nextInputElements.each(function () {
            fnReplaceIndexWithAttribute($(this), null, -1);
        });
    });

    $selectedChildRow.remove();
    console.log('【fnDetailRemoveChild】_after_$(#dvPtPCP_Container).children().length=', $('#dvPtPCP_Container').children().length);
    fnPtCEO_Btn_SetEnabledOrDisableByLength($('#' + jsDvPtPCP_Container).children().length);
};





// 與上面的兄弟節點互換位置，互換index
function fnDetailMoveUpChild(index) {

    var $selectedChildRow = $('#' + jsDvPtPCP_ChildRow_PrefixName + index);
    console.log('$selectedChildRow.length=', $selectedChildRow.length);
    var $previousChildRow = $($selectedChildRow).prev();
    console.log('$previousChildRow.length=', $previousChildRow.length);

    $previousChildRow.each(function () {
        // dvPtPCP_ChildRow_[index]
        fnReplaceIndexWithAttribute($(this), null, 1);

        var $nextInputElements = $(this).find('input, button, select').filter(function () {
            var nextNameAttr = $(this).attr('name');
            var nextIdAttr = $(this).attr('id');
            return regexElementAttrIndex.test(nextNameAttr) || regexElementAttrIndex.test(nextIdAttr);
        });
        $nextInputElements.each(function () {
            fnReplaceIndexWithAttribute($(this), null, 1);
        });
    });


    $selectedChildRow.each(function () {
        // dvPtPCP_ChildRow_[index]
        fnReplaceIndexWithAttribute($(this), null, -1);

        var $nextInputElements = $(this).find('input, button, select').filter(function () {
            var nextNameAttr = $(this).attr('name');
            var nextIdAttr = $(this).attr('id');
            return regexElementAttrIndex.test(nextNameAttr) || regexElementAttrIndex.test(nextIdAttr);
        });
        $nextInputElements.each(function () {
            fnReplaceIndexWithAttribute($(this), null, -1);
        });
    });


    fnPtCEO_Btn_SetEnabledOrDisableByLength(null);
    $previousChildRow.insertAfter($selectedChildRow);    
};








function fnDetailMoveDownChild(index) {

    var $selectedChildRow = $('#' + jsDvPtPCP_ChildRow_PrefixName + index);

    var $nextChildRow = $($selectedChildRow).next();

    $nextChildRow.each(function () {
        // dvPtPCP_ChildRow_[index]
        fnReplaceIndexWithAttribute($(this), null, -1);

        var $nextInputElements = $(this).find('input, button, select').filter(function () {
            var nextNameAttr = $(this).attr('name');
            var nextIdAttr = $(this).attr('id');
            return regexElementAttrIndex.test(nextNameAttr) || regexElementAttrIndex.test(nextIdAttr);
        });
        $nextInputElements.each(function () {
            fnReplaceIndexWithAttribute($(this), null, -1);
        });
    });


    $selectedChildRow.each(function () {
        // dvPtPCP_ChildRow_[index]
        fnReplaceIndexWithAttribute($(this), null, 1);

        var $nextInputElements = $(this).find('input, button, select').filter(function () {
            var nextNameAttr = $(this).attr('name');
            var nextIdAttr = $(this).attr('id');
            return regexElementAttrIndex.test(nextNameAttr) || regexElementAttrIndex.test(nextIdAttr);
        });
        $nextInputElements.each(function () {
            fnReplaceIndexWithAttribute($(this), null, 1);
        });
    });


    $nextChildRow.insertBefore($selectedChildRow);
};







/*
    oriIndex => not null mode => replace the index with newIndex
    newIndex => null mode => find the oriIndex from the attribute, then add increment value as newIndex
*/
function fnReplaceIndexWithAttribute($source, oriIndex, newIndex) {
    
    var attrName = $source.attr('name');
    var attrId = $source.attr('id');
    var attrValue = $source.attr('value');
    var attrOnClick = $source.attr('onclick');

    if (JS_fnIsNullOrUndefined(oriIndex)) {
        var matchedDigit = attrId.match(regexDigit);
        if (!matchedDigit) {
            matchedDigit = attrName.match(regexDigit);
        }
        oriIndex = JS_fnParseNumber(matchedDigit[0]);
        //console.log('oriIndex=', oriIndex);
        newIndex = oriIndex + newIndex;
    }

    
    if (!JS_fnIsNullOrUndefined(attrName)) {
        var newAttrName = attrName.replace(oriIndex, newIndex);
        $source.attr('name', newAttrName);
    }    

    
    if (!JS_fnIsNullOrUndefined(attrId)) {
        var newAttrId = attrId.replace(oriIndex, newIndex);
        $source.attr('id', newAttrId);
    }


    if (!JS_fnIsNullOrUndefined(attrValue)) {
        var newAttrValue = attrValue.replace(oriIndex, newIndex);
        $source.attr('value', newAttrValue);
    }
    
    if (!JS_fnIsNullOrUndefined(attrOnClick)) {
        var newAttrOnClick = attrOnClick.replace(oriIndex, newIndex);
        $source.attr('onclick', newAttrOnClick);
    }
};






