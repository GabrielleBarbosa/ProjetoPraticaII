
function suicidio() {
$('#resposta1').attr('href', 'Suicidio');
$('#txt1').hide();
$('.lbl1').html("");
$('#cabecalho').html("Tem certeza que deseja cometer suicídio?");
$('.modal').modal();
}

function terminarRel() {
    $('#txt1').hide();
    $('.lbl1').hide();
    $('.lbl1').html("");
    $('#cabecalho').html("Tem certeza que deseja terminar o relacionamento?");
    $.post('/Jogo/TerminarRelacionamento')
    $('.modal').modal();
}

function demissao(){
    $('#txt1').hide();
    $('.lbl1').hide();
    $('.lbl1').html("");
    $('#cabecalho').html("Tem certeza que deseja pedir demissão? ");
    $('.modal').modal();
}

function academia() {
    $('#resposta1').attr('href', 'Alterar/100');
    $('#txt1').hide();
    $('.lbl1').hide();
    $('.lbl1').html("");
    $('#cabecalho').html("Irá te custar 100$");
    $('.modal').modal();
}

function visitarParentes() {

}

function cinema() {

}

function viajar() {
    
}















//-----------------------------------------------------


$(document).ready(function () {
    $('.modal').modal();
});