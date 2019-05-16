///////////////////////////////////////////////////////////////////
var modal = document.getElementById("modal1");
var span = document.getElementsByClassName("close")[0];

abrirModal = function () {
    modal.style.display = "block";
};

window.onclick = function (event) {
    if (event.target == modal) {
        modal.style.display = "none";
    }
};

span.onclick = function () {
    modal.style.display = "none";
};