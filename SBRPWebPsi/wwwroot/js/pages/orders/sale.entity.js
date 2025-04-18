


$(function () {    
    $("#txtPtMemberId").kendoComboBox({
        dataTextField: CN_MEM_MemberName,
        dataValueField: CN_MEM_MemberId,
        dataSource: {
            type: "jsonp",
            serverFiltering: true,
            transport: {
                read: {
                    url: jsApiUrlDepartmentSIL,
                    headers: {
                        Authorization: 'Bearer ' + jsApiToken
                    }
                }
            },
            beforeSend: function (req) {
                req.setRequestHeader('Authorization', 'Bearer ' + jsApiToken);
            }
        },
        filter: "contains",
        suggest: true,
        placeholder: "Please select your favourite sport..."
    });

   
});
