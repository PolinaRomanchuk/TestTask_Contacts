$(document).ready(function () {
    $(".popup-btn").click(function (e) {
        var dataPopup = $(this).data('popup');
        popup = $(dataPopup);
        popup.addClass("show");
        return false;
    });
    $(document).mouseup(function (e) {
        var x = $(e.target);
        if (!x.is('.popup')) {
            x = $(e.target).parents('.popup');
        }
        if (x.length == 0) {
            $('.popup.show').removeClass("show");
        }
    });
    $(".exit-button").click(function (e) {
        $('.popup.show').removeClass("show");
    });

    $('[name="update-button"]').click(function () {
        var contactId = $(this).closest("[name = container-contact]").find('.ContactId').val();
        $(".hiddenValueId").val(contactId);
        $.get(`/api/contact/GetModel?id=${contactId}`)
            .then(function (dataObj) {
                $("#name-of-contact-for-update").val(dataObj.name)
                $("#mobilePhone-of-contact-for-update").val(dataObj.mobilePhone)
                $("#birthDate-of-contact-for-update").val(dataObj.birthDate)
                $("#jobTitle-of-contact-for-update").val(dataObj.jobTitle)
            });
    });
});













