
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
    $('.modal').modal();
}

function demissao(){
    $('#txt1').show("Pedindo demissão você não receberá nenhuma compensação");
    $('.lbl1').hide();
    $('.lbl1').html("");
    $('#cabecalho').html("Tem certeza que deseja pedir demissão? ");
    $('#resposta1').attr('href', '/Demissao/');
    $('.modal').modal();
}

function academia() {
    
    $('#txt1').hide();
    $('.lbl1').hide();
    $('#cabecalho').html("Irá te custar $100,00");
    $('#resposta1').attr('href', '/AlterarAcademia/100/20');
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