$(function () {
    let searchButton = document.getElementById("btnSearch");

    if (searchButton) {
        searchButton.addEventListener("click", searchToDo)
    }
});

function searchToDo() {
    let plannerCards = document.querySelectorAll(".plannerCards");
    let inputTitle = document.getElementById("search").value;
    let filter = inputTitle.toUpperCase();
    let title = document.querySelectorAll(".plannerTitle");
    let searchMsg = document.getElementById("searchMsg");

    for (var i = 0; i < plannerCards.length; i++) {
        let focus = plannerCards[i];
        let compare = title[i].dataset.pname;

        if (compare.toUpperCase().includes(filter)) {
            focus.style.display = "";
            searchMsg.style.display = "none";
        }

        else {
            focus.style.display = "none";
            searchMsg.style.display = "block";
        }
    }
}