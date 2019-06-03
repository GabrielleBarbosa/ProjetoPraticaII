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
    $('.modal').modal();
}

function terminarRel() {
    
    $('#lbl1').html("");
    $('#cabecalho').html("Tem certeza que deseja terminar o relacionamento?");
    $('.modal').modal();
}

function demissao() {

    $('#txt1').html("Pedindo demissão você não receberá nenhuma compensação");
    $('#lbl1').html("");
    $('#cabecalho').html("Tem certeza que deseja pedir demissão?");
    $('#resposta1').attr('href', '/Jogo/Demissao');
    $('.modal').modal();
}

function academia() {
    
    $('#txt1').html("");
    $('#lbl1').html("");
    $('#cabecalho').html("Irá te custar $100,00");
    $('#resposta1').attr('href', '/AlterarAcademia/100/20');
    $('.modal').modal();
}

function visitarParentes() {

<<<<<<< HEAD
    $('#txt1').html("Você decidiu ir visitar seus familiares");
=======
    $('#txt1').show("Você decidiu ir visitar seus familiares ainda vivos");
    $('.lbl1').hide();
>>>>>>> bd2fb8fd2d7d6b8eb539cfc498da4a79757af938
    $('.lbl1').html("");
    $('#cabecalho').html("Visitar Família");
    
    if (idade > 18)
        $('#resposta1').attr('href', '/VisitarParentes/20/100');
    else
        $('#resposta1').attr('href', '/VisitarParentes/20');

    $('.modal').modal();
}

function cinema() {

    $('#txt1').html("");
    $('.lbl1').html("");
    $('#cabecalho').html("Ir ao cinema custará $100,00");
    
    if (idade > 18)
        $('#resposta1').attr('href', '/IrAoCinema/100/20');
    else
        $('#resposta1').attr('href', '/IrAoCinema/20');

    $('.modal').modal();
}

function viajar() {

    $('#txt1').html("");
    $('.lbl1').html("");
    $('#cabecalho').html("Viajar te custará $10000,00");
    $('#resposta1').attr('href', '/Viajar/10000/84/47/25/67');
    
    $('.modal').modal();
}