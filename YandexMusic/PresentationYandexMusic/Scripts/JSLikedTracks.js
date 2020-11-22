$(function () {

    for (var i = 0; i < $(`.btn-favorite`).find(`i`).length; i++) {
        let item = $(`.btn-favorite`).find(`i`).get(i);
        if ($(item).attr(`data-like`) == `True`) {
            $(item).attr(`class`, `fa fa-heart`)
        }
    }

    $(`.btn-favorite`).click(function () {
        let heart = $(this).find(`i`);
        let trackId = $(this).attr(`data-trackId`);

        if ($(heart).attr(`class`) == `fa fa-heart-o`) {
            $(heart).attr(`class`, `fa fa-heart`);

            $.ajax({
                method: `GET`,
                url: `/Playlist/AddTrackInPlaylistBeloved/${trackId}`
            }).done(function () {

                $.ajax({
                    method: `GET`,
                    url: `/Track/LikedTrackView`,
                    success: function (html) {
                        $(`#view`).html(html);
                    }
                });
            });
        }
        else {
            $(heart).attr(`class`, `fa fa-heart-o`);

            $.ajax({
                method: `GET`,
                url: `/Playlist/DeleteTrackInPlaylistBeloved/${trackId}`
            }).done(function () {

                $.ajax({
                    method: `GET`,
                    url: `/Track/LikedTrackView`,
                    success: function (html) {
                        $(`#view`).html(html);
                    }
                });
            });
        }
    });
});