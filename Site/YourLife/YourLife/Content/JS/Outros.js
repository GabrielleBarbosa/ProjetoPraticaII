var texto = "";

function suicidioTexto() {
$('#txt1').hide();
$('.lbl1').html("");
$('#cabecalho').html("Tem certeza que deseja cometer suicídio?");
}

function terminarRel() {
    $('#txt1').hide();
    $('.lbl1').html("");
    $('#cabecalho').html("Tem certeza que deseja terminar o relacionamento?");
}

$(document).ready(function () {
    $('.modal').modal();
});