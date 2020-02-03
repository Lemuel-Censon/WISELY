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
        let compare = $(cards[i].data('title'))
    }
}