var idade = 0;

window.onload = function () {
    $.ajaxSetup({ async: false });
    $.when($.post('/Jogo/Idade', {
    },
        function (data) {
            idade = data;
        }))
}

function suicidio() {

    $('#resposta1').attr('href', 'Suicidio');
    $('#lbl1').html("");
    $('#cabecalho').html("Tem certeza que deseja cometer suicídio?");
}

function passear() {
    $('#lbl1').html("");
    $('#txt1').html("");
    $('#cabecalho').html("Deseja sair para dar uma volta na vizinhança?");
    $('#resposta1').attr('href', 'Jogo/Passear/15/10/10');
}

function terminarRel() {
    
    $('#lbl1').html("");
    $('#cabecalho').html("Tem certeza que deseja terminar o relacionamento?");
}

function demissao() {

    $('#lbl1').html("Pedindo demissão você não receberá nenhuma compensação");
    $('#cabecalho').html("Tem certeza que deseja pedir demissão?");
    $('#resposta1').attr('href', '/Jogo/Demissao');
}

function academia() {
    
    $('#txt1').html("");
    $('#lbl1').html("");
    $('#cabecalho').html("Irá te custar $100,00");
    $('#resposta1').attr('href', '/AlterarAcademia/100/20');
}

function visitarParentes() {
    
    $('#txt1').html("Você decidiu ir visitar seus familiares");

    $('#lbl1').html("");
    $('#cabecalho').html("Visitar Família");
    
    if (idade >= 18)
        $('#resposta1').attr('href', '/VisitarParentes/20/100');
    else
        $('#resposta1').attr('href', '/VisitarParentes/20');
    
}

function cinema() {

    $('#txt1').html("");
    $('.lbl1').html("");
    $('#cabecalho').html("Ir ao cinema custará $100,00");
    
    if (idade >= 18)
        $('#resposta1').attr('href', '/IrAoCinema/100/20');
    else
        $('#resposta1').attr('href', '/IrAoCinema/20');
    
}

function viajar() {

    $('#txt1').html("");
    $('.lbl1').html("");
    $('#cabecalho').html("Viajar te custará $10000,00");
    $('#resposta1').attr('href', '/Viajar/10000/84/47/25/67');
    
}

$(document).ready(function(){
    $('.modal').modal();
});