$(function () {
    let i = 0;

    for (let index = 0; index < $(`.playMusic`).length; index++) {
        let item = $(`.playMusic`).get(index);
        $(item).attr(`data-id`, i++)
    }

    $(`.playMusic`).click(function () {
        $(`.playMusic`).css(`outline`, `none`);

        let id = $(this).attr(`data-id`);
        let name = $(this).children(0).attr(`name`).substr(0, 4);

        for (let index = 0; index < $(`.playMusic`).length; index++) {
            let item = $(`.playMusic`).get(index);
            let id = $(item).attr(`data-id`);
            $(item).children(0).remove();
            $(item).append(`<img src="../../images/Play.jpg" class="rounded" name="Play${id}"/>`)
        }

        if (name == `Play`) {
            let parent = $(`[name=Play${id}]`).parent();
            parent.children(0).remove();
            parent.append(`<img src="../../images/Stop.jpg" class="rounded" name="Stop${id}"/>`);

            let currentMusic = $(`.Player audio`).attr(`data-currentMusic`);
            let pushMusic = $(this).attr(`data-location`);

            if (currentMusic != pushMusic) {
                let volume = $(`.Player audio`).get(0).volume;

                $(`.Player audio`).remove();
                $(`.Player`).append(` 
                <audio controls autoplay data-currentMusic="${pushMusic}" style="width:100%">
                               <source src="${pushMusic}" type="audio/mp3" />
                </audio>`);
                $(`.Player audio`).get(0).volume = volume;
            }
            else {
                $(`.Player audio`).get(0).play();
            }
        }
        else {
            $(`.Player audio`).get(0).pause();
        }

    });

});