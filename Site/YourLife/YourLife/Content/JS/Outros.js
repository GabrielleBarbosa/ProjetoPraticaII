
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
    $('#txt1').show("Você decidiu ir visitar seus familiares ainda vivos");
    $('.lbl1').hide();
    $('#cabecalho').html("Visitar Família");
    $('#resposta1').attr('href', '/VisitarParentes/40/20');
    $('.modal').modal();
}

function cinema() {
    $('#txt1').hide();
    $('.lbl1').hide();
    $('#cabecalho').html("Ir ao cinema custará $100,00");
    $('#resposta1').attr('href', '/IrAoCinema/100/20');
    $('.modal').modal();
}

function viajar() {
    $('#txt1').hide();
    $('.lbl1').hide();
    $('#cabecalho').html("Viajar te custará $10000,00");
    $('#resposta1').attr('href', '/Viajar/10000/84/47/25/67');
    $('.modal').modal();
}















//-----------------------------------------------------


$(document).ready(function () {
    $('.modal').modal();
});