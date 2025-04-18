$(function() {
    $('.toolbar-btn').hover(function () {
        //console.log('$(this)=', $(this).length);
        //console.log('$(this).is(: disabled)=', $(this).is(':disabled'));
         
        $(this).addClass('hover');
    }, function () {
        $(this).removeClass('hover');
    });
});





function fnPtAddChild(index) {
    fnDetailCloneChild(index);
};


function fnPtRemoveChild(index) {
    fnDetailRemoveChild(index);
};



function fnPtMoveUpChild(index) {
    fnDetailMoveUpChild(index);
};


function fnPtMoveDownChild(index) {
    fnDetailMoveDownChild(index);
};







function fnPtCEO_Btn_SetEnabledOrDisableByLength(_totalChildrenLength) {
    console.log('【fnPtCEO_Btn_SetEnabledOrDisableByLength】_totalChildrenLength=', _totalChildrenLength);

    if (_totalChildrenLength != null) {        
        var btnAddDisabled = false;

        if (_totalChildrenLength >= 5) {
            btnAddDisabled = true;
        }

        var btnAddElements = document.getElementsByClassName('toolbar-btn-add');
        Array.prototype.forEach.call(btnAddElements, function (elementAdd) {
            elementAdd.disabled = btnAddDisabled;
            if (btnAddDisabled)
                elementAdd.style.display = "none";
            else
                elementAdd.style.display = "block";
        });

        // ============================================================================
        var btnRemoveElements = document.getElementsByClassName('toolbar-btn-remove');
        console.log('btnRemoveElements.length=', btnRemoveElements.length);
        Array.prototype.forEach.call(btnRemoveElements, function (elementRemove) {
            elementRemove.disabled = false;
            elementRemove.classList.remove('toolbar-btn-disabled');
            elementRemove.classList.add('toolbar-btn');
            //elementRemove.style.display = "block";
        });

        if (btnRemoveElements.length == 1) {
            var btnRemoveFirst = document.getElementById('btnPtCEO_Remove_0');
            btnRemoveFirst.disabled = true;
            btnRemoveFirst.classList.remove('toolbar-btn');
            btnRemoveFirst.classList.add('toolbar-btn-disabled');
            //btnRemoveFirst.style.display = "none";
        }
    }



    // ============================================================================
    if (1==1 || _totalChildrenLength == null || _totalChildrenLength == 1) {
        if (_totalChildrenLength == null) {
            _totalChildrenLength = $('#dvPtPCP_Container').children().length;
            console.log('【fnPtCEO_Btn_SetEnabledOrDisableByLength】NULL__totalChildrenLength=', _totalChildrenLength)
        }

        // ---------------------------------------------------------------------------
        var btnMoveUpElements = document.getElementsByClassName('toolbar-btn-moveup');
        Array.prototype.forEach.call(btnMoveUpElements, function (elementMoveUp) {
            elementMoveUp.disabled = false;
            elementMoveUp.classList.remove('toolbar-btn-disabled');
            elementMoveUp.classList.add('toolbar-btn');
        });
        var btnMoveUp_First = document.getElementById('btnPtCEO_MoveUp_0');
        btnMoveUp_First.disabled = true;
        btnMoveUp_First.classList.remove('toolbar-btn');
        btnMoveUp_First.classList.add('toolbar-btn-disabled');



        // ---------------------------------------------------------------------------
        var elementsCount = 0;
        var btnMoveDownElements = document.getElementsByClassName('toolbar-btn-movedown');
        Array.prototype.forEach.call(btnMoveDownElements, function (elementMoveDown) {
            elementsCount++;
            elementMoveDown.disabled = false;
            elementMoveDown.classList.remove('toolbar-btn-disabled');
            elementMoveDown.classList.add('toolbar-btn');
        });
        var btnMoveUp_Down = document.getElementById('btnPtCEO_MoveDown_' + (elementsCount - 1).toString());
        btnMoveUp_Down.disabled = true;
        btnMoveUp_Down.classList.remove('toolbar-btn');
        btnMoveUp_Down.classList.add('toolbar-btn-disabled');
    }   
   
};

