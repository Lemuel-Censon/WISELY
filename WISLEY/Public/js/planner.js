$(function () {
    let searchButton = document.getElementById('btnSearch');

    if (searchButton) {
        searchButton.addEventListener('click', searchToDo);
    }
});

function searchToDo() {
    let input = $('#search').val();
    let filter = input.toUpperCase();
    let cards = $('.plannerCards');
    let title = $('.plannerTitle');

    for (let i = 0, n = cards.length; i < n; i++) {
        let focus = $(cards[i]);
        let compare = $(name[i]).data('title');

        if (compare.toUpperCase().includes(filter)) {
            if ($(focus).hasClass('d-none')) {
                $(focus).removeClass('d-none');
                $(focus).addClass('animated faster fadeIn').one("animationend", function () {
                    let _this = $(this);

                    _this.removeClass('animated faster fadeIn');
                });
            }
        }
        else {
            if (!$(focus).hasClass('d-none')) {
                $(focus).addClass('animated faster fadeOut').one("animationend", function () {
                    let _this = $(this);

                    _this.removeClass('animated faster fadeOut');
                    _this.addClass('d-none');
                })
            }
        }
    }
}