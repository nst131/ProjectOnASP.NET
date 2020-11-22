$(function () {
    $(`#Singers`).on(`change`, `.SingerList`, function () {
        let id = $(`.SingerList option:selected`).val()
        $.ajax({
            method: `GET`,
            url: `/Admin/AdminTrack/ReplaceItem/${id}`
        })
            .done(function (data) {
                $(`.AlbumList`).remove();
                $(`#Albums`).append(`<select name=AlbumId class='AlbumList'></select>`)
                for (var i = 0; i < data.AlbumsId.length; i++) {
                    $(`.AlbumList`).append(`<option value=${data.AlbumsId[i]}>${data.AlbumsName[i]}</option>`)
                }
            })
    })
})