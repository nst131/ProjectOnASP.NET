$(function () {
    // Устанавливаем событи на Воиспроизведение мелодии
    ButtonClickEvent();
});

// Перезапускаем событие клика на Воиспроизведение мелодии(для скрипта JSHeart)
function OnSuccess() {
    ButtonClickEvent();
}

function ButtonClickEvent() {

    let i = 0;

    // Устанвливаем разные индексы на мелодии для их распознования
    for (let index = 0; index < $(`.playMusic`).length; index++) {
        let item = $(`.playMusic`).get(index);
        $(item).attr(`data-id`, i++)
    }

    // Удаляем все прошлые события с этоно объекта
    $(`.playMusic`).off();

    $(`.playMusic`).click(function (e) {   
        $(`.playMusic`).css(`outline`, `none`);

        // Считываем id (типа Play3)
        let id = $(this).attr(`data-id`);
        // Считываем первые 4 символа для понимания Stop or Play
        let name = $(this).children(0).attr(`name`).substr(0, 4);

        // Всем ставим картинку Play 
        for (let index = 0; index < $(`.playMusic`).length; index++) {
            let item = $(`.playMusic`).get(index);
            let id = $(item).attr(`data-id`);
            $(item).children(0).remove();
            $(item).append(`<img src="../../images/Play.jpg" class="rounded" name="Play${id}"/>`)
        }

        // Если прошлый name был на воиспроизведение, то ставим картинку Stop
        if (name == `Play`) {
            let parent = $(`[name=Play${id}]`).parent();
            parent.children(0).remove();
            parent.append(`<img src="../../images/Stop.jpg" class="rounded" name="Stop${id}"/>`);

            // На плеере записан текущий файл(сестоположение), получаем его
            let currentMusic = $(`.Player audio`).attr(`data-currentMusic`);
            // Местоположение нашего файла
            let pushMusic = $(this).attr(`data-location`);

            // Сравниваем эти файлы (Если НЕТ, то)
            if (currentMusic != pushMusic) {
                // Сохраняем прошлую громкость звука
                let volume = $(`.Player audio`).get(0).volume;

                // Устанвливаем в плеер новый путь к треку, воиспроизведение автомат(autoplay)
                $(`.Player audio`).remove();
                $(`.Player`).append(` 
                <audio controls autoplay data-currentMusic="${pushMusic}" style="width:100%">
                               <source src="${pushMusic}" type="audio/mp3" />
                </audio>`);
                // Устанвливаем в плеер прошлый звук
                $(`.Player audio`).get(0).volume = volume;
            }
            else {
                // Иначе воиспроизводим
                $(`.Player audio`).get(0).play();
            }
        }
        // Иначе оставнавливаем трек
        else {
            $(`.Player audio`).get(0).pause();
        }

    });
}