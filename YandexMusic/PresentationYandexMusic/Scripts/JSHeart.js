$(function () {

    // Устанавливаем лайкнутые треки
    for (var i = 0; i < $(`.btn-favorite`).find(`i`).length; i++) {
        let item = $(`.btn-favorite`).find(`i`).get(i);
        if ($(item).attr(`data-like`) == `True`) {
            $(item).attr(`class`, `fa fa-heart`)
        }
    }

    // Событие на нажатие сердечка
    $(`.btn-favorite`).click(function () {
        let heart = $(this).find(`i`);
        let trackId = $(this).attr(`data-trackId`);

        if ($(heart).attr(`class`) == `fa fa-heart-o`) {
            $(heart).attr(`class`, `fa fa-heart`);

            // Добавление в базу дынных трек
            $.ajax({
                method: `GET`,
                url: `/Playlist/AddTrackInPlaylistBeloved/${trackId}`
            }).done(function () {

                // Обновляем все треки UpdateTrackId
                $.ajax({
                    method: `GET`,
                    url: `/Playlist/GetLikedTracksView`,
                    success: function (html) {
                        $(`#LikeTrack`).html(html);
                        // Утанавливаем скрипт ButtonPlayMusic(смотрим другой скрипт)
                        OnSuccess();
                    }
                });
            });
        }
        else {
            $(heart).attr(`class`, `fa fa-heart-o`);

            // Удаляем трек в базе данных
            $.ajax({
                method: `GET`,
                url: `/Playlist/DeleteTrackInPlaylistBeloved/${trackId}`
            }).done(function () {

                // Обновляем все треки UpdateTrackId
                $.ajax({
                    method: `GET`,
                    url: `/Playlist/GetLikedTracksView`,
                    success: function (html) {
                        $(`#LikeTrack`).html(html);
                        // Утанавливаем скрипт ButtonPlayMusic(смотрим другой скрипт)
                        OnSuccess();
                    }
                });
            });
        }
    });
});

//fa fa-heart-o  NoActive
//fa fa-heart    Active