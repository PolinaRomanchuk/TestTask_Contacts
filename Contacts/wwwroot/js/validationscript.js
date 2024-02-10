$(".mobile-phone-check").on("input", function (event) {
    var myPhonevalue = $(this).closest('.mobile-phone-check').val();
    var regularPhone = /^(\+375)(29|25|44|33)(\d{3})(\d{2})(\d{2})$/;
    var valid = regularPhone.test(myPhonevalue);
    if (valid) {
        this.setCustomValidity('');
    } else {
        this.setCustomValidity('Необходимый формат: +375291231212');
    }
});

$(".birthDate-check").on("input", function (event) {
    let currentdate = new Date();
    var stringbirthDate = $(this).closest('.birthDate-check').val();
    var dateofbirthday = Date.parse(stringbirthDate);
    var dateofnow = Date.parse(currentdate);
    if (dateofbirthday > dateofnow) {
        this.setCustomValidity('Неверные данные. Дата рождения не может быть в будущем');
    }
    else this.setCustomValidity('');
});