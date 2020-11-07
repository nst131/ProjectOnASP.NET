$(function () {
    $(`.btn-favorite`).click(function () {
        let heart = $(this).find(`i`);
        if ($(heart).attr(`class`) == `fa fa-heart-o`) {
            $(heart).attr(`class`, `fa fa-heart`);
        }
        else {
            $(heart).attr(`class`, `fa fa-heart-o`);
        }
    });
});