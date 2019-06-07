var idade = 0;

window.onload = function () {
    $.ajaxSetup({ async: false });
    $.when($.post('/Jogo/Idade', {
    },
        function (data) {
            idade = data;
        }));
};

function suicidio() {

    $('#resposta1').attr('href', 'Suicidio');
    $('#lbl1').html("");
    $('#cabecalho').html("Tem certeza que deseja cometer suicídio?");
}

function viajar() {

    $('#lbl1').html("");
    $('#cabecalho').html("Viajar te custará $10000,00");
    $('#resposta1').attr('href', '/Viajar/10000/70/40/30/15');
}

function terminarRel() {
    
    $('#lbl1').html("");
    $('#cabecalho').html("Tem certeza que deseja terminar o relacionamento?");
    $('#resposta1').attr('href', '/Jogo/TerminarRelacionamento');
}

function demissao() {

    $('#lbl1').html("Pedindo demissão você não receberá nenhuma compensação");
    $('#cabecalho').html("Tem certeza que deseja pedir demissão?");
    $('#resposta1').attr('href', '/Jogo/Demissao');
}

function academia() {
    
    $('#lbl1').html("");
    $('#cabecalho').html("Irá te custar $100,00");
    $('#resposta1').attr('href', '/AlterarAcademia/100/30');
}

function visitarParentes() {

    $('#lbl1').html("");
    $('#cabecalho').html("Visitar Família?");
    
    if (idade >= 18)
        $('#resposta1').attr('href', '/VisitarParentes/20/100');
    else
        $('#resposta1').attr('href', '/VisitarParentes/20');
    
}

function cinema() {
    
    $('#lbl1').html("");
    
    if (idade >= 18) {
        $('#cabecalho').html("Ir ao cinema custará $100,00, irá mesmo assim?");
        $('#resposta1').attr('href', '/IrAoCinema/100/20');
    }
    else {
        $('#cabecalho').html("Ir ao cinema?");
        $('#resposta1').attr('href', '/IrAoCinema/20');
    }
    
}

function estudar() {
    
    $('#lbl1').html("");
    $('#cabecalho').html("Estudar faz bem, não é?");
    $('#resposta1').attr('href', '/Estudar/30');
    
}

function carteira() {
    
    $('#lbl1').html("");
    $('#cabecalho').html("Tirar a carteira de motorista te custará $1500,00");
    $('#resposta1').attr('href', '/Carteira/1500');

}

function namoro() {
    
    $('#lbl1').html("");
    $('#cabecalho').html("Fazer uma surpresa para seu namorado(a) te custará $100, mas vale a pena, certo?");
    $('#resposta1').attr('href', '/Namoro/100/50');

}

$(document).ready(function(){
    $('.modal').modal();
});