var texto = "";

function suicidioTexto() {
$('#txt1').hide();
$('.lbl1').html("");
$('#cabecalho').html("Tem certeza que deseja cometer suicídio?");
$('.modal').modal();
$.post('/jogo/Suicidio');
}

function terminarRel() {
    $('#txt1').hide();
    $('.lbl1').html("");
    $('#cabecalho').html("Tem certeza que deseja terminar o relacionamento?");
    $('.modal').modal();
}

function demissao(){
    $('#txt1').hide();
    $('.lbl1').html("");
    $('#cabecalho').html("Tem certeza que deseja pedir demissão? ");
    $('.modal').modal();
    Response.redirect("/Jogo/Login");
}


$(document).ready(function () {
    $('.modal').modal();
});